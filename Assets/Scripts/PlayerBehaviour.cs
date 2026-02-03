using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject treat;
    private GameObject currentTreat;
    public GameObject[] treats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        

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
        transform.position = newPosition;

        if (currentTreat != null) {
            Vector3 treatOffset = new Vector3(0f, -1f, 0f);
            currentTreat.transform.position = transform.position + treatOffset;
            //currentTreat.GetComponent<PolygonCollider2D>().enabled = false;
            currentTreat.GetComponent<Rigidbody2D>().gravityScale = 0f;
        } else
        {
            int choice = Random.Range(0, treats.Length);
            currentTreat = Instantiate(treats[choice], transform.position, Quaternion.identity);
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            currentTreat.GetComponent<Rigidbody2D>().gravityScale = 1f;
            currentTreat.GetComponent<Collider2D>().enabled = true;
            currentTreat = null;
        }
    }
}
