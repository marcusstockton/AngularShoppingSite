
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebServer.Models.Items
{
    public class ItemCategory : Base
    {
        public string Description { get; set; }  
        
        public virtual ItemCategory ParentCategory{get;set;}
    }
}
