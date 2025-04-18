# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copia o csproj e restaura dependências
COPY *.sln .
COPY TesteDesenvolvimento/*.csproj ./TesteDesenvolvimento/
RUN dotnet restore

# Copia o restante do código e compila
COPY . .
WORKDIR /app/TesteDesenvolvimento
RUN dotnet publish -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/publish .

# Expõe a porta 80 (ou o que você usar)
EXPOSE 80

# Comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "TesteDesenvolvimento.dll"]
