using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CarManager : MonoBehaviour
{
    public GameObject indicator;

    ARRaycastManager arManager;
    void Start()
    {
        indicator.SetActive(false);

        arManager = GetComponent<ARRaycastManager>();        
    }


    void Update()
    {
        DetectGround();
    }

    void DetectGround()
    {
        Vector2 screenSize = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

        List<ARRaycastHit> hitInfos = new List<ARRaycastHit>();

        if (arManager.Raycast(screenSize, hitInfos, TrackableType.Planes))
        {
            indicator.SetActive(true);
            indicator.transform.position = hitInfos[0].pose.position;
            indicator.transform.rotation = hitInfos[0].pose.rotation;
        }
        else
        {
            indicator.SetActive(false);
        }
    }
}
