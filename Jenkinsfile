pipeline {
  agent any
  stages {
    stage ('Git Checkout') {
      steps {
        git branch: 'test', credentialsId: '5dfe18e3-6fea-484f-9693-96c3bd62057e', url: 'https://github.com/minhtuanqn/RestAPIWithDotNet.git'
      }
    }
    stage('Clean') {
      steps {
      bat 'dotnet clean'
      echo 'clean is done'
      }
    }
    stage('Build') {
        steps {
        bat 'dotnet build --configuration Release'
        echo 'build is done'
      }
    }
  }
}
