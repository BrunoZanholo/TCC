FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["TCC.BackEnd.API.Monitoramento/TCC.BackEnd.API.Monitoramento.csproj", "TCC.BackEnd.API.Monitoramento/"]
RUN dotnet restore "TCC.BackEnd.API.Monitoramento/TCC.BackEnd.API.Monitoramento.csproj"
COPY . .
WORKDIR "/src/TCC.BackEnd.API.Monitoramento"
RUN dotnet build "TCC.BackEnd.API.Monitoramento.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TCC.BackEnd.API.Monitoramento.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TCC.BackEnd.API.Monitoramento.dll"]