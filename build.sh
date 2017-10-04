#!/usr/bin/env bash

# build server
cd server

# build DXConfig.Server
pushd DXConfig.Server

pwd
ls
dotnet restore
dotnet build

popd

# test DXConfig.Server
pushd Test.Server

pwd
ls
dotnet restore
dotnet test


