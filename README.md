# A demo project for GraphQL
[![Travis Build](https://img.shields.io/travis/com/hamster21/graphql-showcase.svg?style=plastic)](https://travis-ci.com/HaMster21/graphql-showcase) [![Docker Cloud Automated build](https://img.shields.io/docker/cloud/automated/hamster21/graphql-showcase.svg?style=plastic)](https://cloud.docker.com/repository/docker/hamster21/graphql-showcase)

This is an example project of building a single webshop API using GraphQL and ASP.NET Core.

## GraphiQL playground

You can play around with GraphQL and this schema by using the prebuilt docker image. You'd need a working docker environment for this.

```
docker run --rm -i -p 5000:5000 hamster21/graphql-showcase
```

Point your browser to `http://localhost:5000/graphiql/` afterwards to get a visual client to the API.