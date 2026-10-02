using UnityEngine; 
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;

public class Driver : MonoBehaviour
{
    // Set the speed of the car's steering and movement
    [SerializeField] float steerSpeed = .5f;
    [SerializeField] float moveSpeed = .05f;
    [SerializeField] float boostSpeed = 10f; // Boost speed multiplier
    [SerializeField] float regularSpeed = 10f; // Regular speed multiplier
    [SerializeField] float destroyDelay = 0.1f;

    [SerializeField] TMP_Text boostText;

    void Start()
    {
        boostText.gameObject.SetActive(false); // Hide the boost text at the start
    }
    // Update is called once per frame
    void Update()
    {

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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Boost"))
        {
            Debug.Log("You picked up a boost!");
            // Implement boost logic here
            moveSpeed += boostSpeed * 0.5f; // Set the current speed to the boost speed
            boostText.gameObject.SetActive(true); // Show the boost text
            Destroy(collision.gameObject, destroyDelay); // Destroy the boost object after the specified delay    
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WorldCollision"))
        {
            // Implement obstacle logic here
            moveSpeed = regularSpeed; // Reset the speed to regular speed
            boostText.gameObject.SetActive(false); // Hide the boost text then collided to the wall
        }

    }
}
