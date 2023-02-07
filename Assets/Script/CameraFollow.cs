using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 posOffset;

    void Update()
    {
        transform.position = player.transform.position + posOffset;
    }
}
