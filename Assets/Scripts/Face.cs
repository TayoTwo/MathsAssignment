using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face{

    float planetDiameter;
    Mesh mesh;
    int resolution;
    Vector3 localUp;
    Vector3 localForward;
    Vector3 localRight;

    public Face(Mesh mesh,int resolution,Vector3 localUp,float diameter){

        this.mesh = mesh;
        this.resolution = resolution;
        this.localUp = localUp;
        planetDiameter = diameter;

        localRight = new Vector3(localUp.y,localUp.z,localUp.x);
        localForward = Vector3.Cross(localUp,localRight);

    }

    public void ConstructMesh(){

        //Setup
        Vector3[] vertices = new Vector3[resolution * resolution];
        int[] triangles = new int[(resolution-1) * (resolution-1) * 6];
        int triIndex = 0;

        //Run through every row
        for(int y = 0; y < resolution;y++){

            //Run through every column
            for(int x = 0; x < resolution;x++){

                //Which vertice we a re currently on
                int i = x + y * resolution;
                //How far along the triangle list we are percentage wise
                Vector2 percent = new Vector2(x,y) / (resolution - 1);
                Vector3 pointOnUnitCube = localUp + (percent.x-0.5f)* 2f * localRight + (percent.y - 0.5f) * 2 * localForward;
                Vector3 pointOnUnitSphere = pointOnUnitCube.normalized * planetDiameter;
                vertices[i] = pointOnUnitSphere;

                //Don't make triangles starting on the last row of vertices or on the last column of vertices
                if(x != resolution - 1 && y != resolution - 1){
                    
                    //First triangle
                    triangles[triIndex] = i;
                    triangles[triIndex + 1] = i + resolution + 1;
                    triangles[triIndex + 2] = i + resolution;

                    //Second triangle
                    triangles[triIndex + 3] = i;
                    triangles[triIndex + 4] = i + 1;
                    triangles[triIndex + 5] = i + resolution + 1;

                    triIndex += 6;

                }

            }

        }

        //Assign the vertices and triangles accordingly then recalculate the normals so that they are facing the correct direction
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

    }

}
