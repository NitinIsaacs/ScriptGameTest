using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public KeyColor keyColorRequired;           // Color of the key
    public Transform doorFinalPosition;         // Final position of the door
    public bool isDoorLocked = true;            // If true, the player has the key
    private bool hasBeenOpened = false;         // Tracks if door has already been opened

    private void Start()
    {
        // Set door material color based on required key color
        if (keyColorRequired == KeyColor.Green)
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if (keyColorRequired == KeyColor.Blue)
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else if (keyColorRequired == KeyColor.Red)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    public void OpenDoor()
    {
        if (!hasBeenOpened)  // Check if the door hasn't been opened yet
        {
            transform.position = doorFinalPosition.position;  // Move the door to open position
            hasBeenOpened = true;                             // Mark the door as opened
        }
        else
        {
            // Play the audio indicating door is already open
            AudioSource audio = GetComponent<AudioSource>();
            if (audio != null)
            {
                audio.Play();
            }
        }
    }
}