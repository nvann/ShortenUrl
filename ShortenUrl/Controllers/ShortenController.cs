using ShortenUrlService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShortenUrlService.Controllers
{
    public class ShortenController : ApiController
    {
        // POST api/values
        public UrlResponse Post([FromBody]ShortenUrl shortenUrl)
        {   
            string url = shortenUrl.OriginUrl;
            var urlResponse = UrlHelper.GetShortenUrlResponse(url);
            //return new UrlResponse { OriginUrl = url, ShortenUrl = GetUrl(hash), IsNew = true};
            return urlResponse;
        }


        //private static string GetUrl(string hash)
        //{
        //    return Request.RequestUri.Scheme + "://" + Request.RequestUri.Host + "/" + hash;
        //}

    }
}
