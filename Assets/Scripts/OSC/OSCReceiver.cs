using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OSCReceiver : MonoBehaviour 
{
	public string RemoteIP = "127.0.0.1";
	public int SendToPort = 37337;
	public int ListenerPort = 37337;
	public Transform controller; 
	private Osc handler;
	public static List<OscMessage> msgList;
	
	void Start () {
		//make sure this game object has both UDPPackIO and OSC script attached
		UDPPacketIO udp = GetComponent<UDPPacketIO>();
		udp.init(RemoteIP, SendToPort, ListenerPort);
		handler = GetComponent<Osc>();
		handler.init(udp);
		handler.SetAllMessageHandler(DefaultHandler);
		msgList = new List<OscMessage>();
	}
		
	public void DefaultHandler(OscMessage oscMessage)
	{	
		//print(oscMessage);
		// pushing every single message onto the queue is being really slow, we just
		// want the most recent message.
		msgList.Add(oscMessage);
		// msgList[0] = oscMessage;
	}
}