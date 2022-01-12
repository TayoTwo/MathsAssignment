using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    [Range(2,256)]
    public int resolution = 10;
    public Material material;
    public float diameter = 1;
    MeshFilter[] meshFilters;
    Face[] faces;

    void Awake(){

        //If no material is set then use the "Standard" material
        if(material == null){

            material = new Material(Shader.Find("Standard"));

        }

    }

    //Regenerate the mesh 60 times per second
    void FixedUpdate(){

        Initialize();
        GenerateMesh();

    }

    void Initialize(){

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
            faces[i] = new Face(meshFilters[i].sharedMesh,resolution,directions[i],diameter);

        }

    }

    public void GenerateMesh(){

        //Constuct a new mesh for every face on our cube
        foreach(Face face in faces){

            face.ConstructMesh();

        }

    }
    
}
