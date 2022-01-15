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
        planet.GeneratePlanet();
    }

    //Regenerate the planet 60 times per second (Will most likely change in the future)
    void FixedUpdate() {

       // planet.GeneratePlanet();
        
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
    
}
