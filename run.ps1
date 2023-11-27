cd ./java_proto
mvn clean install
cd ../
cd ./location_service/
Start-Process mvn spring-boot:run
cd ..
cd ./user_service/
Start-Process mvn spring-boot:run
cd ..
cd ./packet_service/
Start-Process mvn spring-boot:run
cd ..
cd ./authentication_provider/grpc
Start-Process dotnet run
cd ..
cd..
cd ./gateway/gateway
Start-Process dotnet run
cd ..
cd..