using UnityEngine;

public class Jump : MonoBehaviour
{
    private Vector3 touchBeganPos;
    private Rigidbody rigidbody;

    public bool isGrouded;

    public StartController startController;

    public float touchLength;
    public float maxForce;
    public float step;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); isGrouded = true;
        isGrouded = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrouded = true;
    }  
    private void OnCollisionExit(Collision collision)
    {
        isGrouded = false;
    }

    void Update()
    {
        if (!startController.isGameStart) return;

        if (Input.touchCount > 0)
        {
            touchLength += step;

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touchBeganPos = Input.GetTouch(0).position;
            }

            if (Vector3.Distance(Input.GetTouch(0).position, touchBeganPos) > 50)
            {
                touchLength = 0;
                return;
            }
            else
            {
                if (Input.GetTouch(0).phase == TouchPhase.Ended && isGrouded)
                {
                    if (touchLength < maxForce)
                    {
                        Debug.Log("Jump");
                        rigidbody.AddForce(new Vector3(0, touchLength, 0), ForceMode.Impulse);
                    }
                    else
                    {
                        rigidbody.AddForce(new Vector3(0, maxForce, 0), ForceMode.Impulse);
                    }
                    touchLength = 0;
                }
            }
        }
    }
}
