# Use the official .NET Core SDK as a base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Set the working directory
WORKDIR /app

# Copy the project files to the working directory
COPY . ./

# Build the application
RUN dotnet publish -c Release -o out

# Create a runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

# Copy the published output from build image
COPY --from=build-env /app/out .

# Expose the port the app runs on
EXPOSE 5092

# Define the entry point for the application
ENTRYPOINT ["dotnet", "api-project.dll"]
