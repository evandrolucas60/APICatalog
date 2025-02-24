pipeline {
    agent any

    environment {
        DOTNET_VERSION = '8.0'
        BUILD_DIR = 'publish'
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Setup .NET') {
            steps {
                script {
                    def dotnetInstalled = bat(script: 'dotnet --version', returnStdout: true).trim()
                    if (dotnetInstalled.contains("'dotnet' is not recognized")) {
                        bat 'curl -o dotnet-install.ps1 https://dot.net/v1/dotnet-install.ps1'
                        bat 'powershell -ExecutionPolicy Bypass -File dotnet-install.ps1 -Channel ${DOTNET_VERSION}'
                        env.PATH = "C:\\Users\\${env.USERNAME}\\.dotnet;${env.PATH}"
                        env.DOTNET_ROOT = "C:\\Users\\${env.USERNAME}\\.dotnet"
                    }
                }
            }
        }

        stage('Restore Dependencies') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release --no-restore'
            }
        }

        stage('Run Tests') {
            steps {
                bat 'dotnet test --configuration Release --no-build --logger "trx;LogFileName=test_results.trx" --collect:"XPlat Code Coverage"'
                archiveArtifacts artifacts: '**\\TestResults\\test_results.trx', fingerprint: true
            }
        }

        stage('Publish') {
            steps {
                bat 'dotnet publish -c Release -o ${BUILD_DIR} --self-contained false'
                archiveArtifacts artifacts: "${BUILD_DIR}\\**", fingerprint: true
            }
        }
     
    }
}
