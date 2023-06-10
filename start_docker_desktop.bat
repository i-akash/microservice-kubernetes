@echo off

echo Starting Docker Desktop...
start "" "C:\Program Files\Docker\Docker\Docker Desktop.exe"


echo Starting minikube...
minikube start

echo minikube tunnel...
minikube tunnel