#build phase
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
WORKDIR /source

# Copy csproj and restore as distinct layers
COPY /. ./
RUN dotnet restore "WebAPI/WebAPI.csproj"

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /src/output

#Run phase
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /source
EXPOSE 80
COPY --from=build /src/output .

ENTRYPOINT [ "dotnet","WebAPI.dll" ]