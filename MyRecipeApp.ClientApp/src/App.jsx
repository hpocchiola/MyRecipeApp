import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout.jsx';
import { Home } from './components/Home/Home.jsx';
import { Recipe } from './components/Recipes/Recipe.jsx';

import './custom.css'

export default class App extends Component {

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/recipes' component={Recipe} />
      </Layout>
    );
  }
}
