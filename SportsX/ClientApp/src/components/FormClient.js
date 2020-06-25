import React, { Component } from 'react';
import { Form, Button } from "react-bootstrap";
import { Link } from "react-router-dom";

export class FormClient extends Component {

    constructor(props) {
        super(props);
        let id = 0;
        if (this.props.match.params.id != undefined)
            id = this.props.match.params.id;

        this.state = { idClient: id, client: this.clientModel(), clientsType: [], classifications: []  };

        this.clientModel = this.clientModel.bind(this);
        this.handleChangeName = this.handleChangeName.bind(this);
        this.handleChangeCompanyName = this.handleChangeCompanyName.bind(this);
        this.handleChangeCpfCnpj = this.handleChangeCpfCnpj.bind(this);
        this.handleChangeEmail = this.handleChangeEmail.bind(this);
        this.handleChangeCep = this.handleChangeCep.bind(this);
        this.getClientsType = this.getClientsType.bind(this);
        this.getClassification = this.getClassification.bind(this);
        this.onClickSave = this.onClickSave.bind(this);
        this.createClient = this.createClient.bind(this);
        this.updateClient = this.updateClient.bind(this);
    }

    componentDidMount() {
        this.getClientsType();
        this.getClassification();
        if (this.state.idClient != 0)
            this.getClient();
    }

    async getClient() {
        const response = await fetch('api/client/' + this.state.idClient);
        const data = await response.json();
        data.companyName = data.companyName == null ? '' : data.companyName;
        data.cep = data.cep == null ? '' : data.cep;
        this.setState({ client: data });
    }

    async getClientsType() {
        const response = await fetch('api/clienttype');
        const data = await response.json();
        if (data.length > 0) {
            let client = this.state.client;
            client.idClientType = data[0].id
            this.setState({ client: client });
        }
        this.setState({ clientsType: data });
    }

    async getClassification() {
        const response = await fetch('api/classification');
        const data = await response.json();
        if (data.length > 0) {
            let client = this.state.client;
            client.idClassification = data[0].id
            this.setState({ client: client });
        }
        this.setState({ classifications: data });
    }

    async createClient() {
        let client = this.state.client;
        fetch("api/client", {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(client)
        })
        .then((resp) => {
            return resp.json()
        })
        .then((data) => {
            // Success
            alert("Cadastrado com sucesso.");
            let client = this.clientModel();
            client.idClassification = this.state.classifications[0].id;
            client.idClientType = this.state.clientsType[0].id;
            this.setState({ client: client });
        })
        .catch((error) => {
            // Error
            alert("Ocorreu um erro durante o cadastro.");
        });
    }

    async updateClient() {
        let client = this.state.client;
        fetch("api/client", {
            method: 'put',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(client)
        })
            .then((resp) => {
                return resp.json()
            })
            .then((data) => {
                // Success
                alert("Cadastrado com sucesso.");
                this.setState({ client: data });
            })
            .catch((error) => {
                // Error
                alert("Ocorreu um erro durante o cadastro.");
            });
    }

    clientModel = () => {
        return  {
            id: 0,
            name: '',
            companyName: '',
            cpfCnpj: '',
            email: '',
            cep: '',
            idClassification: 0,
            idClientType: 0
        };
    }

    handleChangeName = (event) => {        
        let client = this.state.client;
        client.name = event.target.value;
        this.setState({ client: client });
    }

    handleChangeCompanyName = (event) => {
        let client = this.state.client;
        client.companyName = event.target.value;
        this.setState({ client: client });
    }

    handleChangeCpfCnpj = (event) => {
        let client = this.state.client;
        client.cpfCnpj = event.target.value;
        this.setState({ client: client });
    }

    handleChangeEmail = (event) => {
        let client = this.state.client;
        client.email = event.target.value;
        this.setState({ client: client });
    }

    handleChangeCep = (event) => {
        let client = this.state.client;
        client.cep = event.target.value;
        this.setState({ client: client });
    }

    handleChangeClientType = (event) => {
        let client = this.state.client;
        client.idClientType = parseInt(event.target.value);
        this.setState({ client: client });
    }

    handleChangeClassification = (event) => {
        let client = this.state.client;
        client.idClassification = parseInt(event.target.value);
        this.setState({ client: client });
    }

    onClickSave = (event) => {
        let message = '';
        if (this.state.client.name == 0)
            message += 'O nome é obrigatório.\n';
        if (this.state.client.cpfCnpj == 0)
            message += 'O CPF ou CNPJ é obrigatório.\n';
        if (this.state.client.email == 0)
            message += 'O e-mail é obrigatório.\n';
        if (message != '')
            alert(message);
        else {
            if (this.state.client.id == 0) {
                this.createClient();
            }
            else {
                this.updateClient();
            }
        }
    }

    render() {
        return (
            <div>
                <h1>Adicionar Cliente</h1>
                <Form>
                    <Form.Group controlId="clientType">
                        <Form.Label>Tipo de cliente</Form.Label>
                        <Form.Control as="select" onChange={this.handleChangeClientType} value={this.state.client.idClientType}>
                            {this.state.clientsType.map(clientType => <option key={clientType.name} value={clientType.id}>{clientType.name}</option>)}
                        </Form.Control>
                    </Form.Group>
                    <Form.Group controlId="classification">
                        <Form.Label>Classificação</Form.Label>
                        <Form.Control as="select" onChange={this.handleChangeClassification} value={this.state.client.idClassification}>
                            {this.state.classifications.map(classification => <option key={classification.name} value={classification.id}>{classification.name}</option>)}
                        </Form.Control>
                    </Form.Group>
                    <Form.Group controlId="name">
                        <Form.Label>Nome</Form.Label>
                        <Form.Control type="text" value={this.state.client.name} onChange={this.handleChangeName} placeholder="Nome" />
                    </Form.Group>
                    <Form.Group controlId="companyName">
                        <Form.Label>Razão Social</Form.Label>
                        <Form.Control type="text" value={this.state.client.companyName} onChange={this.handleChangeCompanyName} placeholder="Razão Social" />
                    </Form.Group>
                    <Form.Group controlId="cpfCnpj">
                        <Form.Label>CPF/CNPJ</Form.Label>
                        <Form.Control type="text" value={this.state.client.cpfCnpj} onChange={this.handleChangeCpfCnpj} placeholder="CPF/CNPJ" />
                    </Form.Group>
                    <Form.Group controlId="email">
                        <Form.Label>Email</Form.Label>
                        <Form.Control type="email" value={this.state.client.email} onChange={this.handleChangeEmail} placeholder="E-mail" />
                    </Form.Group>
                    <Form.Group controlId="CEP">
                        <Form.Label>CEP</Form.Label>
                        <Form.Control type="text" value={this.state.client.cep} onChange={this.handleChangeCep} placeholder="CEP" />
                    </Form.Group>
                    <Button className="float-right" variant="primary" onClick={this.onClickSave} type="button">
                        Salvar
                    </Button>
                    <Link className="btn btn-primary float-right" style={{ marginRight: 10 }} to="/">Voltar</Link>
                </Form>
            </div>
        );
    }
}
