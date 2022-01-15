using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    [Range(2,256)]
    public PlanetShapeSettings planetShapeSettings;
    public Material material;
    public Gradient planetColorGradient;
    public int textureResolution;
    Generator generator;
    MeshFilter[] meshFilters;
    Face[] faces;

    void Initialize(){

        generator = new Generator(planetShapeSettings);

        //If we have generated no faces yet then make a new array of mesh filters
        if(meshFilters == null || meshFilters.Length == 0){

            meshFilters = new MeshFilter[6];

        }

        faces = new Face[6];
        //Array that stores the 6 directions of the 6 faces of our cube
        Vector3[] directions = {Vector3.up,Vector3.down,Vector3.left,Vector3.right,Vector3.forward,Vector3.back};

        for(int i = 0; i < 6; i++){

            //If we don't already have a mesh filter component then add one
            if(meshFilters[i] == null){

                //Make a new child object and add a mesh refilter and a mesh renderer
                GameObject meshObj = new GameObject("face_" + i.ToString());
                meshObj.transform.parent = transform;

                meshObj.AddComponent<MeshRenderer>().sharedMaterial = material;
                meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();

            }

            //Assign the faces
            faces[i] = new Face(generator,meshFilters[i].sharedMesh,planetShapeSettings.resolution,directions[i]);

        }

    }

    public void GeneratePlanet(){

        Initialize();
        GenerateMesh();   
        GenerateColors();     

    }

    public void GenerateMesh(){

        //Constuct a new mesh for every face on our cube
        foreach(Face face in faces){

            face.ConstructMesh();

        }        
    }

    void GenerateColors(){

        foreach(MeshFilter meshFilter in meshFilters){
            //Generate colors based on height
            MeshRenderer meshRenderer = meshFilter.gameObject.GetComponent<MeshRenderer>();
            meshRenderer.sharedMaterial.SetFloat("_min", generator.elevationMin);
            meshRenderer.sharedMaterial.SetFloat("_max", generator.elevationMax);

            Texture2D texture = new Texture2D(textureResolution, 1);
            ChangeColorsTextureFromGradient(texture);

            meshRenderer.material.SetTexture("_color", texture);

        }

    }

    public void OnPlanetShapeSettingsUpdated(){

        Initialize();
        GenerateMesh();

    }

    public void OnPlanetColorSettingsUpdated(){

        Initialize();
        GenerateMesh();

    }

    public void ChangeColorsTextureFromGradient(Texture2D texture)
    {
        Color[] colors = new Color[textureResolution];
        for (int i = 0; i < textureResolution; i++)
        {
            colors[i] = planetColorGradient.Evaluate(i / (textureResolution - 1f));
        }

        texture.SetPixels(colors);
        texture.Apply();
    }



}
