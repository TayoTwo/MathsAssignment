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
        meshRenderer = GetComponent<MeshRenderer>();
        texture = new Texture2D(textureResolution, 1);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColorsTextureFromGradient();
        meshRenderer.material.SetTexture("_color", texture);
        meshRenderer.material.SetFloat("_min", minHeight);
        meshRenderer.material.SetFloat("_max", maxHeight);
    }

    public void ChangeColorsTextureFromGradient()
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
