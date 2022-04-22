### Docker docs

Know docker version just type:

```cmd
docker --version
```

Make a image form a dockerfile:

```cmd
docker build -t ocb04dev/image_name .
```

Run a specific image just:

```cmd
docker run -p 8080:8080 -d ocb04dev/image_name
```

Push docker image to hub just type:
    
```cmd
docker push ocb04dev/image_name
```

Show running containers:

```cmd
docker ps
```

Stop a specific container:

```cmd
docker stop container_id
```

