using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    public Transform ballPozition;

    
    void Update()
    {
        if (ballPozition.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, ballPozition.position.y, transform.position.z);
        }
    }
}
