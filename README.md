# Cloud City API

By Hannah Young

A web API that allows users to store and retrieve information about Cloud City's districts and locations.

## Technologies Used

- C#
- .NET
- MySQL
- Entity Framework
- Swagger/OpenAPI

## Description

This is a web API that showcases my ability to develop an ASP.NET Core API with a robust backend attached to a MySQL database through Entity Framework.

----------------
## Setup

### Requirements

* [git](https://git-scm.com)
* [.NET](https://dotnet.microsoft.com/en-us/)
* [MySQL](https://www.mysql.com/)

### To Start Web API

1. Download and install the [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) as required for your system. Be sure to add the .NET sdk to your PATH
2. Use terminal to navigate to desired parent directory and use `git clone https://github.com/Corgibyte/cloud-city.git CloudCity.Solution`
3. Navigate into the project directory nested inside the .Solution directory: `cd CloudCity.Solution/CloudCity`
4. Create an appsettings.json file: `touch appsettings.json`
5. Edit the new appsettings.json file and add the following, making sure to replace the indicated sections with your MySQL user ID and password:
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=hannah_young;uid=[YOUR MYSQL USER ID];pwd=[YOUR PASSWORD];"
  }
}
```
6. Back in the terminal, in the CloudCity directory build the project: `dotnet restore`
7. Create database from migration data: `dotnet ef database update`
8. Run project: `dotnet run`

### Accessing the Web API

API endpoints can be accessed using a client such as [Postman](https://www.postman.com/) or programatically using your own client. Endpoint testing can also be performed on the Swagger documentation accessed at `http://localhost:5000/swagger`

--------------------

## Endpoints

|Usage | METHOD       | URL       | Params |
| :--------| :------------| :---------| :------|
|Get all Districts | GET    | `http://localhost:5000/api/districts` | |
|Get specific District | GET    | `http://localhost:5000/districts/{id}` | |
|Create District | POST    | `http://localhost:5000/districts/` | District<sup>*</sup> |
|Edit District | PUT    | `http://localhost:5000/districts/{id}` | District<sup>*</sup> |
|Delete District | DELETE    | `http://localhost:5000/districts/{id}` | |
|Get all Locations | GET    | `http://localhost:5000/api/locations` | DistrictId<sup>†</sup> |
|Get specific Location | GET    | `http://localhost:5000/locations/{id}` | |
|Create Location | POST    | `http://localhost:5000/locations/` | Location<sup>*</sup> |
|Edit Location | PUT    | `http://localhost:5000/locations/{id}` | Location<sup>*</sup> |
|Delete Location | DELETE    | `http://localhost:5000/locations/{id}` | |
|||||

*See below for example schemas for Districts and Locations
†Optional filtering parameter

### Schemas

*District:*
```
{
  "required": [
    "description",
    "name"
  ],
  "type": "object",
  "properties": {
    "districtId": {
      "type": "integer",
      "format": "int32"
    },
    "name": {
      "maxLength": 100,
      "minLength": 0,
      "type": "string"
    },
    "description": {
      "maxLength": 1000,
      "minLength": 0,
      "type": "string"
    },
    "locations": {
      "type": "array",
      "items": {
        **LOCATION**
      },
      "nullable": true
    }
  },
  "additionalProperties": false
}
```
*Location:*
```
{
  "required": [
    "level",
    "name"
  ],
  "type": "object",
  "properties": {
    "locationId": {
      "type": "integer",
      "format": "int32"
    },
    "name": {
      "maxLength": 50,
      "minLength": 0,
      "type": "string"
    },
    "description": {
      "maxLength": 1000,
      "minLength": 0,
      "type": "string",
      "nullable": true
    },
    "level": {
      "maximum": 392,
      "minimum": 1,
      "type": "integer",
      "format": "int32"
    },
    "districtId": {
      "type": "integer",
      "format": "int32"
    },
    "district": {
      **DISTRICT**
    }
  },
  "additionalProperties": false
}
```
## Known bugs:

* None as of 01/21/2022 15:45

## License

[Hippocratic License 2.1](https://github.com/Corgibyte/cloud-city/blob/main/LICENSE.md), Copyright 2022 Hannah Young.
