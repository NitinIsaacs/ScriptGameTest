using UnityEngine;

public class Script3 : MonoBehaviour
{
    //Public string variables, Assigned in inspector
    public string One;
    public string Two;
    public string Three;

    void Start()
    {
        //Combines all 3 strings into a sentence
        Debug.Log(One + " " + Two + " " + Three);
    }
}