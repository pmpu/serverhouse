using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace serverhouse_web {
    public class Helpers {
        public static string getCurrentLanguage() {
            return Thread.CurrentThread.CurrentUICulture.ToString().Substring(0, 2);
        }

        public static List<Type> FindAllDerivedTypes<T>() {
            return FindAllDerivedTypes<T>(Assembly.GetAssembly(typeof (T)));
        }

        public static List<Type> FindAllDerivedTypes<T>(Assembly assembly) {
            var derivedType = typeof (T);
            return assembly
                .GetTypes()
                .Where(t =>
                    t != derivedType &&
                    derivedType.IsAssignableFrom(t)
                ).ToList();
        }
    }
}