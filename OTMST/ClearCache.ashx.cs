using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OTMST
{
    /// <summary>
    /// Summary description for ClearCache
    /// </summary>
    public class ClearCache : IHttpHandler
    {

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            foreach (DictionaryEntry item in context.Cache)
                context.Cache.Remove(item.Key as string);

            context.Response.ContentType = "text/html";
            context.Response.Write("Cache cleared.");
        }

    }
}