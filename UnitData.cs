namespace SLKToKV
{
    public class UnitData : Data
    {
        public UnitData(Dictionary<int, string> keyValues) : base(keyValues)
        {
            var i = 1;
            unitBalanceID = TryGetValue( i++);
            sortBalance = TryGetValue( i++);
            sort2 = TryGetValue( i++);
            comments = TryGetValue( i++);
            level = TryGetValue( i++);
            type = TryGetValue( i++);
            goldcost = TryGetValue( i++);
            lumbercost = TryGetValue( i++);
            goldRep = TryGetValue( i++);
            lumberRep = TryGetValue( i++);
            fmade = TryGetValue( i++);
            fused = TryGetValue( i++);
            bountydice = TryGetValue( i++);
            bountysides = TryGetValue( i++);
            bountyplus = TryGetValue( i++);
            lumberbountydice = TryGetValue( i++);
            lumberbountysides = TryGetValue( i++);
            lumberbountyplus = TryGetValue( i++);
            stockMax = TryGetValue( i++);
            stockRegen = TryGetValue( i++);
            stockStart = TryGetValue( i++);
            HP = TryGetValue( i++);
            realHP = TryGetValue( i++);
            regenHP = TryGetValue( i++);
            regenType = TryGetValue( i++);
            manaN = TryGetValue( i++);
            realM = TryGetValue( i++);
            mana0 = TryGetValue( i++);
            regenMana = TryGetValue( i++);
            def = TryGetValue( i++);
            defUp = TryGetValue( i++);
            realdef = TryGetValue( i++);
            defType = TryGetValue( i++);
            spd = TryGetValue( i++);
            minSpd = TryGetValue( i++);
            maxSpd = TryGetValue( i++);
            bldtm = TryGetValue( i++);
            reptm = TryGetValue( i++);
            sight = TryGetValue( i++);
            nsight = TryGetValue( i++);
            STR = TryGetValue( i++);
            INT = TryGetValue( i++);
            AGI = TryGetValue( i++);
            STRplus = TryGetValue( i++);
            INTplus = TryGetValue( i++);
            AGIplus = TryGetValue( i++);
            abilTest = TryGetValue( i++);
            Primary = TryGetValue( i++);
            upgrades = TryGetValue( i++);
            tilesets = TryGetValue( i++);
            nbrandom = TryGetValue( i++);
            isbldg = TryGetValue( i++);
            preventPlace = TryGetValue( i++);
            requirePlace = TryGetValue( i++);
            repulse = TryGetValue( i++);
            repulseParam = TryGetValue( i++);
            repulseGroup = TryGetValue( i++);
            repulsePrio = TryGetValue( i++);
            collision = TryGetValue( i++);
            InBeta = TryGetValue( i++);

        }

        public string unitBalanceID { get; set; }
        public string sortBalance { get; set; }
        public string sort2 { get; set; }
        public string comments { get; set; }
        public string level { get; set; }
        public string type { get; set; }
        public string goldcost { get; set; }
        public string lumbercost { get; set; }
        public string goldRep { get; set; }
        public string lumberRep { get; set; }
        public string fmade { get; set; }
        public string fused { get; set; }
        public string bountydice { get; set; }
        public string bountysides { get; set; }
        public string bountyplus { get; set; }
        public string lumberbountydice { get; set; }
        public string lumberbountysides { get; set; }
        public string lumberbountyplus { get; set; }
        public string stockMax { get; set; }
        public string stockRegen { get; set; }
        public string stockStart { get; set; }
        public string HP { get; set; }
        public string realHP { get; set; }
        public string regenHP { get; set; }
        public string regenType { get; set; }
        public string manaN { get; set; }
        public string realM { get; set; }
        public string mana0 { get; set; }
        public string regenMana { get; set; }
        public string def { get; set; }
        public string defUp { get; set; }
        public string realdef { get; set; }
        public string defType { get; set; }
        public string spd { get; set; }
        public string minSpd { get; set; }
        public string maxSpd { get; set; }
        public string bldtm { get; set; }
        public string reptm { get; set; }
        public string sight { get; set; }
        public string nsight { get; set; }
        public string STR { get; set; }
        public string INT { get; set; }
        public string AGI { get; set; }
        public string STRplus { get; set; }
        public string INTplus { get; set; }
        public string AGIplus { get; set; }
        public string abilTest { get; set; }
        public string Primary { get; set; }
        public string upgrades { get; set; }
        public string tilesets { get; set; }
        public string nbrandom { get; set; }
        public string isbldg { get; set; }
        public string preventPlace { get; set; }
        public string requirePlace { get; set; }
        public string repulse { get; set; }
        public string repulseParam { get; set; }
        public string repulseGroup { get; set; }
        public string repulsePrio { get; set; }
        public string collision { get; set; }
        public string InBeta { get; set; }

    }
}