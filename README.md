# Description

This API calculates the distance between two zip codes using a layered architecture and TDD methodology. It is backed by a MongoDB database in MongoAtlas and is dockerized. The frontend is built using React.

# Endpoints

* # Calculate Distance

  POST /CalculateDistance
  
  Calculates the distance between two zip codes and returns the result.

  Request Body
  
  json
  
  {
    "FromZip": "string",
    "ToZip": "string"
  }
  
  # Responses
  
  200: Returns the calculated distance.
  
  400: There was an error with the zip codes.
  
* # Get All Zips
  
  GET /GetAllZips
  
  Returns all zip code information from the MongoDB database.

  # Responses
  
  200: Returns all zip code information.
  
  400: There was an error retrieving the zip codes.
  
# Getting Started

# Prerequisites
  
  * Docker
  * Docker Compose

# Technologies Used

  * Layered Architecture
  * TDD
  * MongoDB
  * Docker
  * React
  * .NET 6
  
 # How to Use
 
  * Clone the repository.
  * Run docker-compose up to start API container.
  * Navigate to the frontend folder and run npm install to install dependencies.
  * Run npm start to start the frontend.
  * Use the API endpoints to calculate distance and retrieve zip code information.
