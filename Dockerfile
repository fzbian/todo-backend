FROM mcr.microsoft.com/dotnet/sdk:7.0

WORKDIR /app

COPY . .

RUN dotnet publish -c Release -o out

EXPOSE 80

CMD ["dotnet", "out/TodoBackend.dll"]
