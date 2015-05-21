using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CIFR.Helper
{
    public class CacheHelper
    {
        private static object objCacheItem = new object();

        public static void SetCache(string key, object value, int second)
        {
            lock (objCacheItem)
            {
                HttpRuntime.Cache.Insert(key, value, null, DateTime.Now.AddSeconds(second * 1000), System.Web.Caching.Cache.NoSlidingExpiration);
            }
        }

        public static object GetCache(string key)
        {
            if (string.IsNullOrEmpty(key))
                return null;

            return HttpRuntime.Cache[key];
        }

        public static void RemoveCache(string key)
        {
            if (GetCache(key) != null)
            {
                lock (objCacheItem)
                {
                    HttpRuntime.Cache.Remove(key);
                }
            }
        }

        public static void RemoveMultiCache(string keyInclude)
        {
            IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                if (string.IsNullOrEmpty(keyInclude))
                {
                    RemoveCache(CacheEnum.Key.ToString());
                    continue;
                }

                if (CacheEnum.Key.ToString().IndexOf(keyInclude) >= 0)
                    RemoveCache(CacheEnum.Key.ToString());
            }
        }
    }
}
