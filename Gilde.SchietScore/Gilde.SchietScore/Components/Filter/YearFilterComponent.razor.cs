using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components.Filter
{
    public partial class YearFilterComponent
    {
        [Parameter]
        public List<int> AllGameYears { get; set; }
        [Parameter]
        public int SelectedYear { get; set; }
        [Parameter]
        public EventCallback<int> SelectedYearChanged { get; set; }

        protected async Task OnYearSelection(int year)
        {
            await ChangeSelectedYear(year);
        }
        private async Task ChangeSelectedYear(int selectedYear)
        {
            SelectedYear = selectedYear;
            await SelectedYearChanged.InvokeAsync(SelectedYear);
        }
    }
}
