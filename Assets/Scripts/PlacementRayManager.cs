using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementRayManager : MonoBehaviour
{
    private bool settleInPosition = false;
    private GameObject robo;

    public ARRaycastManager raycastManager;
    public GameObject visualPrefab;

    // Update is called once per frame
    void Update()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);
        if (hits.Count > 0)
        {
            if (robo == null) robo = GameObject.Instantiate(visualPrefab, hits[0].pose.position, hits[0].pose.rotation);
            if (!settleInPosition)
            {
                robo.transform.position = hits[0].pose.position;
                robo.transform.rotation = hits[0].pose.rotation;
            }
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                settleInPosition = true;
            }
        }
    }

    public void resetMovingPointer()
    {
        settleInPosition = false;
    }
}
