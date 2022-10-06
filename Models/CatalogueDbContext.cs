﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laborator19_Catalog_.Models
{
    public class CatalogueDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Subject> Subjects  { get; set; }
        public DbSet<Teacher> Teachers  { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-NCBKPTR\SQLEXPRESS;Initial Catalog=Lab19(Catalogue);Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

    }
}
