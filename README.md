# MyRecipeApp

Guide to starting the app

1. Clone the repository (I usually use Visual Studio option when cloning, since I'll be using Visual Studio anyway)
2. If you used VS to clone, just double-click on the solution named My Recipe App. Otherwise, use VS to open the solution from where you cloned the repository.
3. Hit the start button. IIS Express default configuration works great.
4. Both Frontend and Backend should be running now on localhost:https://localhost:44391/.
5. https://localhost:44391/recipes has all the features. You can view the api through swagger on https://localhost:44391/swagger

Note: the first time you start the solution VS will automatically execute npm install. It will also create and seed a SQLite DB called MyRecipeAppDb.db
