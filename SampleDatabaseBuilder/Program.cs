using System.Text.Json;
using UtilsLibrary;
using SampleDatabaseBuilder.Services;

Console.WriteLine("Construct file path...");
string folderPath = Path.Join(Utils.SolutionPath, "FdaNutritionData");
string inputFilePath = Path.Join(folderPath, "20_5.json");
string outputFilePath = Path.Join(folderPath, "20_5_output.json");

Console.WriteLine("Read json file and convert to target object type...");
string json = File.ReadAllText(inputFilePath);
var objects = JsonSerializer.Deserialize<RowData[]>(json);
var samples = SampleService.ConvertToSamples(objects);

Console.WriteLine("Write to database...");
using (var db = new SamplesContext())
{
    foreach (var sample in samples)
        db.Add(sample);
    db.SaveChanges();
}

// Console.WriteLine("Output json...");
// var options = new JsonSerializerOptions()
// {
//     WriteIndented = true, // Enable pretty-printing
//     Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping // Preserve Chinese characters
// };
// string outputJson = JsonSerializer.Serialize(samples, options);
// File.WriteAllText(outputFilePath, outputJson);

Console.WriteLine("Convert complete.");
