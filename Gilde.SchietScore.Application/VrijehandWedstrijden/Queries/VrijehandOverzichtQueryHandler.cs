using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Application.VrijehandWedstrijden.Commands;
using MediatR;

namespace Gilde.SchietScore.Application.VrijehandWedstrijden.Queries
{
    internal class VrijehandOverzichtQueryHandler : IRequestHandler<VrijehandOverzichtQuery>
    {
        private IVrijehandRepository _vrijehandRepository { get; set; }
        private IResultaatRepository _resultaatRepository { get; set; }
        private ICompetitieRepository _competitieRepository { get; set; }

        public VrijehandOverzichtQueryHandler(IVrijehandRepository vrijehandRepository, IResultaatRepository resultaatRepository, ICompetitieRepository competitieRepository)
        {
            _vrijehandRepository = vrijehandRepository;
            _resultaatRepository = resultaatRepository;
            _competitieRepository = competitieRepository;
        }

        public async Task Handle(VrijehandOverzichtQuery request, CancellationToken cancellationToken)
        {
            var latestWedstrijd = await _vrijehandRepository.ReadLatest();

            request.Vrijehand.Id = latestWedstrijd.Id;
            await _resultaatRepository.Create(request.Vrijehand);
            await _resultaatRepository.SaveChanges(cancellationToken);
        }
    }
}
