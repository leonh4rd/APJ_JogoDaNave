using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Overseer : MonoBehaviour
{
    public EnemiesController enemies = null;
    public Transform globalMessageText = null;

    private int level = 0;
    private bool loading = false;

    void Start()
    {
        level = 1;
        if(enemies != null)
        {
            enemies.CreateGame(level);
        }
    }

   
    void Update()
    {
        if(enemies.Count == 0 && !loading)
        {
            if(level >= 3)
            {
                SceneManager.LoadScene("StartScene");
                //Hide in-game score text
                //Hide in-game player lifes
                //Show message of victory
                //Show total score
                //Show button to return to Menu
            }else
            {
                loading = true;
                StartCoroutine(LoadLevel()); 
            }
        }
    }

    IEnumerator LoadLevel()
    {
        globalMessageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        globalMessageText.gameObject.SetActive(false);  
        enemies.CreateGame(++level);
        loading = false;
    } 
}
