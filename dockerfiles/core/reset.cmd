docker kill aspcore
docker rm aspcore
net stop docker
net start docker
docker rmi aspcore
docker build -t aspcore .
create