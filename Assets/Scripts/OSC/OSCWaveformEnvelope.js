public var scaleObject : GameObject;
public var channel = 1;
public var iterations : int = 23;
public var gain = 40.0;
public var moveVector = Vector3(1, 0, 0);
public var spinVector = Vector3(0, 0, 0);

private var minScaleImpulse : float = 0.01;
private var newLastScale : float = 0.0;
private var lastScale : float = 0.0;
private var scaleImpulse : float = 0.0;
private var scaleObjects = new Array();
private var orientation : Vector3;

function Start () {
	var initialParent = scaleObject.transform.parent;
	scaleObjects[0] = scaleObject;
	for(i=1; i<iterations; i++) {
		scaleObjects.push(Instantiate(scaleObject));
		scaleObjects[i].transform.parent = initialParent;
		scaleObjects[i].transform.localPosition = Vector3(moveVector.x*i, moveVector.y*i, moveVector.z*i);
	}
}

function FixedUpdate () {
	
	lastScale = scaleObjects[0].transform.localScale.y;
	scaleObjects[0].transform.localScale.y = scaleImpulse * gain;
	for(i=1; i<scaleObjects.length; i++) {
		newLastScale = scaleObjects[i].transform.localScale.y;
		scaleObjects[i].transform.localScale.y = lastScale;
		lastScale = newLastScale;
		orientation = scaleObjects[i].transform.localEulerAngles;
		scaleObjects[i].transform.localEulerAngles = Vector3( (orientation.x+ spinVector.x), (orientation.y+ spinVector.y), (orientation.z+spinVector.z));
	}
	
	// smoothly fade out the peak impulse to prevent strobing
	if(scaleImpulse > minScaleImpulse) {
		scaleImpulse += -0.01; 
	}	
	else {
		scaleImpulse = minScaleImpulse;
	}
}

function OSCAudioEnvelope (input) {
	if(input.channel == channel){
		scaleImpulse = input.envelope;
	}
}

