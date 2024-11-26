using System.Text.Json;
using NutritionApp.Models;
using NutritionApp.Services;

Console.WriteLine("Construct file path...");
string folderPath = AppDomain.CurrentDomain.BaseDirectory;
for (int i = 0; i < 5; i++)
    folderPath = Path.GetDirectoryName(folderPath);
folderPath = Path.Combine(folderPath, "FdaNutritionData");
string inputFilePath = Path.Combine(folderPath, "20_5.json");
string outputFilePath = Path.Combine(folderPath, "20_5_output.json");

Console.WriteLine("Read json file and convert to target object type...");
string json = File.ReadAllText(inputFilePath);
var objects = JsonSerializer.Deserialize<RowData[]>(json);
var samples = Sample.ConvertToSamples(objects);

Console.WriteLine("Output json...");
var options = new JsonSerializerOptions()
{
    WriteIndented = true, // Enable pretty-printing
    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping // Preserve Chinese characters
};
string outputJson = JsonSerializer.Serialize(samples, options);
File.WriteAllText(outputFilePath, outputJson);

Console.WriteLine("Convert complete.");

// class Data
// {
//     public string 每單位重含量 { get; set; }
//     public string 整合編號 { get; set; }
//     public string 分析項分類 { get; set; }
//     public string 樣品名稱 { get; set; }
//     public string 每100克含量 { get; set; }
//     public string 每單位含量 { get; set; }
//     public string 標準差 { get; set; }
//     public string 每單位重 { get; set; }
//     public string 含量單位 { get; set; }
//     public string 樣本數 { get; set; }
//     public string 廢棄率 { get; set; }
//     public string 樣品英文名稱 { get; set; }
//     public string 資料類別 { get; set; }
//     public string 分析項 { get; set; }
//     public string 食品分類 { get; set; }
//     public string 內容物描述 { get; set; }
//     public string 俗名 { get; set; }
// }
