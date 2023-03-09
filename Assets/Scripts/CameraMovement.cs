using UnityEngine;

public class CameraMovement : MonoBehaviour
{
     public GameObject player;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

}
