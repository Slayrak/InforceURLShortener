using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.Domain.Interfaces.Repositories;
using URLShortener.Domain.Interfaces.Services;
using URLShortener.Domain.Models;

namespace URLShortener.Business.Services
{
    public class URLService : IURLService
    {
        public readonly IURLRepository _iURLRepository;

        public URLService(IURLRepository iURLRepository)
        {
            _iURLRepository = iURLRepository;
        }

        public async Task<IEnumerable<URLModel>> GetAll()
        {
            return await _iURLRepository.GetAll();
        }

        public async Task<URLModel> GetURLInfo(long id)
        {
            return await _iURLRepository.GetURLInfo(id);
        }
        public async Task AddURL(URLModel uRLModel)
        {
            await _iURLRepository.AddURL(uRLModel);
        }

        public void DeleteURL(long id)
        {
            _iURLRepository.DeleteURL(id);
        }
        public void DeleteAll()
        {
            _iURLRepository.DeleteAll();
        }

        public string IdToShortURL(int n)
        {
            char[] map = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

            String shorturl = "";

            // Convert given integer id to a base 62 number 
            while (n > 0)
            {
                // use above map to store actual character 
                // in short url 
                shorturl += (map[n % 62]);
                n = n / 62;
            }

            // Reverse shortURL to complete base conversion 
            return Reverse(shorturl);
        }
        public string Reverse(string input)
        {
            char[] a = input.ToCharArray();
            int l, r = a.Length - 1;
            for (l = 0; l < r; l++, r--)
            {
                char temp = a[l];
                a[l] = a[r];
                a[r] = temp;
            }
            return String.Join("", a);
        }
        public long shortURLtoID(string shortURL)
        {
            int id = 0; // initialize result 

            // A simple base conversion logic 
            for (int i = 0; i < shortURL.Length; i++)
            {
                if ('a' <= shortURL[i] &&
                           shortURL[i] <= 'z')
                    id = id * 62 + shortURL[i] - 'a';
                if ('A' <= shortURL[i] &&
                           shortURL[i] <= 'Z')
                    id = id * 62 + shortURL[i] - 'A' + 26;
                if ('0' <= shortURL[i] &&
                           shortURL[i] <= '9')
                    id = id * 62 + shortURL[i] - '0' + 52;
            }
            return id;
        }

        public async Task<About> GetAbout()
        {
            return await _iURLRepository.GetAbout();
        }
        public void UpdateAbout(About about)
        {
            _iURLRepository.UpdateAbout(about);
        }
    }
}
