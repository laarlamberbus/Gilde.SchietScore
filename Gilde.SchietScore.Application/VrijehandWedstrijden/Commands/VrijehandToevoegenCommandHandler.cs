using Gilde.SchietScore.Application.Repositories;
using MediatR;

namespace Gilde.SchietScore.Application.VrijehandWedstrijden.Commands
{
    internal class VrijehandToevoegenCommandHandler : IRequestHandler<VrijehandToevoegenCommand>
    {
        private IVrijehandRepository _vrijehandRepository { get; set; }
        private IResultaatRepository _resultaatRepository { get; set; }
        private ICompetitieRepository _competitieRepository { get; set; }

        public VrijehandToevoegenCommandHandler(IVrijehandRepository vrijehandRepository, IResultaatRepository resultaatRepository, ICompetitieRepository competitieRepository)
        {
            _vrijehandRepository = vrijehandRepository;
            _resultaatRepository = resultaatRepository;
            _competitieRepository = competitieRepository;
        }

        public async Task Handle(VrijehandToevoegenCommand request, CancellationToken cancellationToken)
        {
            var latestWedstrijd = await _vrijehandRepository.ReadLatest();

            request.Vrijehand.Id = latestWedstrijd.Id;
            await _resultaatRepository.Create(request.Vrijehand);
            await _resultaatRepository.SaveChanges(cancellationToken);
        }
    }
}
