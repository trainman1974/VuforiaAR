using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSlider : MonoBehaviour
{
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
}
