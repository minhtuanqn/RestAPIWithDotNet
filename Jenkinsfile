pipeline {
  agent any
  stages {
    stage ('Clean workspace') {
      steps {
        cleanWs()
      }
    }
    stage ('Git Checkout') {
      steps {
        git branch: 'test', credentialsId: '5dfe18e3-6fea-484f-9693-96c3bd62057e', url: 'https://github.com/minhtuanqn/RestAPIWithDotNet.git'
      }
    }
    stage('Running unit tests') {
      steps {
        sh "dotnet dev-certs https --trust"
        sh "dotnet test  ${workspace}/Staff_Management_test/StaffManagement.UnitTest/StaffManagement.UnitTest.csproj"
      }        
    }
  }
}
