using UnityEngine;
using System.Collections;

public class ToggleLights : MonoBehaviour {
    public GameObject[] roofLights;
    public GameObject[] wallLights;
    public GameObject[] moonBeams;

    public float flOnIntensity;
    public float flOnRange;
    public Color flOnColor;
    public float flOffIntensity;
    public float flOffRange;
    public Color flOffColor;

    public float wlPointOnIntensity;
    public float wlPointOnRange;
    public Color wlPointOnColor;
    public float wlPointOffIntensity;
    public float wlPointOffRange;
    public Color wlPointOffColor;

    public float wlSpotOnIntensity;
    public float wlSpotOnRange;
    public Color wlSpotOnColor;
    public float wlSpotOffIntensity;
    public float wlSpotOffRange;
    public Color wlSpotOffColor;

    enum LIGHTS_STATE
    {
        On,
        Off
    }

    private LIGHTS_STATE currentState;

	// Use this for initialization
	void Start () {
        TurnLightsOn();
	}
	
    // Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.K))
            ToggleTheLights();
	}

    public void TurnLightsOn()
    {
        currentState = LIGHTS_STATE.On;
        foreach (GameObject rl in roofLights)
        {
            rl.renderer.material.shader = Shader.Find("Self-Illumin/Diffuse");
            Light l = rl.transform.FindChild("Point light").GetComponent<Light>();
            l.intensity = flOnIntensity;
            l.range = flOnRange;
            l.color = flOnColor;
        }
        foreach (GameObject wl in wallLights)
        {
            wl.renderer.material.shader = Shader.Find("Self-Illumin/Diffuse");
            Light l = wl.transform.FindChild("Point light").GetComponent<Light>();
            l.intensity = wlPointOnIntensity;
            l.range = wlPointOnRange;
            l.color = wlPointOnColor;

            l = wl.transform.FindChild("Spotlight").GetComponent<Light>();
            l.intensity = wlSpotOnIntensity;
            l.range = wlSpotOnRange;
            l.color = wlSpotOnColor;
        }
        foreach (GameObject mb in moonBeams)
        {
            mb.SetActive(false);
        }
    }

    public void TurnLightsOff()
    {
        currentState = LIGHTS_STATE.Off;
        foreach (GameObject rl in roofLights)
        {
            rl.renderer.material.shader = Shader.Find("Diffuse");
            
            Light l = rl.transform.FindChild("Point light").GetComponent<Light>();
            l.intensity = flOffIntensity;
            l.range = flOffRange;
            l.color = flOffColor;
        }
        foreach (GameObject wl in wallLights)
        {
            wl.renderer.material.shader = Shader.Find("Diffuse");
            
            Light l = wl.transform.FindChild("Point light").GetComponent<Light>();
            l.intensity = wlPointOffIntensity;
            l.range = wlPointOffRange;
            l.color = wlPointOffColor;

            l = wl.transform.FindChild("Spotlight").GetComponent<Light>();
            l.intensity = wlSpotOffIntensity;
            l.range = wlSpotOffRange;
            l.color = wlSpotOffColor;
        }
        foreach (GameObject mb in moonBeams)
        {
            mb.SetActive(true);
        }
    }

    public void ToggleTheLights()
    {
        if (currentState == LIGHTS_STATE.Off)
            TurnLightsOn();
        else
            TurnLightsOff();
    }
}
