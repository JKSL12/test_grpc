using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using GrpcService1;
using GrpcService1.Services;
using System.Net.Http;
using UnityEngine;

public class Test : MonoBehaviour
{
    GrpcChannel channel;
    private Greeter.GreeterClient client;
    private Test1.Test1Client clientTest;

    // Start is called before the first frame update
    void Start()
    {
        channel = GrpcChannel.ForAddress("http://10.200.205.9:5044", new GrpcChannelOptions
        {
            HttpHandler = new GrpcWebHandler(new HttpClientHandler())
        });

        clientTest = new Test1.Test1Client(channel);
        client = new Greeter.GreeterClient(channel);
        //var reply = client.SayHello(new HelloRequest { Name = "unity" });
        //Debug.Log(reply.ToString());

        var reply = clientTest.SayTest(new TestRequest { Id = 1, Name = "nnn" });

        while(reply.ResponseStream.MoveNext().Result)
        {
            var i = reply.ResponseStream.Current;

            Debug.Log(i.Message); 
        }
    }

    private void OnDestroy()
    {
       // channel.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F1))
        {
            var reply = client.SayHelloAsync(new HelloRequest { Name = "unity" });
            Debug.Log(reply.ToString());
        }
    }
}
