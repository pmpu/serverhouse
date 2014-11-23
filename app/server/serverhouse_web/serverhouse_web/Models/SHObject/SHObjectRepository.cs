﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using serverhouse_web.Properties;
using MongoDB.Driver.Linq;

namespace serverhouse_web.Models.SHObject
{
    public class SHObjectRepository
    {
        private MongoDatabase mongoDatabase;
        private MongoCollection objectsCollection;

        public SHObjectRepository() {            
            var mongoClient = new MongoClient(Settings.Default.MongoConnectionString);
            var server = mongoClient.GetServer();
            mongoDatabase = server.GetDatabase(Settings.Default.MongoDatabase);
            objectsCollection = mongoDatabase.GetCollection("objects");   
         
            // check if server is alive, if not - throw exception
            mongoDatabase.Server.Ping();            
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

                // version
                obj.ver_active = true;
                obj.ver_timestamp = (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                objectsCollection.Save(obj);
            }
            else {
                obj = Add(obj);
            }

            return obj;
        }

        private SHObject Add(SHObject obj)
        {

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

            // version
            obj.ver_active = true;
            obj.ver_timestamp = (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            objectsCollection.Save(obj);
            return obj;
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




        public SHObject GetObjectById(long id)
        {
            var obj = (SHObject)objectsCollection.FindOneAs(typeof(SHObject), Query.EQ("id", id));
            return obj;
        }
    }
}