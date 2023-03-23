using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.Domain.Interfaces.Repositories;
using URLShortener.Domain.Models;

namespace URLShortener.Database.Repositories
{
    public class URLRepository : IURLRepository
    {
        private readonly URLDbContext _context;
        public URLRepository(URLDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<URLModel>> GetAll()
        {
            return await _context.Urls.ToListAsync();
        }

        public async Task<URLModel> GetURLInfo(long id)
        {
            return await _context.Urls.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddURL(URLModel uRLModel)
        {
            await _context.Urls.AddAsync(uRLModel);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteURL(long id)
        {
            _context.Remove(await _context.Urls.FirstOrDefaultAsync(x => x.Id == id));

            _context.SaveChanges();
        }
        public async Task DeleteAll()
        {
            foreach (var item in _context.Urls)
            {
                _context.Urls.Remove(item);
            }
            _context.SaveChanges();
        }
    }
}
