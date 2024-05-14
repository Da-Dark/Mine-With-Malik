using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RailSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    
    public GameObject goldBar;
    public GameObject heartPiece;


    [SerializeField]
    private float startDelay = 0;

    [SerializeField]
    private float repeatRate = 2;

    public float trackWidth = 0.2f;

    public GameObject[] track;
    void Start()
    {
        InvokeRepeating("SpawnRail", startDelay, repeatRate);
       // trackIndex = Random.Range(trackIndexMin, trackIndexMax);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
  private IEnumerator spawnRail(float interval)
   {
      yield return new WaitForSeconds(interval);
    // GameObject newRail = Instantiate(railPrefab, new Vector3(0,0,0), Quaternion.identity);
      StartCoroutine(spawnRail(interval));
    }
    void SpawnRail()
    {
        int randomNumber = Random.Range(0, 4);
        Instantiate(track[randomNumber], transform.position, track[randomNumber].transform.rotation);

        int randomNumberGold = Random.Range(0, 2);

        if (randomNumberGold > 0)
        {
            Instantiate(goldBar, transform.position + new Vector3 (0, 0.048f, 0), track[randomNumber].transform.rotation);
            
        }

      /*  if (track[randomNumber] = 3)
        {
            Instantiate(heartPiece, transform.position + new Vector3(0, 0.067f, 0), track[3].transform.rotation);


        }

        /*





        /* if (trackIndex > 1)
        {
            Instantiate(railPrefab, transform.position, railPrefab.transform.rotation);
            trackIndex--;
            Debug.Log("Spawned rail");

        }
        else if (trackIndex == 1)
        {
            Instantiate(backBrokenRailPrefab, transform.position, railPrefab.transform.rotation);
            trackIndex--;
            Debug.Log("Spawned back broken rail");

        }
        else if (trackIndex == 2 || trackIndex == 3)
        {
            Instantiate(slantRailPrefab, transform.position, railPrefab.transform.rotation);
            trackIndex--;
            Debug.Log("Spawned slant rail");

        }
        else
        {
            transform.Translate(Vector3.right * trackWidth);

            trackIndex = Random.Range(trackIndexMin, trackIndexMax);
            Instantiate(frontBrokenRailPrefab, transform.position, railPrefab.transform.rotation);
            trackIndex--;
            Debug.Log("Spawned front broken rail");

        }
*/
        transform.Translate(Vector3.right * trackWidth); // play around with value & moves the spawner down the line one its own transform position. At with of one track
    }

    
}
// have the smaer track the number of rails it spawns, if the number is 0 then it doesnt spawn a track
// Then should run a method that rolls again to generate a new number
//mess around eith values 
