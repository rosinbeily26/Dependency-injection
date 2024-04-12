using Amazon.DynamoDBv2.DataModel;
using Dependency_injection.Interface;
using Dependency_injection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dependency_injection.Stratiges
{
    public class DbDataService : IDataService
    {
        public readonly IDynamoDBContext _context;
        public DbDataService(IDynamoDBContext context)
        {
            _context = context;
        }
        public async Task Create(Post model)
        {
            await _context.SaveAsync<Post>(model);
        }

        public async Task<List<Post>> GetAll()
        {
            return await _context.ScanAsync<Post>(new List<ScanCondition>()).GetRemainingAsync();
        }
    }
}
