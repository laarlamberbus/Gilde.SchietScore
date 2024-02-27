using MediatR;
using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components
{
    public class BaseComponent : ComponentBase
    {
        [Inject]
        protected IMediator Mediator { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }
    }
}
