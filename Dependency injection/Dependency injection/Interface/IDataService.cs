using Dependency_injection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dependency_injection.Interface
{
    public interface IDataService
    {
        Task Create(Post model);
        Task<List<Post>> GetAll();
    }
}
