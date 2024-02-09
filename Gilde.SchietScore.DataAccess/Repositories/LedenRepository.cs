namespace Gilde.SchietScore.Persistence.Repositories
{
    public class LedenService // : ILedenRepository
    {
        //private readonly ISchietScoreDbContext _schietScoreDbContext;
        //private readonly ILedenFactory _ledenFactory;
        //private readonly ILedenBuilder _ledenBuilder;

        //public LedenService(
        //    ISchietScoreDbContext schietScoreDbContext,
        //    ILedenFactory ledenFactory,
        //    ILedenBuilder ledenBuilder)
        //{
        //    _schietScoreDbContext = schietScoreDbContext;
        //    _ledenFactory = ledenFactory;
        //    _ledenBuilder = ledenBuilder;
        //}

        //public async Task Create(Lid entity)
        //{
        //    await _schietScoreDbContext.Leden.AddAsync(_ledenFactory.CreateDto(entity));
        //}

        //public void Delete(Lid entity)
        //{
        //    _schietScoreDbContext.Leden.Entry(_ledenFactory.CreateDto(entity)).State = EntityState.Deleted;
        //}

        //public async Task<IEnumerable<Lid>> ReadAll()
        //{
        //    return _ledenFactory.CreateModels(await _schietScoreDbContext.Leden.ToListAsync());
        //}

        //public async Task Save(CancellationToken cancellationToken)
        //{
        //    await _schietScoreDbContext.SaveChangesAsync(cancellationToken);
        //}

        //public async Task Update(Lid entity)
        //{
        //    var lid = await _schietScoreDbContext.Leden.SingleOrDefaultAsync(l => l.Id == entity.Id);

        //    if (lid == null)
        //        throw new Exception($"Lid met id {entity.Id} bestaat niet in de database.");

        //    lid = _ledenBuilder.BuildDto(lid, entity);
        //}
    }
}
