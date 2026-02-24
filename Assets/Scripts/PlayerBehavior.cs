using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject treat;
    private GameObject currentTreat;
    public GameObject[] treats;
    public float minimumXpos;
    public float maximumXpos;

    private float startTime = 0.0f;

    public int move; // used for the collider constraint in class 2/10
    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTime = 0.0f;


        move = 0; //0 means you can move both ways

    }

    // Update is called once per frame
    void Update()
    {

     
        
        
        float update = 0.0f;
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame) {
            update = -speed;
        }
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame) {
            update = speed;
        }
        Vector3 newPosition = transform.position;
        newPosition.x = transform.position.x + update;
        
        
        float hitTime = Time.time;
        
        
        if (newPosition.x < maximumXpos && newPosition.x > minimumXpos) // only transform to new if new pos is within bounds
        {
            transform.position = newPosition;
        }
       
        

        if (currentTreat != null) {
            Vector3 treatOffset = new Vector3(0f, -1f, 0f);
            currentTreat.transform.position = transform.position + treatOffset;
            //currentTreat.GetComponent<PolygonCollider2D>().enabled = false;
            currentTreat.GetComponent<Rigidbody2D>().gravityScale = 0f;
        } else
        {
            int choice = GameObject.FindGameObjectWithTag("Queue").GetComponent<QueueManager>().updateQueue();
            currentTreat = Instantiate(treats[choice], transform.position, Quaternion.identity);
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            currentTreat.GetComponent<Rigidbody2D>().gravityScale = 1f;
            currentTreat.GetComponent<Collider2D>().enabled = true;
            currentTreat = null;
        }
    }

    
    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        print("you touched" + other.gameObject.name);
        if (other.gameObject.CompareTag("LB"))
        {
            move = 1; //cannot move left
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        
    }
    */
}


