using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 360.0f;
    [SerializeField] private Vector3 _rotation;

    public Transform movePoint;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayerControl();
    }

    private void MovePlayerControl()
    {

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;


        if (Vector3.Distance(transform.position, movePoint.position) <= 0.5)
        {

            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.W))
            {
                movePoint.Translate(1 * forward * moveSpeed * Time.deltaTime);
                //transform.Translate(1 * forward * moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                movePoint.Translate(-1 * forward * moveSpeed * Time.deltaTime);
                //transform.Translate(-1 * forward * moveSpeed * Time.deltaTime);
            }

            else if (Input.GetKey(KeyCode.A))
            {
                movePoint.Translate(-1 * right * moveSpeed * Time.deltaTime);
                //transform.Translate(-1 * right * moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                movePoint.Translate(1 * right * moveSpeed * Time.deltaTime);
                //transform.Translate(1 * right * moveSpeed * Time.deltaTime);
            }
        }


        if (Input.GetKey(KeyCode.Q))
        {
            _rotation = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            _rotation = Vector3.down;
        }
        else
        {
            _rotation = Vector3.zero;
        }
        transform.Rotate(_rotation * rotateSpeed * Time.deltaTime);
    }
}
