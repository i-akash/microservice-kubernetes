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

# Delete all pv
kubectl delete pv --all

# Delete all pvc
kubectl delete pvc --all

# Delete all services
kubectl delete configmap --all

# Delete all secret
kubectl delete secret --all


echo Cleanup completed.