#!/usr/bin/env bash

set -euxo pipefail

mkdir animal-rescue
cd animal-rescue

dotnet new gitignore

dotnet new sln --name AnimalRescue
dotnet new webapi --name AnimalRescueApi --no-https
dotnet sln AnimalRescue.sln add AnimalRescueApi
dotnet new xunit --name AnimalRescueApiIntegrationTests
dotnet sln AnimalRescue.sln add AnimalRescueApiIntegrationTests/
dotnet add AnimalRescueApiIntegrationTests reference AnimalRescueApi

dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool update --global dotnet-aspnet-codegenerator

pushd AnimalRescueApi
  dotnet add package Microsoft.EntityFrameworkCore.SqlServer
  dotnet add package Microsoft.EntityFrameworkCore.InMemory
  dotnet aspnet-codegenerator controller -name AnimalController -async -api -m Animal -outDir Controllers
popd

pushd AnimalRescueApiIntegrationTests
  dotnet add AnimalRescueApiIntegrationTests.csproj package Microsoft.AspNetCore.Mvc.Testing
popd
