FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/BarberEaseApi/BarberEaseApi.csproj", "src/BarberEaseApi/"]
RUN dotnet restore "src/BarberEaseApi/BarberEaseApi.csproj"

COPY . .

WORKDIR "/src/src/BarberEaseApi"
RUN dotnet publish "BarberEaseApi.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "BarberEaseApi.dll"]
