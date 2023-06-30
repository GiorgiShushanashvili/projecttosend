using System;
using Microsoft.EntityFrameworkCore;
using TheProjectToSend.Context;
using TheProjectToSend.DTOs;
using TheProjectToSend.Models;

namespace TheProjectToSend.Repositories
{
    public class GenderRepository : IGenderRepository<Gender>
    {
        private readonly PersonContext _context;

        public GenderRepository(PersonContext context)
        {
            _context = context;
        }

        public async Task<Gender> GetGenderById(int id)
        {
            return await _context.Gender.FirstOrDefaultAsync(x=>x.GenderId==id);
        }
    }
}

