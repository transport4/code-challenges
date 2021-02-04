# Objective

1. Create a simple "Taco Recipe" REST API. 

2. Use the latest NodeJS Framework version.  

3. The API can be set up using Express, or as a Serverless (https://www.serverless.com/) API project.

4.  When you're finished, please push your code to GitHub and send a link to matt.marooney@transport4.com
 
# API Requirements

1. Consumers of the API should be able access full REST endpoints for the following actions:
    - Creating Taco recipes 
    - Updating Taco recipes
    - Deleting Taco recipes
    - Retrieving a list of Taco recipes
    - Retrieve list of Taco sauces from Spoonacular.com Ingredient API
    - Post Taco Recipe to Spoonacular.com API and return Recipe Card image

2. Taco recipes consist of the following data:
    - Recipe Name
    - Recipe Description
    - Recipe Instructions
    - Ingredients:
        - Taco Shell
        - Taco Protein(s)
        - Taco Topping(s)
        - Taco Sauce(s)

3. The API should use some sort of mock DB for persisting the Taco recipe data

4. The API should contain at least one "positive" unit test and one "negative" unit test.

5. Spoonacular API information:
    - API Key: 3c96dbdcf8a645fd830ad715ffc77da2
    - API Documentation: https://spoonacular.com/food-api/docs
    - Use the Create Recipe Card endpoint to generate a recipe card image (https://spoonacular.com/food-api/docs#Create-Recipe-Card)
    - Use the Ingredient endpoints to retrieve the list of possible Taco sauces from Spoonacular (https://spoonacular.com/food-api/docs#Ingredient-Search)

6. Use best-practice REST specifications, async patterns, clean coding practices, and your creativity and ingenuity!



