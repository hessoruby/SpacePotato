using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{

    [SerializeField] InputAction Thrust;
    [SerializeField] InputAction Rotate;
    [SerializeField] float thrustvalue = 1000f;
    [SerializeField] float rotatevalue = 100f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Thrusting();
        Rotating();
    }

    void Thrusting()
    {
        if (Thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustvalue * Time.deltaTime);
        }
    }

    void Rotating()
    {
        float rotation = Rotate.ReadValue<float>();

        if (rotation > 0)
        {
            rotatingfor(-rotatevalue);
        }
        else if (rotation < 0)
        {
            rotatingfor(rotatevalue);
        }
    }

    void rotatingfor(float rotate)
    {
        transform.Rotate(Vector3.forward * Time.fixedDeltaTime * rotate);
    }

    void OnEnable()
    {
        Thrust.Enable();
        Rotate.Enable();
    }
}