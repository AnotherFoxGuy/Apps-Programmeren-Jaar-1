#include <SPI.h>
#include <Ethernet.h>

String data;
byte mac[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };  
IPAddress ip(192, 168, 1, 10);  //fallback ipadress
EthernetServer server(8000);   //server port

void setup()
{
  Serial.begin(9600);

  //no dhcp >> use ip given above
  if (Ethernet.begin(mac) == 0) {
    Serial.println("No DHCP");
    Ethernet.begin(mac, ip);
  }
  
  server.begin();
  Serial.print("Server ip is: "); Serial.println(Ethernet.localIP());
}

void loop()
{
  EthernetClient client = server.available();
  if (client) {
    Serial.println("New client connected");
    while (client.connected()) {
      if (client.available()) {
        //recive data
        char c = client.read();
     
        if (c == ';'){
          Serial.println(data);
          
          //send data
          char buffer [1024];
          sprintf (buffer, "Interval updated to %d", data.toInt());
          Serial.println(buffer);
          server.write(buffer);
          data = "";
          client.stop();
        }
        else{
          data += c;
        }
      }
    }
    Serial.println("Client disconnected");
  }
}
