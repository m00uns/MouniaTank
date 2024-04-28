using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    public static EndManager instance;
    public List<GameObject> enemyList;
    public GameObject player;
    public GameObject gameOverMenu;
    public TextMeshProUGUI endGameText;
    public bool end = false;
    
    //Singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyList.Count <= 0)
        {
            endGameText.text = "GOOD JOB SERGENT!";
            gameOverMenu.SetActive(true);
            end = true;
        }
        else if (player == null)
        {
            endGameText.text = "YOU'RE THE DUMBEST! GO BACK TO TRAINING!";
            gameOverMenu.SetActive(true);
            end = true;
        }
    }
}
