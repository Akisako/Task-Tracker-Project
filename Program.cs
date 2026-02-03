using System.Text.Json;
using TaskTrackerJSON;

namespace TaskTracker
{
    internal class TaskTracker
    {
        static bool TrackerOn {get; set;}
        static List<TaskTrackerJSON.TaskTrackerData> _data = new List<TaskTrackerJSON.TaskTrackerData>();
        static void Main(string[] args)
        {   

            while(TrackerOn == false)
            {
                Console.WriteLine("___TASK TRACKER___");
                Console.Write("What do you wish to do: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "add":
                        AddTask();
                        break;
                    case "del":
                        DeleteTask();
                        break;
                    case "update":
                        UpdateTask();
                        break;
                    case "list":
                        Console.Write("do you wish to see: \n1. Tasks that are done\n2. Tasks that are not done\n3. Tasks that are in progress\n4. All tasks\nYour Reply: ");
                        var _input = Console.ReadLine();
                        ListTasks(_input);
                        break;
                    case "quit":
                        Console.WriteLine("Take care!");
                        TrackerOn = true;
                        break;
                }
            }
        }

        static void AddTask()
        {
            Console.WriteLine("What Task do you wish to add?");
            var _addedTask = Console.ReadLine();

            _data.Add(new TaskTrackerJSON.TaskTrackerData {ID = _data.Count+1, Content = _addedTask, InProgress = false, IsDone = false});

            HandleEditJson();
        }

        static void DeleteTask()
        {
            Console.Write("Please input the ID of the task you wish to delete: ");
            var _delInput = Console.ReadLine();
            int _delInput_index = Convert.ToInt32(_delInput);
            
            var _taskRemoved = _data.Find(x => x.ID == _delInput_index).Content;

            Console.WriteLine($"Removed task : {_taskRemoved}");
            _data.RemoveAt(_delInput_index-1);
        }

        static void UpdateTask()
        {
            Console.Write("Please input the ID of the task you wish to update: ");
            var _upInput = Console.ReadLine();
            int _upInput_index = Convert.ToInt32(_upInput);
            
            var _taskUpdated = _data.Find(x => x.ID == _upInput_index);

            if(_taskUpdated.InProgress == false)
            {
                _taskUpdated.InProgress = true;
                Console.WriteLine($"{_taskUpdated.Content} is now in progress!");
            }
            else if (_taskUpdated.InProgress == true)
            {
                _taskUpdated.IsDone = true;
                Console.WriteLine($"{_taskUpdated.Content} is now done!\nDo you wish to delete this task? -yes -no");

                var _taskIsDoneInput = Console.ReadLine();
                switch (_taskIsDoneInput)
                {
                    case "yes":
                        Console.WriteLine($"Removed task : {_taskUpdated}");
                        _data.RemoveAt(_upInput_index-1);
                        break;
                    case "no":
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        static void ListTasks(string _choice)
        {
            switch (_choice)
            {
                // Done Tasks
                case "1": 
                    int length_done = 0;
                    foreach (TaskTrackerData element in _data)
                    {
                        if(element.IsDone == true)
                        {
                            length_done += 1;
                        }    
                    }
                    if (length_done == 0)
                    {
                        Console.WriteLine("There are no done tasks currently.");
                        break;
                    }
                    foreach (TaskTrackerJSON.TaskTrackerData element in _data)
                    {
                        if (element.IsDone == true)
                            Console.WriteLine($"{element.ID}. {element.Content}");
                    }
                    break;

                // Not Done Tasks
                case "2":
                    int length_NotDone = 0;
                    foreach (TaskTrackerData element in _data)
                    {
                        if(element.IsDone == false)
                        {
                            length_NotDone += 1;
                        }    
                    } 
                    if (length_NotDone == 0)
                    {
                        Console.WriteLine("There are no uncomplete tasks currently.");
                        break;
                    }
                    foreach (TaskTrackerJSON.TaskTrackerData element in _data)
                    {
                        if(element.IsDone == false)
                            Console.WriteLine($"{element.ID}. {element.Content}");
                    }
                    break;

                // In progress Tasks
                case "3": 
                    int length_InProgress = 0;
                    foreach (TaskTrackerData element in _data)
                    {
                        if(element.InProgress == true)
                        {
                            length_InProgress += 1;
                        }    
                    }
                    if (length_InProgress == 0)
                    {
                        Console.WriteLine("There are no tasks in progress currently.");
                        break;
                    }
                    foreach (TaskTrackerJSON.TaskTrackerData element in _data)
                    {
                        if(element.InProgress == true)
                            Console.WriteLine($"{element.ID}. {element.Content}");
                    }
                    break;

                // All Tasks
                case "4": 
                    if (_data.Count == 0)
                    {
                        Console.WriteLine("There are no tasks currently.");
                        break;
                    }

                    foreach (TaskTrackerJSON.TaskTrackerData element in _data)
                    {
                        Console.WriteLine($"{element.ID}. {element.Content}");
                    }
                    break;
            }
        }

        static void HandleEditJson()
        {
            foreach(TaskTrackerData elem in _data)
            {
                TaskTrackerData.EditJsonData(elem);
            }

            
        }

    }
}