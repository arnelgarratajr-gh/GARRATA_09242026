# GARRATA File Processing API
Dotnet Core REST API project for securely processing uploaded JSON files using Dotnet 10. There are two options to run the app (Docker or Local)

## Option 1: Run with Docker (Preferred)
- Install Docker Desktop
- Run and verify Docker Desktop is running
- In VS Code, open the project and change directory to GARRATA_09242026
- Build the image using this command: docker build -t garrata-api .
- Run the container using this command: docker run --name garrata-api-container -p 8080:8080 -e ApiKey=dev-only-api-key garrata-api
- In your browsr, open this URL: http://localhost:8080/swagger

## Option 2: Run locally
- You may use VS Code
- Install Dotnet 10 SDK
- In your IDE, open the project folder GARRATA_09242026
- Open VS Code integrated terminal, change directory to GARRATA_09242026
- In the terminal, run this command: dotnet watch
- In your browser, open this URL: http://localhost:5019/swagger

## API Testing
- In Swagger UI, expand the api process endpoint then click the Try it out button
- Click the **Authorize** button, enter the API key, and click **Authorize**
- An option to upload a file will appear, click Choose File button
- Browse the root folder of GARRATA_09242026 folder and select the file test.json
- After file is uploaded click execute button then api will return a response

## Run with Docker (if there are code changes)
- docker build -t garrata-api .
- docker rm -f garrata-api-container
- docker run --name garrata-api-container -p 8080:8080 -e ApiKey=dev-only-api-key garrata-api
- In your browsr, open this URL: http://localhost:8080/swagger

## API endpoints
### Process a file
```http
POST /api/FileProcessing/process
```

The endpoint requires the `X-API-Key` request header. The development key is
`dev-only-api-key`. For Docker, override it with the `ApiKey` environment
variable instead of using this example key.

Example request header:

```http
X-API-Key: dev-only-api-key
```

Example input:

```json
[
  { "id": 1, "name": "Desk", "active": true },
  { "id": 2, "name": "Office Chair", "active": false },
  { "id": 3, "name": "Keyboard", "active": true },
  { "id": 4, "name": "Desk Lamp", "active": false },
  { "id": 5, "name": "Monitor", "active": true }
]
```

Example response:

```json
{
  "message": "JSON file processed successfully.",
  "fileName": "office-items.json",
  "totalRecords": 5,
  "matchingRecords": 3,
  "records": [
    { "id": 1, "name": "Desk", "active": true },
    { "id": 3, "name": "Keyboard", "active": true },
    { "id": 5, "name": "Monitor", "active": true }
  ]
}
