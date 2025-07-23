using AutoMapper;
using Movies.Contracts;
using Movies.Core.DomainContracts;
using Movies.Core.Dtos;
using Movies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services
{
    // have 2 MovieService.cs and MovieService.cs from root folder
    public class MovieService : IMovieService 
    {
        // ทำงานยังไง? Service เรียก UnitOfWork.Movies.Add(movie) แล้วสุดท้ายเรียก UnitOfWork.CompleteAsync() เพื่อบันทึกจริง
        // เรียก UnitOfWork.CompleteAsync() Torn Nai?
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MovieService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MovieDto>> GetAllAsync()
        {
            var movies = await _unitOfWork.Movies.GetAllAsync();
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }

        public async Task<MovieDto?> GetByIdAsync(Guid id)
        {
           var movie = await _unitOfWork.Movies.GetAsync(id);  
           return movie is null ? null : _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> CreateAsync(MovieCreateDto dto)
        {
            var movie = _mapper.Map<Movie>(dto);
            _unitOfWork.Movies.Add(movie);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<MovieDto>(dto);
        }
        public async Task UpdateAsync(Guid id, MovieUpdateDto dto)
        {
            var movie = await _unitOfWork.Movies.GetAsync(id);
            if (movie is null) throw new Exception("Movie not found");
            _mapper.Map(dto, movie);
            await _unitOfWork.CompleteAsync();  
        }

        public async Task DeleteAsync(Guid id)
        {
            var movie = await _unitOfWork.Movies.GetAsync(id);
            if (movie is null) throw new Exception("Movie not found");
            _unitOfWork.Movies.Remove(movie);
            await _unitOfWork.CompleteAsync();
        }
    
    }
}
