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

        public static void EditJsonData(List<TaskTrackerData> data)
        {
            string _fileName = "TaskTracker.json";
            string _jsonString = JsonSerializer.Serialize(data);

            if (!File.Exists(_fileName))
                File.WriteAllText(_fileName, _jsonString);
            else
            {
                File.AppendAllText(_fileName, _jsonString);
            }
        }

        public static List<TaskTrackerData> ReadJsonData(List<TaskTrackerData> data)
        {
            string _fileName = "TaskTracker.json";
            if (!File.Exists(_fileName))
                return null;
            
            string _jsonString = File.ReadAllText(_fileName);
            var _jsonData = JsonSerializer.Deserialize<List<TaskTrackerData>>(_jsonString);

            if (_jsonData != null)
                foreach(var element in _jsonData)
                    data.Add(element);

            return data;
        }
    }
}
