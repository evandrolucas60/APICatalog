pipeline {
    agent any
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
                scannerHome = tool 'SonarQubeScanner';
            }
            steps {
              withSonarQubeEnv(credentialsId: 'sonarqubeToken', installationName: 'SonarQube') {
                bat "${scannerHome}/bin/sonar-scanner"
              }
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
