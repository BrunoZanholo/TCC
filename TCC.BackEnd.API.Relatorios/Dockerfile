FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["TCC.BackEnd.API.Relatorios/TCC.BackEnd.API.Relatorios.csproj", "TCC.BackEnd.API.Relatorios/"]
RUN dotnet restore "TCC.BackEnd.API.Relatorios/TCC.BackEnd.API.Relatorios.csproj"
COPY . .
WORKDIR "/src/TCC.BackEnd.API.Relatorios"
RUN dotnet build "TCC.BackEnd.API.Relatorios.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TCC.BackEnd.API.Relatorios.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TCC.BackEnd.API.Relatorios.dll"]