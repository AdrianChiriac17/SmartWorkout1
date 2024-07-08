using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using SmartWorkout1.DTOs;
using SmartWorkout1.Entities;
using SmartWorkout1.Repositories.Implementations;
using SmartWorkout1.Repositories.Interfaces;

namespace SmartWorkout1.Components.Pages
{
    public partial class WorkoutPage : ComponentBase
    {
        [Inject]
        public IWorkoutRepository WorkoutRepository { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }    

        private ICollection<Workout> workouts;

        [Parameter]
        public int? UserId { get; set; }

        protected override void OnInitialized()
        {
            workouts = WorkoutRepository.GetWorkouts()
                .Where(x => UserId == null || x.UserId == UserId)
                .ToList();

            base.OnInitialized();
        }

        [SupplyParameterFromForm]
        public WorkoutDTO WorkoutDTO { get; set; } = new WorkoutDTO();

        private void AddExcerciseLog(EditCommandContext<Workout> context)
        {

            if (context != null && context.Item != null)
            {
                NavigationManager.NavigateTo($"/AddEditExcerciseLog/{context.Item.Id}");

            }
        }

        private void DeleteWorkout(DeleteCommandContext<Workout> context)
        {

            var id = context.Item.Id;

            if (context != null && context.Item != null)
            {
                WorkoutRepository.DeleteWorkout(id);
                NavigationManager.Refresh(forceReload: true);
            }

        }

    }
}
