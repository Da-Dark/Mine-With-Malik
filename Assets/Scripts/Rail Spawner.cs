using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject railPrefab;

    [SerializeField]
    private float railInterval = 3.5f;
    
   // [SerializeField]
   // private Vector3 spawnPos = new Vector3(15.72904f, 3.5f, -7.3093f);

    [SerializeField]
    private float startDelay = 0;

    [SerializeField]
    private float repeatRate = 2;

    [SerializeField]
    private int trackIndex = 5;

    [SerializeField]
    private int trackIndexMin = 3;

    [SerializeField]
    private int trackIndexMax = 6;
    void Start()
    {
        InvokeRepeating("SpawnRail", startDelay, repeatRate);
        trackIndex = Random.Range(trackIndexMin, trackIndexMax);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
  //private IEnumerator spawnRail(float interval, GameObject enemy)
   // {
      //yield return new WaitForSeconds(interval);
 //     GameObject newRail = Instantiate(railPrefab, new Vector3(0,0,0), Quaternion.identity);
      //StartCoroutine(spawnRail(interval, newRail));
   // }
    void SpawnRail()
    {
        if (trackIndex > 0)
        {
            Instantiate(railPrefab, transform.position, railPrefab.transform.rotation);
            trackIndex--;
        }
        else
        {
            trackIndex = Random.Range(trackIndexMin, trackIndexMax);
        }
    }
}
// have the smaer track the number of rails it spawns, if the number is 0 then it doesnt spawn a track
// Then should run a method that rolls again to generate a new number
//mess around eith values 
