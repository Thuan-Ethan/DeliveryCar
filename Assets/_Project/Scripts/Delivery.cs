using System;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    // Use bool to check if the tag of the other game object is "Package"
    bool hasPackage; // Default value of bool is false
    [SerializeField] float destroyDelay = 0.1f; // Delay before destroying the package

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Ough!!! It's you: " + collision.gameObject.name);
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {

        // If the tag is Pakage then print out the message to the console
        if (other.CompareTag("Package") && !hasPackage)
        {
            Debug.Log(other.gameObject.name + " was picked up!");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay); // Destroy the package after the specified delay
        }

        if (other.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("You delivered the package to: " + other.gameObject.name);
            hasPackage = false; // if the package is delivered, then set hasPackage to false
        }

        // Insted of use if statement, we can use switch statement to check the tag of the other game object
        //switch (other.tag)
        //{
        //    case "Package":
        //        Debug.Log(other.gameObject.name + "was Pick up!");
        //        break;
        //    case "Customer":
        //        Debug.Log("The package was delivered to " + other.gameObject.name);
        //        break;
        //    default:
        //        Debug.Log("You hit something else: " + other.gameObject.name);
        //        break;
        //}
        //Debug.Log("Ahhhh you ran over me!!! Yesss it's you: " + other.gameObject.name);
    }
}
