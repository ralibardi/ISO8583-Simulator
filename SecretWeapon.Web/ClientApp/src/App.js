import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Transactions } from './components/Transactions/Transactions';
import { Cards } from './components/Cards/Cards';
import { Entities } from './components/Entities/Entities';
import { Users } from './components/Users/Users';

import './custom.css'

export default class App extends Component {
  static displayName = "Secret Weapon";

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/cards' component={Cards} />
        <Route path='/transactions' component={Transactions} />
        <Route path='/entities' component={Entities} />
        <Route path='/users' component={Users} />
      </Layout>
    );
  }
}
