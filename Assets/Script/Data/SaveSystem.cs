// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.IO;
// using System.Runtime.Serialization.Formatters.Binary;
// using UnityEditor.Experimental.RestService;
// using UnityEditor.Experimental;

// public static class SaveSystem 
// {

//     // public static void SavePlayer (DataBase dataBase){
//     //     BinaryFormatter formatter = new BinaryFormatter();
//     //     string path = Application.persistentDataPath + "/CongaRizz";
//     //     FileStream stream = new FileStream(path, FileMode.Create);

//     //     BeanosData data = new BeanosData(dataBase);
//     //     stream.Close();
//     // } 

//     // public static BeanosData LoadPlayer(){
//     //     string path = Application.persistentDataPath + "/CongaRizz";
//     //     if(File.Exists(path)){
//     //         BinaryFormatter formatter = new BinaryFormatter();
//     //         FileStream stream = new FileStream(path, FileMode.Open);

//     //         BeanosData data = formatter.Deserialize(stream) as BeanosData;
//     //         stream.Close();
//     //         return data;
//     //     }else{
//     //         Debug.LogError("Save file was not found in" + path);
//     //         return null;
//     //     }
//     // }

// }
