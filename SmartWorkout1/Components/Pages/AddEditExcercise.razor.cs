using Microsoft.AspNetCore.Components;
using SmartWorkout1.DTOs;
using SmartWorkout1.Entities;
using SmartWorkout1.Repositories.Implementations;
using SmartWorkout1.Repositories.Interfaces;

namespace SmartWorkout1.Components.Pages
{
    public partial class AddEditExcercise : ComponentBase
    {
        [Inject]
        public IExcerciseRepository ExcerciseRepository { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [SupplyParameterFromForm]
        public ExcerciseDTO NewExcercise { get; set; } = new ExcerciseDTO();
        public Excercise excercise { get; set; } = new Excercise();

        public async Task SaveExcercise()
        {
            excercise.Description = NewExcercise.Description;
            excercise.Type = NewExcercise.Type;

            ExcerciseRepository.AddExcercise(excercise);
            //NavigationManager.NavigateTo("/UsersPage");
            await InvokeAsync(() => NavigationManager.NavigateTo("/ExcercisePage"));
        }
    }
}
