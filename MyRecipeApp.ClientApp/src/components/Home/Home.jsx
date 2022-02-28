import React from "react";
import { Typography } from "@mui/material";

export const Home = () => {
  return (
    <div style={{margin:"30px"}}>
      <Typography variant="h3">My Recipe App</Typography>
      <Typography variant="body1">This is a single-page application built with:</Typography>
      <ul>
        <Typography variant="body1"><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</Typography>
        <Typography variant="body1"><a href='https://facebook.github.io/react/'>React</a> for client-side code</Typography>
        <Typography variant="body1"><a href='https://mui.com//'>Material-UI</a> for layout and styling</Typography>
      </ul>
      <Typography variant="subtitle1">Moreover, the app also has:</Typography>
      <ul>
        <Typography variant="body1"><strong>Client-side navigation.</strong></Typography>
        <Typography variant="body1"><strong>Development server integration</strong>. In development mode, the development server from <code>create-react-app</code> runs in the background automatically, so your client-side resources are dynamically built on demand and the page refreshes when you modify any file.</Typography>
        <Typography variant="body1"><strong>Efficient production builds</strong>. In production mode, development-time features are disabled, and your <code>dotnet publish</code> configuration produces minified, efficiently bundled JavaScript files.</Typography>
      </ul>
      <Typography variant="body2">The <code>ClientApp</code> subdirectory is a standard React application based on the <code>create-react-app</code> template. If you open a command prompt in that directory, you can run <code>npm</code> commands such as <code>npm test</code> or <code>npm install</code>.</Typography>
    </div>
  );
};
