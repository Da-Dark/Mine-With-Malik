using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5.0f;
    public float jumpForce = 10.0f;
    private Rigidbody playerRb;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool inShop = false;
    public int PlayerHealth = 3;
    private Animator[] animators;
    public GameObject shopScreen;
    public GameObject deathScreen;
    public GameObject damageScreen;
    public Timer timerScript; // how to call other scripts
    public GameObject goldBar;
    public int gold = 0;
    public int storage = 5;


    public TextMeshProUGUI healthText;
    public TextMeshProUGUI goldText;


    Vector3 respawnHeight = new Vector3(15.72904f, 0.45f, -7.3093f);

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        animators = GetComponentsInChildren<Animator>();

        timerScript = GameObject.Find("Canvas").GetComponent<Timer>(); // when game starts go though everything and find canvas with timer script then set the TimerScript to be what the game is looking for, when checking the canvas for a timer script
    }

    // Update is called once per frame
    void Update()
    {
        if (!inShop)
        { 
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        //  if (Input.GetKeyDown(KeyCode.Space))
        // {
        // playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        //   }
     }

   }
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.gameObject.CompareTag("LevelGround")) // where player takes damage
        {
            Debug.Log("Hi I respawned");

            transform.position = respawnHeight;

            PlayerHealth -= 1;
            healthText.text = "Health: " + PlayerHealth;
           
            damageScreen.SetActive(true); // set ouch screen to active when player takes damage
            
            StartCoroutine(DisplayDamageScreen());
           // else
           // {
              //  shopScreen.SetActive(false);
          //  }

            if (PlayerHealth == 0) 
            {
                deathScreen.SetActive(true);

                Time.timeScale = 0;
            }

        }
        if (other.gameObject.CompareTag("Shop"))
        {
            Debug.Log("Hi Im Shopping");
            inShop = true;
            shopScreen.SetActive(true);
            
            foreach (var animator in animators)
            {
                animator.SetBool("inShop", true);
            }
        }
        if (other.gameObject.CompareTag("End")) // This is where player teleports back
        {
            Debug.Log("Hi Im replaying");

            Vector3 startPos = new Vector3(15.72943f, 0.052f, -6.261f);
            transform.position = startPos;

            timerScript.timeRemaining = timerScript.levelDuration; // This will reset the timer and know that timer is running again
            timerScript.timerIsRunning = true;
        }

        if (other.gameObject.CompareTag("Gold")) // finally!!
        {
            if (gold < storage)
            {
                other.gameObject.SetActive(false); // 

                gold += 1;
            }
            else
            {
                other.gameObject.SetActive(true);

                gold += 0;
            }
          
            UpdateGold();

            
        }
      
    }
    public void UpdateGold()
    {
        goldText.text = "Gold: " + gold + " / " + storage;

    }
    public void ExitShop ()
    {
        inShop = false;
        shopScreen.SetActive(false);


        foreach (var animator in animators)
        {
            animator.SetBool("inShop", false);
        }

    }
    public void quitGame () // Use this for future games
    {
        #if UNITY_STANDALONE
        Application.Quit();
        #endif
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }

    public void RestartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        //do menu screen and fix this
    }

    public IEnumerator DisplayDamageScreen()
    {
        yield return new WaitForSeconds(1.0f); // display damagfe screen for 1 sec
        damageScreen.SetActive(false); // then turn it off
    }
}