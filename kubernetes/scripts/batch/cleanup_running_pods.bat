@echo off

echo Deleting all deployments and pods...

REM Delete all deployments
kubectl delete deployment --all

kubectl delete statefulset --all --cascade=true

REM Delete all pods
kubectl delete pod --all

kubectl delete ingress --all

REM Delete all services
kubectl delete service --all

echo Cleanup completed.