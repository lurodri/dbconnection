using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using api_aurora.Models;

namespace api_aurora.Factories
{
    public static class DbContextFactory
    {
        public static Dictionary<string, string> ConnectionStrings { get; set; }

        public static void SetConnectionString(Dictionary<string, string> connStrs)
        {
            ConnectionStrings = connStrs;
        }

        public static StudentDetailContext Create(string connid)
        {
            if (!string.IsNullOrEmpty(connid))
            {
                string connStr = ConnectionStrings[connid];
                DbContextOptionsBuilder<StudentDetailContext> optionsBuilder = new();
                optionsBuilder.UseMySql(connStr);
                return new StudentDetailContext(optionsBuilder.Options);
            }
            else
            {
                ArgumentNullException argumentNullException = new("ConnectionId");
                throw argumentNullException;
            }
        }
    }
}


