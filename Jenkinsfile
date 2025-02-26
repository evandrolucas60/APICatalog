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
                        bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll begin /k:\"evandrolucas60_APICatalog_11270973-3978-4580-a9ec-0d3a8e107c43\" /d:sonar.sources=\"APICatalog\" /d:sonar.exclusions=\"**/appsettings.Development.json, **/appsettings.json\""
                        
                        // Execute the build command for the correct .csproj
                        bat "dotnet build"

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
