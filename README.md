# ThreadDemoCSharp


## Building Docker Image:
docket build -t thread-demo -f Dockerfile .



## Running Docker Image (80 -> 7210 on the host):
docker run -ti --rm -p 7210:80 --name thdemo thread-demo
