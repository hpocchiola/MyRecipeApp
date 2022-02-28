import React from 'react';
import { Box, AppBar, Toolbar, IconButton, Button } from "@mui/material";
import { useHistory } from 'react-router-dom';
import './NavMenu.css';

export const NavMenu = () => {
  const history = useHistory();

  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="menu"
            sx={{ mr: 2 }}
          >
          </IconButton>
          <Button
            key="Home"
            onClick={() => history.push('/')}
            sx={{ my: 2, color: 'white', display: 'block' }}
          >
            Home
          </Button>
          <Button
            key="Recipes"
            onClick={() => history.push('/recipes')}
            sx={{ my: 2, color: 'white', display: 'block' }}
          >
            Recipes
          </Button>
        </Toolbar>
      </AppBar>
    </Box>
  );
}
