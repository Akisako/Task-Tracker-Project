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

            if (data.ID == 1) // will overwrite the data
                File.WriteAllText(_fileName, "["+_jsonString+"]"); 

            var file_data = ReadJsonData();
            if (file_data.ID != data.ID)
                File.AppendAllText(_fileName, ",["+_jsonString+"]");
                
            Console.WriteLine(File.ReadAllText(_fileName));
        }

        public static TaskTrackerData ReadJsonData()
        {
            string _fileName = "TaskTracker.json";
            string _jsonString = File.ReadAllText(_fileName);
            if (_jsonString.Length == 0)    
                return new TaskTrackerData(); // breaks my code lmao

            TaskTrackerData data = JsonSerializer.Deserialize<TaskTrackerData>(_jsonString)!;
            
            return data;
        }

        // TODO : 
        // - Make program read from Json file to store tasks
        // - Make program append instead of replacing data stored in Json file
    }
}
