#!/usr/bin/env bash

set -euo pipefail

dotnet test

git push

