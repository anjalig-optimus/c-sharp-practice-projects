using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Person_json.Data;
using Person_json.Entities;
using System.Data;

namespace Person_json.Repository
{
    public class PersonRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task PostPersonData(string personJson) { 
            var x = new SqlParameter("@personData", SqlDbType.NVarChar)
            {
                Value = personJson
            };
            await _context.Database.ExecuteSqlRawAsync("EXEC InsertPerson @personData", x);
        }
        public async Task<List<Person>> GetAllPersonsAsync()
        {
            return await _context.Persons.ToListAsync();
        }
    }
}
