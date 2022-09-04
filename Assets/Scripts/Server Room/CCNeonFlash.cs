using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCNeonFlash : MonoBehaviour 
{
    public bool IsActive;
    [ColorUsageAttribute (true, true)]
    public Color MaxBright;
    public float BoostBright = 10;
    public float SwitchTime = 0.1f;
    public enum SwitchMode
    {
        simple = 0,
        multi = 1,
        broken = 2,
        stat = 3,
    }
    public SwitchMode SwitchModes = SwitchMode.simple;
    public int MatId = 1;
    public GameObject LightSource;
    int mode;
    int count;
    Material _Material;
    float LSintensity;

    void Awake()
    {
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks * 1000);
    }

	// Use this for initialization
	void Start () 
    {
        if (IsActive)
        {
            float random = Random.Range(0.07f, 0.95f);
            InvokeRepeating("ColorSwitch", random, SwitchTime);
            _Material = GetComponent<Renderer>().materials[MatId];

            MaxBright = MaxBright * BoostBright;

            if (LightSource)
            {
                LSintensity = LightSource.GetComponent<Light>().intensity;
            }
        }

	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void ColorSwitch()
    {
        //0 - 1 - 0 - 1 - 0...
        if (SwitchModes == SwitchMode.simple)
        {
            mode = 1 - mode;
            if (mode == 0)
            {
                _Material.SetColor("_EmissionColor", Color.black);
                if (LightSource) LightSource.GetComponent<Light>().intensity = 0;
            }
            else
            {
                _Material.SetColor("_EmissionColor", MaxBright);
                if (LightSource) LightSource.GetComponent<Light>().intensity = LSintensity;
            }
        }

        //0 - 0.5 - 1 - 0...
        else if (SwitchModes == SwitchMode.multi)
        {
            mode++;
            if (mode > 2) mode = 0;
            if (mode == 0)
            {
                _Material.SetColor("_EmissionColor", Color.black);
                if (LightSource) LightSource.GetComponent<Light>().intensity = 0;
            }
            else if (mode == 1)
            {
                _Material.SetColor("_EmissionColor", MaxBright * 0.5f);
                if (LightSource) LightSource.GetComponent<Light>().intensity = LSintensity * 0.5f;
            }
            else
            {
                _Material.SetColor("_EmissionColor", MaxBright);
                if (LightSource) LightSource.GetComponent<Light>().intensity = LSintensity;
            }
        }

        //broken lamp
        else
        {
            if (count < 10)
            {
                mode++;
                if (mode > 2) mode = 0;
                if (mode == 0)
                {
                    _Material.SetColor("_EmissionColor", Color.black);
                    if (LightSource) LightSource.GetComponent<Light>().intensity = 0;
                }
                else if (mode == 1)
                {
                    _Material.SetColor("_EmissionColor", MaxBright * 0.5f);
                    if (LightSource) LightSource.GetComponent<Light>().intensity = LSintensity * 0.5f;
                }
                else
                {
                    _Material.SetColor("_EmissionColor", MaxBright);
                    if (LightSource) LightSource.GetComponent<Light>().intensity = LSintensity;
                }
            }
            else if (count < 20)
            {
                _Material.SetColor("_EmissionColor", MaxBright * 0.5f);
                if (LightSource) LightSource.GetComponent<Light>().intensity = LSintensity * 0.5f;
            }
            else
            {
                _Material.SetColor("_EmissionColor", MaxBright);
                if (LightSource) LightSource.GetComponent<Light>().intensity = LSintensity;
            }
            count++;
            if (count > 50) count = 0;
        }

        if (SwitchModes == SwitchMode.stat)
        {
            _Material.SetColor("_EmissionColor", MaxBright);
        }
    }
}
