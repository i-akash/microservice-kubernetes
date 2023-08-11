
#initiate kubeadm 
sudo kubeadm init --control-plane-endpoint "kubecluster.westus2.cloudapp.azure.com:6443" --upload-certs


#make kubeadm config available
mkdir -p $HOME/.kube
sudo cp -i /etc/kubernetes/admin.conf $HOME/.kube/config
sudo chown $(id -u):$(id -g) $HOME/.kube/config