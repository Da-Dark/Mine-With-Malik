using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RailSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    
    public GameObject goldBar;
    public GameObject heartPiece;
    private Vector3 spawnPos;


    [SerializeField]
    private float startDelay = 0;

    [SerializeField]
    private float repeatRate = 2;

    public float trackWidth = 0.2f;

    public GameObject[] track;
    void Start()
    {
        spawnPos = transform.position;
        InvokeRepeating("SpawnRail", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnRail(float interval)
    {
      yield return new WaitForSeconds(interval);
      StartCoroutine(spawnRail(interval));
    }

    public void StopSpawningRails()
    {
        CancelInvoke("SpawnRail");
    }

    public void ResetAndSpawnSomeRails()
    {
        transform.position = spawnPos;
        for (int i = 0; i < 10; i++)
            SpawnRail();
        InvokeRepeating("SpawnRail", startDelay, repeatRate);
    }

    void SpawnRail()
    {
            int randomNumber = Random.Range(0, 4);


            GameObject index = (GameObject)Instantiate(track[randomNumber], transform.position, track[randomNumber].transform.rotation);
            index.AddComponent<MoveForward>();
            index.GetComponent<MoveForward>().doDelete = true;

            float goldOffset = 0.048f; // 



            int randomNumberGold = Random.Range(0, 2);




            /*  if (track[randomNumber] = 3)
              {
                  Instantiate(heartPiece, transform.position + new Vector3(0, 0.067f, 0), track[3].transform.rotation);


              }
      */


            if (randomNumber == 0)
            {
                // Instantiate(track[0], transform.position, track[0].transform.rotation);

                Debug.Log("Spawned front rail");


            }
            if (randomNumber == 1)
            {
                // Instantiate(track[1], transform.position, track[1].transform.rotation);

                Debug.Log("Spawned flat rail");

            }

            if (randomNumber == 2)
            {
                // Instantiate(track[2], transform.position, track[2].transform.rotation);

                Debug.Log("Spawned back rail");

            }
            if (randomNumber == 3)
            {
               //  Instantiate(track[3], transform.position, track[3].transform.rotation);

                goldOffset = 0.225f; //only paste if the platform raises or lowers
                Debug.Log("Spawned high rail");

            }
            if (randomNumber == 4)
            {
                // Instantiate(track[4], transform.position, track[4].transform.rotation);

                Debug.Log("Spawned hidden rail");

            }

            if (randomNumberGold > 0)// the gold is raised with the spawned platform
            {
                GameObject goldIndex = (GameObject)Instantiate(goldBar, transform.position + new Vector3(0, goldOffset, 0), track[randomNumber].transform.rotation);
                goldIndex.AddComponent<MoveForward>();
                goldIndex.GetComponent<MoveForward>().doDelete = true;
            }

            transform.Translate(Vector3.right * trackWidth); // play around with value & moves the spawner down the line one its own transform position. At with of one track
    }
}
// have the smaer track the number of rails it spawns, if the number is 0 then it doesnt spawn a track
// Then should run a method that rolls again to generate a new number
//mess around eith values 
