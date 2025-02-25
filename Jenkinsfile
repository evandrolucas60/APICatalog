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
        
        stage("SonarQube Analysis") {
            steps {
                script {
                    def scannerHome = tool 'SonarScanner for .NET'
                    withSonarQubeEnv() {
                        // Execute the SonarScanner begin command with the correct source directory
                        bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll begin /k:\"evandrolucas60_APICatalog_d53fc9b9-89b8-4ea7-944e-ae66c349b1a2\" /d:sonar.sources=\"ApiCatalogo\" /d:sonar.exclusions=\"**/appsettings.Development.json\""

                        
                        // Execute the build command for the correct .csproj
                        bat "dotnet build ApiCatalogo/ApiCatalogo.csproj --configuration Release"

                        // Execute the SonarScanner end command
                        bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll end"
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
