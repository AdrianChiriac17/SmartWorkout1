using Microsoft.AspNetCore.Components;

namespace SmartWorkout1.Components
{
    public partial class ShowName : ComponentBase
    {
        [Parameter]
        public string input { get; set; }
    }
}
