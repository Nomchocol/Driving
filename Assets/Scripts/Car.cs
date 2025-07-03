using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 20f;
    public float turnSpeed = 45f;
    private float horizontalInput;
    private float forwardInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
    }
}
