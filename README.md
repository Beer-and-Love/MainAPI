# MainAPI
# API under development in C# .NET

## Implementations currently being tested:

## 1
Method that calculates the distance of the user in relation to other users in the chosen city, using the Haversine formula.

## 2
Method to keep Location up to date: Receive (from Client) Updated Location containing latitude and longitude, to update in correct user extracts authentication token ID. Search the user, update in the Database. '

## Project configuration

To use these methods in your own project, follow the steps below:

To run the API locally, you can follow these steps:

Install the .NET 6 SDK on your machine. You can download it here: https://dotnet.microsoft.com/download/dotnet/6.0

Clone the project repository on your local machine. Make sure you have an up-to-date copy of the source code.

Open a terminal or command prompt in the project's root folder.

Run the following command to restore project dependencies:

```sh
dotnet restore
```


Then run the command below to compile the project:

```sh
dotnet construction
```

If the build is successful, you can run an API using the following command:

```sh
dotnet run --project <path to project>
```


Be sure to replace "<path to project>" with the relative or absolute path to your API project file.

The API will now be running locally on your computer. You can access it in your browser or an API testing tool using the address: http://localhost:5000.

To stop the API from running, just press Ctrl + C in the terminal or command prompt where the API is running.
You will need to add a connectionstring and set password and login to generate Jwt Token.

## Contribution

If you want to contribute to this project, feel free to fork the repository and submit a pull request with your improvements.

Be sure to follow coding and documentation best practices.
## Contact

If you have any questions or suggestions related to this project, feel free to contact us.
