using SLKToKV;
using System;
using System.Collections;
using System.Text;
#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.

public class SlkCell
{
    public int Row { get; set; }
    public int Column { get; set; }
    public string Value { get; set; }
}

public class SlkLine
{
    public int Row { get; set; }
    public Dictionary<int, string>? KeyValue { get; set; }
}


public class SLKToKVCLass
{
    private const StringComparison selectedCulture = StringComparison.InvariantCultureIgnoreCase;
    static void Main()
    {
        string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var path = Path.Combine(sCurrentDirectory, @"..\..\..\TestData\");
        var generationDirectory = Directory.CreateDirectory(path + "Generated/");


        var gameStrings = ReadAllEntitiesDescription(path);
        var gameData = ReadGameData(path);


        //Console.WriteLine("Search for unit by id : ");
        //var selectedId = Console.ReadLine();

        //while (selectedId.Length != 4)
        //{
        //    Console.WriteLine("Id should contain 4 chars");
        //    selectedId = Console.ReadLine();
        //}
        var selectedId = "n03M";
        var notFoundIds = new List<string>();
        var unitsDirectory = Directory.CreateDirectory(generationDirectory.FullName + "Units/");
        foreach (var item in gameData.UnitDataList)
        {
            var unitInfo = GetUnitInformation(gameStrings, gameData, item.unitBalanceID);
            notFoundIds.AddRange(unitInfo.Item2);
            var currentUnitName = gameStrings.FirstOrDefault(x => x.Id.Equals(item.unitBalanceID)).Name.Replace('"', ' ');

            var resultPath = Path.GetFullPath(unitsDirectory + currentUnitName + ".txt");
            File.WriteAllText(resultPath, unitInfo.Item1);
        }

        var sb = new StringBuilder();
        foreach (var item in notFoundIds.Distinct())
        {
            sb.AppendLine(item);
        }
        File.WriteAllText(unitsDirectory.FullName+"errors.txt", sb.ToString());
        //Console.WriteLine(unitInfo);
        //GenerateItems(path, gameStrings, gameData);

        Console.WriteLine("Exiting...");
    }

    private static void GenerateItems(string generationDirectory, List<GenericDescription> gameStrings, GameTypes gameData)
    {
        var itemResult = new List<FullItemData>();

        foreach (var item in gameData.ItemDataList)
        {
            var currentItem = gameStrings.FirstOrDefault(x => x.Id.Equals(item.itemID));
            itemResult.Add(new FullItemData { Description = currentItem, Stats = item });
        }

        var itemStringBuilderResult = new StringBuilder();
        foreach (var item in itemResult)
        {
            var currentStringBuilder = new StringBuilder();
            var currentItemName = @$"""item_" + item.Description.Name.ToLower().Replace(' ', '_').Replace("+", "").Replace("\"", "") + "\"";
            currentStringBuilder.AppendLine("//============================================================================================");
            currentStringBuilder.AppendLine("//" + item.Description.Name);
            currentStringBuilder.AppendLine("//============================================================================================");
            currentStringBuilder.AppendLine(currentItemName);
            currentStringBuilder.AppendLine("{");
            currentStringBuilder.AppendLine(@$"    ""ID"" ""{item.Description.Id}""");
            currentStringBuilder.AppendLine(@$"    ""BaseClass"" ""item_datadriven""");
            currentStringBuilder.AppendLine(@$"    ""AbilityBehavior"" ""DOTA_ABILITY_BEHAVIOR_PASSIVE""");
            currentStringBuilder.AppendLine(@$"    ""AbilityTextureName"" ""item_helm""");

            if (item.Stats != null)
            {

                currentStringBuilder.AppendLine(@$"    //""Abilities"" ""{item.Stats.abilList}""");


                currentStringBuilder.AppendLine(@$"    ""ItemCost"" ""{item.Stats.goldcost}""");
                currentStringBuilder.AppendLine(@$"    ""ItemKillable"" ""1""");
                currentStringBuilder.AppendLine(@$"    ""ItemSellable"" ""{item.Stats.sellable}""");
                currentStringBuilder.AppendLine(@$"    ""ItemPurchasable"" ""1""");/*{Convert.ToInt32(item.Stats.@class.Equals("Purchasable"))}*/
                currentStringBuilder.AppendLine(@$"    ""ItemDroppable"" ""{item.Stats.droppable}""");
                currentStringBuilder.AppendLine(@$"    ""ItemInitialCharges"" ""{item.Stats.uses}""");
                currentStringBuilder.AppendLine(@$"    ""ItemDisplayCharges"" ""1""");
                currentStringBuilder.AppendLine(@$"    ""ItemRequiresCharges"" ""1""");
            }
            currentStringBuilder.AppendLine(@$"    ""Modifiers""");
            currentStringBuilder.AppendLine("    {");
            currentStringBuilder.AppendLine(@$"        ""modifier_{currentItemName}"" ");
            currentStringBuilder.AppendLine("        {");

            currentStringBuilder.AppendLine(@$"             ""Passive"" ""1""");
            currentStringBuilder.AppendLine(@$"             ""IsHidden"" ""1""");
            currentStringBuilder.AppendLine(@$"             ""Properties""");

            currentStringBuilder.AppendLine("               {");
            currentStringBuilder.AppendLine();
            currentStringBuilder.AppendLine("               }");
            currentStringBuilder.AppendLine("        }");
            currentStringBuilder.AppendLine("    }");

            currentStringBuilder.AppendLine("}");
            itemStringBuilderResult.Append(currentStringBuilder.ToString());
        }

        var resultPath = Path.GetFullPath(generationDirectory + "ItemResultData.txt");
        File.WriteAllText(resultPath, itemStringBuilderResult.ToString());
        Console.WriteLine("ItemResultData file was generated at path - " + resultPath);
    }

