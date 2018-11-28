dotnet publish -c Release 

cp dockerfile ./bin/release/netcoreapp2.1/publish

docker build -t quicklee-api-image ./bin/release/netcoreapp2.1/publish

docker tag quicklee-api-image  registry.heroku.com/quicklee/web

docker push registry.heroku.com/quicklee/web

heroku container:release web -a quicklee