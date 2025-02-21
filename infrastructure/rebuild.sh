#!
systemctl stop website-control.service
docker-compose build
systemctl start website-control.service