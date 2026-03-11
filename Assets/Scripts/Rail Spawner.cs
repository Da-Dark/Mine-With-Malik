using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class RailSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject goldBar;
    public GameObject heartPiece;
    private Vector3 spawnPos;

    private bool wasGap = false;

    [SerializeField]
    private float startDelay = 0;

    [SerializeField]
    private float repeatRate = 2;

    public float trackWidth = 0.2f;

    public RailTrack[] track;
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
        int randomNumber = Random.Range(0, track.Length);
        if (wasGap)
        {
            int howManyNonGaps = 0;
            int nonGapIndex = 0;
            int[] nonGapIndexes = null;

            // Run 1
            for (int i = 0; i < track.Length; i++)
                if (!track[i].IsGap) howManyNonGaps++;
            nonGapIndexes = new int[howManyNonGaps];

            // Run 2
            for (int i = 0; i < track.Length; i++)
            {
                if (!track[i].IsGap)
                {
                    nonGapIndexes[nonGapIndex] = i;
                    nonGapIndex++;
                }
            }

            randomNumber = nonGapIndexes[Random.Range(0, nonGapIndexes.Length)];
        }

        RailTrack trackIndex = track[randomNumber];
        wasGap = trackIndex.IsGap;
        GameObject index = (GameObject)Instantiate(trackIndex.RailType, transform.position, trackIndex.RailType.transform.rotation);
        index.AddComponent<MoveForward>();
        index.GetComponent<MoveForward>().doDelete = true;
        float goldOffset = trackIndex.GoldOffset;
        int randomNumberGold = Random.Range(0, 2); // How often I want the gold to spawn, currently (50%)

        if (randomNumberGold > 0)// the gold is raised with the spawned platform
        {
            GameObject goldIndex = (GameObject)Instantiate(goldBar, transform.position + new Vector3(0, goldOffset, 0), trackIndex.RailType.transform.rotation);
            goldIndex.AddComponent<MoveForward>();
            goldIndex.GetComponent<MoveForward>().doDelete = true;
        }

        transform.Translate(Vector3.right * trackWidth); // play around with value & moves the spawner down the line one its own transform position. At with of one track
    }
}
// have the smaer track the number of rails it spawns, if the number is 0 then it doesnt spawn a track
// Then should run a method that rolls again to generate a new number
//mess around eith values 
