using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Models.Items;

namespace WebServer.Models
{
    public class Image : Base
    {
        public string Path { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
