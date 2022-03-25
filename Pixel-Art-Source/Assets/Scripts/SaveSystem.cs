using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    public static void SavePicture(string data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "Apple.save");
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SavePictureCoca(string data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "Coca.save");
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SavePictureMango(string data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "Mango.save");
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SavePictureCake(string data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "Cake.save");
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static string LoadPicture()
    {
        string path = Path.Combine(Application.persistentDataPath, "Apple.save");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            string data = formatter.Deserialize(stream) as string;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("File not found in" + path);
            return null;
        }
    }
    public static string LoadPictureCoca()
    {
        string path = Path.Combine(Application.persistentDataPath, "Coca.save");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            string data = formatter.Deserialize(stream) as string;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("File not found in" + path);
            return null;
        }
    }
    public static string LoadPictureMango()
    {
        string path = Path.Combine(Application.persistentDataPath, "Mango.save");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            string data = formatter.Deserialize(stream) as string;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("File not found in" + path);
            return null;
        }
    }
    public static string LoadPictureCake()
    {
        string path = Path.Combine(Application.persistentDataPath, "Cake.save");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            string data = formatter.Deserialize(stream) as string;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("File not found in" + path);
            return null;
        }
    }
}
