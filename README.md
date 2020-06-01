# AGL Coding Challenge

This is a .NET Core Web API solution for sorting pet names and categorizing them under the gender of their owners.

## Problem Definition

A json web service has been set up at the url: `http://agl-developer-test.azurewebsites.net/people.json` which returns a list of people and their pets. The solution should return a result with the names of all cats alphabetically sorted under the gender of their owner. 

For example, the People API returns a list of the following JSON schema : 
```
[
   {
      "name":"Bob",
      "gender":"Male",
      "age":23,
      "pets":[
         {
            "name":"Garfield",
            "type":"Cat"
         },
         {
            "name":"Fido",
            "type":"Dog"
         }
      ]
   },
   {
      "name":"John",
      "gender":"Male",
      "age":21,
      "pets":[
         {
            "name":"Max",
            "type":"Cat"
         },
         {
            "name":"June",
            "type":"Cat"
         }
      ]
   }
]
```

Then the solution should return/print :
```
Male
    - Garfield
    - June
    - Max
```

## Solution

A Web Api solution written in .NET Core 3.1 which fetches the JSON response from the URL provided and lists the names of cats sorted in ascending order of their names categorized under the gender of their respective owners. 

The result will be of the following schema : 
```
[
  {
    "ownerGender": "Male",
    "petNames": [
      "string"
    ]
  },
  {
    "ownerGender": "Female",
    "petNames": [
      "string"
    ]
  }
]

```

## API Documentation
The Swagger documentation for this API has been hosted at the home page on launch here : `https://localhost:44330/index.html`. The endpoint can also be tested via the Swagger UI hosted in the same path. 

The open api swagger documentation can be downloaded as JSON here : `https://localhost:44330/swagger/v1/swagger.json` 

## Tools used
The Web API has been developed using these : 
- [Newtonsoft.Json](https://www.newtonsoft.com/json)
- [Serilog.AspNetCore](https://github.com/serilog/serilog-aspnetcore)
- [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)

## Testing 
Unit tests have been written using 
- [Xunit](https://github.com/xunit/xunit)  
- [NSubstitute](https://nsubstitute.github.io/) and
- [FluentAssertions](https://fluentassertions.com/introduction)

Test data is created following a _test builder pattern_ for easy readability and extensibility.

## Coverage

100% unit test coverage for the business logic. 

![Code Coverage](/images/codeCoverage.JPG)