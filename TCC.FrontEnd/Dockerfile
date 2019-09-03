FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["TCC.FrontEnd/TCC.FrontEnd.csproj", "TCC.FrontEnd/"]
RUN dotnet restore "TCC.FrontEnd/TCC.FrontEnd.csproj"
COPY . .
WORKDIR "/src/TCC.FrontEnd"
RUN dotnet build "TCC.FrontEnd.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TCC.FrontEnd.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TCC.FrontEnd.dll"]