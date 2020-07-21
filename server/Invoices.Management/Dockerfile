#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Invoices.Management/Invoices.Management.csproj", "Invoices.Management/"]
COPY ["Invoices.Shared/Invoices.Shared.csproj", "Invoices.Shared/"]
RUN dotnet restore "Invoices.Management/Invoices.Management.csproj"
COPY . .
WORKDIR "/src/Invoices.Management"
RUN dotnet build "Invoices.Management.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Invoices.Management.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Invoices.Management.dll"]