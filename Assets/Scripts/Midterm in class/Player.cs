using UnityEngine;

public class Player : MonoBehaviour
{
    public bool hasGreenKey = false;   // Tracks if the player has the Green key
    public bool hasBlueKey = false;    // Tracks if the player has the Blue key
    public bool hasRedKey = false;     // Tracks if the player has the Red key

    void Update()
    {
        // Check if the player presses the 'E' key
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            // Cast a ray forward from camera to detect objects
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3f))
            {
                // Check if the raycast hit the door
                if (hit.collider.CompareTag("Door"))
                {
                    LockedDoor door = hit.collider.GetComponent<LockedDoor>(); // Get reference to the LockedDoor script

                    if (!door.isDoorLocked) // If the door isn't locked, player can open it
                    {
                        door.OpenDoor();    // Open the door
                    }
                    else // If the door is locked, check if player has the correct key
                    {
                        if ((door.keyColorRequired == KeyColor.Green && hasGreenKey) ||
                            (door.keyColorRequired == KeyColor.Blue && hasBlueKey) ||
                            (door.keyColorRequired == KeyColor.Red && hasRedKey))
                        {
                            door.OpenDoor(); // Player has the correct key, open the door
                        }
                    }
                }
            }
        }
    }
}
