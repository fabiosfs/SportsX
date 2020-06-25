import React, { Component } from 'react';
import { Link } from "react-router-dom";
import { FaEdit, FaTrash } from 'react-icons/fa';
import { Button } from 'react-bootstrap';

export class Home extends Component {

    constructor(props) {
        super(props);
        this.state = { clients: [], loading: true, redirect: false };
        this.handleDelete = this.handleDelete.bind(this);
    }

    componentDidMount() {
        this.populateGrid();
    }

    handleDelete(client) {
        if (window.confirm('Deseja deletar este item?')) {
            fetch("api/client/" + client.id, {
                method: 'delete'
            })
            .then((resp) => {

            })
            .then((data) => {
                // Success
                alert("Deletado com sucesso.");
                let clients = [...this.state.clients];
                let clientRemove = clients.indexOf(client);
                if (clientRemove !== -1) {
                    clients.splice(clientRemove, 1);
                    this.setState({ clients: clients });
                }
                
            })
            .catch((error) => {
                // Error
                alert("Ocorreu um erro durante a remoção.");
            });
        }
    }

    render() {
        return (
            <div>
                <b id="tabelLabel" style={{fontSize: 28}}>Clientes</b>
                <Link className="btn btn-primary float-right" to="/form">Adicionar</Link>
                {// Verifica se j� carregou os dados do cliente e se foi retornado mais de um valor e exibe se n�o exibe a grid
                    this.state.clients.length > 0 && !this.state.loading
                    ?   this.state.loading
                        ? <p><em>Loading...</em></p>
                            : <table className='table table-striped' aria-labelledby="tabelLabel">
                                <thead>
                                    <tr>
                                        <th>CPF/CNPJ</th>
                                        <th>Nome</th>
                                        <th>Classificação</th>
                                        <th>Telefones</th>
                                        <th>Ações</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {
                                        this.state.clients.map(client =>
                                            <tr key={client.id}>
                                                <td>{client.cpfCnpj}</td>
                                                <td>{client.name}</td>
                                                <td>{client.classification.name}</td>
                                                <td></td>
                                                <td>
                                                    <Link className="btn btn-primary" to={() => `/form/${client.id}`} ><FaEdit /></Link>
                                                    <Link className="btn btn-danger" to="/" onClick={() => this.handleDelete(client)} ><FaTrash /></Link>
                                                </td>
                                            </tr>
                                        )}
                                </tbody>
                            </table>
                    : <p>Nenhum registro encontrado</p>
                }
            </div>
        );
    }

    async populateGrid() {
        const response = await fetch('api/client');
        const data = await response.json();
        this.setState({ clients: data, loading: false });
    }
}