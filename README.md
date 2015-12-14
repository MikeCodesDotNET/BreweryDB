# BreweryDB
![alt tag](http://www.brewerydb.com/img/badge.png)

A simple to use .NET based API for calling into BreweryDB. 

BreweryDB is your database of breweries, beers, beer events and guilds! 

[Get an API Key](http://www.brewerydb.com/)

##Implemented Features
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

##How to use it
###Client
```c#
private readonly BreweryDbClient client = new BreweryDbClient(Keys.ApplicationKey);
```
###Beers
####Fetch beer by id
```c#
var response = await client.Beers.Get("cBLTUw");
```

####Fetch all beers
```c#
//Returns first page (50 beers per page)
var response = await client.Beers.GetAll();

//Returns third page (50 beers per page)
var response = await client.Beers.GetAll(3);
```

####Fetch beers with parameter
```c#
var parameters = new NameValueCollection {{BeerRequestParameters.Name, "duvel single"}};
var response = await client.Beers.Get(parameters);
```

####Search for beer
```c#
var response = await client.Breweries.Search("duvel");
```


