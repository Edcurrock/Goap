using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Xml.Linq;

public class DataToExcel : MonoBehaviour
{
   
   public ItemData data;
   private void Start() 
   {
        string path =Application.persistentDataPath + "/XML/item_data.xml";
        print(path);
        UpdateDataXML(path);
      //SaveGameInfo(path);
   }

   public void SaveGameInfo(string path)
   {
       
       print(path);
       XmlSerializer serializer = new XmlSerializer(typeof(ItemData));
       using(FileStream stream = new FileStream(path, FileMode.Create))
       {
           serializer.Serialize(stream, data);
       }
   }

   private void UpdateDataXML(string path)
   {
        XDocument document = XDocument.Load(path);
        foreach (var item in data.gameInfoItems)
        {
            XElement root = new XElement("gameInfoItems");
            root.Add(new XAttribute("gameOverInfo", item.gameOverInfo));
            root.Add(new XAttribute("time", item.time));
            document.Element("ItemData").Add(root);
        }
        document.Save(path);
   }
}

[System.Serializable]
public class ItemData
{
    public List<GameInfoItem> gameInfoItems = new List<GameInfoItem>();
}

[System.Serializable]
public class GameInfoItem
{
    public string gameOverInfo;
    public string time;
}