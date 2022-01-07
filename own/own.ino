#include <ESP8266WiFi.h>
#include <WiFiClient.h>

#include <PubSubClient.h>

const char* ssid = "GPONWIFI_8168";//put your wifi network name here
const char* password = "00000018C3";//put your wifi password here




WiFiClient espClient;
PubSubClient client(espClient);

int SensorState;
int p=16;

// current temperature & humidity, updated in loop()
float t = 30.0;
float h = 40.0;

const char* mqtt_server = "broker.hivemq.com";

void setup() 
{
  Serial.begin(9600);
pinMode(p, OUTPUT);
  

  setup_wifi();
  client.setServer(mqtt_server, 1883);
  client.setCallback(MQTTcallback);
  

  
}

void setup_wifi() {
   delay(100);
  // We start by connecting to a WiFi network
    Serial.print("Connecting to ");
    Serial.println(ssid);
    WiFi.begin(ssid, password);
    while (WiFi.status() != WL_CONNECTED) 
    {
      delay(500);
      Serial.print(".");
    }
  Serial.println("");
  Serial.println("WiFi connected");
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());
}

void reconnect() {
  // Loop until we're reconnected
  while (!client.connected()) 
  {
    Serial.print("Attempting MQTT connection...");
    // Create a random client ID
    String clientId = "ESP8266Client-";
    clientId += String(random(0xffff), HEX);
    // Attempt to connect
    //if you MQTT broker has clientID,username and password
    //please change following line to    if (client.connect(clientId,userName,passWord))
    if (client.connect(clientId.c_str()))
    {
      Serial.println("connected");
     //once connected to MQTT broker, subscribe command if any
      client.subscribe("/home/Device");
    } else {
      Serial.print("failed, rc=");
      Serial.print(client.state());
      Serial.println(" try again in 5 seconds");
      // Wait 6 seconds before retrying
      delay(6000);
    }
  }
} //end reconnect()

void MQTTcallback(char* topic, byte* payload, unsigned int length) {
 
  Serial.print("Message arrived in topic: ");
  Serial.println(topic);
 
  Serial.print("Message:");

  String message;
  for (int i = 0; i < length; i++) {
    message = message + (char)payload[i];  //Conver *byte to String
  }
   Serial.print(message);
  if(message == "10") {digitalWrite(p,LOW);}   //LED on  
  if(message == "11") {digitalWrite(p,HIGH);} //LED off
 
  Serial.println();
  Serial.println("-----------------------");  
}
void loop() 
{
//MQTTcallback();
    if (!client.connected()) {
      reconnect();
    }
    client.loop();
    
    String msg="{\"temperature\":";
     msg= msg+ t;
     msg = msg+",\"humidity\":" ;
     msg=msg+h ;
     msg=msg+"}";
     char message[58];
     msg.toCharArray(message,58);
    client.publish("/AHXPD/arduino", message);

    delay(10000);
  
}
