import React, { Component } from 'react';
import { Link } from "react-router-dom";
import { FaEdit, FaTrash } from 'react-icons/fa';
import { Form } from "react-bootstrap";

export class Home extends Component {

    constructor(props) {
        super(props);
        this.state = { clients: [], loading: true, redirect: false, clientsType: [{ id: 0, name: "Todos" }] };
        this.handleDelete = this.handleDelete.bind(this);
        this.populateGrid = this.populateGrid.bind(this);
        this.getClientsType = this.getClientsType.bind(this);
    }

    componentDidMount() {
        this.populateGrid(0);
        this.getClientsType();
    }

    getClientsType = () => {
        fetch('api/clienttype')
        .then((resp) => {
            return resp.json()
        })
        .then((data) => {
            // Success
            let clientsType = this.state.clientsType;
            data.map(x => clientsType.push(x));
            this.setState({ clientsType: clientsType });
        })
        .catch((error) => {
            // Error
        });
    }

    populateGrid = (idClientType) => {
        idClientType = (idClientType == 0 ? '' : idClientType);
        fetch('api/client/clients/' + idClientType)
        .then((resp) => {
            return resp.json()
        })
        .then((data) => {
            // Success
            this.setState({ clients: data, loading: false });
        })
        .catch((error) => {
            // Error
            alert("Ocorreu um erro para buscar a listagem.");
        });
    }

    handleChangeClientType = (event) => {
        this.populateGrid(event.target.value);
    }

    handleDelete = (client) => {
        if (window.confirm('Deseja deletar este item?')) {
            fetch("api/client/" + client.id, {
                method: 'delete'
            })
            .then((resp) => {

            })
            .then((data) => {
                // Success
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
                <Form.Group controlId="clientType">
                    <Form.Control as="select" onChange={this.handleChangeClientType}>
                        {this.state.clientsType.map(clientType => <option key={clientType.name} value={clientType.id}>{clientType.name}</option>)}
                    </Form.Control>
                </Form.Group>
                {// Verifica se j� carregou os dados do cliente e se foi retornado mais de um valor e exibe se n�o exibe a grid
                    this.state.clients.length > 0 || this.state.loading
                    ?   this.state.loading
                        ? <div style={{ textAlign: "center" }}><b>Aguarde...</b></div>
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
                                                <td>{client.telephones.map(x => x.number).join(', ')}</td>
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
}