# BlazorGraphTraining
Company training for GraphQL and Blazor.

There is no production propose for this proyect. It's a learning project using the last technologies, so multiple mistakes can be commited by the author (me).

# How to run it?
You need to have installed docker and docker swarm because this proyect is deployed using services. Once is installed, execute the 'deploy.sh' script.
The first time, database will take long to install, the service has retries for this porpose, once the database is deployed, the next try it will connect and everything will work fine and all the structure will be automatically created.
