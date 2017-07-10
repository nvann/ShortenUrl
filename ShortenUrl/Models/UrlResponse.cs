using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortenUrlService.Models
{
    public class UrlResponse
    {
        public string OriginUrl { get; set; }
        public string ShortenUrl { get; set; }
        public bool Exists { get; set; }
        public bool IsNew { get; set; }
    }
}