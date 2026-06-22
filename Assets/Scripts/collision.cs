
using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{

   void OnCollisionEnter(Collision other )
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("this is our friend ");
                break;
            case "Fuel":
                Debug.Log("we got extra fuel ");
                break;
            default:
                Debug.Log("YOU are dead ");
                ReloadLevel();
                break;

                
        }
        void ReloadLevel()
        {   int activescene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(activescene);
        }
        
    }
}