    private static Tuple<string, List<string>> GetUnitInformation(List<GenericDescription> gameStrings, GameTypes gameData, string selectedId)
    {
        var abilitytListResult = new List<FullAbilityData>();
        var unitListResult = new List<FullUnitData>();
        var idsNotFound = new List<string>();
        foreach (var item in gameData.AbilityDataList)
        {
            var currentAbility = gameStrings.FirstOrDefault(x => x.Id.Equals(item.alias));
            abilitytListResult.Add(new FullAbilityData { AbilityId = currentAbility.Id, Description = currentAbility, Stats = item });
        }

        foreach (var item in gameData.UnitDataList)
        {
            var currentUnit = gameStrings.FirstOrDefault(x => x.Id.Equals(item.unitBalanceID));
            unitListResult.Add(new FullUnitData { UnitId = currentUnit.Id, Description = currentUnit, Stats = item });
        }

        var selectedUnitData = gameData.UnitAbilityDataList.FirstOrDefault(x => x.UnitId.Equals(selectedId, selectedCulture));
        if (selectedUnitData == null)
        {
            Console.WriteLine(@$"Unit with ID : {selectedId} was not find.");
            return null;
        }
        var strBuilder = new StringBuilder();

        strBuilder.Append(unitListResult.First(x => x.UnitId.Equals(selectedId, selectedCulture)).ToString());
        strBuilder.AppendLine("Ability List:");
        foreach (var ability in selectedUnitData.AbilityList)
        {
            if (ability.Contains('_'))
            {
                continue;
            }
            var result = abilitytListResult.FirstOrDefault(x => x.AbilityId.Equals(ability, selectedCulture));
            if (result is null)
            {
                idsNotFound.Add(ability);
                continue;
            }
            strBuilder.AppendLine(result.ToString());
        }

        strBuilder.AppendLine("Hero ability list:");
        foreach (var ability in selectedUnitData.HeroAbilityList)
        {
            if (ability.Contains('_'))
            {
                continue;
            }
            var result = abilitytListResult.FirstOrDefault(x => x.AbilityId.Equals(ability, selectedCulture));
            if (result is null)
            {
                idsNotFound.Add(ability);
                continue;
            }
            strBuilder.AppendLine(result.ToString());
        }

        return new Tuple<string, List<string>>(strBuilder.ToString(), idsNotFound);
    }

    public void PrintResult(int currentRow, List<SlkLine> slkLines)
    {
        StringBuilder resultBuilder = new StringBuilder();
        for (int i = 2; i <= currentRow; i++)
        {
            var relatedLines = slkLines.Single(x => x.Row == i);

            StringBuilder builder = new StringBuilder();

            builder.Append("\"" + (i - 1) + '\"' + "\n{\n");
            foreach (var line in relatedLines.KeyValue)
            {

                builder.Append(slkLines[0].KeyValue[line.Key] + "           " + line.Value + "\n");

            }
            builder.Append("}" + "\n");
            resultBuilder.Append(builder);
        }
        Console.WriteLine(resultBuilder.ToString());

    }
    public static List<GenericDescription> ReadAllEntitiesDescription(string path)
    {
        var objectStrings = Directory.GetFiles(path, "*Strings.txt");
        var resultStrings = new List<GenericDescription>();
        foreach (var filePath in objectStrings)
        {
            var file = File.ReadAllLines(filePath);

            var itemList = new List<GenericDescription>();

            GenericDescription currentItem = null;
            var lengthCounter = 0;
            for (int i = 0; i < file.Length; i++)
            {
                var currentValue = file[i];
                if (currentValue.StartsWith("["))
                {
                    currentItem = new GenericDescription();
                    itemList.Add(currentItem);
                    var id = new String(currentValue.Skip(1).Take(4).ToArray<Char>());
                    currentItem.Id = id.Replace("\"", "");
                    lengthCounter++;
                }
                else if (currentValue.StartsWith("Name"))
                {
                    currentItem.Name = new String(currentValue.Skip(5).ToArray<Char>());
                }
                else if (currentValue.StartsWith("Hotkey"))
                {
                    currentItem.Hotkey = new String(currentValue.Skip(7).ToArray<Char>());
                }
                else if (currentValue.StartsWith("Tip"))
                {
                    currentItem.Tip = new String(currentValue.Skip(4).ToArray<Char>());
                }
                else if (currentValue.StartsWith("Ubertip"))
                {
                    currentItem.Ubertip = new String(currentValue.Skip(8).ToArray<Char>());
                }
                else if (currentValue.StartsWith("Description"))
                {
                    currentItem.Description = new String(currentValue.Skip(12).ToArray<Char>());
                }
            }
            resultStrings.AddRange(itemList);
        }

        return resultStrings;
    }

