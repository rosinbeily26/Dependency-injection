using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
namespace Dependency_injection.Models
{
    [DynamoDBTable(tableName: "post")]

    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid().ToString();
        }
        [DynamoDBHashKey]
        public string Id { get; set; }
        public DateTime PostDateTime { get; set; }
        public string Tittle { get; set; }
        public string Content { get; set; }


    }
}
