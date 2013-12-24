using UnityEngine;
using System.Collections;

public class FFTScale : MonoBehaviour 
{
	public int channel = 1;
	public GameObject[] fftObjects;
	private float gain = 0.25f;
	
	void OSCfft (OSCHandler.FftData fftData) {
		if(fftData.channel == channel) {
			for(int i=0; i<24; i++) {
				//Debug.Log("fft");
				//Vector3 objectLocalScale = fftObjects[i].transform.localScale;
				//objectLocalScale.y = fftData.ranges[i] *gain;
				Vector3 offset = new Vector3(1, fftData.ranges[i] *gain, 1);
				fftObjects[i].transform.localScale = offset;
			}
		}
	}
}
