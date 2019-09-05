FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["TCC.BackEnd.API.ComunicacaoSeguranca/TCC.BackEnd.API.ComunicacaoSeguranca.csproj", "TCC.BackEnd.API.ComunicacaoSeguranca/"]
RUN dotnet restore "TCC.BackEnd.API.ComunicacaoSeguranca/TCC.BackEnd.API.ComunicacaoSeguranca.csproj"
COPY . .
WORKDIR "/src/WTCC.BackEnd.API.ComunicacaoSeguranca"
RUN dotnet build "TCC.BackEnd.API.ComunicacaoSeguranca.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TCC.BackEnd.API.ComunicacaoSeguranca.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TCC.BackEnd.API.ComunicacaoSeguranca.dll"]