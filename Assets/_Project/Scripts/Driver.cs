using UnityEngine; 
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    // Set the speed of the car's steering and movement
    [SerializeField] float steerSpeed = .5f;
    [SerializeField] float moveSpeed = .05f;

    // Update is called once per frame
    void Update()
    {
        float steer = 0f;
        float move = 0f;

        // Use the new Input System to check for keyboard input and steer the car left or right and Forward, Backward
        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
            Debug.Log("Steering Left");
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
            Debug.Log("Steering Right");
        }
        else if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
            Debug.Log("Moving Forward");
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
            Debug.Log("Moving Backward");
        }

        float steerAmount = steer * steerSpeed * Time.deltaTime;
        float moveAmount = move * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0f, moveAmount, 0);
    }
}
