using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    public float donusHizi;
    


    void Update()
    {
        transform.Rotate(0f,0f,donusHizi);
    }
}
