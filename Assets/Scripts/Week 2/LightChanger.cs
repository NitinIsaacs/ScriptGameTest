using System.Runtime.CompilerServices;
using UnityEngine;

public class LightChanger : MonoBehaviour
{
    public Light lightChange;
    public Vector3 lightMover;
   // public bool yesNo = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeLightColor(Color.blue);
        lightChange.intensity = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        AdjustLight();
        Debug.Log("LIGHTOBJECT ADJUSTED");

        if(Input.GetKeyDown(KeyCode.G))
        {
            ChangeLightColor(Color.green);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            ChangeLightColor(Color.blue);
        }
        
        if(Input.GetKeyDown(KeyCode.R))
        {  
            ChangeLightColor(Color.red);
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            lightChange.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            lightChange.gameObject.SetActive(true);
        }
    }

    private void AdjustLight()
    {
        lightChange.intensity += 40f * Time.deltaTime;
    }

    public void ChangeLightColor(Color santaClaus)
    {
        lightChange.color = santaClaus;
    }
}