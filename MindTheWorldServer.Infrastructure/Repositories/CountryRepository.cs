using Microsoft.EntityFrameworkCore;
using MindTheWorldServer.Domain;
using MindTheWorldServer.Infrastructure.Definitions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorldServer.Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly MindTheWorldContext _context;

        public CountryRepository()
        {
        }

        public CountryRepository(MindTheWorldContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Country>> GetCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetCountryAsync(int countryId)
        {
            return await _context.Countries.FindAsync(countryId);
        }

        public async Task<Country> GetCountryByNameAsync(string countryName)
        {
            return await _context
                .Countries
                .SingleOrDefaultAsync(c => c.Name == countryName);
        }

        public async Task<Country> SaveAsync(Country country)
        {
            await _context.Countries.AddAsync(country);

            return country;
        }
    }
}
