using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform target;

    Vector3 offset;


    void Start()
    {
        offset = target.position - transform.position;
    }

    void LateUpdate()
    {
        transform.position = target.position - offset;
    }
}
