using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public HealthManager hm;
    public int currentCheese;
    public int currentHP;
    public TextMeshProUGUI cheeseText;
    public ThirdPersonMovement player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCheese(int cheeseToAdd)
    {
        currentCheese += cheeseToAdd;
        if (currentCheese >= 100)
        {
            currentCheese = 0;
            hm.currentLives += 1;
        }
        cheeseText.text = "Cheese: " + currentCheese + "!";
    }

    public void AddLife(int livesToAdd)
    {
        hm.currentLives += 1;
    }

    public void RemoveHP()
    {
        if (currentHP != 0)
        {
            currentHP -= 1;
            print(currentHP);
        }
        else
        {
            cheeseText.text = "Game Over!";
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        

    }
}
