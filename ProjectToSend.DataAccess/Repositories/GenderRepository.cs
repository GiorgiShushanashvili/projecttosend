using System;
using Microsoft.EntityFrameworkCore;
using ProjectToSend.DataAccess.Contracts.Repositories;
using ProjectToSend.DataAccess.Repositories;
using TheProjectToSend.Context;
using TheProjectToSend.DTOs;
using TheProjectToSend.Models;

namespace TheProjectToSend.Repositories
{
    public class GenderRepository : GenericRepository<Gender>,IGenderRepository
    {
        private readonly PersonContext _context;
        public GenderRepository(PersonContext context):base(context)
        {
            _context = context;
        }

        public async Task<Gender> GetGenderById(int id)
        {
            return await _context.Gender.FirstOrDefaultAsync(x=>x.GenderId==id);
        }
    }
}

