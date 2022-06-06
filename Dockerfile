# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Debug -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
# RUN apt-get update; \
# 	apt-get install -y --no-install-recommends \
# 		curl
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "cloud-fishing.dll", "--environment", "Production"]
EXPOSE 80
