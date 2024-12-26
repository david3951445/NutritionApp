using System.Text.Json;
using UtilsLibrary;
using SampleDatabaseBuilder.Services;

Console.WriteLine("Construct file path...");
string folderPath = Path.Join(Utils.SolutionPath, "FdaNutritionData");
string inputFilePath = Path.Join(folderPath, "20_5.json");

Console.WriteLine("Read data from json file...");
string json = File.ReadAllText(inputFilePath);
var rowDatas = JsonSerializer.Deserialize<RowData[]>(json);

Console.WriteLine("Start creating database...");
using (var context = new SamplesContext())
{
    // Recreate database
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    Console.WriteLine("Save to database...");
    // Create1(context, rowDatas);
    Create2(context, rowDatas);
}

// Console.WriteLine("Output json...");
// JsonSerializerOptions options = new()
// {
//     WriteIndented = true, // Enable pretty-printing
//     Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping // Preserve Chinese characters
// };
// string outputFilePathA0100101 = Path.Join(folderPath, "20_5_A0100101.json");
// var A0100101 = rowDatas.Where(x => x.整合編號 == "A0100101");
// string outputJson = JsonSerializer.Serialize(A0100101, options);
// File.WriteAllText(outputFilePathA0100101, outputJson);
// string outputFilePath = Path.Join(folderPath, "20_5_output.json");
// string outputJson = JsonSerializer.Serialize(samples, options);
// File.WriteAllText(outputFilePath, outputJson);

Console.WriteLine("Convert complete.");

void Create2(SamplesContext context, IEnumerable<RowData> rowDatas)
{
    AnalysisItemCatagoryInfo[] analysisItemCatagoryInfos =
        (from row in rowDatas.GroupBy(x => x.整合編號).First()
         group row by row.分析項分類 into grouped
         select new AnalysisItemCatagoryInfo
         {
             Name = grouped.Key,
             AnalysisItemInfos =
                 (from catagoryRow in grouped
                  select new AnalysisItemInfo
                  {
                      Name = catagoryRow.分析項,
                      Unit = EnumExtensions.ParseOrDefault<Unit>(catagoryRow.含量單位),
                      DisplayOrder = GetAnalysisItemInfoDisplayOrder(catagoryRow)
                  })
                  .OrderBy(ii => ii.DisplayOrder)
                  .ToArray(),
            DisplayOrder = GetAnalysisItemCatagoryInfoDisplayOrder(grouped.First())
         })
         .OrderBy(ci => ci.DisplayOrder)
         .ToArray();

    context.AnalysisItemCatagoryInfos.AddRange(analysisItemCatagoryInfos);
    context.SaveChanges();

    FoodCatagory[] foodCatagory =
        (from row in rowDatas
         group row by row.食品分類 into grouped
         let first = grouped.First()
         select new FoodCatagory
         {
             Id = first.整合編號[..1],
             Name = first.食品分類,
         }).ToArray();

    context.FoodCatagories.AddRange(foodCatagory);
    context.SaveChanges();

    Sample[] samples =
        (from row in rowDatas
         group row by row.整合編號 into grouped
         let first = grouped.First()
         select new Sample
         {
             Id = grouped.Key,
             Name = first.樣品名稱,
             CommonName = first.俗名,
             EnglishName = first.樣品英文名稱,
             ContentDescription = first.內容物描述,
             FoodCatagory = foodCatagory.First(x => x.Name == first.食品分類),
             AnalysisItems =
                 (from sampleRow in grouped
                  select new AnalysisItem
                  {
                      Value = sampleRow.每100克含量,
                      AnalysisItemInfo = analysisItemCatagoryInfos
                         .First(x => x.Name == sampleRow.分析項分類).AnalysisItemInfos
                         .First(info => info.Name == sampleRow.分析項),
                      SampleId = grouped.Key
                  }).ToArray()
         }).ToArray();

    context.Samples.AddRange(samples);
    context.SaveChanges();
}

int GetAnalysisItemInfoDisplayOrder(RowData row)
{
    string[] names = DbGlossary.ItemCatagory.GetSubItems(row.分析項分類);
    int index = Array.IndexOf(names, row.分析項);
    return index == -1 ? names.Length : index;
}

int GetAnalysisItemCatagoryInfoDisplayOrder(RowData row)
{
    string[] names = DbGlossary.ItemCatagory.OrderedNames;
    int index = Array.IndexOf(names, row.分析項分類);
    return index == -1 ? names.Length : index;
}

// void CreateAnalysisItems()
// {
// AnalysisItemInfo[] generalIngredients =
// {
//     new() { Name = "熱量", Unit = Unit.kcal },
//     new() { Name = "修正熱量", Unit = Unit.kcal },
//     new() { Name = "水分", Unit = Unit.g },
//     new() { Name = "粗蛋白", Unit = Unit.g },
//     new() { Name = "粗脂肪", Unit = Unit.g },
//     new() { Name = "飽和脂肪", Unit = Unit.g },
//     new() { Name = "灰分", Unit = Unit.g },
//     new() { Name = "總碳水化合物", Unit = Unit.g },
//     new() { Name = "膳食纖維", Unit = Unit.g },
// };
// AnalysisItemInfo[] sugarAnalysis =
// {
//     new() { Name = "糖質總量", Unit = Unit.g },
//     new() { Name = "葡萄糖", Unit = Unit.g },
//     new() { Name = "果糖", Unit = Unit.g },
//     new() { Name = "半乳糖", Unit = Unit.g },
//     new() { Name = "麥芽糖", Unit = Unit.g },
//     new() { Name = "蔗糖", Unit = Unit.g },
//     new() { Name = "乳糖", Unit = Unit.g },
// };
// ...