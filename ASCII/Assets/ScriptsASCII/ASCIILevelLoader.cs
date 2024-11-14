using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ASCIILevelLoader : MonoBehaviour
{
    //load a level based off a text file

    //Variables 

    //offsets for positions in the level 
    public float xOffset;
    public float yOffset;

    //prefabs for the game objects we want in the scene 
    public GameObject player;
    public GameObject wall;
    public GameObject obstacle;
    public GameObject goal;

    //variable for the current player 
    public GameObject currentPlayer;

    //Variables for the starting position of our player 
    Vector2 startPos;

    //name for the level file 
    public string fileName;

    //Variable for our current level number 
    public int currentLevel = 0;

    //empy game object to hold our level
    public GameObject level;

    //when the level changes we want to load that level 
    //also make current level a property 
    public int CurrentLevel 
    {
        get { return  currentLevel; }
        set 
        { 
            currentLevel = value;
            LoadLevel();
        }
    }

    //start is called before the first frame update 
    private void Start()
    {
        LoadLevel();
    }

    //Load a level based on a ASCII text file 
    void LoadLevel()
    {
        //destroy the current level 
        Destroy(level);

        //create a new level gameobject 
        level = new GameObject("Level");

        //build a new level path based on the currentlevel 
        string current_file_path = Application.dataPath + "/Resources/" + fileName.Replace("Num", currentLevel + "");

        //pull the contents of that file into a string array 
        //each line of the file will be an item in the array
        string[] fileLines = File.ReadAllLines(current_file_path);

        //loop through each line in the file
        for (int y = 0; y < fileLines.Length; y++)
        { 
            //get the current line 
            string lineText = fileLines[y];

            //split the line into a char array 
            char[] characters = lineText.ToCharArray();

            //loop through each character in the array we just made 
            for (int x = 0; x < characters.Length; x++) 
            {
                //take the current character 
                char c = characters[x];

                //variable for the new Object 
                GameObject newObject;

                //write a switch statement for the character to determine what it means 
                switch(c) 
                {
                    //check if the character is the letter p and make that my player
                    case 'p': //checks if its p
                        //make a player gameObject
                        newObject = Instantiate<GameObject>(player);
                        //check to seeif we have a player already and if we do not, make this the player 
                        if(currentPlayer = null)
                            currentPlayer = newObject;
                        //save this position to the startPos to use for resetting the player
                        startPos = new Vector2(x + xOffset, -y + yOffset);
                        break;
                    //write a case where if the character is w we make a wall
                    case 'w': //checks if its w
                        //make a wall 
                        newObject = Instantiate<GameObject>(wall);
                        break;
                    //write a case if the character is an * make an obstacle 
                    case '*': //checks if its *
                        newObject = Instantiate<GameObject>(obstacle);
                        break;
                    //write a case if the character is an & make a goal 
                    case '&': //checks if its &
                        newObject = Instantiate<GameObject>(goal);
                        break;
                    //if it is any other character go to default and leave the space blank
                    default:
                        newObject = null;
                        break;
                }

                //take the new object and check if its null 
                if(newObject != null ) 
                {
                    //check if its a player 
                    if (!newObject.name.Contains("Player"))
                    {
                        //make the level gameobject the parent of new object
                        newObject.transform.parent = level.transform;
                    }

                    //no matter what the new object is set its position based on the offsets
                    //and also the position in the file 
                    newObject.transform.position = new Vector3(x + xOffset, -y + yOffset, 0);
                }
            }
           
        }

    }
}
