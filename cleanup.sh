echo Deleting all deployments and pods...

# Delete all deployments
kubectl delete deployment --all

# Delete all statefulset
kubectl delete statefulset --all --cascade=background

# Delete all pods
kubectl delete pod --all

# Delete all ingress
kubectl delete ingress --all

# Delete all services
kubectl delete service --all

echo Cleanup completed.