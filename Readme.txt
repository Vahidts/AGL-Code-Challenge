# AGL Code challenge
#Vahid Salari
#Programming challenge
A json web service has been set up at the url: http://agl-developer-test.azurewebsites.net/people.json

You need to write some code to consume the json and output a list of all the cats in alphabetical order under a heading of the gender of their owner.

You can write it in any language you like. You can use any libraries/frameworks/SDKs you choose.

Example:
Male
	Angel
	Molly
	Tigger
Female
	Gizmo
	Jasper
	Notes

Submissions will only be accepted via github or bitbucket
Use industry best practices
Use the code to showcase your skill.
A json web service has been set up at the url: http://agl-developer-test.azurewebsites.net/people.json
You need to write some code to consume the json and output a list of all the cats in alphabetical order under a heading of the gender of their owner.
You can write it in any language you like. You can use any libraries/frameworks/SDKs you choose.
Link: http://agl-developer-test.azurewebsites.net/

************************************************
************************************************
************************************************

## Solution
Solution is implmented as .Net Core Console Application with Visual Studio 2019.
Architecture of the project is a monolith application and consist of following projects:

Core:
AGL.Application: Application logic and model.interfaces for repository and services
AGL.Domain: Enterprise model.

AGL.InfraStructure: Implementation of Repositories that retrieve the data from provided web services.
AGL.Presentation.UI: Starting point and Presentation layer of the application that call the application layer method and
presnet the data as desired format.

In order to run the application in 
Run Agl.Presentation.UI.exe application with desired pet type:

Agl.Presentation.UI.exe cat 


Test:
AGL.IntegrationTest

Includes an end-end test for the program.

AGL.UnitTests
Includes a series of unit test that test logic of the code and validation upon a test data.


Technologies:
.Net Core Dependency Injection
FluentValidation for validation.
Logging with Log4net
using Moq to  Mocking the external services(e.g webservices)


