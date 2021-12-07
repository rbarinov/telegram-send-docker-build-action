FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TelegramSendDockerBuildAction/TelegramSendDockerBuildAction.csproj", "TelegramSendDockerBuildAction/"]
RUN dotnet restore "TelegramSendDockerBuildAction/TelegramSendDockerBuildAction.csproj"
COPY . .
WORKDIR "/src/TelegramSendDockerBuildAction"
RUN dotnet build "TelegramSendDockerBuildAction.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TelegramSendDockerBuildAction.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "/app/TelegramSendDockerBuildAction.dll"]
