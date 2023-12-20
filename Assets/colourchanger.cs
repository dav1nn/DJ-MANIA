using UnityEngine;

public class colourchanger : MonoBehaviour
{
    
    void OnCollisionEnter(Collision collision)
    {
        
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
