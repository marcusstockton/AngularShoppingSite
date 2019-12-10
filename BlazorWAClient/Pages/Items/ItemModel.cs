
using System.Collections.Generic;
using System;

namespace BlazorWAClient.Pages.Items
{
    public class ImageModel
    {
        public string Path {get;set;}
        public string FileName {get;set;}
        public string Type {get;set;}
    }

    public class ReviewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public UserModel CreatedBy { get; set; }
    }

    public class UserModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }

    public class ItemModel
    {
        public string Id {get;set;}
        public string Name {get;set;}
        public string Title {get;set;}
        public string Description {get;set;}
        public decimal Price{get;set;}
        public UserModel CreatedBy{get;set;}
        public DateTime CreatedDate{get;set;}
        public DateTime UpdatedDate{get;set;}
        public UserModel UpdatedBy{get;set;}
        public virtual List<ImageModel> Images{get;set;}
        public virtual List<ReviewModel> Reviews{get;set;}
    }
}