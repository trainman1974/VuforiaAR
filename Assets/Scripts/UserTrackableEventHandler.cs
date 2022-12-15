using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserTrackableEventHandler : DefaultObserverEventHandler
{
   public GameObject _Canvas; 

    protected override void OnTrackingFound()
    {
        _Canvas.SetActive(true);
        base.OnTrackingFound();    
    }
        protected override void OnTrackingLost()
    {
        _Canvas.SetActive(false);
        base.OnTrackingFound();    
    }
 
    
}

