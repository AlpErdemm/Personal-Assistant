using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{
    public static void SaveHabits(HabitsHandler hData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/habits.bin";

        FileStream stream = new FileStream(path, FileMode.Create);

        HabitsData data = new HabitsData(hData);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static HabitsData LoadHabits()
    {
        string path = Application.persistentDataPath + "/habits.bin";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HabitsData data = formatter.Deserialize(stream) as HabitsData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File not found.");
            return null;
        }
    }

    public static void SaveTasks(TaskHandler tHandler)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/tasks.bin";

        FileStream stream = new FileStream(path, FileMode.Create);

        TasksData data = new TasksData(tHandler);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static TasksData LoadTasks()
    {
        string path = Application.persistentDataPath + "/tasks.bin";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            TasksData data = formatter.Deserialize(stream) as TasksData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File not found.");
            return null;
        }
    }
}
