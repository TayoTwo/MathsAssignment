using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetEditor : MonoBehaviour
{

    public GameObject planetPrefab;
    public Planet planet;
    [SerializeField]
    public PlanetShapeSettings settings;
    public Material material;
    public Gradient planetColorGradient;
    public int textureResolution;


    void Awake(){

        //If no material is set then use the "Standard" material
        if(material == null){

            material = new Material(Shader.Find("Standard"));

        }

        //Spawn a planet 
        GameObject obj = (GameObject)Instantiate(planetPrefab,Vector3.zero,Quaternion.identity);
        planet = obj.GetComponent<Planet>();

        planet.material = material;
        planet.planetShapeSettings = settings;
        planet.planetColorGradient = planetColorGradient;
        planet.textureResolution = textureResolution;
        //planet.GeneratePlanet();
    }

    //Regenerate the planet 60 times per second (Will most likely change in the future)
    void FixedUpdate() {

        planet.GeneratePlanet();
        
    }

    //Regenerate the planet (can be used as an OnClick() method)
    public void Regenerate(){

        Destroy(planet);
        GameObject obj = (GameObject)Instantiate(planetPrefab,Vector3.zero,Quaternion.identity);
        planet = obj.GetComponent<Planet>();

        planet.material = material;
        planet.planetShapeSettings = settings;
        planet.GeneratePlanet();
        
    }
    
    public void Slider_Roughness1(float newRoughness)
    {
        planet.planetShapeSettings.noiseLayers[0].noiseSettings.roughness = newRoughness;
    }
    public void Slider_Persistence1(float newPersistence)
    {
        planet.planetShapeSettings.noiseLayers[0].noiseSettings.persistence = newPersistence;
    }

    public void Slider_MinValue1(float newMinValue)
    {
        planet.planetShapeSettings.noiseLayers[0].noiseSettings.minValue = newMinValue;
    }

    public void Slider_Roughness2(float newRoughness)
    {
        planet.planetShapeSettings.noiseLayers[1].noiseSettings.roughness = newRoughness;
    }
    public void Slider_Persistence2(float newPersistence)
    {
        planet.planetShapeSettings.noiseLayers[1].noiseSettings.persistence = newPersistence;
    }

    public void Slider_MinValue2(float newMinValue)
    {
        planet.planetShapeSettings.noiseLayers[1].noiseSettings.minValue = newMinValue;
    }


}
