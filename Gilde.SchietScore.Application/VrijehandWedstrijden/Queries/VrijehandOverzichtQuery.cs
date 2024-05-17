using Gilde.SchietScore.Domain;
using MediatR;

namespace Gilde.SchietScore.Application.VrijehandWedstrijden.Queries
{
    public class VrijehandOverzichtQuery : IRequest
    {
        public Vrijehand Vrijehand { get; set; }
        public VrijehandOverzichtQuery(Vrijehand vrijehand)
        {
            Vrijehand = vrijehand;
        }
    }
}
