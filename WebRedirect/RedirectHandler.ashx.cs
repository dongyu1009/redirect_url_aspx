using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

namespace WebRedirect
{
    /// <summary>
    /// RedirectHandler 的摘要说明
    /// </summary>
    public class RedirectHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string Query = context.Request.Url.Query.ToString();
            string redirectURL = "http://127.0.0.1:8100/";
            var request = (HttpWebRequest)WebRequest.Create(redirectURL + Query);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            context.Response.ContentType = "text/plain";
            context.Response.Write(responseString);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}