FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

ENV ConnectionStrings__DefaultConnection="Host=dpg-d41p7v15pdvs73bdpg5g-a.oregon-postgres.render.com;Database=bdclientes_0bav;Username=admin;Password=UVw94ftbVgKc7yFm9yzOytQqOOJCmm23"

ENTRYPOINT ["dotnet", "MeuProjeto.dll"]
