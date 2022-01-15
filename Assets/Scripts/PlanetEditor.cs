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

    [SerializeField] FlexibleColorPicker m_WaterColorPicker;
    [SerializeField] FlexibleColorPicker m_SandColorPicker;
    [SerializeField] FlexibleColorPicker m_GrassColorPicker;
    [SerializeField] FlexibleColorPicker m_CloudsColorPicker;
    [SerializeField] FlexibleColorPicker m_MountainsColorPicker;

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


        //Initialise Colours picker
        m_WaterColorPicker.color = Color.blue;
        m_SandColorPicker.color = Color.yellow;
        m_GrassColorPicker.color = Color.green;
        m_CloudsColorPicker.color = Color.grey;
        m_MountainsColorPicker.color = Color.black;

    }

    //Regenerate the planet 60 times per second (Will most likely change in the future)
    void FixedUpdate() {

        planet.GeneratePlanet();
        ChangeColourGradient();
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
    
    //UI Sliders
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

    public void ChangeColourGradient()
    {
        Gradient gradient = new Gradient();
        GradientColorKey[] colorKey;
        GradientAlphaKey[] alphaKey;

        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[5];
        colorKey[0].color = m_WaterColorPicker.color;
        colorKey[0].time = 0.0f;

        colorKey[1].color = m_SandColorPicker.color;
        colorKey[1].time = 0.065f;

        colorKey[2].color = m_GrassColorPicker.color;
        colorKey[2].time = 0.115f;

        colorKey[3].color = m_CloudsColorPicker.color;
        colorKey[3].time = 0.868f;

        colorKey[4].color = m_MountainsColorPicker.color;
        colorKey[4].time = 1.0f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 1.0f;


        gradient.SetKeys(colorKey,alphaKey);

        planet.planetColorGradient = gradient;
    }

}
