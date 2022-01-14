using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlanetShapeSettings : ScriptableObject
{
    //Radius of the planet
    public float planetRadius = 1;
    //Controls the volume of vertices on each face of the unit cube
    public int resolution = 20;
    public NoiseLayer[] noiseLayers;

    //We can use the first layer as a mask for the second to make more realistic looking landmasses
    [System.Serializable]
    public class NoiseLayer{

        public bool enabled = true;
        public bool useFirstLayerAsMask; 
        public NoiseSettings noiseSettings;

    }

}
