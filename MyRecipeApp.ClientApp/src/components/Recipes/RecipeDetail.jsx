import React from "react";
import { Box, Card, CardContent, Typography } from "@mui/material";
import { Ingredients } from "./Ingredients";

export const RecipeDetail = ({ recipe, ...props }) => {
  return (
    <Box>
      <Card variant="outlined" className="recipe-card">
        <CardContent>
          <Typography variant="h5" component="div">
            {recipe.title}
          </Typography>
          <Typography variant="subtitle1">
            Ingredients:
          </Typography>
          <Ingredients ingredients={recipe.ingredients}></Ingredients>
        </CardContent>
      </Card>
    </Box>
  );
};
