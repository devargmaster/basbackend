# Bas Backend (Challenge)

Este proyecto incluye una solución .NET para la API `Bas Backend` y servicios relacionados.

## Variables sensibles

Para evitar exponer contraseñas en el archivo `docker-compose.yml`, se utilizan variables de entorno cargadas desde un archivo `.env` (no versionado). Se provee un ejemplo en `.env.sample`.

1. Copia `.env.sample` a `.env` y ajusta los valores de acuerdo a tu entorno.
2. Ejecuta `docker compose up` normalmente; Docker Compose leerá las variables desde `.env`.

```
cp .env.sample .env
# editar .env con tus valores
```

Estas variables se referencian en `docker-compose.yml` mediante la sintaxis `${VARIABLE}`.

