#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RealtimeOrders.Client.Console/RealtimeOrders.Client.Console.csproj", "RealtimeOrders.Client.Console/"]
RUN dotnet restore "RealtimeOrders.Client.Console/RealtimeOrders.Client.Console.csproj"
COPY . .
WORKDIR "/src/RealtimeOrders.Client.Console"
RUN dotnet build "RealtimeOrders.Client.Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RealtimeOrders.Client.Console.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RealtimeOrders.Client.Console.dll"]