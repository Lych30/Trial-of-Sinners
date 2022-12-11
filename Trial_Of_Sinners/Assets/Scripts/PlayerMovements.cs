using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    Transform cam;
    Vector3 direction;
    Rigidbody rb;
    [Range(0.1f,1f)]
    public float Speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        direction = (cam.position - transform.position).normalized;
        direction = new Vector3(direction.x, 0 ,direction.z);
        Vector3 DirectionToAdd = Vector3.zero;
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0 || Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            
            DirectionToAdd += direction * Input.GetAxis("Vertical") * Speed;
            Debug.Log("Up/Down");
        }
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            DirectionToAdd += Quaternion.Euler(0, -90, 0) * direction * Input.GetAxis("Horizontal") * Speed;
            Debug.Log("Left/Right");
        }
        rb.MovePosition(transform.position + DirectionToAdd);
    }
}
