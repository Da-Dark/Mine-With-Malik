using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RepeatingBackround : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 startPos;
    public PlayerController playerControllerScript;

    [SerializeField]
    private float startDelay = 0;

    [SerializeField]
    private float repeatRate = 2;

    public float backroundWidth = 0.2f; // fix

    public GameObject backround;

    void Start()
    {
        startPos = transform.position;

        InvokeRepeating("Backround", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (!playerControllerScript.CompareTag("Shop"))
        {
            // transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        if (playerControllerScript.CompareTag("Shop"))
        {
            Destroy(gameObject);
      }
      */
    }

    private IEnumerator spawnBackround(float interval)
    {
        yield return new WaitForSeconds(interval);
        StartCoroutine(spawnBackround(interval));
    }

    void SpawnBackround()
    {
        Instantiate(backround, transform.position, backround.transform.rotation);

        Debug.Log("Backround, here!");
    }
}
// make it the same for rail as backround
