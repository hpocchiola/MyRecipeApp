import React from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout.jsx';
import { Home } from './components/Home/Home.jsx';
import { Recipe } from './components/Recipes/Recipe.jsx';
import { initializeInterceptors } from "./utils/api/axios-interceptors";

import './custom.css'

export const App = () => {

  initializeInterceptors()

  return (
    <Layout>
      <Route exact path='/' component={Home} />
      <Route exact path='/recipes' component={Recipe} />
    </Layout>
  );
}
