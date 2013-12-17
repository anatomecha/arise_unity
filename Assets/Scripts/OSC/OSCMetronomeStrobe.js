private var lightComponent : Light;
private var lerpedColor : Color;
var restColor : Color = Color.black;

function Start () {
	lightComponent = gameObject.GetComponent(Light);
}

function OSCMetronome (tempo) {
	StopCoroutine( "StrobeLight");	
	StartCoroutine( "StrobeLight", 0.5);
}

function StrobeLight(fadeTime) {
	var startColor : Color = Color(1, 0, 0, 1);
	var startTime = Time.time;
	var normalizedEelapsedTime = 0.0;
	lightComponent.intensity = 5.0;
	
	while(normalizedEelapsedTime <=1.0){
		elapsedTime = (Time.time - startTime);
		normalizedEelapsedTime = elapsedTime/fadeTime;
		lerpedColor = Color.Lerp(startColor, restColor, normalizedEelapsedTime);
		lightComponent.color = lerpedColor;
		yield;
	}
	lightComponent.color = restColor;
}

