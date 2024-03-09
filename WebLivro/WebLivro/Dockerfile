FROM mcr.microsoft.com/dotnet/sdk:8.0
EXPOSE 80

COPY ["/bin/Release/net8.0/publish", "app"]

ENTRYPOINT [ "dotnet","app/WebLivro.dll"]