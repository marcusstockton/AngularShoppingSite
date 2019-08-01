using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebServer.Models;
using WebServer.Models.DTOs.Reviews;

namespace WebServer.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDetails>> GetReviewsForItem(Guid itemid);
        Task<ReviewDetails> GetReviewById(Guid Id, Guid reviewId);
        Task<ReviewDetails> UpdateReviewById(Guid id, ReviewEdit review);
        Task<ReviewDetails> CreateReview(ReviewCreate review);
        Task<bool> DeleteReviewById(Guid id);
    }
}
