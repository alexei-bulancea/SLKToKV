namespace SLKToKV
{
    public class AbilityData : Data
    {
       public string alias { get; set; }
        public string code { get; set; }
        public string comments { get; set; }
        public string version { get; set; }
        public string useInEditor { get; set; }
        public string hero { get; set; }
        public string item { get; set; }
        public string sort { get; set; }
        public string race { get; set; }
        public string checkDep { get; set; }
        public string levels { get; set; }
        public string reqLevel { get; set; }
        public string levelSkip { get; set; }
        public string priority { get; set; }
        public string targs1 { get; set; }
        public string Cast1 { get; set; }
        public string Dur1 { get; set; }
        public string HeroDur1 { get; set; }
        public string Cool1 { get; set; }
        public string Cost1 { get; set; }
        public string Area1 { get; set; }
        public string Rng1 { get; set; }
        public string DataA1 { get; set; }
        public string DataB1 { get; set; }
        public string DataC1 { get; set; }
        public string DataD1 { get; set; }
        public string DataE1 { get; set; }
        public string DataF1 { get; set; }
        public string DataG1 { get; set; }
        public string DataH1 { get; set; }
        public string DataI1 { get; set; }
        public string UnitID1 { get; set; }
        public string BuffID1 { get; set; }
        public string EfctID1 { get; set; }
        public string targs2 { get; set; }
        public string Cast2 { get; set; }
        public string Dur2 { get; set; }
        public string HeroDur2 { get; set; }
        public string Cool2 { get; set; }
        public string Cost2 { get; set; }
        public string Area2 { get; set; }
        public string Rng2 { get; set; }
        public string DataA2 { get; set; }
        public string DataB2 { get; set; }
        public string DataC2 { get; set; }
        public string DataD2 { get; set; }
        public string DataE2 { get; set; }
        public string DataF2 { get; set; }
        public string DataG2 { get; set; }
        public string DataH2 { get; set; }
        public string DataI2 { get; set; }
        public string UnitID2 { get; set; }
        public string BuffID2 { get; set; }
        public string EfctID2 { get; set; }
        public string targs3 { get; set; }
        public string Cast3 { get; set; }
        public string Dur3 { get; set; }
        public string HeroDur3 { get; set; }
        public string Cool3 { get; set; }
        public string Cost3 { get; set; }
        public string Area3 { get; set; }
        public string Rng3 { get; set; }
        public string DataA3 { get; set; }
        public string DataB3 { get; set; }
        public string DataC3 { get; set; }
        public string DataD3 { get; set; }
        public string DataE3 { get; set; }
        public string DataF3 { get; set; }
        public string DataG3 { get; set; }
        public string DataH3 { get; set; }
        public string DataI3 { get; set; }
        public string UnitID3 { get; set; }
        public string BuffID3 { get; set; }
        public string EfctID3 { get; set; }
        public string targs4 { get; set; }
        public string Cast4 { get; set; }
        public string Dur4 { get; set; }
        public string HeroDur4 { get; set; }
        public string Cool4 { get; set; }
        public string Cost4 { get; set; }
        public string Area4 { get; set; }
        public string Rng4 { get; set; }
        public string DataA4 { get; set; }
        public string DataB4 { get; set; }
        public string DataC4 { get; set; }
        public string DataD4 { get; set; }
        public string DataE4 { get; set; }
        public string DataF4 { get; set; }
        public string DataG4 { get; set; }
        public string DataH4 { get; set; }
        public string DataI4 { get; set; }
        public string UnitID4 { get; set; }
        public string BuffID4 { get; set; }
        public string EfctID4 { get; set; }

        public string InBeta { get; set; }

        public AbilityData(Dictionary<int, string> keyValues) : base(keyValues)
        {
            int i = 1;
            alias = TryGetValue(keyValues, i++);
            code  = TryGetValue(keyValues,  i++);
            comments  = TryGetValue(keyValues,  i++);
            version  = TryGetValue(keyValues,  i++);
            useInEditor  = TryGetValue(keyValues,  i++);
            hero  = TryGetValue(keyValues,  i++);
            item  = TryGetValue(keyValues,  i++);
            sort  = TryGetValue(keyValues,  i++);
            race  = TryGetValue(keyValues,  i++);
              checkDep  = TryGetValue(keyValues,  i++);
              levels  = TryGetValue(keyValues,  i++);
              reqLevel  = TryGetValue(keyValues,  i++);
              levelSkip  = TryGetValue(keyValues,  i++);
              priority  = TryGetValue(keyValues,  i++);
              targs1  = TryGetValue(keyValues,  i++);
              Cast1  = TryGetValue(keyValues,  i++);
              Dur1  = TryGetValue(keyValues,  i++);
              HeroDur1  = TryGetValue(keyValues,  i++);
              Cool1  = TryGetValue(keyValues,  i++);
              Cost1  = TryGetValue(keyValues,  i++);
              Area1  = TryGetValue(keyValues,  i++);
              Rng1  = TryGetValue(keyValues,  i++);
              DataA1  = TryGetValue(keyValues,  i++);
              DataB1  = TryGetValue(keyValues,  i++);
              DataC1  = TryGetValue(keyValues,  i++);
              DataD1  = TryGetValue(keyValues,  i++);
              DataE1  = TryGetValue(keyValues,  i++);
              DataF1  = TryGetValue(keyValues,  i++);
              DataG1  = TryGetValue(keyValues,  i++);
              DataH1  = TryGetValue(keyValues,  i++);
              DataI1  = TryGetValue(keyValues,  i++);
              UnitID1  = TryGetValue(keyValues,  i++);
              BuffID1  = TryGetValue(keyValues,  i++);
              EfctID1  = TryGetValue(keyValues,  i++);
              targs2  = TryGetValue(keyValues,  i++);
              Cast2  = TryGetValue(keyValues,  i++);
              Dur2  = TryGetValue(keyValues,  i++);
              HeroDur2  = TryGetValue(keyValues,  i++);
              Cool2  = TryGetValue(keyValues,  i++);
              Cost2  = TryGetValue(keyValues,  i++);
              Area2  = TryGetValue(keyValues,  i++);
              Rng2  = TryGetValue(keyValues,  i++);
              DataA2  = TryGetValue(keyValues,  i++);
              DataB2  = TryGetValue(keyValues,  i++);
              DataC2  = TryGetValue(keyValues,  i++);
              DataD2  = TryGetValue(keyValues,  i++);
              DataE2  = TryGetValue(keyValues,  i++);
              DataF2  = TryGetValue(keyValues,  i++);
              DataG2  = TryGetValue(keyValues,  i++);
              DataH2  = TryGetValue(keyValues,  i++);
              DataI2  = TryGetValue(keyValues,  i++);
              UnitID2  = TryGetValue(keyValues,  i++);
              BuffID2  = TryGetValue(keyValues,  i++);
              EfctID2  = TryGetValue(keyValues,  i++);
              targs3  = TryGetValue(keyValues,  i++);
              Cast3  = TryGetValue(keyValues,  i++);
              Dur3  = TryGetValue(keyValues,  i++);
              HeroDur3  = TryGetValue(keyValues,  i++);
              Cool3  = TryGetValue(keyValues,  i++);
              Cost3  = TryGetValue(keyValues,  i++);
              Area3  = TryGetValue(keyValues,  i++);
              Rng3  = TryGetValue(keyValues,  i++);
              DataA3  = TryGetValue(keyValues,  i++);
              DataB3  = TryGetValue(keyValues,  i++);
              DataC3  = TryGetValue(keyValues,  i++);
              DataD3  = TryGetValue(keyValues,  i++);
              DataE3  = TryGetValue(keyValues,  i++);
              DataF3  = TryGetValue(keyValues,  i++);
              DataG3  = TryGetValue(keyValues,  i++);
              DataH3  = TryGetValue(keyValues,  i++);
              DataI3  = TryGetValue(keyValues,  i++);
              UnitID3  = TryGetValue(keyValues,  i++);
              BuffID3  = TryGetValue(keyValues,  i++);
              EfctID3  = TryGetValue(keyValues,  i++);
              targs4  = TryGetValue(keyValues,  i++);
              Cast4  = TryGetValue(keyValues,  i++);
              Dur4  = TryGetValue(keyValues,  i++);
              HeroDur4  = TryGetValue(keyValues,  i++);
              Cool4  = TryGetValue(keyValues,  i++);
              Cost4  = TryGetValue(keyValues,  i++);
              Area4  = TryGetValue(keyValues,  i++);
              Rng4  = TryGetValue(keyValues,  i++);
              DataA4  = TryGetValue(keyValues,  i++);
              DataB4  = TryGetValue(keyValues,  i++);
              DataC4  = TryGetValue(keyValues,  i++);
              DataD4  = TryGetValue(keyValues,  i++);
              DataE4  = TryGetValue(keyValues,  i++);
              DataF4  = TryGetValue(keyValues,  i++);
              DataG4  = TryGetValue(keyValues,  i++);
              DataH4  = TryGetValue(keyValues,  i++);
              DataI4  = TryGetValue(keyValues,  i++);
              UnitID4  = TryGetValue(keyValues,  i++);
              BuffID4  = TryGetValue(keyValues,  i++);
              EfctID4  = TryGetValue(keyValues,  i++);
              InBeta  = TryGetValue(keyValues,  i++);
        }
        public string GetDataValue()
        {
            if (DataA1 != null)
                return DataA1;
            else if (DataB1 != null)
                return DataB1;
            else if (DataC1 != null)
                return DataC1;
            else if (DataD1 != null)
                return DataD1;
            else if (DataE1 != null)
                return DataE1;
            else if (DataF1 != null)
                return DataF1;
            else if (DataG1 != null)
                return DataG1;
            else if (DataH1 != null)
                return DataH1;
            else if (DataI1 != null)
                return DataI1;

            else if (DataA2 != null)
                return DataA2;
            else if (DataB2 != null)
                return DataB2;
            else if (DataC2 != null)
                return DataC2;
            else if (DataD2 != null)
                return DataD2;
            else if (DataE2 != null)
                return DataE2;
            else if (DataF2 != null)
                return DataF2;
            else if (DataG2 != null)
                return DataG2;
            else if (DataH2 != null)
                return DataH2;
            else if (DataI2 != null)
                return DataI2;


            else if (DataA3 != null)
                return DataA3;
            else if (DataB3 != null)
                return DataB3;
            else if (DataC3 != null)
                return DataC3;
            else if (DataD3 != null)
                return DataD3;
            else if (DataE3 != null)
                return DataE3;
            else if (DataF3 != null)
                return DataF3;
            else if (DataG3 != null)
                return DataG3;
            else if (DataH3 != null)
                return DataH3;
            else if (DataI3 != null)
                return DataI3;


            else if(DataA4 != null)
                return DataA4;
            else if (DataB4 != null)
                return DataB4;
            else if (DataC4 != null)
                return DataC4;
            else if (DataD4 != null)
                return DataD4;
            else if (DataE4 != null)
                return DataE4;
            else if (DataF4 != null)
                return DataF4;
            else if (DataG4 != null)
                return DataG4;
            else if (DataH4 != null)
                return DataH4;
            else if (DataI4 != null)
                return DataI4;
            return null;
        }
    }
}
