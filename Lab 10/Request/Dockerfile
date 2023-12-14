FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Requesr/Requesr.csproj", "Requesr/"]
RUN dotnet restore "Requesr/Requesr.csproj"
COPY . .
WORKDIR "/src/Requesr"
RUN dotnet build "Requesr.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Requesr.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Requesr.dll"]
