using DAL.EF;
using DAL.Entities;
using DAL.Repository.Base;
using DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository;

public class ContactRepository : Repo<Contact, int>, IContactRepository
{
    public ContactRepository(ApplicationDbContext context)
        : base(context) 
    {
        
    }
}
