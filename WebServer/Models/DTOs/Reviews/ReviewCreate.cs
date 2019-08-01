namespace WebServer.Models.DTOs.Reviews
{
    public class ReviewCreate
    {
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
