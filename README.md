#### Overview

The following is my implementation of the [Backend Project for Coterie.](https://github.com/CoterieInsure/backend-takehome)

##### High-level diagram of Quote Rating API

![](https://raw.githubusercontent.com/ErikKierstead/Coterie-Backend-Project/main/QuoteRatingAPI%20Flow.png?token=AAZ6SN4IZBTZ7WO7BG62WOTBXRG7O)

Please note I did take some extra time on the README and diagram to demonstrate my documentation experience.

#### Required Tools and Software

* Visual Studio 2019, Postman, and .NET 5 Runtime

#### Cloning and Running the Quote Ratings API

1. Clone the Quote Ratings Api project from Github
2. Run the QuoteRatingsApi.sln in Visual Studio 2019 using IIS Express

A browser should now launch and is required to remain open while Visual Studio is running the API.  

Use port that browser launches with in future URLs.

#### Testing API

Swagger and Postman may be used to test API.

* Swagger:  http://localhost:11365/swagger/index.html
* Quote Rating API endpoint: POST http://localhost:11365/api/quoteRating

HTTPs has been disabled for testing convenience.

##### Request Body:  Raw JSON

```
{
   "revenue" :0,
   "state" : "FL",
   "business": Architect"
}
```

Constraints:

* State: FL, OH, TX
* Business: Architect, Plumber, Programmer
* Revenue:  Min and max values for double

A validation error is expected when values exceed constraints.

##### Swagger Instructions

Swagger launches in browser when the program is running.

1. Select POST and 'Try Me'
2. Configure Request Body and select 'Execute'

##### Postman Instructions

1. Launch the Postman application and add a new tab (+)
2. Set URL to POST http://localhost:11365/api/quoteRating
3. Select body tab, configure Request Body, and select 'Send'

#### What I Would Do Next

With the limited time it was my intention to demonstrate due care when organizing a new application.

The greatest challenge was having little accounting domain knowledge which may impact meaningful class names and caused a hesitancy to create a Repository project.

##### API Versioning

* Research.  Adjust routes, actions, and Swagger as necessary

##### Unit Testing

* Create UnitTests folder under solution and a project for non-WebApi projects (i.e. Service.UnitTests)
* Install NSubsitute, MSTest, and AutoFixture packages
* Create [Class]Tests.cs for each class tested
* Create test methods to test public constructors, properties, and methods

##### Repository

If algorithm values are retrieved via EF Core or an API we can create repositories to wrap them.

* Create Repository project with repositories and inject into QuoteRatingEngine
* Even without a solid schema I would move values out of QuoteRatingEngine into repository for demo

##### Validation, Swagger, and Error Handling

* Research into best practices

##### Replace the IQuoteCalculator in QuoteRatingEngine

* This pattern is likely not appropriate for the problems this engine will ultimately be solving
