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
        stage("Code Quality") {
            steps {
                script {
                    def scannerHome = tool 'SonarScanner for .NET'
                    withSonarQubeEnv() {
                        // Execute the SonarScanner begin command with the correct source directory
                        bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll begin /k:\"evandrolucas60_APICatalog_626c6022-c8ad-4b91-9744-99fce1c27a16\" /d:sonar.sources=\"APICatalog\" /d:sonar.exclusions=\"**/appsettings.Development.json, **/appsettings.json\""
                        
                        // Execute the build command for the correct .csproj
                        bat "dotnet build"

                        // Execute the SonarScanner end command
                        bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll end"
                    }
                }
            }
        }
       stage("Security Testing") {
            steps {
                script {
                    dependencyCheckAnalyzer(
                        scanPath: '.', 
                        outdir: 'dependency-check-report', 
                        suppressionFile: '', 
                        failOnError: false, 
                        isAutoupdateDisabled: false
                    )
                }

                publishHTML([
                    allowMissing: false, 
                    alwaysLinkToLastBuild: false, 
                    keepAll: false, 
                    reportDir: 'dependency-check-report', 
                    reportFiles: 'dependency-check-report.html', 
                    reportName: 'Dependency Check Report', 
                    reportTitles: ''
                ])
            }
        }
        stage("Run Tests") {
            steps {
                bat 'dotnet test --configuration Release'
            }
        }
    }
}
