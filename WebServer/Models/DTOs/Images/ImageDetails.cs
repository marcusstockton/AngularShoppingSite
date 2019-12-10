using System;

namespace WebServer.Models.DTOs.Images
{
    public class ImageDetails
    {
        public string Path { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public Guid ItemId { get; set; }
    }
}