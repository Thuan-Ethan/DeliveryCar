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

        //// Use the new Input System to check for keyboard input and steer the car left or right and Forward, Backward
        //if (Keyboard.current.aKey.isPressed)
        //{
        //    steer = 1f;
        //    //Debug.Log("Steering Left");
        //}
        //else if (Keyboard.current.dKey.isPressed)
        //{
        //    steer = -1f;
        //    //Debug.Log("Steering Right");
        //}
        //else if (Keyboard.current.wKey.isPressed)
        //{
        //    move = 1f;
        //    //Debug.Log("Moving Forward");
        //}
        //else if (Keyboard.current.sKey.isPressed)
        //{
        //    move = -1f;
        //    //Debug.Log("Moving Backward");
        //}

        var kb = Keyboard.current;
        // Check if the keyboard is not null to avoid null reference exception
        if (kb == null)
            return;

        float steerInput = (kb.aKey.isPressed ? 1f : 0f) - (kb.dKey.isPressed ? 1f : 0f);
        float moveInput = (kb.wKey.isPressed ? 1f : 0f) - (kb.sKey.isPressed ? 1f : 0f);

        float steerAmount = steerInput * steerSpeed * Time.deltaTime;
        float moveAmount = moveInput * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0f, moveAmount, 0);
    }
}
