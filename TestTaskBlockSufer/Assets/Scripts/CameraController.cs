using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform character;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - character.position;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, character.position.z + offset.z);
    }
}
