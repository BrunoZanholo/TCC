FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["WTCC.BackEnd.API.ComunicacaoSeguranca/WTCC.BackEnd.API.ComunicacaoSeguranca.csproj", "WTCC.BackEnd.API.ComunicacaoSeguranca/"]
RUN dotnet restore "WTCC.BackEnd.API.ComunicacaoSeguranca/WTCC.BackEnd.API.ComunicacaoSeguranca.csproj"
COPY . .
WORKDIR "/src/WTCC.BackEnd.API.ComunicacaoSeguranca"
RUN dotnet build "WTCC.BackEnd.API.ComunicacaoSeguranca.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WTCC.BackEnd.API.ComunicacaoSeguranca.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WTCC.BackEnd.API.ComunicacaoSeguranca.dll"]