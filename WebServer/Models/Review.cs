using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Models.Items;

namespace WebServer.Models
{
    public class Review : Base
    {
        [Range(0,5)]
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid ItemId { get; set; }

        public virtual Item Item { get; set; }

    }
}
