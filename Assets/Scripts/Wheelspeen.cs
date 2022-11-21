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
    }
    void FixedUpdate()
    {
        if (!IsSpining && speed<=0)
        {
            speed += 0.002f;
        }
        if (IsSpining && speed > -0.4f)
        {
            speed -= 0.002f;
        }
        //updatee += Time.deltaTime;
        Wheel.transform.Rotate(0, 0, speed);
        /*
        if (updatee > 0.01f)
        {
            updatee = 0.0f;
            Wheel.transform.Rotate(0, 0, speed);
        }
        */
    }
    public void WheelStop()
    {
        IsSpining = !IsSpining;
        StartButton.SetActive(!IsSpining);
        StopButton.SetActive(IsSpining);
        StartCoroutine(Fade());
    }
    IEnumerator Fade()
    {
        print("Start Coroutine");
        // меняем альфу
        //alpha = 0f;
            for (int i = 0; i < 32; i++)
            {
                if (!IsSpining && alpha <= 1f )
                {
                    alpha = alpha + 0.03f;
                }
                else if  (IsSpining &&  alpha >= 0.03f )
                {
                    alpha = alpha - 0.03f;
                }
                print("alpha " + alpha);
                // вызов функции
                NewTexture();
                yield return new WaitForSeconds(0.1f);
            }
               
        //yield return break;
        //задаем значения альфы
        if (!IsSpining)
        {
            alpha = 1;
        }
        else if  (IsSpining)
        {
            alpha = 0;
        }
        print("End Coroutine");


    }
    private void NewTexture()
    {
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
        print("New Texture");

    }


}