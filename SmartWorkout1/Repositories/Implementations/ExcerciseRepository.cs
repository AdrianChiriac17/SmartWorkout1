using Microsoft.EntityFrameworkCore;
using SmartWorkout1.Context;
using SmartWorkout1.DTOs;
using SmartWorkout1.Entities;
using SmartWorkout1.Repositories.Interfaces;

namespace SmartWorkout1.Repositories.Implementations
{
    public class ExcerciseRepository : IExcerciseRepository
    {
        private readonly SmartWorkoutContext _context;
        public ExcerciseRepository(SmartWorkoutContext context)
        {
            _context = context;
        }
        public ICollection<ExcerciseDTO> GetExcercises()
        {
            return _context.Excercises.Select(DTO => new ExcerciseDTO
            {   
                Description = DTO.Description,
                Id = DTO.Id,
                Type = DTO.Type,
                ImageURL= DTO.ImageURL,

            }).ToList();
        }

        public void AddExcercise(ExcerciseDTO excerciseDTO)
        {
            _context.Excercises.Add(new Excercise()
            {
                Description=excerciseDTO.Description,
                Type=excerciseDTO.Type,
                ImageURL = excerciseDTO.ImageURL,

            });
            _context.SaveChanges();

        }
        public void EditExcercise(ExcerciseDTO excerciseDTO)
        {
            var excercise = _context.Excercises.SingleOrDefault(e => e.Id == excerciseDTO.Id);

            if (excercise != null)
            {
                excercise.Description=excerciseDTO.Description;
                excercise.Type = excerciseDTO.Type;
                excercise.ImageURL = excerciseDTO.ImageURL;
                _context.SaveChanges();
            }
        }

        public void DeleteExcercise(int? id)
        {
            if (id != null) _context.Excercises.Where(e => e.Id == id).ExecuteDelete();
        }

        public ExcerciseDTO GetById(int? id)
        {
            var excercise = _context.Excercises.SingleOrDefault(e => e.Id == id);
            ExcerciseDTO excerciseDTO= new ExcerciseDTO();
            excerciseDTO.Exist = excercise != null;
            if (excercise != null)
            {
                excerciseDTO.Description = excercise.Description;
                excerciseDTO.Type = excercise.Type;
                excerciseDTO.ImageURL = excercise.ImageURL;
            }
            return excerciseDTO;
        }
    }
}
