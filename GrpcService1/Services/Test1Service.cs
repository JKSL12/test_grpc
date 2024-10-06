using Grpc.Core;
using GrpcService1;

namespace GrpcService1.Services
{
    public class Test1Service : Test1.Test1Base
    {
        private readonly ILogger<Test1Service> _logger;
        public Test1Service(ILogger<Test1Service> logger)
        {
            _logger = logger;
        }

        public override async Task SayTest(TestRequest request, IServerStreamWriter<TestReply> responseStream, ServerCallContext context)
        {
            int i = 0;
            while (i < 10)
            {
                await responseStream.WriteAsync(new TestReply() { Message = i.ToString() });
                await Task.Delay(TimeSpan.FromSeconds(1), context.CancellationToken);
                i++;
            }
        }
    }
}
