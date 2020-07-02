# Cálculo de Juros
Repositório para cálculo de juros.

### Deploy local utilizando Docker.

1. Criar a imagem: 
```
docker build -t calculo-juros .
```
2. Criar o container:
```
docker container run -p 5000:80 calculo-juros:latest
```
Acessar a URL: 'http://localhost:5000'.




