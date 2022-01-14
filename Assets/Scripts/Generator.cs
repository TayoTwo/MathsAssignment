using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator
{

    PlanetShapeSettings shapeSettings;
    NoiseFilter[] noiseFilters;

    public Generator(PlanetShapeSettings shapeSettings){

        this.shapeSettings = shapeSettings;
        noiseFilters = new NoiseFilter[shapeSettings.noiseLayers.Length];

        for(int i = 0;i < noiseFilters.Length;i++){

            noiseFilters[i] = new NoiseFilter(shapeSettings.noiseLayers[i].noiseSettings);

        }

    }

    //Apply our noise layers to the points on the unit sphere
    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSqhere){

        float firstLayerValue = 0;
        float elevation = 0;

        if(noiseFilters.Length > 0){

            firstLayerValue = noiseFilters[0].Evaluate(pointOnUnitSqhere);
            if(shapeSettings.noiseLayers[0].enabled){

                elevation = firstLayerValue;

            }

        }
        
        for(int i = 1;i < noiseFilters.Length;i++){

            //If the layer is enabled load its settings
            if(shapeSettings.noiseLayers[i].enabled){

                float mask = 1;

                if(shapeSettings.noiseLayers[i].useFirstLayerAsMask){

                    mask = firstLayerValue;

                }

                elevation += noiseFilters[i].Evaluate(pointOnUnitSqhere);

            }

        }
        
        return pointOnUnitSqhere * shapeSettings.planetRadius * (1 + elevation);

    }

}
