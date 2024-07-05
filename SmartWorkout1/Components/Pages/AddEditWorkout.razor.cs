using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using SmartWorkout.Repositories.Interfaces;
using SmartWorkout1.DTOs;
using SmartWorkout1.Entities;
using SmartWorkout1.Repositories.Interfaces;

namespace SmartWorkout1.Components.Pages
{
    public partial class AddEditWorkout : ComponentBase
    {
        [Inject]
        public IWorkoutRepository WorkoutRepository { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int UserId { get; set; }


        [SupplyParameterFromForm]
        public WorkoutDTO WorkoutDTO { get; set; } = new WorkoutDTO();


        public async Task SaveWorkout()
        {

            WorkoutDTO.UserId = UserId;
            WorkoutRepository.AddWorkout(WorkoutDTO);
            await InvokeAsync(() => NavigationManager.NavigateTo("/WorkoutPage"));
        }
    }
}
