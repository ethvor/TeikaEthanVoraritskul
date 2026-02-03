using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject fruit;

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
    }
}
