# CalcService
Web Service providing REST API for basic Math Operations

## Prerequisits
- .NET 8.0 (Core)
- Docker

## Build

- From solution directory run
'cmd
docker build -f .\CalcService\Dockerfile -t calcservice:latest .

## Run

'cmd
docker run -d -p 8080:8080 calcservice:latest

## Test

### Healtcheck
http://localhost:8080/_health

### Swagger UI
http://localhost:8080/swagger/index.html