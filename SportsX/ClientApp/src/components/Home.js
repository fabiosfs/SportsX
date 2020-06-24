import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { clients: [], loading: true };
    }

    componentDidMount() {
        this.populateGrid();
    }

    static renderClient(clients) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Nome</th>
                    </tr>
                </thead>
                <tbody>
                    {clients.map(client =>
                        <tr key={client.id}>
                            <td>{client.name}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        return (
            <div>
                <h1 id="tabelLabel" >Clientes</h1>
                {// Verifica se já carregou os dados do cliente e se foi retornado mais de um valor e exibe se não exibe a grid
                    this.state.clients.length > 0 && !this.state.loading
                    ?   this.state.loading
                        ? <p><em>Loading...</em></p>
                        : Home.renderClient(this.state.clients)
                    : <p>Nenhum registro encontrado</p>
                }
            </div>
        );
    }

    async populateGrid() {
        const response = await fetch('api/client');
        const data = await response.json();
        console.log(data);
        this.setState({ clients: data, loading: false });
    }
}
