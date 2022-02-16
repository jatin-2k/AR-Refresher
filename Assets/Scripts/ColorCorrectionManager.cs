using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ColorCorrectionManager : MonoBehaviour
{
    private float averageBrightness;
    private float averageColorTemperature;
    private Color colorCorrection;

    public ARCameraManager ARCamera;
    public Light directionalLight;
    public UnityEngine.UI.Image image;

    // Start is called before the first frame update
    void Start()
    {
        ARCamera.frameReceived += (args) =>
        {
            averageBrightness = (float)args.lightEstimation.averageBrightness;
            averageColorTemperature = (float)args.lightEstimation.averageColorTemperature;
            colorCorrection = (Color)args.lightEstimation.colorCorrection;
        };

        directionalLight.useColorTemperature = true;
    }

    // Update is called once per frame
    void Update()
    {
        directionalLight.intensity = averageBrightness;
        directionalLight.colorTemperature = averageColorTemperature;
    }
}
