using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLKToKV
{
    public class FullAbilityData
    {
        public string AbilityId { get; set; }
        public AbilityData Stats { get; set; }
        public GenericDescription Description { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("AbilityId : " + AbilityId);
            sb.AppendLine("Descriprion : ");
            sb.AppendLine(Description.ToString());

            return sb.ToString();
        }
    }
}
