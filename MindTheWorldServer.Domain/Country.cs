using MindTheWorldServer.Domain.Base;
using System.Collections.Generic;

#nullable disable

namespace MindTheWorldServer.Domain
{
    public class Country : Entity<int>
    {
        public Country()
        {
            Co2EmissionsPerPeople = new HashSet<Co2EmissionsPerPerson>();
            CoalConsumptions = new HashSet<CoalConsumption>();
            EpidemicDeaths = new HashSet<EpidemicDeath>();
            GrossDomesticProducts = new HashSet<GrossDomesticProduct>();
            HappinessScores = new HashSet<HappinessScore>();
            HumanDevelopmentIndices = new HashSet<HumanDevelopmentIndex>();
            InfantMortalities = new HashSet<InfantMortality>();
            LiteracyRateAdultTotals = new HashSet<LiteracyRateAdultTotal>();
            MaterialFootprintPerCapita = new HashSet<MaterialFootprintPerCapitum>();
            OilConsumptions = new HashSet<OilConsumption>();
            Populations = new HashSet<Population>();
            RenewableWaters = new HashSet<RenewableWater>();
            ResidentialElectricityUses = new HashSet<ResidentialElectricityUse>();
            WaterSourceAccesses = new HashSet<WaterSourceAccess>();
            WaterWithdrawlPerPeople = new HashSet<WaterWithdrawlPerPerson>();
        }

        public string Name { get; set; }

        public virtual ICollection<Co2EmissionsPerPerson> Co2EmissionsPerPeople { get; set; }

        public virtual ICollection<CoalConsumption> CoalConsumptions { get; set; }

        public virtual ICollection<EpidemicDeath> EpidemicDeaths { get; set; }

        public virtual ICollection<GrossDomesticProduct> GrossDomesticProducts { get; set; }

        public virtual ICollection<HappinessScore> HappinessScores { get; set; }

        public virtual ICollection<HumanDevelopmentIndex> HumanDevelopmentIndices { get; set; }

        public virtual ICollection<InfantMortality> InfantMortalities { get; set; }

        public virtual ICollection<LiteracyRateAdultTotal> LiteracyRateAdultTotals { get; set; }

        public virtual ICollection<MaterialFootprintPerCapitum> MaterialFootprintPerCapita { get; set; }

        public virtual ICollection<OilConsumption> OilConsumptions { get; set; }

        public virtual ICollection<Population> Populations { get; set; }

        public virtual ICollection<RenewableWater> RenewableWaters { get; set; }

        public virtual ICollection<ResidentialElectricityUse> ResidentialElectricityUses { get; set; }

        public virtual ICollection<WaterSourceAccess> WaterSourceAccesses { get; set; }

        public virtual ICollection<WaterWithdrawlPerPerson> WaterWithdrawlPerPeople { get; set; }

        public override bool IsTransient => Id == default;
    }
}
