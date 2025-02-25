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
        
        stage('SonarQube Analysis') {
    def scannerHome = tool 'SonarScanner for .NET'
    withSonarQubeEnv() {
      bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll begin /k:\"evandrolucas60_APICatalog_d53fc9b9-89b8-4ea7-944e-ae66c349b1a2\""
      bat "dotnet build"
      bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll end"
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
