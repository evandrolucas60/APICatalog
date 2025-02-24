pipeline {
    agent any
    environment {
        SONARQUBE = 'SonarQube'  // Nome do servidor SonarQube configurado no Jenkins
        SONAR_LOGIN = credentials('squ_7c507bb55b0b0a88cd18ba04ba3ec9175ae649c2')  // Token do SonarQube armazenado no Jenkins
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
            steps {
                script {
                    // Inicia a análise do SonarQube
                    bat "dotnet sonarscanner begin /k:\"project-key\" /d:sonar.login=\"${SONAR_LOGIN}\""
                    bat 'dotnet build'
                    bat "dotnet sonarscanner end /d:sonar.login=\"${SONAR_LOGIN}\""
                }
            }  // Fechando corretamente o bloco 'steps'
        }
        stage("Run Tests") {
            steps {
                bat 'dotnet test --configuration Release'
            }
        }
    }
}
