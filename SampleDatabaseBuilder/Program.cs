using System.Text.Json;
using UtilsLibrary;
using SampleDatabaseBuilder.Services;

Console.WriteLine("Construct file path...");
string folderPath = Path.Join(Utils.SolutionPath, "FdaNutritionData");
string inputFilePath = Path.Join(folderPath, "20_5.json");
// string outputFilePath = Path.Join(folderPath, "20_5_output.json");

Console.WriteLine("Read json file and convert to target object type...");
string json = File.ReadAllText(inputFilePath);
var objects = JsonSerializer.Deserialize<RowData[]>(json);
var samples = SampleService.ConvertToSamples(objects);

Console.WriteLine("Write to database...");
using (var context = new SamplesContext())
{
    Console.WriteLine("Detect whether there exist duplicated samples...");
    var duplicatedSamples = samples.GroupBy(s => s.SampleId)
        .Where(g => g.Count() > 1)
        .Select(g => g.Key)
        .ToList();
    if (duplicatedSamples.Any())
    {
        Console.WriteLine("Duplicated samples exist:");
        foreach (var id in duplicatedSamples)
            Console.WriteLine(id);
        Console.WriteLine("Please clean up the database before running this program.");
        return;
    }

    foreach (var sample in samples)
        context.Add(sample);
    context.SaveChanges();
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
