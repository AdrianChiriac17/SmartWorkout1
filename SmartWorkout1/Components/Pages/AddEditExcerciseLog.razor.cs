using Microsoft.AspNetCore.Components;
using SmartWorkout1.DTOs;
using SmartWorkout1.Entities;
using SmartWorkout1.Repositories.Interfaces;

namespace SmartWorkout1.Components.Pages
{
    public partial class AddEditExcerciseLog : ComponentBase
    {
        [Inject]
        public IExcerciseLogRepository ExcerciseLogRepository { get; set; }
        [Inject]
        public IExcerciseRepository ExcerciseRepository { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int? ExcerciseLogId { get; set; }
        [Parameter]
        public int? workoutId { get; set; }

        [SupplyParameterFromForm]
        public ExcerciseLogDTO ExcerciseLogDTO { get; set; } = new ExcerciseLogDTO();
        protected override void OnParametersSet()
        {
            if (ExcerciseLogId != null)
            {
                ExcerciseLogDTO = ExcerciseLogRepository.GetById(ExcerciseLogId);
            }
        }
        public ExcerciseLogDTO excerciseLog { get; set; } = new ExcerciseLogDTO();


        public async Task SaveExcerciseLog()
        {
            if (ExcerciseLogId == null)
            {
                ExcerciseLogDTO.WorkoutId = workoutId ?? 0;
                ExcerciseLogRepository.AddExcerciseLog(ExcerciseLogDTO);
            }
            else
            {
                ExcerciseLogDTO.Id = ExcerciseLogId.Value;
                ExcerciseLogRepository.EditExcerciseLog(ExcerciseLogDTO);
            }
            await InvokeAsync(() => NavigationManager.NavigateTo("/ExcerciseLogPage"));
        }


        public List<ExcerciseLogDTO> GetExcerciseLogsByWorkoutId(int workoutId)
        {
            return ExcerciseLogRepository.GetByWorkoutId(workoutId);
        }

        public ICollection<ExcerciseDTO> GetExcercises()
        {
            return ExcerciseRepository.GetExcercises();
        }
    }
}
