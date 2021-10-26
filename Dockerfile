# #See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
# WORKDIR /app
# EXPOSE 5000/tcp

# FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
# WORKDIR /src
# COPY ["Web/Web.csproj", "Web/"]
# COPY ["Data/Data.csproj", "Data/"]
# COPY ["Core/Core.csproj", "Core/"]
# RUN dotnet restore "Web/Web.csproj"
# COPY . .
# WORKDIR "/src/Web"
# RUN dotnet build "Web.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "Web.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /publish
# #COPY --from=publish /app/publish .
# COPY ./publish /publish
# ENTRYPOINT ["dotnet", "Web.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Web/Web.csproj", "Web/"]
COPY ["Data/Data.csproj", "Data/"]
COPY ["Core/Core.csproj", "Core/"]
RUN dotnet restore "Web/Web.csproj"
COPY . .
WORKDIR "/src/Web"
RUN dotnet build "Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.dll"]