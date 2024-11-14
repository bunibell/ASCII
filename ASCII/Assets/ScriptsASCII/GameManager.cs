using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Variables 
    public static GameManager Instance;
    
    //singleton
    private void Awake()
    {
        if (Instance == null)
        { 
        DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
