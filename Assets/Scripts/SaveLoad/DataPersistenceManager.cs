using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class DataPersistenceManager : MonoBehaviour
{


    [Header("Fild Storage Config")]
    [SerializeField] private string fileName;


    private GameData gameData;
    private FileDataHandler dataHandler;
    private List<IDataPersitence> dataPersistenceObjects;

    

    public static DataPersistenceManager instance {
        get;
        private set;
    }
    private void Awake() {
        if (instance != null) {
            Debug.LogError("Found more than one data persistence manager in the scene");
        }
        instance = this;
    }
    private void Start() {
        #if UNITY_STANDALONE_OSX
            this.dataHandler = new FileDataHandler(Application.dataPath + "/SaveFiles", fileName);
            this.dataPersistenceObjects = FindAllDataPersitenceObjects();
        #endif
        #if UNITY_STANDALONE_WIN
            this.dataHandler = new FileDataHandler(Application.dataPath + "\\SaveFiles", fileName);
            this.dataPersistenceObjects = FindAllDataPersitenceObjects();
        #endif
    }

    public void NewGame() {
        this.gameData = new GameData();
    }

    public void LoadGame() {

        if (dataHandler == null) {
            #if UNITY_STANDALONE_OSX
                this.dataHandler = new FileDataHandler(Application.dataPath + "/SaveFiles", fileName);
                this.dataPersistenceObjects = FindAllDataPersitenceObjects();
            #endif
            #if UNITY_STANDALONE_WIN
                this.dataHandler = new FileDataHandler(Application.dataPath + "\\SaveFiles", fileName);
                this.dataPersistenceObjects = FindAllDataPersitenceObjects();
            #endif
            
        }
        this.gameData = dataHandler.Load();

        if (this.gameData == null) {
            Debug.Log("No data was found. initialising to default values");
            NewGame();
        }

        foreach(IDataPersitence dataPersitenceObj in dataPersistenceObjects) {
            dataPersitenceObj.LoadData(gameData);
        }
    }

    public void SaveGame() {
        foreach (IDataPersitence dataPersitenceObj in dataPersistenceObjects) {
            dataPersitenceObj.SaveData(gameData);
        }

        dataHandler.Save(gameData);
    }

    

    public void DeleteGame() {
        dataHandler.Delete();
    }

    private List<IDataPersitence> FindAllDataPersitenceObjects() {
        IEnumerable<IDataPersitence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersitence>();
        return new List<IDataPersitence>(dataPersistenceObjects);
    }

}
