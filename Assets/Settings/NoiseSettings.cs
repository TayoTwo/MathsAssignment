using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoiseSettings
{
    public float strength = 1;
    [Range(1,8)]
    public int numLayers = 1;
    public float bassRoughness = 1;
    //When roughness > 1 the frequency will increase with each layer
    public float roughness = 2;
    //When persistance < 1 the amplitude will decrease with each layer(i.e the height)
    public float persistence = 0.5f;
    public Vector3 centre;
    public float minValue = 1;
}
