echo ON
docker create --hostname=aspcore --name aspcore -v c:\docker\data\core:c:\external -p 84:80 aspcore