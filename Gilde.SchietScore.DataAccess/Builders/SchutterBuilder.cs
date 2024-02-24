using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Builders.Interfaces;
using Gilde.SchietScore.Persistence.Dtos;

namespace Gilde.SchietScore.Persistence.Builders
{
    public class SchutterBuilder : ISchutterBuilder
    {
        public LidDto BuildDto(LidDto toBuild, Schutter toBuildFrom)
        {
            toBuild.Naam = toBuildFrom.Naam;
            toBuild.IsSchietendLid = true;
            toBuild.DeelnemerClassType = toBuildFrom.DeelnemerKlasseType.ToString();
            toBuild.KNTSNummer = toBuildFrom.KNTSNummer;
            return toBuild;
        }
    }
}
