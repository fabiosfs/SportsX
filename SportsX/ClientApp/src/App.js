import React, { Component } from 'react';
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FormClient } from './components/FormClient';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Layout>
            <Router>
                <Switch>
                    <Route exact path='/' component={Home} />
                    <Route path='/form/:id?' component={FormClient} />
                </Switch>
            </Router>
        </Layout>
    );
  }
}
