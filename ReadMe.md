# GARRATA File Processing API
Dotnet Core REST API project for securely processing uploaded JSON files using Dotnet 10

## Run locally
- You may use VS Code
- Install Dotnet 10 SDK
- In your IDE, open the project folder GARRATA_09242026
- Open VS Code integrated terminal, change directory to GARRATA_09242026
- In the terminal, run this command: dotnet watch
- In your browser, open this URL: http://localhost:5019/swagger

## Run with Docker
- Install Docker Desktop
- Run and verify Docker Desktop is running
- In VS Code, open the project and change directory to GARRATA_09242026
- Build the image using this command: docker build -t garrata api .
- Run the container using this command: docker run --name garrata-api-container -p 8080:8080 garrata-api
- In your browsr, open this URL: http://localhost:8080/swagger

## Run with Docker (if there are code changes)
- docker build -t garrata-api .
- docker rm -f garrata-api-container
- docker run --name garrata-api-container -p 8080:8080 garrata-api
- In your browsr, open this URL: http://localhost:8080/swagger

## API Testing
- In Swagger UI, expand the api process endpoint then click the Try it out button
- An option to upload a file will appear, click Choose File button
- Browse the root folder of GARRATA_09242026 folder and select the file test.json
- After file is uploaded click execute button then api will return a response
