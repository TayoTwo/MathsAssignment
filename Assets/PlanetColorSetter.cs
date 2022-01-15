using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetColorSetter : MonoBehaviour
{
    public int textureResolution;
    public float minHeight;
    public float maxHeight;
    public Gradient planetColorGradient;

    Texture2D texture;
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //meshRenderer = GetComponent<MeshRenderer>();
        //texture = new Texture2D(textureResolution, 1);
        //ChangeColorsTextureFromGradient();
        //meshRenderer.material.SetTexture("_color", texture);
    }
}
