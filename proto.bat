cd ./Tool/Protos

protoc -I="./" --csharp_out="../../proto/" --grpc_out="../../proto/" --plugin=protoc-gen-grpc=C:\Users\khw1_\vcpkg\installed\x64-windows\tools\grpc\grpc_csharp_plugin.exe ./*

cd ../../proto

ROBOCOPY ./ "../My project (4)\Assets\Scripts\proto" /E

ROBOCOPY ./ "../GrpcService1\proto" /E

pause