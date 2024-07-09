using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartWorkout1.Entities;

namespace SmartWorkout1.Attributes
{
	public class UniqueEmailAttribute : ValidationAttribute
	{
		private readonly Type _dbContextType;

		//constructor
		public UniqueEmailAttribute(Type dbContextType)
		{
			_dbContextType = dbContextType;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value == null)
				return ValidationResult.Success;

			var dbContext = (DbContext)validationContext.GetService(_dbContextType);
			var email = value.ToString();
			var entity = dbContext.Set<User>().SingleOrDefault(u => u.Email == email);
			// we search in the DbContext of the User database for a user that has an email identical to the input

			if (entity != null)
				return new ValidationResult("Email is already in use.");

			return ValidationResult.Success;
		}
	}
}