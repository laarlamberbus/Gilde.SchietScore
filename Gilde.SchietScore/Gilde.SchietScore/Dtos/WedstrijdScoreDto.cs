﻿namespace Gilde.SchietScore.Dtos
{
    public class WedstrijdScoreDto
    {
        public int Score { get; set; }
        public WedstrijdDto Wedstrijd { get; set; }
        public LidDto Schutter { get; set; }
    }
}
