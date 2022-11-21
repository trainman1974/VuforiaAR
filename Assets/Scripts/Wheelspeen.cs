using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheelspeen : MonoBehaviour
{
    private float updatee;
    public GameObject Wheel;
    public GameObject sparks1;
    bool IsSpining=true;
    float speed= -0.4f;
    private Renderer RendererSparks1;
    public Texture2D mainTexture;
    public GameObject StartButton;
    public GameObject StopButton;
    float alpha = 0f;
    void Start()
    {
        RendererSparks1 = sparks1.GetComponent<Renderer>();
        StartCoroutine(Fade(RendererSparks1, alpha, mainTexture));
    }
    void Update()
    {
        if (!IsSpining && speed<=0)
        {
            speed += 0.0002f;
        }
        if (IsSpining && speed > -0.4f)
        {
            speed -= 0.0002f;
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
        StartButton.SetActive(!IsSpining);
        StopButton.SetActive(IsSpining);
        StartCoroutine(Fade(RendererSparks1, alpha, mainTexture));
    }
    IEnumerator Fade(Renderer RendererSparks1, float alpha, Texture2D mainTexture)
    {
        print("2");
        alpha = 1f;
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
        RendererSparks1.material.mainTexture = _NewTexture;
        yield return null;
    }
}