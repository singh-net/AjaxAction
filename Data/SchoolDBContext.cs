using AjaxActionLinks.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxActionLinks.Data
{
    public class SchoolDBContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-L7B08NOA\SQLEXPRESS; Database=AjaxSchoolDb; Trusted_Connection = True;");

        }
        public DbSet<Student> Students { get; set; }

    }
}
