# SEP3 

<h3 align="left">Languages and Tools:</h3>
<a href="https://git-scm.com/" target="_blank"> <img src="https://www.vectorlogo.zone/logos/git-scm/git-scm-icon.svg" alt="git" width="40" height="40">
<a href="https://www.postgresql.org" target="_blank"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/postgresql/postgresql-original-wordmark.svg" alt="postgresql" width="40" height="40"><a href="https://spring.io/" target="_blank"> <img src="https://www.vectorlogo.zone/logos/springio/springio-icon.svg" alt="spring" width="40" height="40">
<a href="https://www.rabbitmq.com/" target="_blank"> <img src="https://github.com/cosmindemian/SEP3/assets/114725463/5f4b2a0f-94a8-48ae-bae3-4c292521ad4b" alt="spring" width="40" height="40">
<a href="https://www.java.com" target="_blank" > <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/java/java-original.svg" alt="java" width="40" height="40">
<a href="https://www.w3schools.com/cs/" target="_blank"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40">
<a href="https://getbootstrap.com" target="_blank"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/bootstrap/bootstrap-plain-wordmark.svg" alt="bootstrap" width="40" height="40"> 
<a href="https://www.w3schools.com/css/" target="_blank"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/css3/css3-original-wordmark.svg" alt="css3" width="40" height="40">
<a href="https://www.w3.org/html/" target="_blank"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/html5/html5-original-wordmark.svg" alt="html5" width="40" height="40">
<a href="https://maven.apache.org/" target="_blank"> <img src="https://github.com/cosmindemian/SEP3/assets/114725463/fc644644-265d-4893-b215-b960fd049d94" alt="maven" width="60" height="40"></a>
<a href="https://gradle.org/" target="_blank"> <img src="https://www.vectorlogo.zone/logos/gradle/gradle-icon.svg" alt="gradle" width="40" height="40"></a>

## Configuration

#### 1. Java Microservices
To run the java microservices you need to have application.properties file in location_service, packet_service, user_service (..\src\main\resources\application.properties).

```
spring.datasource.url= ${your_database_url}
spring.datasource.username= {your_username}
spring.datasource.password= {your_pass}
spring.jpa.properties.hibernate.dialect=org.hibernate.dialect.PostgreSQLDialect
spring.jpa.hibernate.ddl-auto=create
grpc.server.port= {your_port}
```
(Use different ports for every service)
```
packet_service port = 9091
location_service port = 9092
user_service port = 9093
```
#### 2. Proto files
- Run maven clean install in java_proto.
- Open gateway and build CSharpProto.

#### 4. Authentication_provider.
Open Authentication_provider
Create a “Config” folder in persistence.
Inside the folder, create class “DatabaseConfig” with the following constants:
```
public const string Host = "localhost";
public const string Name = "postgres";
public const string Password = "database_password";
public const string Database = "postgres";
```
Run “dotnet ef database update” through the terminal in persistence.

#### 5.  RabbitMQ 
- Create a new exchange “notification_exchange” 
- In queues and streams create a new queue called “notification”;

#### 6. Roles
- To run the application, “Roles” table needs a default value.
- In “authentication_provider” schema, in the table Roles (if it does not exist, create it) then add the following values:
  
| Id  | Name  |
| --- | ----- |
| 1   | user  |
| 2   | Admin |

If you want to use admin features (like creating/deleting a location), you have to change your account role in the database, to reflect that you are an Admin (Credentials table/RoleId to the Admin roleId).~

