pipeline {
  agent any
  stages {
    stage ('Clean workspace') {
      steps {
        cleanWs()
      }
    }
    stage('Restore Nuget Dependencies') {
      steps {
        bat '"C:\\Program Files\\dotnet\\dotnet.exe" restore "D:\\Users\\victo\\Documents\\GitHub\\BaseCSharpSelenium\\SeleniumTest_Alpha.sln"'
      }
    }
    stage('Execute Tests') {
     steps {
      bat '"C:\\Program Files\\dotnet\\dotnet.exe" test'
     }
    }    
    stage('Publish Reports') {
     steps {
      allure includeProperties: false, jdk: '', results: [[path: 'SeleniumTestLocal\\bin\\Debug\\netcoreapp3.1\\allure-results']]
     }
    }
  }
}