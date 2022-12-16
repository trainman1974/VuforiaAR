using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSlider : MonoBehaviour
{
 public Texture2D[] Images = new Texture2D[6];
 public GameObject FrameMesh;
 private Material FrameMaterial;
 private float elapsedTime = 2f;
 private bool  _finCoroutine = true;
 private float offset = 0;
 private int countImages = 0;
  

    public void Start()
    {
        FrameMaterial = FrameMesh.GetComponent<MeshRenderer>().material;

        //назначаем материал
        //FrameMaterial.SetTexture("Texture2D_9e4f93b668fc41cba6506e35218eacf7",Images[1]);

        //добавляем офссет

        FrameMaterial.SetFloat("Vector1_e1946e1dceea41d5965ecb73385273f6", offset);

        print("MaterialName " + FrameMaterial );    
    }
    public void Update()
    {
    }
        public void SlideRight()
    {
        if(_finCoroutine == true)
        {
            StartCoroutine(Offset());            
        }        
    }
        public void SlideLeft()
    {
        if(_finCoroutine == true)
        {
            StartCoroutine(Offset());            
        }        
    }
    IEnumerator Offset()
    {
        _finCoroutine = false;

        //сдвигаем картинк влево
        while (offset >= 1)
        {
            offset = (float)(offset + 0.01);            
            FrameMaterial.SetFloat("Vector1_e1946e1dceea41d5965ecb73385273f6", offset);
            yield return new WaitForSeconds(0.1f);
            print("offset picture old "); 
        }
        //меняем картинку
        offset = -1;
        FrameMaterial.SetTexture("Texture2D_9e4f93b668fc41cba6506e35218eacf7",Images[countImages]);
        //выдвигаем картинку
        while (offset <= 0)
        {
            offset = (float)(offset + 0.01);            
            FrameMaterial.SetFloat("Vector1_e1946e1dceea41d5965ecb73385273f6", offset);
            yield return new WaitForSeconds(0.1f);
            print("offset picture new ");
        }
         
        //меняем счетчик массива картинок
        if (countImages < 6)
        {
            countImages = countImages+1;
        }
        else countImages = 0;
        _finCoroutine = true;        
    }
}


/*
     public GameObject images;
    float desiredDuration = 2f;
    float elapsedTime = 2f;
    float percentageComplete;
    Vector3 startPos;
    Vector3 endPos;

    public void Start()
    {
        startPos = images.transform.position;
        endPos = images.transform.position;
    }
    public void SlideRight()
    {
        if (elapsedTime > 2)
        {
            startPos = images.transform.position;
            endPos = new Vector3(images.transform.position.x - 41, 0, 0);
            elapsedTime = 0;
            percentageComplete = 0;
        }
    }
    public void SlideLeft()
    {
        if (elapsedTime > 2)
        {
            startPos = images.transform.position;
            endPos = new Vector3(images.transform.position.x + 41, 0, 0);
            elapsedTime = 0;
            percentageComplete = 0;
        }
    }
    public void Update()
    {
        elapsedTime += Time.deltaTime;
        percentageComplete = elapsedTime / desiredDuration;
        images.transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0, 1, percentageComplete));

        if (images.transform.position.x == 205)
            images.transform.position = new Vector3(0, 0, 0);

        if (images.transform.position.x == -205)
            images.transform.position = new Vector3(0, 0, 0);
    }
    */