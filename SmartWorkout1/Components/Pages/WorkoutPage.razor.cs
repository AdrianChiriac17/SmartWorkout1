using Microsoft.AspNetCore.Components;
using SmartWorkout1.Entities;
using SmartWorkout1.Repositories.Interfaces;

namespace SmartWorkout1.Components.Pages
{
    public partial class WorkoutPage : ComponentBase
    {
        [Inject]
        public IWorkoutRepository WorkoutRepository { get; set; }
        private ICollection<Workout> workouts;

        protected override void OnInitialized()
        {
            workouts = WorkoutRepository.GetWorkouts();
            base.OnInitialized();
        }
    }
}
