using UnityEngine;

public class SkyCam : MonoBehaviour
{
    public Camera SkyCamera;
    public Camera PlayerCamera;

    public Transform RotatingSkybox;

    public float RotationAmount;

    void Update()
    {
        SkyCamera.gameObject.transform.rotation = PlayerCamera.gameObject.transform.rotation;

        RotationAmount -= 5 * Time.deltaTime;
        RotatingSkybox.rotation = Quaternion.Euler(new Vector3(0, RotationAmount, 0));
    }
}