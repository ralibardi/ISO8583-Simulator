import React, { Component } from 'react';

export class Cards extends Component {
  static displayName = Cards.name;

  constructor(props) {
    super(props);
    this.state = { cards: [], loading: true };
  }

  componentDidMount() {
    this.populateCardData();
  }

  static renderCardsTable(cards) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Id</th>
            <th>DePlainText</th>
          </tr>
        </thead>
        <tbody>
          {cards.map(card =>
            <tr key={card.id}>
              <td>{card.id}</td>
              <td>{card.dePlainText}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Cards.renderCardsTable(this.state.cards);

    return (
      <div>
        <h1 id="tabelLabel" >Cards</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateCardData() {
    const response = await fetch('/cards/get');
    const data = await response.json();
    this.setState({ cards: data, loading: false });
  }
}
