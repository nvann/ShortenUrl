using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ShortenUrlService.Models
{
    public class UrlHelper
    {
        static String alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private static string GetUrl(string path)
        {
            Uri requestUri = HttpContext.Current.Request.Url;

            return requestUri.Scheme + "://" + requestUri.Host + "/" + path;
        }

        public static UrlResponse GetOriginUrlResponse(string hash)
        {
            using (var context = new ShortenUrlContext())
            {
                var shortenUrl = context.ShortenUrls.FirstOrDefault(u => u.Hash == hash);
            
                if (shortenUrl == null)
                {
                    return new UrlResponse { Exists = false };
                }
                return new UrlResponse { OriginUrl = shortenUrl.OriginUrl, ShortenUrl = GetUrl(hash), Exists = true };
            }
        }

        public static ShortenUrl GetShortenUrl(string longHash)
        {
            using (var context = new ShortenUrlContext())
            {
                return context.ShortenUrls.FirstOrDefault(u => u.LongHash == longHash);
            }
             
        }

        public static UrlResponse GetShortenUrlResponse(string url)
        {
            using (var context = new ShortenUrlContext())
            {
                String longHash = GetLongHash(url);

                ShortenUrl shortenUrl = GetShortenUrl(longHash);

                bool isNew = false;

                if(shortenUrl == null)
                {
                    shortenUrl = new ShortenUrl {OriginUrl = url, LongHash = longHash };
                    context.ShortenUrls.Add(shortenUrl);
                    context.SaveChanges();

                    string hash = ConvertToBase(shortenUrl.Id, alphabet);
                    shortenUrl.Hash = hash;
                    context.SaveChanges();
                    isNew = true;
                }
                

                UrlResponse urlResponse = new UrlResponse {
                    OriginUrl = url,
                    ShortenUrl = GetUrl(shortenUrl.Hash),
                    IsNew = isNew
                };
                return urlResponse;
            }
        }
        public static String ConvertToBase(long number, string alphanumeric)
        {
            int toBase = alphanumeric.Length;
            StringBuilder result = new StringBuilder();
            while (number > 0)
            {
                int index = (int)(number % toBase);
                result.Insert(0, alphanumeric[index]);
                number = number / toBase;

            }
            return result.ToString();
        }

        static String GetLongHash(string data)
        {   
            byte[] hash;
            using (MD5 md5 = MD5.Create())
            {
                md5.Initialize();
                md5.ComputeHash(Encoding.UTF8.GetBytes(data));
                hash = md5.Hash;
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }
    }
}