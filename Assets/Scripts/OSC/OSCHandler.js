public var oscEnabled : boolean = true;
public var oscSendEnabled : boolean = false;
public var metronome : boolean = false;

private var osc : Osc;
private var oscMessage;

// OSC Message data types

private var audioEnvelopeData : AudioEnvelopeData;
class AudioEnvelopeData{
	var channel : int = 0;
	var envelope : float = 0.0;
}

private var midiNoteData : MidiNoteData;
class MidiNoteData{
	var channel : int = 0;
	var note : Array = [];
}

private var fftData : FftData;
class FftData{
	var channel : int = 0;
	var ranges : Array = [];
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


public function Start () { 
	//osc = GameObject.Find("all_objects").GetComponent(Osc);
	
	//instantiate new osc data types
	audioEnvelopeData = new AudioEnvelopeData();
	midiNoteData = new MidiNoteData();
	fftData = new FftData();
	
	//initialize osc data types
	
	// midiNoteData
	for(i=0; i<128; i++) {
		midiNoteData.note[i] = 0;
	}
	
	// fftData
	for(i=0; i<24; i++) {
		fftData.ranges[i] = 0.0;
	}
}

public function Update () {
	if(!oscEnabled) { return; }
	metronome = false;
	
	// reset midiNoteData
	for(i=0; i<128; i++) {
		midiNoteData.note[i] = 0;
	}
	
	while (OSCReceiver.msgList.length > 0)
	{
		oscMessage = OSCReceiver.msgList.Shift();
		//Debug.Log("length of queue = " + OSCReceiver.msgList.length + ". handling address " + oscMessage.Address);
		if (! oscMessage) { continue; }
		
		//parse the address
		addressTokens = oscMessage.Address.Split("/" [0]);
		
		if (oscMessage.Address.Equals("/metronome")) {
			Debug.Log("metronome = " + oscMessage.Values[0]);
			metronome = true;
			BroadcastMessage("OSCMetronome", 1, SendMessageOptions.DontRequireReceiver);
		}
		
		// audio envelopes: /audio/envelope value:float channel:int
		else if (oscMessage.Address.Equals("/audio/envelope"))
		{
			audioEnvelopeData.channel = parseInt(oscMessage.Values[1]); 
			audioEnvelopeData.envelope = parseFloat(oscMessage.Values[0]);
			//Debug.Log("audioEnvelopeData " + parseFloat(oscMessage.Values[1]) + " " + parseFloat(oscMessage.Values[0]));
			BroadcastMessage("OSCAudioEnvelope", audioEnvelopeData, SendMessageOptions.DontRequireReceiver);
		}
		
		// midi notes: /midi/note pitch:int velocity:int channel:int
		else if (oscMessage.Address.Equals("/midi/note"))
		{
			midiNoteData.channel = parseFloat(oscMessage.Values[2]);
			midiNoteData.note[parseInt(oscMessage.Values[0])] = parseInt(oscMessage.Values[1]);
			//Debug.Log("midiNoteData = " + oscMessage.Values[0] + " " + oscMessage.Values[1] + " " + oscMessage.Values[2]);
			BroadcastMessage("OSCMidiNote", midiNoteData, SendMessageOptions.DontRequireReceiver);
		}
		
		else if (oscMessage.Address.Equals("/fft")) {
			//Debug.Log("fft = " + oscMessage.Values[0]);
			rangeValues = oscMessage.Values[0].Split(" "[0]);
			//print(oscMessage.Values[1]);
			fftData.channel = oscMessage.Values[1];
			//print(rangeValues[0][1]);
			if(true) {
				var c : int;
				for(c=0; c<24; c++){
					fftData.ranges[c] = parseFloat(rangeValues[c]);
				}
				BroadcastMessage("OSCfft", fftData, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}

