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
                    def dotnetInstalled = sh(script: 'dotnet --version || echo "not installed"', returnStdout: true).trim()
                    if (dotnetInstalled == "not installed") {
                        sh 'wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh'
                        sh 'chmod +x dotnet-install.sh'
                        sh './dotnet-install.sh --channel 8.0'
                    }
                }
            }
        }

        stage('Restore Dependencies') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release --no-restore'
            }
        }

        stage('Run Tests') {
            steps {
                sh 'dotnet test --configuration Release --no-build --logger trx'
            }
        }

        stage('Publish') {
            steps {
                sh 'dotnet publish -c Release -o ${BUILD_DIR}'
                archiveArtifacts artifacts: "${BUILD_DIR}/**", fingerprint: true
            }
        }

        stage('Deploy') {
            steps {
                echo "Implementar lógica de deploy aqui (ex: cópia para servidor, Docker, Kubernetes, etc.)"
            }
        }
    }
}
