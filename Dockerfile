FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

COPY Ao3Api.sln .
COPY Ao3Api/*.csproj ./Ao3Api/
COPY Ao3Domain/*.csproj ./Ao3Domain/
RUN dotnet restore

COPY . .
RUN dotnet publish -c debug -o /app --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 
WORKDIR /app
COPY --from=build /app .
COPY Ao3Api/Mock /app/Mock
ENTRYPOINT ["dotnet", "Ao3Api.dll"]