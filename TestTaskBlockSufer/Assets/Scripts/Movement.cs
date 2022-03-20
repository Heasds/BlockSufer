using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 velocity;

    public StartController startController;

    public float speed;
    public float smoothTime;
    public float minX;
    public float maxX;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        velocity = Vector3.zero;
    }
   
    void FixedUpdate()
    {
        if (!startController.isGameStart) return;

        Vector2 touchDeltaPosition = Vector2.zero;

        if (Input.touchCount > 0)
        {
            touchDeltaPosition = Input.GetTouch(0).deltaPosition * speed;
        }

        Vector3 actualPosition = rigidbody.position;
        Vector3 target = new Vector3(Mathf.Clamp(actualPosition.x + touchDeltaPosition.x, minX, maxX), transform.position.y, transform.position.z);
        rigidbody.position = Vector3.SmoothDamp(actualPosition, target + (Vector3.forward * speed) , ref velocity, smoothTime);
    }
}
