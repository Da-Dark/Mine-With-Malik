using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform destination;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Teleport(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        Physics.SyncTransforms();
       // look.x = rotation.eulerAngles.x;
       // look.y = rotation.eulerAngles.y;
    }
    //private void OnTriggerEnter(Collider other)
   // {
    //    if (other.CompareTag ("Player") && other.TryGetComponent<Player>(out var player))
      //  {
      //      player.Teleport(destination.position, destination.rotation);
      //  }
  //  }
  //Once you finish the level, take the players position and move it to shop area
  //have game track when the level ends, then update the players position to be at the cave exit
}
