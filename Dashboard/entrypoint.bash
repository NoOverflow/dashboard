#!/bin/bash

set -e

export PATH="$PATH:/root/.dotnet/tools"

dotnet ef migrations add InitialMigration

until dotnet ef database update
do
    >&2 echo "SQL Server is starting up"
    sleep 1
done

>&2 echo "SQL Server is up - executing command"

cd /app/publish
dotnet Dashboard.dll