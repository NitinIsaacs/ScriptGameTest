using UnityEngine;
using System.Collections.Generic;

public class ResetTargets : MonoBehaviour
{
    public List<GameObject> targets;  // List of targets to reset

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // On pressing 'R'
        {
            foreach (GameObject target in targets)
                target.SetActive(true); // Reactivate each target
        }
    }
}
