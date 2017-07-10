using ShortenUrlService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShortenUrlService.Controllers
{
    public class LengthenController : ApiController
    {
        // POST api/values
        public UrlResponse Post([FromBody]ShortenUrl shortenUrl)
        {
            string hash = shortenUrl.Hash;
            var urlResponse = UrlHelper.GetOriginUrlResponse(hash);
            return urlResponse;
        }

        // POST api/values
        public UrlResponse Get(string hash)
        {
            if(hash != null && hash.Contains("/"))
            {
                hash = hash.Substring(hash.LastIndexOf("/") + 1);
            }
            var urlResponse = UrlHelper.GetOriginUrlResponse(hash);
            return urlResponse;
        }
    }
}
