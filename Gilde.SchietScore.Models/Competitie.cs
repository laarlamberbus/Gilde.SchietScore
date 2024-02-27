﻿namespace Gilde.SchietScore.Domain
{
    public abstract class Competitie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public bool IsActive { get; set; }
        public Opgelegd Opgelegd { get; set; }
        public Vrijehand Vrijehand { get; set; }
    }
}
