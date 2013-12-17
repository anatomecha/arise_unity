public var channel : int = 1;
public var restColor : Color = Color.black;
public var activeColor : Color = Color.red;
public var peakLEDs : PeakLED[];

class PeakLED {
	public var obj : GameObject;
	public var peakLevel : float;
	@System.NonSerialized public var mat : Material;
}

function Start () {
	
	// initialize all peakLEDs
	for(peakLED in peakLEDs) {
		peakLED.mat = peakLED.obj.gameObject.GetComponent(Renderer).material;
		SetPeakLEDColor(peakLED, restColor);
	}
}

function SetPeakLEDColor(peakLED : PeakLED, inputColor : Color) {
	peakLED.mat.SetColor("_Color", inputColor);
	peakLED.mat.SetColor("_TintColor", inputColor);
	peakLED.mat.SetColor("_Emission", inputColor);
	//peakLED.mat.SetColor("_TintColor", inputColor);
}

function OSCAudioEnvelope (input) {
	if(input.channel == channel) {
		for(peakLED in peakLEDs) {
			if(input.envelope >= peakLED.peakLevel) {
				SetPeakLEDColor(peakLED, activeColor);
			}
			else {
				SetPeakLEDColor(peakLED, restColor);
			}
		}
	}
}