    public static List<GenericDescription> ReadItemAbilityDescription(string path)
    {
        var file = File.ReadAllLines(Path.GetFullPath(path + "ItemAbilityStrings.txt"));

        var itemList = new List<GenericDescription>();

        GenericDescription currentItem = null;
        for (int i = 0; i < file.Length; i++)
        {
            var currentValue = file[i];
            if (currentValue.StartsWith("["))
            {
                currentItem = new GenericDescription();
                itemList.Add(currentItem);
                var id = new String(currentValue.Skip(1).Take(4).ToArray<Char>());
                currentItem.Id = id.Replace("\"", "");
            }
            else if (currentValue.StartsWith("Name"))
            {
                currentItem.Name = new String(currentValue.Skip(5).ToArray<Char>());
            }
            else
            {
                continue;
            }
           
        }
        return itemList;
    }

    public static GameTypes ReadGameData(string path)
    {
        var gameTypes = new GameTypes();
        var fileList = new List<string> { "abilitydata.slk", "itemdata.slk", "unitabilities.slk", "unitbalance.slk" };
        foreach (var fileName in fileList)
        {
            string[] text = System.IO.File.ReadAllLines(Path.GetFullPath(path + fileName));

            var slkcells = new List<SlkCell>();
            var currentRow = 0;
            var lastColumn = 1;
            foreach (string line in text)
            {
                if (line.StartsWith('C'))
                {
                    string[] columns = line.Split(';');
                    var currentLine = new SlkCell();
                    foreach (var column in columns)
                    {
                        if (column.StartsWith("Y"))
                        {
                            currentRow = int.Parse(column.Substring(1));
                            //Console.WriteLine(column + "---StartsWith_Y");
                        }
                        else if (column.StartsWith("X"))
                        {
                            currentLine.Column = int.Parse(column.Substring(1));
                            lastColumn = currentLine.Column;
                            //Console.WriteLine(column + "---StartsWith_X");
                        }
                        else if (column.StartsWith("K"))
                        {
                            currentLine.Value = column.Substring(1);
                            // Console.WriteLine(column + "---StartsWith_K");
                        }
                    }
                    currentLine.Row = currentRow;
                    if (currentLine.Column == 0)
                        currentLine.Column = lastColumn;
                    slkcells.Add(currentLine);
                }
            }

            var slkLines = new List<SlkLine>();
            for (int i = 1; i <= currentRow; i++)
            {
                var tt = slkcells.Where(x => x.Row == i);
                var line = new SlkLine();
                line.Row = i;
                line.KeyValue = new Dictionary<int, string>();

                foreach (var item in tt)
                {
                    line.KeyValue.Add(item.Column, item.Value.Replace("\"", ""));
                }
                slkLines.Add(line);
            }

            for (int i = 2; i <= currentRow; i++)
            {
                var relatedLines = slkLines.Single(x => x.Row == i);
                switch (fileName)
                {
                    case "abilitydata.slk": gameTypes.AbilityDataList.Add(new AbilityData(relatedLines.KeyValue)); break;
                    case "itemdata.slk": gameTypes.ItemDataList.Add(new ItemData(relatedLines.KeyValue)); break;
                    case "unitabilities.slk": gameTypes.UnitAbilityDataList.Add(new UnitAbility(relatedLines.KeyValue)); break;
                    case "unitbalance.slk": gameTypes.UnitDataList.Add(new UnitData(relatedLines.KeyValue)); break;
                    default:
                        break;
                }

            }

        }
        var resultBuilder = new StringBuilder();
        foreach (var item in gameTypes.ItemDataList)
        {
            //if (item.abilList.Contains('_'))
            //{
                resultBuilder.Append(item.GenerateStringFromItem(item.itemID));
                continue;
            //}
            //var abilityIds = item.abilList.Split(',');
            //var abilityBuilder = new StringBuilder();

            //foreach (var Id in abilityIds)
            //{
            //    var selectedAbility = abilityDataList.Single(x => x.alias.Equals(Id));
            //    abilityBuilder.Append(selectedAbility.GenerateStringFromItem(selectedAbility.alias));
            //}
            //var itemWithAbility = item.GenerateStringFromItemWithAbility(item.itemID, abilityBuilder);
            //resultBuilder.Append(itemWithAbility);

        }
        //var resultPath = Path.GetFullPath(path + "itemdata.txt");
        //File.WriteAllText(resultPath, resultBuilder.ToString());
        //Console.WriteLine("ItemData file was generated at path - " + resultPath);
        return gameTypes;
    }
}
