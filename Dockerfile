FROM microsoft/dotnet:3.0-sdk AS build-env
WORKDIR /app

# a /app dirbe a l2l.sln-t
COPY l2l.sln ./l2l.sln 
COPY l2l.Data/l2l.Data.csproj ./l2l.Data/l2l.Data.csproj
COPY l2l.Data.Tests/l2l.Data.Tests.csproj ./l2l.Data.Tests/l2l.Data.Tests.csproj

RUN dotnet restore

COPY . ./
RUN dotnet test -v n