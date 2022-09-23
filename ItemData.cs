using System.Text;

namespace SLKToKV
{
    public class ItemData : Data
    {
        public string itemID { get; set; }
        public string comment { get; set; }
        public string scriptname { get; set; }
        public string version { get; set; }
        public string @class { get; set; }
        public string Level { get; set; }
        public string oldLevel { get; set; }
        public string abilList { get; set; }
        public string cooldownID { get; set; }
        public string ignoreCD { get; set; }
        public string uses { get; set; }
        public string prio { get; set; }
        public string usable { get; set; }
        public string perishable { get; set; }
        public string droppable { get; set; }
        public string pawnable { get; set; }
        public string sellable { get; set; }
        public string pickRandom { get; set; }
        public string powerup { get; set; }
        public string drop { get; set; }
        public string stockMax { get; set; }
        public string stockRegen { get; set; }
        public string stockStart { get; set; }
        public string goldcost { get; set; }
        public string lumbercost { get; set; }
        public string HP { get; set; }
        public string morph { get; set; }
        public string armor { get; set; }
        public string file { get; set; }
        public string scale { get; set; }
        public string selSize { get; set; }
        public string colorR { get; set; }
        public string colorG { get; set; }
        public string colorB { get; set; }
        public string InBeta { get; set; }

        public List<AbilityDataShort> AbilityDataShort { get; set; }

        public ItemData(Dictionary<int, string> keyValues) : base(keyValues)
        { 
            itemID = TryGetValue(keyValues, 1);
            comment  = TryGetValue(keyValues, 2);
            scriptname = TryGetValue(keyValues, 3);
            version  = TryGetValue(keyValues,4);
            @class  = TryGetValue(keyValues,5);
            Level  = TryGetValue(keyValues,6);
            oldLevel  = TryGetValue(keyValues,7);
            abilList  = TryGetValue(keyValues,8);
            cooldownID  = TryGetValue(keyValues,9);
            ignoreCD  = TryGetValue(keyValues,10);
            uses  = TryGetValue(keyValues,11);
            prio  = TryGetValue(keyValues,12);
            usable  = TryGetValue(keyValues,13);
            perishable  = TryGetValue(keyValues,14);
            droppable  = TryGetValue(keyValues,15);
            pawnable  = TryGetValue(keyValues,16);
            sellable  = TryGetValue(keyValues,17);
            pickRandom  = TryGetValue(keyValues,18);
            powerup  = TryGetValue(keyValues,19);
            drop  = TryGetValue(keyValues,20);
            stockMax  = TryGetValue(keyValues,21);
            stockRegen  = TryGetValue(keyValues,22);
            stockStart  = TryGetValue(keyValues,23);
            goldcost  = TryGetValue(keyValues,24);
            lumbercost  = TryGetValue(keyValues,25);
            HP  = TryGetValue(keyValues,26);
            morph  = TryGetValue(keyValues,27);
            armor  = TryGetValue(keyValues,28);
            file  = TryGetValue(keyValues,29);
            scale  = TryGetValue(keyValues,30);
            selSize  = TryGetValue(keyValues,31);
            colorR  = TryGetValue(keyValues,32);
            colorG  = TryGetValue(keyValues,33);
            colorB  = TryGetValue(keyValues,34);
            InBeta  = TryGetValue(keyValues,35);
        }

        public StringBuilder GenerateStringFromItemWithAbility(string currentId, StringBuilder abilityBuilder)
        {
            StringBuilder resultBuilder = new StringBuilder();
            resultBuilder.Append("\"" + currentId + '\"' + "\n{\n");

            var rr = this.GetType().GetProperties();
            foreach (var currentProperty in rr)
            {
                if (currentProperty.Name.Equals("abilList"))
                {
                    resultBuilder.Append('"' + currentProperty.Name + '"');
                    resultBuilder.Append("\n" + "{" + "\n");
                    resultBuilder.Append(abilityBuilder);
                    resultBuilder.Append("\n" + "}" + "\n");
                    continue;
                }
                resultBuilder.Append('"' + currentProperty.Name + '"' + "           " + '"' + currentProperty.GetValue(this) + '"' + "\n");

            }
            resultBuilder.Append("}" + "\n");
            var tt = resultBuilder.ToString();
            return resultBuilder;
        }
    }
}
