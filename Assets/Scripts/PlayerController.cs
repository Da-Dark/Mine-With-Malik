using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Main Functions")]
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
    public Shop shopScipt;


    public TextMeshProUGUI healthText;
    public TextMeshProUGUI goldText;

    [Header("Extras")]
    public MoveForward[] backdropItems;

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
            // playerRb.velocity = (((Vector3.forward*-1) * Time.deltaTime * speed)*playerRb.mass) + new Vector3(0, playerRb.velocity.y, 0);

            if (playerRb.velocity.y > 0)
                isOnGround = false;

            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
               playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }
        
        }
        if (deathScreen.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.R))
                RestartGame();
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


            if (PlayerHealth <= 0)
            {
                deathScreen.SetActive(true);

                Time.timeScale = 0;
            }
            else
            {
                foreach (MoveForward backdropItem in backdropItems)
                {
                    backdropItem.ResetPosition();
                }
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

            GameObject[] excessRails = GameObject.FindGameObjectsWithTag("Rail");
            GameObject[] excessGold = GameObject.FindGameObjectsWithTag("Gold");
            foreach (GameObject railItem in excessRails)
                Destroy(railItem);
            foreach (GameObject goldItem in excessGold)
                Destroy(goldItem);
            GameObject.FindWithTag("RailSpawner").GetComponent<RailSpawner>().ResetAndSpawnSomeRails();
            foreach (MoveForward backdropItem in backdropItems)
                backdropItem.ResetPosition();
        }

        if (other.gameObject.CompareTag("Gold")) // finally!!
        {
            if (gold < storage)
            {
                Destroy(other.gameObject);

                gold += 1;
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
    public void RemoveGold(int amount)
    {
        gold -= amount;
    }
    public void AddHearts(int amount)
    {
        PlayerHealth += amount;
    }
    public int CompareGold()
    {
        return gold;
    }
}