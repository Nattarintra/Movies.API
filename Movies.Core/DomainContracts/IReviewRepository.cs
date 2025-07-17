using Movies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.DomainContracts
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllAsync();
        Task<Review?> GetAsync(Guid id);
        Task<bool> AnyAsync(Guid id);
        void Add(Review review);
        void Update(Review review);
        void Remove(Review review);
    }
}
