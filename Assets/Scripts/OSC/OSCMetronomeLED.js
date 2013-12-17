public var channel : int = 1;
public var restColor : Color = Color.black;
public var activeColor : Color = Color.red;
public var metronomeLEDs : MetronomeLED[];

class MetronomeLED {
	public var obj : GameObject;
	@System.NonSerialized public var mat : Material;
}

function Start () {
	
	// initialize all LEDs
	for(metronomeLED in metronomeLEDs) {
		metronomeLED.mat = metronomeLED.obj.gameObject.GetComponent(Renderer).material;
		SetMetronomeLEDColor(metronomeLED, restColor);
	}
}

function SetMetronomeLEDColor(metronomeLED : MetronomeLED, inputColor : Color) {
	metronomeLED.mat.SetColor("_Color", inputColor);
	metronomeLED.mat.SetColor("_TintColor", inputColor);
	metronomeLED.mat.SetColor("_Emission", inputColor);
	//metronomeLED.mat.SetColor("_TintColor", inputColor);
}

function OSCMetronome (tempo) {
	StopCoroutine( "StrobeLED");	
	StartCoroutine( "StrobeLED", 0.5);
}

function StrobeLED(fadeTime) {
	var startTime = Time.time;
	var normalizedEelapsedTime = 0.0;
	
	while(normalizedEelapsedTime <=1.0){
		elapsedTime = (Time.time - startTime);
		normalizedEelapsedTime = elapsedTime/fadeTime;
		lerpedColor = Color.Lerp(activeColor, restColor, normalizedEelapsedTime);
		for(metronomeLED in metronomeLEDs) {
			SetMetronomeLEDColor(metronomeLED, lerpedColor);
		}
		yield;
	}
	
	for(metronomeLED in metronomeLEDs) {
		SetMetronomeLEDColor(metronomeLED, restColor);
	}
}

