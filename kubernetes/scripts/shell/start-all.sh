# echo build images

# docker build -f ./AuthAPI/Dockerfile -t i7akash/auth-api:latest .
# docker build -f ./PaymentAPI/Dockerfile -t i7akash/payment-api:latest .
# docker build -f ./ShipmentAPI/Dockerfile -t i7akash/shipment-api:latest .

# echo push images to dockerhub

# docker push i7akash/auth-api:latest
# docker push i7akash/payment-api:latest
# docker push i7akash/shipment-api:latest

cd ./AuthAPI/kubernetes
kubectl apply -f .
cd ../../

cd ./PaymentAPI/kubernetes
kubectl apply -f .
cd ../../

cd ./ShipmentAPI/kubernetes
kubectl apply -f .
cd ../../

cd ./Rabbit/kubernetes
kubectl apply -f .
cd ../../

cd ./ElasticSearch/kubernetes
kubectl apply -f .
cd ../../

# cd ./FluentD/kubernetes
# kubectl apply -f .
# cd ../../