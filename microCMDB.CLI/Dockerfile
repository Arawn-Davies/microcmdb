#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY . .

RUN dotnet restore

RUN dotnet build "microCMDB.CLI.csproj" -c $BUILD_CONFIGURATION -o /app/build

RUN dotnet publish "microCMDB.CLI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Use the .NET runtime image as the final base image
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Install SSH server
RUN apt-get update && apt-get install -y openssh-server
RUN mkdir /var/run/sshd

# Configure SSH
RUN echo 'root:docker' | chpasswd
RUN sed -i 's/#PermitRootLogin prohibit-password/PermitRootLogin yes/' /etc/ssh/sshd_config

# Expose SSH port
EXPOSE 22

# Start SSH service and the microCMDB.CLI application
CMD ["/usr/sbin/sshd", "-D"]

#ENTRYPOINT ["dotnet", "microCMDB.CLI.dll"]