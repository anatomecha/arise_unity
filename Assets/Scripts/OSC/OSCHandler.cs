using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class OSCHandler : MonoBehaviour 
{
	
	public bool oscEnabled = true;
	public bool oscSendEnabled = false;
	public bool metronome = false;
	
	private Osc osc;
	private OscMessage oscMessage;
	
	// OSC Message data types
	
	private AudioEnvelopeData audioEnvelopeData;
	public class AudioEnvelopeData {
		public int channel = 0;
		public float envelope = 0.0f;
	}
	
	private MidiNoteData midiNoteData;
	public class MidiNoteData {
		public int channel = 0;
		public List<float> note = new List<float>(128);
	}
	
	private FftData fftData;
	public class FftData {
		public int channel = 0;
		public List<float> ranges = new List<float>(24);
	}
	
	private DirectDriveData directDriveData;
	public class DirectDriveData {
		public int channel = 0;
		public float impulse = 0.0f;
	}
	
	
	/*
	function SendOscMessage(address,val) {
		oscMessage = new OscMessage();
		oscMessage.Address = address;
		values = new ArrayList();
		values.Add(val);
		oscMessage.Values = values;
		
		if(oscSendEnabled) { 
			osc.Send(oscMessage);
	 		//Debug.Log("OSCOutput " + address + " " + oscMessage.Values[0]);
	 	}
	}*/
	
	
	void Start () { 
		//osc = GameObject.Find("all_objects").GetComponent(Osc);
		
		//instantiate new osc data types
		audioEnvelopeData = new AudioEnvelopeData();
		
		directDriveData = new DirectDriveData();
		
		midiNoteData = new MidiNoteData();
		for(int i=0; i<128; i++) { midiNoteData.note.Add(0.0f); }
		
		fftData = new FftData();
		for(int i=0; i<24; i++) { fftData.ranges.Add(0.0f); }
		
	}
	
	void Update () {
		if(!oscEnabled) { return; }
		metronome = false;
		
		// reset midiNoteData
		for(int i=0; i<128; i++) {
			midiNoteData.note[i] = 0.0f;
		}
		
		//while (OSCReceiver.msgList.Length > 0)
		for (int i=0; i<OSCReceiver.msgList.Count; i++)
		{
			oscMessage = OSCReceiver.msgList[i];
			//Debug.Log("length of queue = " + OSCReceiver.msgList.length + ". handling address " + oscMessage.Address);
			if ( oscMessage == null) { continue; }
			
			//parse the address
			string[] addressTokens = oscMessage.Address.Split("/" [0]);
			
			if (oscMessage.Address.Equals("/metronome")) {
				//Debug.Log("metronome = " + oscMessage.Values[0]);
				metronome = true;
				BroadcastMessage("OSCMetronome", 1, SendMessageOptions.DontRequireReceiver);
			}
			
			// audio envelopes: /audio/envelope value:float channel:int
			else if (oscMessage.Address.Equals("/audio/envelope"))
			{
				//Debug.Log("audioEnvelopeData " + oscMessage.Values[1] + " " + oscMessage.Values[0]);
				audioEnvelopeData.channel = Convert.ToInt32(oscMessage.Values[1]); 
				audioEnvelopeData.envelope = Convert.ToSingle(oscMessage.Values[0]);
				BroadcastMessage("OSCAudioEnvelope", audioEnvelopeData, SendMessageOptions.DontRequireReceiver);
			}
			
			// midi notes: /midi/note pitch:int velocity:int channel:int
			else if (oscMessage.Address.Equals("/midi/note"))
			{
				//Debug.Log("midiNoteData = " + oscMessage.Values[0] + " " + oscMessage.Values[1] + " " + oscMessage.Values[2]);
				midiNoteData.channel = Convert.ToInt32(oscMessage.Values[2]);
				midiNoteData.note[Convert.ToInt32(oscMessage.Values[0])] = Convert.ToSingle(oscMessage.Values[1]);
				BroadcastMessage("OSCMidiNote", midiNoteData, SendMessageOptions.DontRequireReceiver);
			}
			
			else if (oscMessage.Address.Equals("/fft")) {
				//Debug.Log("fft = " + oscMessage.Values[0]);
				string[] rangeValues = Convert.ToString(oscMessage.Values[0]).Split(" "[0]);
				//print(oscMessage.Values[1]);
				fftData.channel = Convert.ToInt32(oscMessage.Values[1]);
				//print(rangeValues[0][1]);
				for(int c=0; c<24; c++){
					fftData.ranges[c] = Convert.ToSingle(rangeValues[c]);
				}
				BroadcastMessage("OSCfft", fftData, SendMessageOptions.DontRequireReceiver);
			}
			
			// direct drive slider: /directdrive/slider value:float channel:int
			else if (oscMessage.Address.Equals("/directdrive/slider"))
			{
				//Debug.Log("directdriveSlider " + oscMessage.Values[1] + " " + oscMessage.Values[0]);
				directDriveData.channel = Convert.ToInt32(oscMessage.Values[1]); 
				directDriveData.impulse = Convert.ToSingle(oscMessage.Values[0]);
				BroadcastMessage("OSCDirectDriveSlider", directDriveData, SendMessageOptions.DontRequireReceiver);
			}
		}
		OSCReceiver.msgList.Clear();
	}
}
