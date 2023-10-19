using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer: MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 360.0f;
    [SerializeField] private Vector3 _rotation;

    private Vector3 position;

   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayerControl();
    }

    private void MovePlayerControl()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _rotation = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.A))
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
