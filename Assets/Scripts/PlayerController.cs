using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Required for scene management


public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    public int health = 5;
    private int score = 0;
    // Set the score to 0
    public Text scoreText;
    // New public Text scoreText variable
    public Text healthText;
    // New public Text healthText variable
    public Text winLoseText;
    //New public Text winloseText variable
    public Image winLoseTextBackground;
    public Image winLoseBG;

    void Start()
    {
           SetScoreText();
           SetHealthText();
        // Call the method to update the UI
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
    void Update()
    {
          // Check if health is zero
        if (health == 0)
        {
            //Lose the game
            winLoseText.text = "Game Over";
            winLoseText.color = Color.white;
            winLoseTextBackground.color = Color.red;
            // Activer WinLoseBG
            winLoseBG.gameObject.SetActive(true);

            StartCoroutine(LoadScene(3));
            //call the coroutine
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false); // Disable the object
            score = score + 1;
            SetScoreText(); // Update the score text
            // OR
            // Destroy(other.gameObject); // Destroy the object
        }

         // Check if the player collides with an object tagged as "Trap"
        if (other.gameObject.CompareTag("Trap"))
        {
            // Decrement the player's health
            health = health -1;
            SetHealthText();
        }

        if(other.gameObject.CompareTag("Goal"))
        {
            //win the game
            winLoseText.text = "You Win !";
            winLoseText.color = Color.black;
            winLoseTextBackground.color = Color.green;
            // Activer WinLoseBG
            winLoseBG.gameObject.SetActive(true);

            StartCoroutine(LoadScene(3));
            //call the coroutine
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
        // Update the ScoreText object with the Player's current score
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + health;
        // Update the HealthText object with the Player's current health point
    }

    private IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // recharge the scene
    }
}
