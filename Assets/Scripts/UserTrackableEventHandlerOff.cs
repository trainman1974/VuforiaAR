using UnityEngine;

public class UserTrackableEventHandlerOff : DefaultTrackableEventHandler
{
    protected override void OnTrackingFound()
    {
        GameObject CubeEmmiter = GameObject.FindGameObjectWithTag("CubeEmmiter");
        //CubeEmmiter.SetActive(false);
        Destroy(CubeEmmiter);
        base.OnTrackingFound();       
    }
}