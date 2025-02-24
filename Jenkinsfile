pipeline {
    agent any
    stages {
        stage("Cloning ApiCatalog Project") {
            steps {
                git url: 'https://github.com/evandrolucas60/APICatalog.git', branch: 'main'
            }
        }
        stage("Restore Dependencies") {
            steps {
                // Restaurar as dependências do projeto .NET
                bat 'dotnet restore'
            }
        }
        stage("Build") {
            steps {
                // Construir o projeto .NET
                bat 'dotnet build --configuration Release'
            }
        }
        stage("Test") {
            steps {
                // Rodar os testes do projeto .NET
                bat 'dotnet test --configuration Release'
            }
        }
        stage("Publish") {
            steps {
                // Publicar o projeto para produção (criar artefatos para deploy)
                bat 'dotnet publish --configuration Release --output ./publish'
            }
        }
    }
}
