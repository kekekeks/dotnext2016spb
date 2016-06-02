echo ON
docker create --hostname=classicweb --name classicweb -v c:\docker\data\classic:c:\external -p 83:80 classicweb