using UnityEngine;

public class BackgroundRunner : MonoBehaviour
{
    public bool GenerateBackground = false;
    public float NextBackgroundInstance = 0;
    public float BackgroundLifespan = 10;
    public Transform MinecartTransform;
    public GameObject BackgroundRoot;
    public GameObject BackgroundPrefab;
    void Update()
    {
        if (GenerateBackground)
        {
            while (-MinecartTransform.localPosition.z >= NextBackgroundInstance)
            {
                NextBackgroundInstance += 0.9f;
                GameObject index = Instantiate(BackgroundPrefab, Vector3.zero, Quaternion.identity);
                index.transform.parent = BackgroundRoot.transform;
                index.transform.localPosition = new Vector3(0, 0, -NextBackgroundInstance);
                Destroy(index, BackgroundLifespan);
            }
        }
    }

    public void ClearBackgrounds()
    {
        foreach (Transform index in BackgroundRoot.transform)
        {
            Destroy(index.gameObject);
        }
    }
}
