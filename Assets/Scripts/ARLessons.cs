using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARLessons : MonoBehaviour
{
    public ARSession session;
    public ARPlaneManager planeManager;
    public ARPointCloudManager cloudManager;
    public TMPro.TMP_Text screenText1;
    public TMPro.TMP_Text screenText2;
    int nplanes = 0;


    // Start is called before the first frame update
    void Start()
    {
        ARSession.stateChanged += (args) => screenText1.text = ARSession.state.ToString();
        planeManager.planesChanged += (args) =>
        {
            nplanes += args.added.Count;
            nplanes -= args.removed.Count;
            screenText2.text = nplanes + " Planes";
        };

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

}
