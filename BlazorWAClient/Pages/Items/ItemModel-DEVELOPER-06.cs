
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorWAClient.Pages.Items
{
    public class ImageModel
    {
        public string Path {get;set;}
        public string FileName {get;set;}
        public string Type {get;set;}
    }

    public class ItemModel
    {
        public string Id {get;set;}
        
        [Required]
        public string Name {get;set;}

        [Required]
        public string Title {get;set;}

        [Required]
        public string Description {get;set;}
        public decimal Price{get;set;}
        public virtual List<ImageModel> Images{get;set;}
    }
}