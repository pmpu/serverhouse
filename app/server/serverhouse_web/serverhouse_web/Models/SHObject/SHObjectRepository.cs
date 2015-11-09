using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using serverhouse_web.Properties;
using MongoDB.Driver.Linq;
using System.Text.RegularExpressions;
using MongoDB.Bson.Serialization;
using SolrNet;
using Microsoft.Practices.ServiceLocation;
using SolrNet.Commands;
using SolrNet.Impl;
using SolrNet.Commands.Parameters;
using SolrNet.Exceptions;

namespace serverhouse_web.Models.SHObject
{
    public class SHObjectRepository
    {
        private MongoDatabase mongoDatabase;
        private MongoCollection objectsCollection;

        private ISolrOperations<SolrObject> solrWorker;
        private SolrConnection solrConn;
        private CommitCommand solrCommit;
         

        public SHObjectRepository() {         
   
            // init MongoDB for storing
            var mongoClient = new MongoClient(Settings.Default.MongoConnectionString);
            var server = mongoClient.GetServer();
            mongoDatabase = server.GetDatabase(Settings.Default.MongoDatabase);
            objectsCollection = mongoDatabase.GetCollection("objects");            
            // check if server is alive, if not - throw exception
            mongoDatabase.Server.Ping();            

            // init Solr for search            
            solrConn = new SolrConnection("http://localhost:8983/solr/main_core");

            solrWorker = ServiceLocator.Current.GetInstance<ISolrOperations<SolrObject>>();

            solrCommit = new CommitCommand();
            solrCommit.WaitFlush = null;
            solrCommit.WaitSearcher = true;


           
        }


        public List<string> getPropertyNames(string q) {
            var queryAllProps =
                (from obj in objectsCollection.AsQueryable<SHObject>()
                where obj.ver_active == true
                select obj.properties).ToList();

            var propNames = new List<String>();

            foreach (var objProperties in queryAllProps) {
                foreach (var prop in objProperties) {
                    if (!propNames.Contains(prop.Key)) {
                        if (Regex.IsMatch(prop.Key, q, System.Text.RegularExpressions.RegexOptions.IgnoreCase)) {
                            propNames.Add(prop.Key);
                        }
                    }
                }
            }

            return propNames;
            
        }
        

        public SHObject AddVersion(SHObject obj) {
            var hasVersions =
                   (from o in objectsCollection.AsQueryable<SHObject>()
                   where o.id == obj.id
                   select o).Count() > 0;

            if (hasVersions)
            {
                SHObject currentVersion = getCurrentVersion(obj.id);
                // remove all later versions
                objectsCollection.Remove(Query.And(Query.EQ("id", obj.id), Query.GT("ver_timestamp", currentVersion.ver_timestamp)));

                // disable previous versions
                UpdateBuilder updateOtherVersions = MongoDB.Driver.Builders.Update
                   .Set("ver_active", false);
                objectsCollection.Update(Query.EQ("id", obj.id), updateOtherVersions, UpdateFlags.Multi);

                // set new databaseId
                obj.databaseId = Guid.NewGuid().ToString();
            } else {
                // no versions

                // databaseId
                if (string.IsNullOrEmpty(obj.databaseId))
                {
                    obj.databaseId = Guid.NewGuid().ToString();
                }

                // id
                long maxId = 0;
                var findMax = objectsCollection.AsQueryable<SHObject>()
                                .Select(c => c.id);
                if (findMax.Count() > 0)
                {
                    maxId = findMax.Max();
                }
                obj.id = maxId + 1;
            }

            // version
            obj.ver_active = true;
            obj.ver_timestamp = (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            // add to solr
            SolrObject solr_obj = new SolrObject();
            solr_obj.id = obj.id;

            var solar_props = new Dictionary<string, string>();
            foreach(var prop in obj.properties){
                solar_props.Add(prop.Key, prop.Value.ToString());
            }
            solr_obj.properties = solar_props;            

            solrWorker.Add(solr_obj);
            solrCommit.Execute(solrConn);

            // save to mongo
            objectsCollection.Save(obj);

            return obj;
        }

        public List<SHObject> getObjects(int page = 1, int pageSize = 10) {
            page = Math.Abs(page);
            return
                (from obj in objectsCollection.AsQueryable<SHObject>() 
                 where obj.ver_active == true
                    select obj).Skip((page-1)*pageSize).Take(pageSize).ToList();
        }

        public List<SHObject> findObjects(string q, int page = 1, int pageSize = 10){
            page = Math.Abs(page);

            var results = new List<SHObject>();

            ISolrQueryResults<SolrObject> solrResults;

            try
            {
                solrResults = solrWorker.Query(new SolrQuery(q), new QueryOptions
                {
                    Fields = new[] { "id" },
                    Start = (page-1)*pageSize,
                    Rows = pageSize
                });
            }
            catch (InvalidFieldException e) {
                return results;
            }

            foreach (var solr_obj in solrResults) {
                var obj = getObjectById(solr_obj.id);
                if (obj != null) {
                    results.Add(obj);
                }                
            }            

            return results;
        }

        public SHObject getObjectById(long id) {
            return getCurrentVersion(id);
        }

        public SHObject getCurrentVersion(long id) {
            var queryCurrentVersion =
                from obj in objectsCollection.AsQueryable<SHObject>()
                where obj.ver_active == true && obj.id == id
                     select obj;

            if (queryCurrentVersion.Count() > 0){
                return queryCurrentVersion.First();                
            }

            return null;
        }

        public SHObject getPrevVersion(long id) { 
            SHObject currentVersion = getCurrentVersion(id);

            if (currentVersion != null)
            {
                var queryPrevVersion =
                   from obj in objectsCollection.AsQueryable<SHObject>()
                   where obj.id == id && obj.ver_timestamp < currentVersion.ver_timestamp
                   select obj;

                if (queryPrevVersion.Count() > 0)
                {
                    return queryPrevVersion.OrderByDescending(o => o.ver_timestamp).First();
                }
            }

            return null;
        }

        public SHObject getNextVersion(long id)
        {
            SHObject currentVersion = getCurrentVersion(id);

            if (currentVersion != null)
            {
                var queryPrevVersion =
                   from obj in objectsCollection.AsQueryable<SHObject>()
                   where obj.id == id && obj.ver_timestamp > currentVersion.ver_timestamp
                   select obj;

                if (queryPrevVersion.Count() > 0)
                {
                    return queryPrevVersion.OrderBy(o => o.ver_timestamp).First();
                }
            }

            return null;
        }

        public bool versionBack(long id) {                        
            SHObject prevVersion = getPrevVersion(id);

            if (prevVersion != null) {
                makeVersionActive(prevVersion);
                return true;
            }
            return false;
        }

        public bool versionForward(long id)
        {
            SHObject nextVersion = getNextVersion(id);
            if (nextVersion != null)
            {
                makeVersionActive(nextVersion);
                return true;
            }
            return false;
        }

        private void makeVersionActive(SHObject version) {
            version.ver_active = true;
            objectsCollection.Save(version);

            // disable other versions
            UpdateBuilder updateOtherVersions = MongoDB.Driver.Builders.Update
                .Set("ver_active", false);
            objectsCollection.Update(
                Query.And(Query.EQ("id", version.id), Query.NE("_id", version.databaseId)),
                updateOtherVersions, UpdateFlags.Multi);
        }

        public void Delete(SHObject obj){
            objectsCollection.Remove(Query.EQ("id", obj.id));
            solrWorker.Delete(new SolrQueryByField("id", obj.id.ToString()));
            solrCommit.Execute(solrConn);
        }
        
    }
}