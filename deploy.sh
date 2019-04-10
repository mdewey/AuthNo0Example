# powershell
dotnet publish -c Release 

# powershell
cp dockerfile ./bin/release/netcoreapp2.2/publish

# docker cli
docker build -t sdg-foobar-image ./bin/release/netcoreapp2.2/publish

# docker cli
docker tag sdg-foobar-image registry.heroku.com/sdg-foobar/web

# docker cli
docker push registry.heroku.com/sdg-foobar/web

# powershell
heroku container:release web -a sdg-foobar

# sudo chmod 755 deploy.sh
# ./deploy.sh