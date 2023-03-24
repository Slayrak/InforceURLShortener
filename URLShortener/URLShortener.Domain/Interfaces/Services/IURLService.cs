using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.Domain.Models;

namespace URLShortener.Domain.Interfaces.Services
{
    public interface IURLService
    {
        Task<IEnumerable<URLModel>> GetAll();

        Task<URLModel> GetURLInfo(long id);
        Task AddURL(URLModel uRLModel);

        void DeleteURL(long id);
        void DeleteAll();

        Task<About> GetAbout();
        void UpdateAbout(About about);

        string IdToShortURL(int n);
        string Reverse(string input);
        long shortURLtoID(string shortURL);
    }
}
