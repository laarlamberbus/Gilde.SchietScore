using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components.Filter
{
    public partial class WeekFilterComponent
    {
        [Parameter]
        public List<DateOnly> AllGameWeeks { get; set; }
        [Parameter]
        public DateOnly? SelectedWeek { get; set; }
        [Parameter]
        public EventCallback<DateOnly?> SelectedWeekChanged { get; set; }


        protected async Task OnGameDateSelection(DateOnly selectedGameDate)
        {
            await ChangeSelectedWeek(selectedGameDate);
        }

        private async Task ChangeSelectedWeek(DateOnly? selectedWeek)
        {
            SelectedWeek = selectedWeek;
            await SelectedWeekChanged.InvokeAsync(SelectedWeek);
        }
    }
}
