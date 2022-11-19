using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheelspeen : MonoBehaviour
{
    private float updatee;
    public GameObject Wheel;
    public GameObject sparks;
    public GameObject sparks1;
    bool IsSpining=true;
    float speed=0f;
    private Renderer Renderer;
    private Renderer Renderer1;
    //public Color sparks;
    public Texture texture;
    public Texture texture1;
    void Start()
    {
        Renderer = sparks.GetComponent<Renderer>();
        Renderer1 = sparks1.GetComponent<Renderer>();
    }
    void Update()
    {
        //sparks = Color.Lerp(sparks.linear, new Vector4(sparks.linear.r, sparks.linear.g, sparks.linear.b, 0), 0.001f);
        if (!IsSpining && speed<=0)
        {
            speed += 0.0001f;
        }
        if (IsSpining && speed > -0.4f)
        {
            speed -= 0.0001f;
        }
        updatee += Time.deltaTime;
        if (updatee > 0.01f)
        {
            updatee = 0.0f;
            Wheel.transform.Rotate(0, 0, speed);
        }
    }
    public void WheelStop()
    {
        IsSpining = !IsSpining;
        //Wheel.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,100), updatee);
        if (!IsSpining)
        {
            Renderer.material.mainTexture = texture;
            Renderer1.material.mainTexture = texture;
        }
        else
        {
            Renderer.material.mainTexture = texture1;
            Renderer1.material.mainTexture = texture1;
        }
    }
}