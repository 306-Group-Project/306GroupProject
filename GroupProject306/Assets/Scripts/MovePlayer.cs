using System.Collections;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private float rotateSpeed = 360.0f;
    [SerializeField] private Vector3 _rotation;

    public Transform movePoint;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        StartCoroutine(PlayerMoveLoop());
    }

    private IEnumerator PlayerMoveLoop()
    {
        while (true)
        {
            MovePlayerControl();
            yield return new WaitForSecondsRealtime(0.006f);
        }
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
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.unscaledDeltaTime);

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                movePoint.Translate(1 * forward * moveSpeed * Time.unscaledDeltaTime); 
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                movePoint.Translate(-1 * forward * moveSpeed * Time.unscaledDeltaTime);         
            }

            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                movePoint.Translate(-1 * right * moveSpeed * Time.unscaledDeltaTime);          
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                movePoint.Translate(1 * right * moveSpeed * Time.unscaledDeltaTime);       
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
        transform.Rotate(_rotation * rotateSpeed * Time.unscaledDeltaTime);

        
    }
}
