﻿using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Builders.Interfaces;
using Gilde.SchietScore.Persistence.Dtos;
using Gilde.SchietScore.Persistence.Factories.Interfaces;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace Gilde.SchietScore.Persistence.Repositories
{
    public class VrijehandRepository : IVrijehandRepository
    {
        private readonly ISchietScoreDbContext _schietScoreDbContext;
        private readonly IVrijehandFactory _vrijehandFactory;
        private readonly IVrijehandBuilder _vrijehandBuilder;

        public VrijehandRepository(
            ISchietScoreDbContext schietScoreDbContext,
            IVrijehandFactory vrijehandFactory,
            IVrijehandBuilder vrijehandBuilder)
        {
            _schietScoreDbContext = schietScoreDbContext;
            _vrijehandFactory = vrijehandFactory;
            _vrijehandBuilder = vrijehandBuilder;
        }

        public async Task Create(Vrijehand entity, CancellationToken cancellationToken = default)
        {
            await _schietScoreDbContext.Wedstrijden.AddAsync(_vrijehandFactory.CreateDto(entity), cancellationToken);
        }

        public async Task<Vrijehand> ReadWedstrijddag(DeelnemerKlasse deelnemerKlasse, DateOnly dateOnly, CancellationToken cancellationToken = default)
        {
            var result = await _schietScoreDbContext
                                    .Resultaten.Where(s => 
                                        s.Datum == dateOnly &&
                                        s.Deelnemer.Klasse == deelnemerKlasse.ToString() &&
                                        EF.Functions.Like(s.Wedstrijd.Naam, $"%{nameof(Vrijehand)}%"))
                                    .Include(s => s.Deelnemer)
                                    .Include(s => s.Wedstrijd)
                                    .ToListAsync();

            var leden = new List<LidDto>();
            var vrijehand = new Vrijehand();
            var deelnemers = new List<Deelnemer>();

            foreach(var r in result)
            {
                vrijehand.Datum = r.Datum;
                deelnemers.Add(new Schutter()
                {
                    Id = r.Id,
                    Naam = r.Deelnemer.Naam,
                    Klasse = (DeelnemerKlasse)Enum.Parse(typeof(DeelnemerKlasse), r.Deelnemer.Klasse),
                    KNTSNummer = r.Deelnemer.KNTSNummer,
                    Score = r.Score
                });
            }
            vrijehand.Deelnemers = deelnemers;

            return vrijehand;
        }

        public async Task Update(IEnumerable<Vrijehand> entities, CancellationToken cancellationToken = default)
        {
            foreach (var schutter in entities)
            {
                await Update(schutter, cancellationToken);
            }
        }

        public async Task Update(Vrijehand entity, CancellationToken cancellationToken = default)
        {
            var wedstrijdToPersist = await _schietScoreDbContext.Wedstrijden.FindAsync(entity.Id, cancellationToken);

            if(wedstrijdToPersist != null)
                _vrijehandBuilder.BuildDto(wedstrijdToPersist, entity);
        }

        public async Task SaveChanges(CancellationToken cancellationToken = default)
        {
            await _schietScoreDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken = default)
        {
            var entityToDelete = await _schietScoreDbContext.Leden.FindAsync(id, cancellationToken);
            
            if (entityToDelete != null)
                entityToDelete.SoftDeleted = true;
        }

        public async Task<Vrijehand> ReadById(int id, CancellationToken cancellationToken = default)
        {
            return _vrijehandFactory.CreateModel(await _schietScoreDbContext.Wedstrijden.FindAsync(id, cancellationToken));
        }

        public async Task<List<DateOnly>> ReadAlleWedstrijdagenPerJaar(int jaar, CancellationToken cancellationToken = default)
        {
            return await _schietScoreDbContext.Resultaten
                            .Where(r => r.Datum.Year == jaar)
                            .Select(r => r.Datum)
                            .Distinct()
                            .OrderBy(d => d)
                            .ToListAsync(cancellationToken);
        }

        public async Task<List<int>> ReadAlleWedstrijdJaren(CancellationToken cancellationToken = default)
        {
            return await _schietScoreDbContext.Resultaten
                             .Select(r => r.Datum.Year)
                             .Distinct()
                             .OrderBy(d => d)
                             .ToListAsync(cancellationToken);
        }

        public async Task RegisterNewResultaatVrijehand(Schutter schutter, DateOnly wedstrijddag, CancellationToken cancellationToken = default)
        {
            var wedstrijdID = _schietScoreDbContext.Wedstrijden.Single(w => EF.Functions.Like(w.Naam, $"%{nameof(Vrijehand)} {schutter.Klasse}%")).Id;

            await _schietScoreDbContext.Resultaten.AddAsync(new ResultaatDto { DeelnemerId = schutter.Id, WedstrijdId = wedstrijdID, Datum = wedstrijddag, Score = schutter.Score, AantalKogels = schutter.AantalKogels }, cancellationToken);
        }
    }
}
