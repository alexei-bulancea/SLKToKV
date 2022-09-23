using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLKToKV
{
    public class Data
    {
        public Data(Dictionary<int, string> keyValues)
        {

        }

        internal string TryGetValue(Dictionary<int, string> keyValues, int id)
        {
            string temp;
            keyValues.TryGetValue(id, out temp);

            return temp;
        }

        public virtual StringBuilder GenerateStringFromItem(string currentId)
        {
            StringBuilder resultBuilder = new StringBuilder();
            resultBuilder.Append("\"" + currentId + '\"' + "\n{\n");

            var rr = this.GetType().GetProperties();
            foreach (var currentProperty in rr)
            {
                resultBuilder.Append('"' + currentProperty.Name + '"' + "           " + '"' + currentProperty.GetValue(this) + '"' + "\n");

            }
            resultBuilder.Append("}" + "\n");
            var tt = resultBuilder.ToString();
            return resultBuilder;
        }

    }
}
