using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using SmartWorkout1.DTOs;
using SmartWorkout1.Repositories.Interfaces;

namespace SmartWorkout1.Components.Pages
{
    public partial class ExcercisePage : ComponentBase
    {
        [Inject]
        public IExcerciseRepository ExcerciseRepository { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private ICollection<ExcerciseDTO> excercises;

        protected override void OnInitialized()
        {
            excercises = ExcerciseRepository.GetExcercises();
            base.OnInitialized();
        }

        private void EditExcercise(EditCommandContext<ExcerciseDTO> context)
        {

            if (context != null && context.Item != null)
            {
                NavigationManager.NavigateTo($"/excercise/edit/{context.Item.Id}");
            }
        }

        private void DeleteExcercise(DeleteCommandContext<ExcerciseDTO> context)
        {

            if (context != null && context.Item != null)
            {
                ExcerciseRepository.DeleteExcercise(context.Item.Id);
                NavigationManager.Refresh(forceReload: true);
            }

        }

        /*
        public void CreateExcerciseLog(EditCommandContext<Excercise> context)
        {
            var id = context.Item.Id;

            if (context.Item != null && context != null)
            {
                //NavigationManager.NavigateTo($"/excerciselog/add/{WorkoutId}/{id}");
            }
        }
        */
    }
}
