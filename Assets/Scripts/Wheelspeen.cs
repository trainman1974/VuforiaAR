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
    private Renderer RendererSparks;
    private Renderer RendererSparks1;
    public Texture2D mainTexture;
    float alpha = 1f;
    void Start()
    {
        RendererSparks = sparks.GetComponent<Renderer>();
        RendererSparks1 = sparks1.GetComponent<Renderer>();
    }
    void Update()
    {
        //sparks = Color.Lerp(sparks.linear, new Vector4(sparks.linear.r, sparks.linear.g, sparks.linear.b, 0), 0.001f);
        if (!IsSpining && speed<=0)
        {
            speed += 0.0002f;
            alpha += 0.0005f;
        }
        if (IsSpining && speed > -0.4f)
        {
            speed -= 0.0002f;
            alpha -= 0.0005f;
        }
        updatee += Time.deltaTime;
        if (updatee > 0.01f)
        {
            updatee = 0.0f;
            Wheel.transform.Rotate(0, 0, speed);
        }
        Texture2D _NewTexture = new Texture2D(32, 32);

        Vector4 _Color = new Vector4(alpha, alpha, alpha, alpha);
        for (int y = 0; y < 32; y++)
        {
            for (int x = 0; x < 32; x++)
            {
                Vector4 _OldColor = mainTexture.GetPixel(x, y);
                _NewTexture.SetPixel(x, y, (_OldColor - _Color));
            }
        }
        _NewTexture.Apply();
        RendererSparks.material.mainTexture = _NewTexture;
    }
    public void WheelStop()
    {
        IsSpining = !IsSpining;
        //Wheel.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,100), updatee);
        if (!IsSpining)
        {
            //RendererSparks.material.mainTexture = testTexture;            
            //Color c = RendererSparks1.material.color;

            /// рабочие значения от 0 до 1
            /// придумай как менять эти значения.

            ////создание текстуры
            Texture2D _NewTexture = new Texture2D(32, 32);

            Vector4 _Color = new Vector4 (alpha,alpha,alpha,alpha);
            for (int y = 0; y < 32; y++)
            {
             for (int x = 0; x < 32; x++)
             { 
                Vector4 _OldColor = mainTexture.GetPixel(x,y);
                _NewTexture.SetPixel(x, y, (_OldColor - _Color)); 
             }             
            }     
            _NewTexture.Apply();
            RendererSparks.material.mainTexture = _NewTexture;

        }
        else
        {
            RendererSparks.material.mainTexture = mainTexture;
            RendererSparks1.material.mainTexture = mainTexture;
        }
    }
}