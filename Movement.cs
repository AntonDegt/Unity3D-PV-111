using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 1f;
    public float sensetivity = 1f;
    public int lookXLimit = 80;

    private float rotationX = 0;

    private void Update()
    {
        rb.transform.Translate(
            ((rb.transform.forward * Input.GetAxis("Vertical")) +
             (rb.transform.right * Input.GetAxis("Horizontal")))
             * speed * Time.deltaTime);

        rotationX += -Input.GetAxis("Mouse Y") * sensetivity;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        rb.transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * sensetivity, 0);
    }
}
