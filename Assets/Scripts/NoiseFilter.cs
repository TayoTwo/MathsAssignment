using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFilter
{

    NoiseSettings noiseSettings;
    Noise noise = new Noise();

    public NoiseFilter(NoiseSettings noiseSettings){

        this.noiseSettings = noiseSettings;

    }

    public float Evaluate(Vector3 point){

        //float noiseValue = (noise.Evaluate(point * noiseSettings.roughness + noiseSettings.centre) + 1) / 2;
        float noiseValue = 0;
        float frequency = noiseSettings.bassRoughness;
        float amplitude = 1;

        for(int i = 0;i < noiseSettings.numLayers;i++){

            //Evaulate each point and appy a height based on our Noise Filter
            float v = noise.Evaluate(point * frequency + noiseSettings.centre);
            noiseValue += ((v+1)/2) * amplitude;

            //When roughness > 1 the frequency will increase with each layer
            frequency *= noiseSettings.roughness;
            //When persistance < 1 the amplitude will decrease with each layer
            amplitude *= noiseSettings.persistence;
        }

        //Flatten the planet by the minValue (makes it look as if the noise is coming out of the planet)
        noiseValue = Mathf.Max(0,noiseValue-noiseSettings.minValue);
        return noiseValue * noiseSettings.strength;

    }

}
