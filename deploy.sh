#!/bin/bash
export LOCAL_DIR="$PWD"

export STACK_NETWORK=training_local

IS_NET_HERE=`docker network ls | grep "$STACK_NETWORK " | wc -l`;

if [ "$IS_NET_HERE" -eq 0 ]
then
    echo "[network.sh] Network $STACK_NETWORK will be created"
    docker network create --attachable -d overlay ${STACK_NETWORK}
else
    echo "[network.sh] Network $STACK_NETWORK yet created"
fi

echo "Deploying"
docker stack deploy -c ${LOCAL_DIR}/docker-compose.yml training
