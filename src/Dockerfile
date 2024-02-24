# Use the official ASP.NET Core runtime image
# See https://hub.docker.com/_/microsoft-dotnet-aspnet/ for other versions
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

# Use the official SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["BlazorMailW3.Server/BlazorMailW3.Server.csproj", "BlazorMailW3.Server/"]
COPY ["BlazorMailW3.Client/BlazorMailW3.Client.csproj", "BlazorMailW3.Client/"]
COPY ["BlazorMailW3.Shared/BlazorMailW3.Shared.csproj", "BlazorMailW3.Shared/"]
RUN dotnet restore "BlazorMailW3.Server/BlazorMailW3.Server.csproj"

# Copy the rest of the source code
COPY . .
WORKDIR "/src/BlazorMailW3.Server"
RUN dotnet build "BlazorMailW3.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorMailW3.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorMailW3.Server.dll"]
