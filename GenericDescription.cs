using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLKToKV
{
    public class GenericDescription
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Hotkey { get; set; }
        public string Tip { get; set; }
        public string Ubertip { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("\tId : " + Id);
            sb.AppendLine("\tName : " + Name);
            sb.AppendLine("\tUbertip : " + Ubertip);

            return sb.ToString();
        }
    }
}
