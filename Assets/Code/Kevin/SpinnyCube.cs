using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnyCube : MonoBehaviour
{
    public int freqX;
    public int freqY;
    public int freqZ;
    public int x;
    public int y;
    public int z;

    void Update()
    {
        transform.Rotate(new Vector3(x, 0, 0) * Time.deltaTime * freqX);
        transform.Rotate(new Vector3(0, y, 0) * Time.deltaTime * freqY);
        transform.Rotate(new Vector3(0, 0, z) * Time.deltaTime * freqZ);
    }
}
