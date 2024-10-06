using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcService1;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("http://10.200.205.9:5044");
var client = new Greeter.GreeterClient(channel);

while (true)
{
    var reply = client.SayHelloAsync(
                  new HelloRequest { Name = "GreeterClient" });

}

Console.WriteLine("Press any key to exit...");
//Console.ReadKey();