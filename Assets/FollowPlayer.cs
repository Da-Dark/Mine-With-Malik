using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, -0.559f, playerTransform.position.z);
    }
}
