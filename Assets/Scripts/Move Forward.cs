using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private float leftBound = -7.93f;

    private Vector3 deletePos = new Vector3(-4.064525f, -0.1904428f, 4.973406f);
    private Vector3 initialPos;


    void Start()
    {
       initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //constantly update its own position, take your own position and add a new Vector3w
        //Delete once it reaches a specific z value

        if (transform.position.z > leftBound && gameObject.CompareTag("Cave"))
        {
            transform.position = initialPos;
        }

    }
}
