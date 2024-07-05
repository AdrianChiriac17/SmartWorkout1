using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        [Parameter]
        public int? ExcerciseId { get; set; }
        protected override void OnParametersSet()
        {
            if (ExcerciseId != null)
            {
                ExcerciseDTO = ExcerciseRepository.GetById(ExcerciseId);
            }
        }

        [SupplyParameterFromForm]
        public ExcerciseDTO ExcerciseDTO { get; set; } = new ExcerciseDTO();
        public Excercise excercise { get; set; } = new Excercise();


        public async Task SaveExcercise()
        {
            if (ExcerciseId == null)
            {
                ExcerciseRepository.AddExcercise(ExcerciseDTO);
            }
            else
            {
                ExcerciseDTO.Id = ExcerciseId;
                ExcerciseRepository.EditExcercise(ExcerciseDTO);
            }
            await InvokeAsync(() => NavigationManager.NavigateTo("/ExcercisePage"));
        }
    }
}
