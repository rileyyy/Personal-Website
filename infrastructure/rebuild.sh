#!
systemctl stop website-control.service
docker compose pull
systemctl start website-control.service