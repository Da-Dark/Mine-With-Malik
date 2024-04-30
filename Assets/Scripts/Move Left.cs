using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private float leftBound = -4.8f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        //constantly update its own position, take your own position and add a new Vector3
        //Delete once it reaches a specific z value

        if (transform.position.z > leftBound && gameObject.CompareTag("MRail"))
        {
            Destroy(gameObject);
        }

    }
}
