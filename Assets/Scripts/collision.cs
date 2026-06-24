
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class collision : MonoBehaviour
{
    [SerializeField] float aftercollisiondelay=2f;
    [SerializeField] AudioClip crashsound;
    [SerializeField] AudioClip wonthat;
    [SerializeField] ParticleSystem crashparticle;
    [SerializeField] ParticleSystem wonparticles;



    AudioSource audiosource;
    bool iscontrollable =false;


    private void Start() 
    {
        audiosource=GetComponent<AudioSource>();

        
    }
    void Update()
    {
        DebugRespond();
    }
    private void OnCollisionEnter(Collision other )
    {
        if (iscontrollable) { return; }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("this is our friend ");
                break;
            case "Finish":
                
                afterlevel();
                break;
            
            default:
                aftercrash();


                break;

                
        }}
    void aftercrash()
    {   
        audiosource.Stop();
        crashparticle.Play();
        audiosource.PlayOneShot(crashsound);
        Invoke("ReloadLevel",aftercollisiondelay);
        
        GetComponent<movement>().enabled = false;
        iscontrollable=true;
        
    }
    void afterlevel()
    {   
        audiosource.Stop();
        audiosource.PlayOneShot(wonthat);
        wonparticles.Play();
        Invoke("nextlevel", 2f);
        iscontrollable=true;

        GetComponent<movement>().enabled = false;
     }
    void ReloadLevel()
        {   int activescene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(activescene);
            
            


        }
    void nextlevel()
        {
            int activescene = SceneManager.GetActiveScene().buildIndex;
            int nextscene=activescene+1;
            
            if (nextscene ==SceneManager.sceneCountInBuildSettings )
            {
                nextscene=0;
            }
            SceneManager.LoadScene(nextscene);
            

        }
    void DebugRespond()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            nextlevel();
        }
    }
    }

 