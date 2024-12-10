using System.Diagnostics;
using SerializationReflectionOtus.Models;
using SerializationReflectionOtus.Serializers;

var obj = F.Get();
const int iterations = 100000; 

var stopwatch = Stopwatch.StartNew();
for (int i = 0; i < iterations; i++)
{
    var csv = CsvSerializer.Serialize(obj); 
}
stopwatch.Stop();
Console.WriteLine($"csv: \"{CsvSerializer.Serialize(obj)}\"");
Console.WriteLine($"Reflection: Serialization of {iterations} iterations took {stopwatch.ElapsedMilliseconds} ms");

string csvString = CsvSerializer.Serialize(obj);
stopwatch.Restart();
for (int i = 0; i < iterations; i++)
{
    var deserializedObj = CsvSerializer.Deserialize<F>(csvString); 
}
stopwatch.Stop();
Console.WriteLine($"Reflection: Deserialization of {iterations} iterations took {stopwatch.ElapsedMilliseconds} ms");

var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj); 
Console.WriteLine($"json: {json}");
stopwatch.Restart();
for (int i = 0; i < iterations; i++)
{
    var serializedJson = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
}
stopwatch.Stop();
Console.WriteLine($"Newtonsoft.Json: Serialization of {iterations} iterations took {stopwatch.ElapsedMilliseconds} ms");

stopwatch.Restart();
for (int i = 0; i < iterations; i++)
{
    var deserializedJson = Newtonsoft.Json.JsonConvert.DeserializeObject<F>(json); 
}
stopwatch.Stop();
Console.WriteLine($"Newtonsoft.Json: Deserialization of {iterations} iterations took {stopwatch.ElapsedMilliseconds} ms");


Console.WriteLine("----------------------------------------------");
Console.WriteLine("Student serialization:");
var student = new Student("Max", 22);
var studentCsv = CsvSerializer.Serialize(student);
Console.WriteLine(studentCsv); 