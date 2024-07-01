﻿using SmartWorkout1.Context;
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

        public ICollection<Excercise> GetExcercises()
        {
            return _context.Excercises.ToList();
        }
    }
}