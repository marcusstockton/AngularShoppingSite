using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Data;
using WebServer.Interfaces;
using WebServer.Models;
using WebServer.Models.DTOs.Reviews;

namespace WebServer.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ReviewService(ApplicationDbContext context, IUserService userService, IMapper mapper)
        {
            _context = context;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<ReviewDetails> CreateReview(ReviewCreate item)
        {
            var review = _mapper.Map<Review>(item);
            review.CreatedById = _userService.GetLoggedInUserId();
            review.CreatedDate = DateTime.Now;
            await _context.AddAsync(review);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReviewDetails>(review);
        }

        public async Task<bool> DeleteReviewById(Guid id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if(review == null)
            {
                return false;
            }
            try 
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<ReviewDetails> GetReviewById(Guid itemId, Guid reviewId)
        {
            var review = await _context.Reviews
                .Include(x=>x.CreatedBy)
                .Include(x=>x.UpdatedBy)
                .FirstOrDefaultAsync(x=>x.ItemId == itemId && x.Id == reviewId);

            return _mapper.Map<ReviewDetails>(review);
        }

        public async Task<IEnumerable<ReviewDetails>> GetReviewsForItem(Guid itemid)
        {
            var reviews = await _context.Reviews
                .Include(x=>x.CreatedBy)
                .Include(x=>x.UpdatedBy)
                .Where(x=>x.ItemId == itemid)
                .OrderByDescending(x=>x.CreatedDate)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewDetails>>(reviews);
        }

        public async Task<ReviewDetails> UpdateReviewById(Guid id, ReviewEdit reviewdto)
        {
            if(reviewdto.Id == id)
            {
                var review = await _context.Reviews
                    .Include(x=>x.CreatedBy)
                    .Include(x=>x.UpdatedBy)
                    .SingleOrDefaultAsync(x=>x.Id == id);

                review.UpdatedById = _userService.GetLoggedInUserId();
                review.UpdatedDate = DateTime.Now;
                _context.Entry(review).CurrentValues.SetValues(reviewdto);

                await _context.SaveChangesAsync();

                return _mapper.Map<ReviewDetails>(review);
            }
            return null;
        }
    }
}
