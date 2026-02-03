using System.Text.Json;
using System.Text.Json.Serialization;

namespace TaskTrackerJSON
{
    public class TaskTrackerData
    {
        public int ID {get; set;}
        public string? Content {get; set;}
        public bool InProgress {get; set;}
        public bool IsDone {get; set;}


        public static void EditJsonData(TaskTrackerData data)
        {
            string _fileName = "TaskTracker.json";
            string _jsonString = JsonSerializer.Serialize(data);

            File.WriteAllText(_fileName, _jsonString);
            Console.WriteLine(File.ReadAllText(_fileName));
        }

        // TODO : 
        // - Make program read from Json file to store tasks
        // - Make program append instead of replacing data stored in Json file
    }
}