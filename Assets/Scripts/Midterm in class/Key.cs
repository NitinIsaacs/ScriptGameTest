using UnityEngine;

public enum KeyColor
{
    Green,
    Blue,
    Red
}

public class Key : MonoBehaviour
{
    public KeyColor keyColor;  // Stores the color of this key

    private void Start()
    {
        // Set key material color based on keyColor variable
        if (keyColor == KeyColor.Green)
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if (keyColor == KeyColor.Blue)
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else if (keyColor == KeyColor.Red)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player is touching the touching the key
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>(); // Get reference to the player script

            // Check the color of the key and update player's key inventory accordingly
            if (keyColor == KeyColor.Green && !player.hasGreenKey)
            {
                player.hasGreenKey = true; // Player picks up green key
                Destroy(gameObject);       // Destroy the key after pickup
            }
            else if (keyColor == KeyColor.Blue && !player.hasBlueKey)
            {
                player.hasBlueKey = true;  // Player picks up blue key
                Destroy(gameObject);       // Destroy the key after pickup
            }
            else if (keyColor == KeyColor.Red && !player.hasRedKey)
            {
                player.hasRedKey = true;   // Player picks up red key
                Destroy(gameObject);       // Destroy the key after pickup
            }
        }
    }
}