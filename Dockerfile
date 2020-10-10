FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS runtime
WORKDIR /app
EXPOSE 80


# copy and publish app and libraries
COPY . ./


RUN dotnet restore ./hacka-getnet/hacka-getnet.sln
RUN dotnet build ./hacka-getnet/hacka-getnet.sln --no-restore -c Release

RUN dotnet publish ./hacka-getnet/hacka-getnet.sln -c Release -o published


CMD ASPNETCORE_URLS=http://*:$PORT dotnet published/hacka-getnet.dll
