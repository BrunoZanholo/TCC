FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["TCC.BackEnd.API.CadastrosAtivos/TCC.BackEnd.API.CadastrosAtivos.csproj", "TCC.BackEnd.API.CadastrosAtivos/"]
RUN dotnet restore "TCC.BackEnd.API.CadastrosAtivos/TCC.BackEnd.API.CadastrosAtivos.csproj"
COPY . .
WORKDIR "/src/TCC.BackEnd.API.CadastrosAtivos"
RUN dotnet build "TCC.BackEnd.API.CadastrosAtivos.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TCC.BackEnd.API.CadastrosAtivos.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TCC.BackEnd.API.CadastrosAtivos.dll"]