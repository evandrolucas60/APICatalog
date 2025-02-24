pipeline {
    agent any
    tools {
        jdk 'JAVA21LTS' // Nome do JDK configurado no Jenkins
    }
    stages {
        stage("Cloning ApiCatalog Project") {
            steps {
                git url: 'https://github.com/evandrolucas60/APICatalog.git', branch: 'main'
            }
        }
        
        stage("Build and Restore Dependencies") {
            steps {
                bat 'dotnet restore'
                bat 'dotnet build --configuration Release'
            }
        }
        
        stage("Code Quality - Analyze with SonarQube") {
            environment {
                scannerHome = tool 'SonarQubeScanner'
            }
            steps {
                withSonarQubeEnv(credentialsId: 'sonarqubeToken', installationName: 'SonarQube') {
                    bat """
                        ${scannerHome}/bin/sonar-scanner \
                            -Dsonar.projectKey=ApiCatalog \
                            -Dsonar.projectName=ApiCatalog \
                            -Dsonar.projectVersion=1.0 \
                            -Dsonar.sources=.
                    """
                }
            }
        }
        
        stage("Run Tests") {
            steps {
                bat 'dotnet test --configuration Release'
            }
        }
    }
}
