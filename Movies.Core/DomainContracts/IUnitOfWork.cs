using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Movies.Core.DomainContracts.IMovieRepository;

namespace Movies.Core.DomainContracts
{
    // หน้าที่: เป็นตัวจัดการ Transaction และรวมทุก Repository เข้าด้วยกันในคลาสเดียว
    public interface IUnitOfWork
    {
        IMovieRepository Movies { get; }
        //IActorRepository Actors { get; } // I will add this later 21/07
        //IReviewRepository Reviews { get; } // I will add this later 21/07
        Task CompleteAsync();
    }
}
