using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public Renderer meshRender;
    public float speed = 0.1f;

    void Update()
    {
        Vector2 offset = meshRender.material.mainTextureOffset;
        offset += new Vector2(0, speed * Time.deltaTime);
        meshRender.material.mainTextureOffset = offset;
    }
}
