#Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /source
COPY . .
RUN dotnet restore "./BookManagement/BookManagement.csproj" --disable-parallel
RUN dotnet publish "./BookManagement/BookManagement.csproj" -c release -o /app --no-restore

#Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet","BookManagement.dll","--environment=Development"]
