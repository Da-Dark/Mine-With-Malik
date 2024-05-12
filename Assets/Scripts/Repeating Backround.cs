using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackround : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - 50)
        {
            transform.position = startPos;
        }
    }
}
// make it the same for rail as backround
