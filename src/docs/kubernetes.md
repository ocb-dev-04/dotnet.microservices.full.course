## Kubernetes docs

To create a deploy with a kubernetes file, get to K8S path and type:

```cmd
kubectl apply -f [file-name].yaml
```

Show all kubernetes deployment created:

```cmd
kubectl get deployments
```

Show all kubernets running:

```cmd
kubectl get pods
```

Delete some running deployment:

```cmd
kubectl delete deployments [deployment-name]
```