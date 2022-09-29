using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLKToKV
{
    public class FullUnitData
    {
        public string UnitId { get; set; }
        public UnitData Stats { get; set; }
        public GenericDescription Description { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("UnitId : " + UnitId);
            sb.AppendLine("Descriprion : " );
            sb.AppendLine(Description.ToString());

            return sb.ToString();
        }
    }
}
