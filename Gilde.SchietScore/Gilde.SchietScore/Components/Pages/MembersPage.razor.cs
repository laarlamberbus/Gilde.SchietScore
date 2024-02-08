using Gilde.SchietScore.Data.Services.Interfaces;
using Gilde.SchietScore.Models;
using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components.Pages
{
    public partial class MembersPage
    {
        [Inject]
        private IMemberService? MemberService { get; set; }

        public List<Member> _members;

        protected async override Task OnInitializedAsync()
        {
            if(MemberService != null)
                _members = await MemberService.GetMembers();
        }
    }
}
