using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLKToKV
{
    public class UnitAbility : Data
    {
        public UnitAbility(Dictionary<int, string> keyValues) : base(keyValues)
        {
            UnitId = TryGetValue(1);
            var abilityList = TryGetValue(5);
            AbilityList = string.IsNullOrEmpty(abilityList) ? new List<string>() : abilityList.Split(',').ToList();

            var heroAbilityList = TryGetValue(6);
            HeroAbilityList = string.IsNullOrEmpty(heroAbilityList) ? new List<string>() : heroAbilityList.Split(',').ToList();
        }

        public string UnitId { get; set; }

        public List<string> AbilityList { get; set; }
        public List<string> HeroAbilityList { get; set; }
    }
}
