using Movies.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Contracts
{
    public interface IServiceManager
    {
        IMovieService Movies { get; }
        // เพิ่ม IActorService
        // IReviewService ภายหลังถ้าต้องการ
    }
}
