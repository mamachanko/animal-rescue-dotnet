#!/usr/bin/env bash

set -euo pipefail


docker run \
  --rm \
  --name animaldb \
  --publish 5432:5432 \
  --env POSTGRES_DB=animaldb \
  --env POSTGRES_PASSWORD=secret \
  postgres:12.5

