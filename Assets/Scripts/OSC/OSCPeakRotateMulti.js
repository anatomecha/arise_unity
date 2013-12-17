var oscPeakObjects : OSCPeakRotateObject[];


class OSCPeakRotateObject {
	public var peakObject : GameObject;
	public var channel : int = 1;
	public var minVector : Vector3;
	public var maxVector : Vector3;
}


function OSCAudioEnvelope (input) {
	for(oscPeakObject in oscPeakObjects) {
		if(input.channel == oscPeakObject.channel) {
			oscPeakObject.peakObject.transform.localEulerAngles =  Vector3.Lerp(oscPeakObject.minVector, oscPeakObject.maxVector, input.envelope);
		}
	}
}

