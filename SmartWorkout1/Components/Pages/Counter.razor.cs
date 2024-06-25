using Blazorise;
using Microsoft.AspNetCore.Components;

namespace SmartWorkout1.Components.Pages
{
    public partial class Counter : ComponentBase
    {
        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
        }


        bool alertvisible = true;

        string name;

}
}
