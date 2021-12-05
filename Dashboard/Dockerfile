#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/sdk:6.0

EXPOSE 5000

WORKDIR /src
COPY ["Dashboard/Dashboard.csproj", "Dashboard/"]
RUN dotnet restore "Dashboard/Dashboard.csproj"
COPY . .
WORKDIR "/src/Dashboard"
RUN dotnet build "Dashboard.csproj" -c Release -o /app/build

RUN dotnet publish "Dashboard.csproj" -c Release -o /app/publish

RUN dotnet tool install --global dotnet-ef
RUN dotnet add package Blazor.ContextMenu

RUN chmod +x ./entrypoint.bash
CMD /bin/bash ./entrypoint.bash