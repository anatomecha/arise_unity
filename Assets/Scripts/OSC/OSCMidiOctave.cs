using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class OSCMidiOctave : MonoBehaviour 
{
	public int channel = 1;
	public Color restColor = Color.black;
	public Color lowNoteColor = Color.blue;
	public Color highNoteColor = Color.red;
	public List<GameObject> noteObjects;
	//public static List<NoteData> noteDataObjects;
	public List<NoteData> noteDataObjects = new List<NoteData>();
	
	private Color lerpedColor;
	private float fadeTime = 0.175f;
	private NoteData noteData;
	
	public class NoteData {
		public GameObject obj ;
		public Material mat ;
		public int octave;
		public float velocity;
	}
	
	void Start () {
		
		// create noteDataObjects for each noteObject
		foreach(GameObject obj in noteObjects) {
			noteData = new NoteData();
			noteData.obj = obj.gameObject;
			noteData.mat = obj.gameObject.GetComponent<Renderer>().material;
			noteDataObjects.Add(noteData);
			
			// Note: octave and velocity get set below when input is received
			
			SetNoteColor(noteData, restColor);
		}
	}
	
	void SetNoteColor(NoteData noteData, Color inputColor) {
		noteData.mat.SetColor("_Emission", inputColor);
		noteData.mat.SetColor("_Color", inputColor);
		noteData.mat.SetColor("_TintColor", inputColor);
	}
	
	void OSCMidiNote (OSCHandler.MidiNoteData input) {
		if(input.channel == channel) {
			//loop through all midi notes
			for(int midiNote=0; midiNote<128; midiNote++) { 
				if(input.note[midiNote] !=0) {
					//StopCoroutine( "FadeNoteColor");
					int pitchValue = Convert.ToInt32(Mathf.Repeat(midiNote, 12));
					NoteData noteData = noteDataObjects[pitchValue];
					
					// pack the velocity and octave data into noteData because coroutine takes only one input
					noteData.velocity = input.note[midiNote]/127.0f;
					noteData.octave = Mathf.FloorToInt(midiNote/10);
					//print("OSCMidiNote:" + midiNote + " obj:"  + noteData.obj + " pitch:" + pitchValue + " octave:" + noteData.octave + " ch:" + input.channel + " vel:" + noteData.velocity);
					StartCoroutine( FadeNoteColor(noteData) );
				}
			}
		}
	}
	
	IEnumerator FadeNoteColor (NoteData noteData) {
		Color octaveColor = Color.Lerp(lowNoteColor, highNoteColor, noteData.octave/10.0f);
		Color startColor = Color.Lerp(restColor, octaveColor, noteData.velocity);
		float startTime = Time.time;
		float normalizedEelapsedTime = 0.0f;
		
		// smoothly interopolate the color toward restColor over fadeTime
		while(normalizedEelapsedTime <=1.0){
			float elapsedTime = (Time.time - startTime);
			normalizedEelapsedTime = elapsedTime/fadeTime;
			lerpedColor = Color.Lerp(startColor, restColor, normalizedEelapsedTime);
			
			SetNoteColor(noteData, lerpedColor);
			
			yield return null;
		}
		
		SetNoteColor(noteData, restColor);
	}
}