#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base

WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

WORKDIR /src

ADD atlas.crt /usr/local/share/ca-certificates/atlas.crt
RUN chmod 644 /usr/local/share/ca-certificates/atlas.crt && update-ca-certificates
RUN apt-get update && apt-get install -y curl   && curl -sL https://deb.nodesource.com/setup_10.x | bash -   && apt-get install -y nodejs   && curl -L https://www.npmjs.com/install.sh | sh
RUN apt remove -y cmdtest
RUN apt remove -y yarn
RUN curl -sS https://dl.yarnpkg.com/debian/pubkey.gpg |  apt-key add -
RUN echo "deb https://dl.yarnpkg.com/debian/ stable main" | tee /etc/apt/sources.list.d/yarn.list
RUN apt-get update
RUN apt-get install -y yarn
COPY ["AtlasWeb/Core/Core.csproj", "AtlasWeb/Core/"]
COPY ["ATLASDEV/AtlasModel/AtlasModel.csproj", "ATLASDEV/AtlasModel/"]
COPY ["ATLASDEV/AtlasEnums/AtlasEnums.csproj", "ATLASDEV/AtlasEnums/"]
COPY ["ATLASDEV/ArGeAssembly/ArGeAssembly.csproj", "ATLASDEV/ArGeAssembly/"]
COPY ["ATLASDEV/TTObjectClasses/TTObjectClasses.csproj", "ATLASDEV/TTObjectClasses/"]
COPY ["ATLASDEV/AtlasDataModel/AtlasDataModel.csproj", "ATLASDEV/AtlasDataModel/"]
COPY ["DynamicForms/DynamicForms.csproj", "DynamicForms/"]
COPY ["AtlasWeb/Infrastructure/Infrastructure.csproj", "AtlasWeb/Infrastructure/"]
COPY ["Utils/SutKuralService/RuleChecker.Engine/RuleChecker.Engine.csproj", "Utils/SutKuralService/RuleChecker.Engine/"]
COPY ["Utils/SutKuralService/RuleChecker.Interface/RuleChecker.Interface.csproj", "Utils/SutKuralService/RuleChecker.Interface/"]
COPY ["AtlasDataSource/AtlasDataSource.csproj", "AtlasDataSource/"]
COPY ["ReportClasses/ReportClasses.csproj", "ReportClasses/"]
COPY ["ATLASDEV/TTObjectClassesReports/TTObjectClassesReports.csproj", "ATLASDEV/TTObjectClassesReports/"]
COPY ["Utils/SutKuralService/RuleChecker.Service/RuleChecker.Service.csproj", "Utils/SutKuralService/RuleChecker.Service/"]
COPY ["DashboardClasses/DashboardClasses.csproj", "DashboardClasses/"]
COPY ["ATLASDEV/TTLogisticsAssembly/TTLogisticsAssembly.csproj", "ATLASDEV/TTLogisticsAssembly/"]
COPY ["ATLASDEV/TTHospitalAssembly/TTHospitalAssembly.csproj", "ATLASDEV/TTHospitalAssembly/"]
COPY ["HealthInsurance/HealthInsurance.csproj", "HealthInsurance/"]
COPY ["ATLASDEV/TTLogisticsAssemblyReports/TTLogisticsAssemblyReports.csproj", "ATLASDEV/TTLogisticsAssemblyReports/"]

COPY ./AtlasWeb/Core/packageProd.json ./AtlasWeb/Core/package.json
COPY ./AtlasWeb/Core/ngcc.config.js ./AtlasWeb/Core/ngcc.config.js
RUN dotnet restore "AtlasWeb/Core/Core.csproj" -s http://atlasbagetserver:5555/v3/index.json -s https://api.nuget.org/v3/index.json 

WORKDIR /src
COPY . .
WORKDIR "/src/AtlasWeb/Core"
RUN dotnet build "Core.csproj" -c Release -o /app/build 

FROM build AS publish
RUN dotnet publish "Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN apt update
RUN apt install -y libgdiplus libc6 libc6-dev
RUN apt install -y fontconfig libharfbuzz0b libfreetype6

ENV TZ=Turkey/XXXXXX
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "Core.dll"]