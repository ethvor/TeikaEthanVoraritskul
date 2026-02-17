using Unity.VisualScripting;
using UnityEngine;

public class TreatBehavior : MonoBehaviour
{
    public GameObject[] treats;
    public int treatType;
    private bool isMerging = false; //make so only one can merge
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        treats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().treats;
    }
    
    
    
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Treat")
        {
            int otherType = other.gameObject.GetComponent<TreatBehavior>().treatType;
            
            
            if(otherType == treatType && treatType < treats.Length -1 && !isMerging)
            {
                isMerging = true; //set self to merging
                other.gameObject.GetComponent<TreatBehavior>().isMerging = true; //set other to merging

                //get spawn position (contact point)
                Vector2 testSpawnPos = other.contacts[0].point;
                
                
                
                
                
                //create merged one
                int choice = treatType + 1;
                GameObject newTreat = Instantiate(treats[choice], testSpawnPos, Quaternion.identity);
                newTreat.GetComponent<Collider2D>().enabled = true;
                newTreat.GetComponent<Rigidbody2D>().gravityScale = 1;
                
                
                //destroy other
                Destroy(other.gameObject);
                //destroy self
                Destroy(gameObject);




            }

            
                
        }
        
    }
















    // public float timeout;
    // public float timeStart;
    //
    //
    //
    //
    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
    //     timeout = 1.5f;
    //
    // }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //     
    // }
    //
    //
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //
    //
    //     if (other.CompareTag("Deathbox"))
    //     {
    //         timeStart = Time.time;
    //     }
    //     
    //     
    //     
    //     
    //     
    //     
    //     
    // }
    //
    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     float currentTime = Time.time;
    //     float timeThusFar = currentTime - this.timeStart;
    //
    //     if (timeThusFar > timeout)
    //     {
    //         //do something
    //         print("GAME OVER");
    //     }
    //
    //     
    //
    // }
    //
    // private void OnTriggerExit2D(Collider2D other)
    // {
    //
    //     if (other.CompareTag("Deathbox"))
    //     {
    //         timeStart = 0.0f;
    //     }
    //    
    //     
    //     
    //     
    //     
    // }
    //

}
