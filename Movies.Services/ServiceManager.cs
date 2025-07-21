using Movies.Contracts;
using Movies.Core.DomainContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IMovieService> _movieService;

        public ServiceManager(IUnitOfWork unitOfWork, AutoMapper.IMapper mapper)
        {
            _movieService = new Lazy<IMovieService>(() => new MovieService(unitOfWork, mapper));
        }
        public IMovieService Movies => _movieService.Value;
    }
}
