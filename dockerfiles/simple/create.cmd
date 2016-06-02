echo ON
docker create --hostname=simple --name simple -v c:\docker\data\simple:c:\external -p 81:80 simple