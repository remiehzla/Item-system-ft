using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataManager : MonoBehaviour
{
    // Singleton class; only one is wanted in the scene
    // Get the instance publicly
    // Modify it only within this class

    // This class keeps track of our game's data

    [Header("File Storage Configuration")]
    [SerializeField] private string fileName;

    private GameData gameData;

    private List<IDataManager> dataObjects;
    private FileDataHandler dataHandler;

    public static DataManager instance { get; private set; }

    // Initialize the instance
    private void Awake()
    {
        // Check for errors first
        if (instance != null)
        {
            Debug.LogError("More DPMs found in the scene.");
        }

        instance = this;
    }

    private void Start()
    {
        // Uses the standard path conforming to the OS
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        // Reference the scripts that are using the interface
        this.dataObjects = FindAllDataObjects();
        // Load the game on start-up
        LoadGame();
    }

    public void NewGame()
    {

        // Initialize the game data to be new game data object
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        // Load any saved data using the FileDataHandler
        // If null, new game is created
        this.gameData = dataHandler.Load();

        // If no data found, initialize new game 

        if (this.gameData == null)
        {
            Debug.Log("No data found. Initializing default data.");
            NewGame();
        }

        // Push the loaded data to all the other scripts
        foreach (IDataManager dataPersistanceObj in dataObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }

    }

    public void SaveGame()
    {
        // Pass the data to other scripts first,
        // so that they can update it
        foreach (IDataManager dataPersistanceObj in dataObjects)
        {
            dataPersistanceObj.SaveData(gameData);
        }

        // Save the file using the DataHandler
        dataHandler.Save(gameData);

    }

    private void OnApplicationQuit()
    {
        // Save the game each time you quit
        SaveGame();
    }

    // Find all scripts that use the data persistence interface 
    private List<IDataManager> FindAllDataObjects()
    {
        // Those scripts must also extend from MonoBehaviour
        IEnumerable<IDataManager> dataObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataManager>();

        return new List<IDataManager>(dataObjects);
    }
}
