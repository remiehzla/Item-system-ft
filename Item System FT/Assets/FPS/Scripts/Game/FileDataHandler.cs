using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    // Where we save the data on the computer
    private string dataDirPath = "";

    // Name of the file that we want to save
    private string dataFileName = "";

    // Take the values and set them
    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    // Return a game data object
    public GameData Load()
    {  
        // Path.Combine used to work on different OS's
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        // Check if the file exists first
        if (File.Exists(fullPath))
        {
            try
            {
                // Load the serialized data
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                // Deserialize data from JSON -> GAME OBJ DATA
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);

            }
            catch (Exception e)
            {
                Debug.LogError("ERROR: Could not load file: " + fullPath + "\n" + e);
            }
        }

        return loadedData;
    }

    // Save a game data object
    public void Save(GameData data)
    {
        // Needs a full path, including the file name
        // Path.Combine used to work on different OS's
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        //Use Try Catch in case an error appears
        try
        {
            // Create the directory path the file will be written to
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            // Serialize the data into a JSON string
            string dataToStore = JsonUtility.ToJson(data, true);

            // Write the file into the file system
            // Using() blocks are very useful here, as they assure that the connection
            // to the file is closed once we're done reading/writing to it
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                // We want to write on that file
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    //Pass the data that we want to write
                    writer.Write(dataToStore);
                }
            }

        }
        catch (Exception e)
        {
            // Shows the error in the console in case there is one
            Debug.LogError("ERROR: Couldn't save data file:" + fullPath + "\n" + e);
        }
    }
}
