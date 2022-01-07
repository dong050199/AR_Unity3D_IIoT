using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using System.Text;
using System;

public class ButtonHandler : MonoBehaviour
{
	private MqttClient client;
	public Text Device1, Device2, Device3, Device4, Device5;
	bool dev1, dev2, dev3, dev4, dev5;
	public Button btn1, btn2, btn3, btn4, btn5;

	//client = new MqttClient("broker.hivemq.com",1883 , false , null );

//them function nay vao event click cua unity se duoc dashboard can thiet.
	public void Deviceone()
	{
		client = new MqttClient("broker.hivemq.com", 1883, false, null);
		

		string clientId = Guid.NewGuid().ToString();
		client.Connect(clientId);
		if (dev1)
		{
			btn1.GetComponent<Image>().color = Color.green;
			dev1 = false;
			Device1.text = "Pump 1 Turned On";

			client.Publish("donglvtn1", Encoding.UTF8.GetBytes("{\"P1_RUN_BT_SV\":true}"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,true); 


		}
		else
		{
			btn1.GetComponent<Image>().color = Color.red;
			dev1 = true;
			Device1.text = "Pump 1 Turned Off";
			

			client.Publish("donglvtn1", Encoding.UTF8.GetBytes("{\"P1_STOP_BT_SV\":true}"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,true);

		}
	}

 

	public void Devicetwo()
	{
		if (dev2)
		{
			btn2.GetComponent<Image>().color = Color.green;
			dev2 = false;
			Device2.text = "Pump 3 Turned On";

            client.Publish("donglvtn1", Encoding.UTF8.GetBytes("{\"P3_RUN_BT_SV\":true}"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }
		else
		{
			btn2.GetComponent<Image>().color = Color.red;
			dev2 = true;
			Device2.text = "Pump 3 Turned Off";

            client.Publish("donglvtn1", Encoding.UTF8.GetBytes("{\"P3_STOP_BT_SV\":true}"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }
	}
	public void Devicethree()
	{
		if (dev3)
		{
			btn3.GetComponent<Image>().color = Color.green;
			dev3 = false;
			Device3.text = "Pump 2 Turned On";

            client.Publish("donglvtn1", Encoding.UTF8.GetBytes("{\"P2_RUN_BT_SV\":true}"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }
		else
		{
			btn3.GetComponent<Image>().color = Color.red;
			dev3 = true;
			Device3.text = "Pump 2 Turned Off";

            client.Publish("donglvtn1", Encoding.UTF8.GetBytes("{\"P2_STOP_BT_SV\":true}"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }

	}

	public void Devicefour()
	{
		if (dev4)
		{
			btn4.GetComponent<Image>().color = Color.green;
			dev4 = false;
			Device4.text = "Pump 4 Turned On";

            client.Publish("donglvtn1", Encoding.UTF8.GetBytes("{\"P4_RUN_BT_SV\":true}"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }
		else
		{
			btn4.GetComponent<Image>().color = Color.red;
			dev4 = true;
			Device4.text = "Pump 4 Turned Off";

            client.Publish("donglvtn1", Encoding.UTF8.GetBytes("{\"P4_STOP_BT_SV\":true}"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }
	}

    public void Devicefive()
    {
        if (dev5)
        {
            btn5.GetComponent<Image>().color = Color.green;
            dev5 = false;
            Device5.text = "Manual Enable";

            client.Publish("donglvtn1", Encoding.UTF8.GetBytes("{\"MAN_BT_SV\":true}"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }
        else
        {
            btn5.GetComponent<Image>().color = Color.red;
            dev5 = true;
            Device5.text = "Manual Disable";

            client.Publish("donglvtn1", Encoding.UTF8.GetBytes("{\"AUTO_BT_SV\":true}"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }
    }




}
