using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Net_UrlShorter.BLL;

namespace Net_UrlShorter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortenController : ControllerBase
    {
        private static Dictionary<string, string> _urlMapping = new Dictionary<string, string>();

        [HttpPost]
        public IActionResult Shorten([FromBody] string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return BadRequest("Input URL cannot be empty.");
            }
            Uri uriResult;
            bool isValidUrl = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (!isValidUrl)
            {
                return BadRequest("Invalid URL format.");
            }
            GenerateShortUrlManager generateShortUrlMAnager = new();
            string shortUrl = generateShortUrlMAnager.GenerateShortUrl();
            _urlMapping.Add(shortUrl, url);

            return Ok($"Shortened URL: https://short.com/{shortUrl}");
        }
    }
}
