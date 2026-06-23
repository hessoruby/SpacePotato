using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{

    [SerializeField] InputAction Thrust;
    [SerializeField] InputAction Rotate;
    [SerializeField] float thrustvalue = 1000f;
    [SerializeField] float rotatevalue = 100f;
    [SerializeField] AudioClip mainengine;
    [SerializeField] ParticleSystem thrustparticle;
    [SerializeField] ParticleSystem rightparticle;
    [SerializeField] ParticleSystem leftparticle;



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
        {audiosource.PlayOneShot(mainengine);
         thrustparticle.Play();}

            rb.AddRelativeForce(Vector3.up * thrustvalue * Time.deltaTime);
            
        }
        else
        {    thrustparticle.Stop();
            audiosource.Stop();
        }
    }

    void Rotating()
    {
        float rotation = Rotate.ReadValue<float>();

        if (rotation > 0)
        {
            rotatingfor(-rotatevalue);
            leftparticle.Play();
            
            
        }
        else if (rotation < 0)
        {
            rotatingfor(rotatevalue);
            rightparticle.Play();
            
        }
        else
        {rightparticle.Stop();
            leftparticle.Stop();
            
        }
    }

    void rotatingfor(float rotate)
    {   rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.fixedDeltaTime * rotate);
        rb.freezeRotation = false;

        
        
        
    }

    void OnEnable()
    {
        Thrust.Enable();
        Rotate.Enable();
    }
}