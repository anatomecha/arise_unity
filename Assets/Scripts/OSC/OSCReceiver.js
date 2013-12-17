
//You can set these variables in the scene because they are public 
public var RemoteIP : String = "127.0.0.1";
public var SendToPort : int = 37337;
public var ListenerPort : int = 37337;
public var controller : Transform; 
private var handler : Osc;
public static var msgList = new Array();

// Use this for initialization
public function Start () {
	//make sure this game object has both UDPPackIO and OSC script attached
	var udp : UDPPacketIO = GetComponent("UDPPacketIO");
	udp.init(RemoteIP, SendToPort, ListenerPort);
	handler = GetComponent("Osc");
	handler.init(udp);
	handler.SetAllMessageHandler(DefaultHandler);
}
	
public function DefaultHandler(oscMessage : OscMessage) : void
{	
	//print(oscMessage);
	// pushing every single message onto the queue is being really slow, we just
	// want the most recent message.
	msgList.Add(oscMessage);
	// msgList[0] = oscMessage;
}


