public var channel : int = 1;
public var restColor : Color = Color.black;
public var lowNoteColor : Color = Color.blue;
public var highNoteColor : Color = Color.red;
public var noteObjects : GameObject[];
private var noteDataObjects = new Array();
private var lerpedColor : Color;
private var fadeTime = 0.175;
private var noteData : NoteData;

class NoteData {
	public var obj : GameObject;
	public var mat : Material;
	public var octave : int;
	public var velocity : float;
}

function Start () {
	
	// create noteDataObjects for each noteObject
	for(obj in noteObjects) {
		noteData = new NoteData();
		noteData.obj = obj.gameObject;
		noteData.mat = obj.gameObject.GetComponent(Renderer).material;
		noteDataObjects.Push(noteData);
		// Note: octave and velocity get set below when input is received
		
		SetNoteColor(noteData, restColor);
	}
}

function SetNoteColor(noteData : NoteData, inputColor : Color) {
	noteData.mat.SetColor("_Emission", inputColor);
	noteData.mat.SetColor("_Color", inputColor);
	noteData.mat.SetColor("_TintColor", inputColor);
}

function OSCMidiNote (input) {
	if(input.channel == channel) {
		//loop through all midi notes
		for(midiNote=0; midiNote<128; midiNote++) { 
			if(input.note[midiNote] !=0) {
				//StopCoroutine( "FadeNoteColor");
				var pitchValue = Mathf.Repeat(midiNote, 12);
				var noteData = noteDataObjects[pitchValue];
				
				// pack the velocity and octave data into noteData because coroutine takes only one input
				noteData.velocity = input.note[midiNote]/127.0;
				noteData.octave = Mathf.FloorToInt(midiNote/10);
				//print("OSCMidiNote:" + midiNote + " obj:"  + noteData.obj + " pitch:" + pitchValue + " octave:" + noteData.octave + " ch:" + input.channel + " vel:" + noteData.velocity);
				StartCoroutine( FadeNoteColor(noteData) );
			}
		}
	}
}

function FadeNoteColor (noteData) {
	var octaveColor : Color = Color.Lerp(lowNoteColor, highNoteColor, noteData.octave/10.0);
	var startColor : Color = Color.Lerp(restColor, octaveColor, noteData.velocity);
	var startTime = Time.time;
	var normalizedEelapsedTime = 0.0;
	
	// smoothly interopolate the color toward restColor over fadeTime
	while(normalizedEelapsedTime <=1.0){
		elapsedTime = (Time.time - startTime);
		normalizedEelapsedTime = elapsedTime/fadeTime;
		lerpedColor = Color.Lerp(startColor, restColor, normalizedEelapsedTime);
		
		SetNoteColor(noteData, lerpedColor);
		
		yield;
	}
	
	SetNoteColor(noteData, restColor);
}
