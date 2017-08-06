using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class BeatGenerator : MonoBehaviour {

    AudioSource aus;
    public float[] samples = new float[512];

	void Start () {
        aus = GetComponent<AudioSource>();
	}
	
	void Update () {
        GetSpectrumAudioSource();

    }

    void GetSpectrumAudioSource()
    {
        aus.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }
}
