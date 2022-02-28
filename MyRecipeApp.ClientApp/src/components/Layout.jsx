import React, { Component } from 'react';
import { NavMenu } from './NavMenu';
import { Grid } from "@mui/material"

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <NavMenu />
        <Grid item xs={12}>
          {this.props.children}
        </Grid>
      </div>
    );
  }
}
