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
    stage('Restore packages') {
      steps {
        sh "dotnet restore ${workspace}\\Staff_Management_test\\StaffManagement.sln"
      }
    }
    stage('Clean') {
      steps {
        sh "msbuild.exe ${workspace}\\Staff_Management_test\\StaffManagement.sln" /nologo /nr:false /p:platform=\"x64\" /p:configuration=\"release\" /t:clean"
      }
    }
    stage('Running unit tests') {
      steps {
        sh "dotnet test  ${workspace}/Staff_Management_test/StaffManagement.UnitTest/StaffManagement.UnitTest.csproj"
      }        
    }
  }
}
