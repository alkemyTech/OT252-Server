using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class MemberRepository :GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
