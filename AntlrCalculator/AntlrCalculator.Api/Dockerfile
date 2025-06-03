FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Install Java (needed for ANTLR)
RUN apt-get update && apt-get install -y default-jre

# Copy csproj files and restore dependencies
COPY ["AntlrCalculator.Api/AntlrCalculator.Api.csproj", "AntlrCalculator.Api/"]
COPY ["AntlrCalculator.WinForms/AntlrCalculator.WinForms.csproj", "AntlrCalculator.WinForms/"]
RUN dotnet restore "AntlrCalculator.Api/AntlrCalculator.Api.csproj" -r linux-x64

# Copy the rest of the code
COPY . .

# Build the application
RUN dotnet build "AntlrCalculator.Api/AntlrCalculator.Api.csproj" -c Release -o /app/build -r linux-x64 --no-restore

# Publish the application
FROM build AS publish
RUN dotnet publish "AntlrCalculator.Api/AntlrCalculator.Api.csproj" -c Release -o /app/publish -r linux-x64 --no-restore --self-contained false

# Final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=publish /app/publish .

# Set environment variables
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 80

ENTRYPOINT ["dotnet", "AntlrCalculator.Api.dll"] 