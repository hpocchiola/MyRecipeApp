import React from 'react';
import { List, ListItem, ListItemIcon, ListItemText } from "@mui/material";
import RestaurantIcon from '@mui/icons-material/Restaurant';

export const Ingredients = ({ingredients, ...props}) => {
    return (
        <List>
            {ingredients.map((ingredient, index) => (
                <ListItem key={index}>
                    <ListItemIcon>
                        <RestaurantIcon />
                    </ListItemIcon>
                    <ListItemText primary={ingredient.name}/>
                </ListItem>
            ))}
        </List>
    )
}