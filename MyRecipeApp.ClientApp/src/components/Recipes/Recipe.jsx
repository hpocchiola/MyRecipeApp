import React, { useState, useEffect, useCallback } from "react";
import { get, post } from "../../utils/api/api"
import { RecipeDetail } from "./RecipeDetail";
import { Grid, Typography } from "@mui/material";
import "./Recipe.css";
import { Filters } from "./Filters";


export const Recipe = () => {
  const [recipes, setRecipes] = useState(undefined);

  const getRecipes = useCallback(() => {
    get("/recipes").then((response) => {
      setRecipes(response.data);
    });
  }, [])

  useEffect(() => {
    getRecipes();
  }, [getRecipes]);

  const handleSubmit = (value) => {
    post("/recipes/search", value).then((response) => {
      setRecipes(response.data);
    })
  }

  return (
    <>
      <Grid container className="recipes-grid">
        <Grid item xs={12} className="recipe-card-grid">
          <Filters handleSubmit={handleSubmit} handleClear={getRecipes}></Filters>
        </Grid>
        {recipes ? recipes.length > 0 ? recipes.map((recipe, index) =>
          <Grid key={index} item xs={2} className="recipe-card-grid">
            <RecipeDetail key={index} recipe={recipe}></RecipeDetail>
          </Grid>
        ) :
          <Grid item xs={12} className="recipe-card-grid">
            <Typography variant="subtitle1">No recipes were found. Try adjusting the filters</Typography>
          </Grid>
          : null}
      </Grid>
    </>
  );
};
