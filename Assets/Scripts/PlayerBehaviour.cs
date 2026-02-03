using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject treat;

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

        if (treat != null) {
            Vector3 offset = new Vector3(0, -1.0f, 0);
            treat.transform.position = transform.position + offset;
            treat.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            treat.GetComponent<Collider2D>().enabled = false;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            treat.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            treat.GetComponent<Collider2D>().enabled = true;
            treat = null;
        }
    }
}
