using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed;

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
