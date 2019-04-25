using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class Review : Base
    {
        [Range(0,5)]
        public int Rating { get; set; }

        [MaxLength(250)]
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual Guid ItemId { get; set; }

    }
}
