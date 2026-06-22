using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{

    [SerializeField] InputAction Thrust;
    [SerializeField] InputAction Rotate;
    [SerializeField] float thrustvalue = 1000f;
    [SerializeField] float rotatevalue = 100f;

    Rigidbody rb;
    AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
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
            if(!audiosource.isPlaying)
        {audiosource.Play();}

            rb.AddRelativeForce(Vector3.up * thrustvalue * Time.deltaTime);
            
        }
        else
        {
            audiosource.Stop();
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
    {    rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.fixedDeltaTime * rotate);
        rb.freezeRotation = false;

        
        
        
    }

    void OnEnable()
    {
        Thrust.Enable();
        Rotate.Enable();
    }
}