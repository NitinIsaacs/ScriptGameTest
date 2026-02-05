using UnityEngine;
using TMPro;

public class ClickHandler : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject winScreen;
    public TMP_Text misclickText;

    [Header("Audio Clips")]
    public AudioClip successClip;
    public AudioClip failClip;

    private int misclicks = 0;

    void Update()
    {
        // left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Cast a ray into the scene from the camera
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Check if we hit the tagged "Luigi" object
                if (hit.collider.CompareTag("Luigi"))
                {
                    // Play success sound
                    AudioSource.PlayClipAtPoint(successClip, Camera.main.transform.position);

                    // Show win screen and display misclick count
                    winScreen.SetActive(true);
                    misclickText.text = "Misclicks: " + misclicks;

                    // Pause game
                    Time.timeScale = 0f;
                }
                else
                {
                    // it's a (me) miss
                    AudioSource.PlayClipAtPoint(failClip, Camera.main.transform.position);
                    misclicks++;
                }
            }
            else
            {
                // Clicked empty space also counts as a miss
                AudioSource.PlayClipAtPoint(failClip, Camera.main.transform.position);
                misclicks++;
            }
        }
    }
}