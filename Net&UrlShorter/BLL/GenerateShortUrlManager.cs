using System;
namespace Net_UrlShorter.BLL
{
	public class GenerateShortUrlManager
	{
        public string GenerateShortUrl()
        {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] shortUrl = new char[6];

            for (int i = 0; i < 6; i++)
            {
                shortUrl[i] = characters[random.Next(characters.Length)];
            }
            return new string(shortUrl);
        }
    }
}

