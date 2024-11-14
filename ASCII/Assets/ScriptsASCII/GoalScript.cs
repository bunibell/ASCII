using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    //on collision with the player make the next level
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //increase the currentlevel property
        GameManager.Instance.GetComponent<ASCIILevelLoader>().CurrentLevel++;
    }
}
