FROM dysnomia/netcore-sdk-3-1 AS build-env
WORKDIR /app

# Build Project
COPY . ./
RUN dotnet sonarscanner begin /k:"howtoopen-me" /d:sonar.host.url="***REMOVED***" /d:sonar.login="***REMOVED***" /d:sonar.cs.opencover.reportsPaths="**/coverage.opencover.xml" /d:sonar.coverage.exclusions="**Test*.cs"
RUN dotnet restore Dysnomia.HowToOpenMe.sln
RUN dotnet publish Dysnomia.HowToOpenMe.sln -c Release -o out
RUN dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
RUN dotnet sonarscanner end /d:sonar.login="***REMOVED***"

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Dysnomia.HowToOpenMe.WebApp.dll"]