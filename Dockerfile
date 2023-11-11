FROM mcr.microsoft.com/dotnet/sdk:7.0

WORKDIR /app

COPY . .

RUN dotnet restore
RUN dotnet publish -c Release -o out

EXPOSE 80

CMD ["dotnet", "out/todo-backend.dll"]