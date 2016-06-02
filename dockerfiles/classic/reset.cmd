docker kill classicweb
docker rm classicweb
net stop docker
net start docker
docker rmi classicweb
docker build -t classicweb .
create