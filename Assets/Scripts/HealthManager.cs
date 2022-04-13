using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int maxLives;
    public int currentLives;
    
    public ThirdPersonMovement player;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameoverText;

    public float invincibilityLength;
    public float invincibilityCounter;

    public Renderer playerR;

    private float flashCounter;
    public float flashLength = 0.15f;

    private bool isRespawning;
    private Vector3 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentLives = maxLives;

        respawnPoint = new Vector3(-12,1,-6);

    }

    // Update is called once per frame
    void Update()
    {
        if(invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                playerR.enabled = !playerR.enabled;

            }
            if(invincibilityCounter <= 0)
            {
                playerR.enabled = true;
            }
        }
        healthText.text = "Health: " + currentHealth;
        livesText.text = "Lives: " + currentLives;

    }

    public void Respawn()
    {
        Debug.Log("respawning player at " + respawnPoint);
        StartCoroutine(ChangePos(player));
        currentHealth = maxHealth;
        //SceneManager.LoadScene("test");
    }

    public void setRespawnPoint(Vector3 checkpoint)
    {
        respawnPoint = checkpoint;
    }

    IEnumerator ChangePos(ThirdPersonMovement player)
    {
        player.GetComponent<MeshRenderer>().enabled = false;
        player.enabled = false;

        yield return new WaitForSeconds(1);
        player.transform.position = respawnPoint;
        yield return new WaitForSeconds(0.1f);
        player.enabled = true;
        player.GetComponent<MeshRenderer>().enabled = true;
    }

    public void HurtPlayer(int damage)
    {
        if(invincibilityCounter <= 0)
        {
            currentHealth -= damage;
            
            

            if (currentHealth <= 0 && currentLives > 0)
            {
                Debug.Log("respawning player at " + respawnPoint);
                currentLives -= 1;
                Respawn();
            } 
            else if (currentHealth <= 0 && currentLives == 0) {
                Debug.Log("Out of lives");
                StartCoroutine(ReloadLevel(player));
            }
            else
            {

                print(currentHealth);

                //player.Knockback(kbdirection);

                invincibilityCounter = invincibilityLength;

                playerR.enabled = false;

                flashCounter = flashLength;
            }
        }
    }

    IEnumerator ReloadLevel(ThirdPersonMovement player)
    {
        gameoverText.text = "GAME OVER!";
        player.GetComponent<MeshRenderer>().enabled = false;
        player.enabled = false;

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
