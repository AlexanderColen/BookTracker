FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["BookTracker/BookTracker.csproj", "BookTracker/"]
RUN dotnet restore "BookTracker/BookTracker.csproj"
COPY . .
WORKDIR "/src/BookTracker"
RUN dotnet build "BookTracker.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BookTracker.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BookTracker.dll"]