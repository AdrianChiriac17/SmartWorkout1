using Microsoft.AspNetCore.Components;
using SmartWorkout1.Entities;
using SmartWorkout1.Repositories.Interfaces;

namespace SmartWorkout1.Components.Pages
{
    public partial class ExcercisePage : ComponentBase
    {
        [Inject]
        public IExcerciseRepository ExcerciseRepository { get; set; }
        private ICollection<Excercise> excercises;

        protected override void OnInitialized()
        {
            excercises = ExcerciseRepository.GetExcercises();
            base.OnInitialized();
        }
    }
}
