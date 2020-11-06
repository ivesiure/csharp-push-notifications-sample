using System.Net;
using Newtonsoft.Json;

namespace YberaParis_PushMessages
{

  class Program
  {
    private const string FcmServerKey = "{FIREBASE_SERVER_KEY}";
    
    private const string FcmDeviceToken = "{DEVICE_TOKEN}";

    private const string ServiceUrl = "https://fcm.googleapis.com/fcm/send";

    static void Main(string[] args)
    {
      using (WebClient client = new WebClient())
      {
        client.Headers.Add("Content-Type", "application/json");
        client.Headers.Add("Authorization", $"key={FcmServerKey}");

        string body = JsonConvert.SerializeObject(new
        {
          to = FcmDeviceToken,
          notification = new
          {
            title = "Título da mensagem",
            body = "Corpo da mensagem",
            mutable_content = true,
            sound = "Tri-tone"
          }
        });

        client.UploadString(ServiceUrl, body);
      }
    }
  }
}
