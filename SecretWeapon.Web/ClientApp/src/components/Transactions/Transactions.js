import React, { Component } from 'react';

export class Transactions extends Component {
  static displayName = Transactions.name;

  constructor(props) {
    super(props);
    this.state = { transactions: [], loading: true };
  }

  componentDidMount() {
    this.populateTransactionData();
  }

  static renderTransactionsTable(transactions) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Id</th>
            <th>DePlainText</th>
          </tr>
        </thead>
        <tbody>
          {transactions.map(transaction =>
            <tr key={transaction.id}>
              <td>{transaction.id}</td>
              <td>{transaction.dePlainText}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Transactions.renderTransactionsTable(this.state.transactions);

    return (
      <div>
        <h1 id="tabelLabel" >Transactions</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateTransactionData() {
    const response = await fetch('/transactions/get');
    const data = await response.json();
    this.setState({ transactions: data, loading: false });
  }
}
