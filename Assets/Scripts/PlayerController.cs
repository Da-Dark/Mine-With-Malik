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


    public TextMeshProUGUI healthText;
    //public TextMeshProUGUI storageText;


    Vector3 respawnHeight = new Vector3(15.72904f, 0.45f, -7.3093f);

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        animators = GetComponentsInChildren<Animator>();
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LevelGround"))
        {
            Debug.Log("Hi I respawned");

            transform.position = respawnHeight;

            PlayerHealth -= 1;
            healthText.text = "Health: " + PlayerHealth;

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
        if (other.gameObject.CompareTag("End"))
        {
            Debug.Log("Hi Im replaying");
            
            Vector3 startPos = new Vector3(15.72943f, 0.052f, -6.261f);
            transform.position = startPos;
            
        }
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
    public void quitGame ()
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
        //do menu screen and fix this
    }
}