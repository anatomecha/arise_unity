public var channel : int = 1;
public var fftObjects : GameObject[];
private var gain : float = .5;

function OSCfft (input) {
	if(input.channel == channel) {
		for(i=0; i<24; i++) {
			fftObjects[i].transform.localScale.y = input.ranges[i] *gain;
		}
	}
}

