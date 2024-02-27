using Gilde.SchietScore.Domain;
using MediatR;

namespace Gilde.SchietScore.Application.VrijehandWedstrijden.Commands
{
    public class VrijehandToevoegenCommand : IRequest
    {
        public Vrijehand Vrijehand { get; set; }
        public VrijehandToevoegenCommand(Vrijehand vrijehand)
        {
            Vrijehand = vrijehand;
        }
    }
}
