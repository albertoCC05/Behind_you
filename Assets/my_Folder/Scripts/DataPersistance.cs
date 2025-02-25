using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public static class DataPersistance 
{  
    public static bool level1 = false;
    public static bool level2 = false;
   

    private const string SAVE_FILE_NAME = "/save-file.txt";
    private const string SAVE_MUSIC_FILE = "/save-musicValue.txt";
    public static bool saveFileExist;

    public static float musicValue;
    public static float fxValue;

    // I made two functions of save and load, one saves the progres of the player, and the other saves the value of music and sound efects
    
  
    public static void Save()
    {
        SaveObject saveObject = new SaveObject
        {
            level1Completed = level1,
            level2Completed = level2,
           
        };

        string jsonContent = JsonUtility.ToJson(saveObject);

        System.IO.File.WriteAllText(Application.dataPath + SAVE_FILE_NAME,  jsonContent);

        saveFileExist = true;
    }
    public static void Load()
    {
        if (System.IO.File.Exists(Application.dataPath + SAVE_FILE_NAME))
        {
            string jsonContent = System.IO.File.ReadAllText(Application.dataPath + SAVE_FILE_NAME);

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(jsonContent);

            level1 = saveObject.level1Completed;
            level2 = saveObject.level2Completed;

            saveFileExist = true;
        }
    }
    public static void SaveMusic(float musicVolume, float fxVolume)
    {
        musicValue = musicVolume;
        fxValue = fxVolume;

        SaveObjectMusic saveMusic = new SaveObjectMusic
        {
            music = musicValue,
            fx = fxValue,
        };

        string jsonMusicContent = JsonUtility.ToJson(saveMusic);

        Debug.Log($"guardado: {jsonMusicContent}");

        System.IO.File.WriteAllText(Application.dataPath + SAVE_MUSIC_FILE, jsonMusicContent);

 
    }
    public static void LoadMusic()
    {
        if (System.IO.File.Exists(Application.dataPath + SAVE_MUSIC_FILE))
        {
            string jsonMusicContent = System.IO.File.ReadAllText(Application.dataPath + SAVE_MUSIC_FILE);

            Debug.Log($"cargado: {jsonMusicContent}");

            SaveObjectMusic saveMusic = JsonUtility.FromJson<SaveObjectMusic>(jsonMusicContent);

            musicValue = saveMusic.music;
            fxValue = saveMusic.fx;

        }
    }
    public static void DeleteSaveFiles()
    {
        if (System.IO.File.Exists(Application.dataPath + SAVE_FILE_NAME))
        {
            Debug.Log("Datos Borrados");
            DataPersistance.level1 = false;
            DataPersistance.level2 = false;
            System.IO.File.Delete(Application.dataPath + SAVE_FILE_NAME);
            saveFileExist = false;
        }
    }
}