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

        public async Task ShortenURL(string url)
        {
            throw new NotImplementedException();
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
