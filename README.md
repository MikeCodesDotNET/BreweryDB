# BreweryDB
![alt tag](http://www.brewerydb.com/img/badge.png)  

[![Build Status](https://www.bitrise.io/app/3735847bfb75f667.svg?token=A_GJ04CSfVtaF_2D7kMzRg)](https://www.bitrise.io/app/3735847bfb75f667)  

A simple to use .NET based API for calling into BreweryDB. 

BreweryDB is your database of breweries, beers, beer events and guilds! 

[Get an API Key](http://www.brewerydb.com/)

## Implemented Features
* Adjuncts
* Beers
* Breweries
* Categories
* Events
* Features
* Fermentables
* Fluidsize
* Guilds
* SocialSites
* Yeasts

## How to use it
### Client
```csharp
private readonly BreweryDbClient client = new BreweryDbClient(Keys.ApplicationKey);
```
### Beers
#### Fetch beer by id
```csharp
var response = await client.Beers.Get("cBLTUw");
```

#### Fetch all beers
```csharp
//Returns first page (50 beers per page)
var response = await client.Beers.GetAll();

//Returns third page (50 beers per page)
var response = await client.Beers.GetAll(3);
```

#### Fetch beers with parameter
```csharp
var parameters = new NameValueCollection {{BeerRequestParameters.Name, "duvel single"}};
var response = await client.Beers.Get(parameters);
```

#### Search for beer
```csharp
var response = await client.Beer.Search("duvel");
```

### Breweries
#### Fetch brewery by id
```csharp
var response = await client.Breweries.Get("YXDiJk");
```

#### Fetch all brewery
```csharp
//Returns first page (50 beers per page)
var response = await client.Breweries.GetAll();

//Returns third page (50 beers per page)
var response = await client.Breweries.GetAll(4);
```

#### Fetch brewery with parameter
```csharp
var parameters = new Helpers.NameValueCollection {{BreweryRequestParameters.Name, "Ad Lib Brewing Company" } };
var response = await client.Breweries.Get(parameters);
```

#### Search for brewery
```c#
var response = await client.Breweries.Search("duvel");
```

