using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sadow_Mov : MonoBehaviour
{
    private List<int> shadowList = Tracking.tracking;
    private int thisShadowOrder = Tracking.shadowOrder;

    private void Start()
    {
        Tracking.tracking = new List<int>();


    }
    private void Update()
    {
        if(thisShadowOrder == Tracking.currentShadow ) 
        {
            for(int i = 1; i <= shadowList.Count; i++) 
            {
                
            }
        }
    }
}
