FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["TCC.IdentityServer/TCC.IdentityServer.csproj", "TCC.IdentityServer/"]
RUN dotnet restore "TCC.IdentityServer/TCC.IdentityServer.csproj"
COPY . .
WORKDIR "/src/TCC.IdentityServer"
RUN dotnet build "TCC.IdentityServer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TCC.IdentityServer.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TCC.IdentityServer.dll"]