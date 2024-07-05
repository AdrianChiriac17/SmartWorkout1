using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using SmartWorkout1.Entities;
using SmartWorkout1.Repositories.Implementations;
using SmartWorkout1.Repositories.Interfaces;

namespace SmartWorkout1.Components.Pages
{
    public partial class ExcercisePage : ComponentBase
    {
        [Inject]
        public IExcerciseRepository ExcerciseRepository { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private ICollection<Excercise> excercises;

        protected override void OnInitialized()
        {
            excercises = ExcerciseRepository.GetExcercises();
            base.OnInitialized();
        }

        private void EditExcercise(EditCommandContext<Excercise> context)
        {

            if (context != null && context.Item != null)
            {
                NavigationManager.NavigateTo($"/excercise/edit/{context.Item.Id}");
            }
        }

        private void DeleteExcercise(DeleteCommandContext<Excercise> context)
        {

            if (context != null && context.Item != null)
            {
                ExcerciseRepository.DeleteExcercise(context.Item.Id);
                NavigationManager.Refresh(forceReload: true);
            }

        }
    }
}
