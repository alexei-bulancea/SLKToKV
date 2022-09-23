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

    static void Main()
    {
        string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var path = Path.Combine(sCurrentDirectory, @"..\..\..\TestData\");


        var itemDescription = ReadAllItemDescription(path);
        var itemAbilityDescription = ReadItemAbilityDescription(path);
        var itemWithAbilities= ReadAllITems(path);

        var itemList = itemWithAbilities.Item1;
        var abilityList = itemWithAbilities.Item2;

        var itemResult = new List<FullItemData>();
        foreach (var item in itemDescription)
        {
            var currentItem = itemList.FirstOrDefault(x => x.itemID.Equals(item.Id));
            itemResult.Add(new FullItemData { Description = item, Stats = currentItem});
        }

        var abilitytListResult = new List<FullAbilityData>();
        var shortAbility = new List<AbilityDataShort>();
        foreach (var item in itemAbilityDescription)
        {
            var currentItem = abilityList.FirstOrDefault(x => x.alias.Equals(item.Id));
            abilitytListResult.Add(new FullAbilityData { Description = item, Stats = currentItem });
            shortAbility.Add(new AbilityDataShort { Id = item.Id, Stat = item.Name, Value = currentItem?.GetDataValue() });
        }

        var resultBuilder = new StringBuilder();
        foreach (var item in shortAbility)
        {
            resultBuilder.AppendLine(nameof(item.Id) + "            " + item.Id);
            resultBuilder.AppendLine(nameof(item.Stat) + "            " + item.Stat);
            resultBuilder.AppendLine(nameof(item.Value) + "            " + item.Value);
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
            currentStringBuilder.AppendLine(@$"    ""ID"" ""{item.Description.Id}""" );
            currentStringBuilder.AppendLine(@$"    ""BaseClass"" ""item_datadriven""" );
            currentStringBuilder.AppendLine(@$"    ""AbilityBehavior"" ""DOTA_ABILITY_BEHAVIOR_PASSIVE""" );
            currentStringBuilder.AppendLine(@$"    ""AbilityTextureName"" ""item_helm""" );

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

            if (item.Stats != null)
            {

                var currentAbilities = item.Stats.abilList.Split(',');
                foreach (var ability in currentAbilities)
                {
                    var abilityInfo = shortAbility.FirstOrDefault(x => x.Id.Equals(ability));
                    if (abilityInfo == null)
                        continue;
                    currentStringBuilder.AppendLine("//" + abilityInfo.Id + "             " + abilityInfo.Stat + "               " + abilityInfo.Value);

                }
            }

            currentStringBuilder.AppendLine();
                currentStringBuilder.AppendLine("               }");
                currentStringBuilder.AppendLine("        }");
                currentStringBuilder.AppendLine("    }");

                currentStringBuilder.AppendLine("}");
            itemStringBuilderResult.Append(currentStringBuilder.ToString());
        }
        var resultPath = Path.GetFullPath(path + "ItemResultData.txt");
        File.WriteAllText(resultPath, itemStringBuilderResult.ToString());
        Console.WriteLine("ItemResultData file was generated at path - " + resultPath);

        // var abilitytListResult = new List<FullAbilityData>();
        // var shortAbility = new List<AbilityDataShort>();
        // foreach (var item in itemAbilityDescription)
        // {
        //     var currentItem = abilityList.FirstOrDefault(x => x.alias.Equals(item.Id));
        //     abilitytListResult.Add(new FullAbilityData { Description = item, Stats = currentItem });
        //     shortAbility.Add(new AbilityDataShort { Id = item.Id, Stat = item.Name, Value = currentItem?.GetDataValue()});
        // }
        //var rrr =  abilitytListResult.Where(x => x.Description != null).ToList();

        // var resultBuilder = new StringBuilder();
        // foreach (var item in shortAbility)
        // {
        //     resultBuilder.AppendLine(nameof(item.Id) + "            " + item.Id );
        //     resultBuilder.AppendLine(nameof(item.Stat) + "            " + item.Stat);
        //     resultBuilder.AppendLine(nameof(item.Value) + "            " + item.Value);
        // }
        // File.WriteAllText((Path.GetFullPath(path + "abilityItemData.txt"), resultBuilder.ToString());

        Console.WriteLine("TErminated");
       // Console.ReadLine();
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
    public static List<ItemString> ReadAllItemDescription(string path)
    {
        var file = File.ReadAllLines(Path.GetFullPath(path + "ItemStrings.txt"));

        var itemList = new List<ItemString>();

        ItemString currentItem = null;
        var lengthCounter = 0;
        for (int i = 0; i < file.Length; i++)
        {
            var currentValue = file[i];
            if (currentValue.StartsWith("["))
            {
                currentItem = new ItemString();
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
        return itemList;
    }

    public static List<ItemString> ReadItemAbilityDescription(string path)
    {
        var file = File.ReadAllLines(Path.GetFullPath(path + "ItemAbilityStrings.txt"));

        var itemList = new List<ItemString>();

        ItemString currentItem = null;
        for (int i = 0; i < file.Length; i++)
        {
            var currentValue = file[i];
            if (currentValue.StartsWith("["))
            {
                currentItem = new ItemString();
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

    public static Tuple<List<ItemData>, List<AbilityData>> ReadAllITems(string path)
    {
        var abilityDataList = new List<AbilityData>();
        var itemDataList = new List<ItemData>();
        var fileList = new List<string> { "abilitydata.slk", "itemdata.slk" };
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
                    case "abilitydata.slk": abilityDataList.Add(new AbilityData(relatedLines.KeyValue)); break;
                    case "itemdata.slk": itemDataList.Add(new ItemData(relatedLines.KeyValue)); break;
                    default:
                        break;
                }

            }

        }
        var resultBuilder = new StringBuilder();
        foreach (var item in itemDataList)
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
        var resultPath = Path.GetFullPath(path + "itemdata.txt");
        File.WriteAllText(resultPath, resultBuilder.ToString());
        Console.WriteLine("ItemData file was generated at path - " + resultPath);
        return new Tuple<List<ItemData>, List<AbilityData>>(itemDataList, abilityDataList);
    }
}
