
# Weekdays Service API

This is a lambda api that calculates the number of weekdays between two given dates 'from' and 'to'.

The application is based on the aws serverless application model (SAM) and is written in C# and runs on .net core framework 3.1


# Build instructions
- To build and package this solution run following netcore commands from .\weekdays-api\src\weekdays directory

- To zip the packaged source files into \weekdays-api\src\weekdays\bin\Release\netcoreapp3.1\weekdays.zip run:
- dotnet lambda package 

- To run tests run following commands from .\weekdays-api\test\weekdays.Tests directory
- dotnet test


# Deployment instructions. 

  - Create an s3 bucket for the source code of your lambda by running following command from \weekdays-api\src\weekdays directory: 
  - aws s3 mb s3://weekdayscfs3bucket --region ap-southeast-2

  - To prepare the package for the deployment to CF and to transform the template.yml run:
  - aws cloudformation package --template-file ./template.yml --output-template-file sam-template.yml --s3-bucket weekdayscfs3bucket

  - To deploy the packaged source code to aws lambda using CF run:
  - aws cloudformation deploy --template-file ./sam-template.yml --stack-name weekdays-api --capabilities CAPABILITY_IAM

  
# Testing instructions. 
 - The api can be tested using postman.
 - In order to test make a simple get call with the 'from' and 'to' values as parameters:

   GET https://[host url]/Prod/v1/default?from=01/01/2020&to=05/01/2020  

 - The above call will return 1

 - The api may be run locally and when started from the VS debug menu it will be listening on    http://localhost:5000/v1/default. The following calls may be used for testing locally:
 
 https://localhost:5000/Prod/v1/default?from=01/01/2020&to=05/01/2020 
 
