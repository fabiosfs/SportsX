import React, { Component } from 'react';
import { Form, Button, Col } from "react-bootstrap";
import { Link } from "react-router-dom";
import InputMask from 'react-input-mask';

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
        this.handleAddTelephone = this.handleAddTelephone.bind(this);
        this.handleHtmlTelephone = this.handleHtmlTelephone.bind(this);
        this.handleChangeTelephone = this.handleChangeTelephone.bind(this);
        this.handleRemoveTelephone = this.handleRemoveTelephone.bind(this);
    }

    componentDidMount() {
        this.getClientsType();
        this.getClassification();
        if (this.state.idClient != 0)
            this.getClient();
    }

    getClient = () => {
        fetch('api/client/' + this.state.idClient)
        .then((resp) => {
            return resp.json()
        })
        .then((data) => {
            // Success
            data.companyName = data.companyName == null ? '' : data.companyName;
            data.cep = data.cep == null ? '' : data.cep;
            this.setState({ client: data });
        })
        .catch((error) => {
            // Error
        });
    }

    getClientsType = () => {
        fetch('api/clienttype')
        .then((resp) => {
            return resp.json()
        })
        .then((data) => {
            // Success
            if (data.length > 0) {
                let client = this.state.client;
                client.idClientType = data[0].id
                this.setState({ client: client });
            }
            this.setState({ clientsType: data });
        })
        .catch((error) => {
            // Error
        });
    }

    getClassification = () => {
        fetch('api/classification')
        .then((resp) => {
            return resp.json()
        })
        .then((data) => {
            // Success
            if (data.length > 0) {
                let client = this.state.client;
                client.idClassification = data[0].id
                this.setState({ client: client });
            }
            this.setState({ classifications: data });
        })
        .catch((error) => {
            // Error
        });
    }

    createClient = () => {
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

    updateClient = () => {
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
            fetch("api/telephone/client/" + client.id, {
                method: 'put',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(client.telephones)
            })
            .then((resp) => {
                return resp.json()
            })
            .then((data) => {
                // Success
                alert("Atualizado com sucesso.");
                client.telephones = data
                this.setState({ client: client });
            })
            .catch((error) => {
                // Error
                alert("Ocorreu um erro durante a atualização dos dados da pessoa.");
            });
            this.setState({ client: data });
        })
        .catch((error) => {
            // Error
            alert("Ocorreu um erro durante a atualização dos dados da pessoa.");
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
            idClientType: 0,
            telephones: [{id:0, number: ''}]
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

    handleChangeTelephone = (key, event) => {
        let client = this.state.client;
        client.telephones[key].number = event.target.value;
        this.setState({ client: client });
    }

    handleAddTelephone = (event) => {
        let client = this.state.client;
        client.telephones.push({ id: 0, number: '' });
        this.setState({client: client});
    }

    handleRemoveTelephone = (telephone) => {
        let client = this.state.client;
        let telephoneRemove = client.telephones.indexOf(telephone);
        if (telephoneRemove !== -1) {
            client.telephones.splice(telephoneRemove, 1);
            this.setState({ client: client });
        }
    }

    handleHtmlTelephone = () => {
        let telephones = this.state.client.telephones;
        return telephones.map((telephone, key) => {
            return <Form.Row className="align-items-center" style={{ marginBottom: 5 }} key={key}>
                <Col>
                    <InputMask mask="(99) 99999-9999" value={telephone.number} onChange={(e) => { this.handleChangeTelephone(key, e) }} >
                        <Form.Control id="inlineFormInput" placeholder="(99) 99999-9999" />
                    </InputMask>
                    
                </Col>
                <Col>
                    <Button variant="danger" type="button" onClick={() => { this.handleRemoveTelephone(telephone) }} >Remover</Button>
                </Col>
            </Form.Row>
        });
    }

    onClickSave = (event) => {
        let message = '';
        if (this.state.client.name == 0)
            message += 'O nome é obrigatório.\n';
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
                <b id="tabelLabel" style={{ fontSize: 28 }}>Adicionar Cliente</b>
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
                    {
                        this.state.client.idClientType == 2
                            ?
                                <Form.Group controlId="companyName">
                                    <Form.Label>Razão Social</Form.Label>
                                    <Form.Control type="text" value={this.state.client.companyName} onChange={this.handleChangeCompanyName} placeholder="Razão Social" />
                                </Form.Group>
                            : null
                    }
                    {
                        this.state.client.idClientType == 2
                            ?
                            <Form.Group controlId="cpfCnpj">
                                <Form.Label>CNPJ</Form.Label>
                                <InputMask mask="99.999.999/9999-99" value={this.state.client.cpfCnpj} onChange={this.handleChangeCpfCnpj}>
                                    <Form.Control type="text" placeholder="00.000.000/0000-00" />
                                </InputMask>
                            </Form.Group>
                            :
                            <Form.Group controlId="cpfCnpj">
                                <Form.Label>CPF</Form.Label>
                                <InputMask mask="999.999.999-99" value={this.state.client.cpfCnpj} onChange={this.handleChangeCpfCnpj}>
                                    <Form.Control type="text" placeholder="000.000.000-00" />
                                </InputMask>
                            </Form.Group>
                    }
                    <Form.Group controlId="email">
                        <Form.Label>Email</Form.Label>
                        <Form.Control type="email" value={this.state.client.email} onChange={this.handleChangeEmail} placeholder="E-mail" />
                    </Form.Group>
                    <Form.Group controlId="CEP">
                        <Form.Label>CEP</Form.Label>
                        <InputMask mask="99.999-999" value={this.state.client.cep} onChange={this.handleChangeCep}>
                            <Form.Control type="text" placeholder="00-000-000" />
                        </InputMask>
                    </Form.Group>
                    <Button className="float-right" variant="primary" onClick={this.handleAddTelephone} type="button">
                            Adicionar Telefone
                    </Button>
                    <Form.Group controlId="teephone">
                        <Form.Label>Telefones</Form.Label>
                    </Form.Group>
                    {this.handleHtmlTelephone()}
                    <Button className="float-right" variant="primary" onClick={this.onClickSave} type="button">
                        Salvar
                    </Button>
                    <Link className="btn btn-primary float-right" style={{ marginRight: 10 }} to="/">Voltar</Link>
                </Form>
            </div>
        );
    }
}
