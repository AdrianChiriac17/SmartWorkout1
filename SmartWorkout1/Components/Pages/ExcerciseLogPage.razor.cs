using Microsoft.AspNetCore.Components;
using SmartWorkout1.Entities;
using SmartWorkout1.Repositories.Interfaces;

namespace SmartWorkout1.Components.Pages
{
    public partial class ExcerciseLogPage : ComponentBase
    {
        [Inject]
        public IExcerciseLogRepository ExcerciseLogRepository { get; set; }
        private ICollection<ExcerciseLog> excerciselogs;

        protected override void OnInitialized()
        {
            excerciselogs = ExcerciseLogRepository.GetExcerciseLogs();
            base.OnInitialized();
        }
    }
}
