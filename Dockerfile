# -------- BUILD STAGE --------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file
COPY MySolution.slnx .

# Copy csproj files individually (important for caching)
COPY MySolution.API/MySolution.API.csproj MySolution.API/    
COPY MySolution.Application/MySolution.Application.csproj MySolution.Application/
COPY MySolution.Domain/MySolution.Domain.csproj MySolution.Domain/
COPY MySolution.Infrastructure/MySolution.Infrastructure.csproj MySolution.Infrastructure/

# Restore
RUN dotnet restore MySolution.API/MySolution.API.csproj

# Copy full source
COPY . .

# Publish API project
RUN dotnet publish MySolution.API/MySolution.API.csproj -c Release -o /app/publish

# -------- RUNTIME STAGE --------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "MySolution.API.dll"]