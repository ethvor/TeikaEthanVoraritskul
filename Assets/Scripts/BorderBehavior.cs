using Unity.VisualScripting;
using UnityEngine;

public class BorderBehavior : MonoBehaviour
{
    public float timeout;
    public float timeStart;
    public GameObject gameOver;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeout = 1.5f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Treat"))
        {
            timeStart = Time.time;
        }
        
        
        
        
        
        
        
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Treat"))
        {
            float currentTime = Time.time;
            float timeThusFar = currentTime - this.timeStart;


            if (timeThusFar > timeout)
            {
                //do something
                gameOver.SetActive(true);
            }

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Treat"))
        {
            timeStart = Time.time;
        }
       
        
        
        
        
    }
    
    
}