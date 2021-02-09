using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveShop(ShopScrollList shopScrollList)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/shop.dat";
        FileStream stream = new FileStream(path, FileMode.Create);
        ShopData shopData = new ShopData(shopScrollList);
        formatter.Serialize(stream, shopData);
        stream.Close();
    }

    public static ShopData LoadShop()
    {
        string path = Application.persistentDataPath + "/shop.dat";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            ShopData shopData = formatter.Deserialize(stream) as ShopData;
            stream.Close();
            return shopData;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}
