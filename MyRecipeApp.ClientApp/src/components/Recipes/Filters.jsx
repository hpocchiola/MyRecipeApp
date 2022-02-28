import React, { useState, useEffect } from 'react';
import { Grid, TextField, Select, OutlinedInput, MenuItem, InputLabel, FormControl, IconButton } from "@mui/material";
import { get } from "../../utils/api/api"
import SearchIcon from '@mui/icons-material/Search';
import DeleteIcon from '@mui/icons-material/Delete';

const defaultValues = {
    title: "",
    ingredients: []
};

const ITEM_HEIGHT = 48;
const ITEM_PADDING_TOP = 8;
const MenuProps = {
    PaperProps: {
        style: {
            maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
            width: 250,
        },
    },
};

export const Filters = ({ handleSubmit, handleClear, ...props }) => {
    const [formValues, setFormValues] = useState(defaultValues)
    const [availableIngredients, setAvailableIngredients] = useState([]);

    useEffect(() => {
        get("/ingredients").then((response) => {
            setAvailableIngredients(response.data);
        });
    }, []);

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormValues({
            ...formValues,
            [name]: value,
        });
    };

    const formSubmit = (e) => {
        e.preventDefault();
        handleSubmit(formValues);
    }

    const clearForm = () => {
        setFormValues(defaultValues);
        handleClear();
    }

    return (
        <Grid item xs={12}>
            <FormControl sx={{ m: 1, width: 300 }}>
                <TextField
                    name="title"
                    label="Title"
                    type="text"
                    onChange={handleInputChange}
                    value={formValues.title}
                />
            </FormControl>
            <FormControl sx={{ m: 1, width: 300 }}>
                <InputLabel id="ingredient-label">Ingredients</InputLabel>
                <Select
                    labelId="ingredient-label"
                    multiple
                    name="ingredients"
                    value={formValues.ingredients}
                    onChange={handleInputChange}
                    input={<OutlinedInput label="Ingredients" />}
                    MenuProps={MenuProps}
                >
                    {availableIngredients.map((ingredient) => (
                        <MenuItem
                            key={ingredient.name}
                            value={ingredient.name}
                        >
                            {ingredient.name}
                        </MenuItem>
                    ))}
                </Select>
            </FormControl>
            <label htmlFor="search-button-icon">
                <IconButton className="icon" onClick={formSubmit} color="primary" aria-label="search" component="span">
                    <SearchIcon fontSize="large" />
                </IconButton>
            </label>
            <label htmlFor="clear-button-icon">
                <IconButton
                    disabled={!formValues.title && formValues.ingredients.length === 0}
                    className="icon"
                    onClick={clearForm}
                    color="secondary"
                    aria-label="clear filters"
                    component="span">
                    <DeleteIcon fontSize="large" />
                </IconButton>
            </label>
        </Grid>
    )
}