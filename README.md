# LimeHome-BE Setup

 

## Versions (Current)

Visual Studio 2019 - 16.6.4

 

## Initial setup


	
Checkout the repo (currently build is on "master" branch) 
	Setup an IIS website pointing at "HotelsAPp.Api" folder 
	Open the HotelsApp.sln in visual studio 
	Right click the solution and select "Restore Nuget Packages" 
	Make sure the DB connection string in "appsettings.json" points to localhost: 


Server=127.0.0.1\\SQLEXPRESS2017,1434;Database=Limehome_Test01;User Id=limehome_Test01; Password=test2020;Application Name=Limehome_Test01;

- build the project

## Database Setup


	
Open SQL Server Management Studio 
	When the app is started there will be created empty tables in the database
	The user for the db must be db_owner


## Back-End Test


	
Open postman and import the attached Limehome.postman_collection.json file in postman and start testing the endpoints
