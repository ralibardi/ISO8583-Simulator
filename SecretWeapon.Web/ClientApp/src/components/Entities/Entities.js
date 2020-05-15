import React, { Component } from 'react';

export class Entities extends Component {
  static displayName = Entities.name;

  constructor(props) {
    super(props);
    this.state = { entities: [], loading: true };
  }

  componentDidMount() {
    this.populateEntityData();
  }

  static renderEntitiesTable(entities) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Id</th>
            <th>DePlainText</th>
          </tr>
        </thead>
        <tbody>
          {entities.map(entity =>
            <tr key={entity.id}>
              <td>{entity.id}</td>
              <td>{entity.dePlainText}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Entities.renderEntitiesTable(this.state.entities);

    return (
      <div>
        <h1 id="tabelLabel" >Entities</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateEntityData() {
    const response = await fetch('/entities/get');
    const data = await response.json();
    this.setState({ entities: data, loading: false });
  }
}
