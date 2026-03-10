using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuBehavior : MonoBehaviour
{



    public void goToGame()
    {
        SceneManager.LoadScene("Scenes/TeikaGame");
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
