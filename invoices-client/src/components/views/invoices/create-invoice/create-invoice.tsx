import React, { Component } from 'react';
import { TextField, PrimaryButton } from 'office-ui-fabric-react';
import InvoiceService from '../../../../services/invoice.service';

interface ICreateinvoiceProps {}
interface ICreateInvoiceState {
    idNumber: string;
    name: string;
    amount: string;
    errorMessage: string;
}

class CreateInvoice extends Component<ICreateinvoiceProps, ICreateInvoiceState> {
    constructor(props: ICreateinvoiceProps) {
        super(props);
        
        this.state = {
            idNumber: '',
            name: '',
            amount: '',
            errorMessage: ''
        }

        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    componentDidMount() {
        // this.setState({errorMessage: ''}, async () => {
        //     try {
        //         // const clientsResult = await InvoiceService.allClients() as [];
        //         // const clients = clientsResult.map((c: any) => {return { key: c.userId, text: c.name }});
                
        //         // this.setState({clients: clients})
                
        //         // console.log(clients)
        //     } catch (error) {
        //         console.error(error);
        //     }
        // })
    }

    private handleInputChange(event: any) {
        const target = event.target;
        const value = target.value;
        const name = target.name && target.id;
        this.setState(prevState => ({
            ...prevState,
            [name]: value
        }));
    }

    private handleSubmit(event: any) {
        event.preventDefault();
        this.setState({errorMessage: ''}, async () => {
            try {
                const invoice = {
                    idNumber: this.state.idNumber,
                    name: this.state.name,
                    amount: +this.state.amount
                }

                await InvoiceService.create(invoice);
                
                window.location.reload();
            } catch (error) {
                console.error(error);
            }
        })
    }

    render (): JSX.Element {
        return (
            <div className='create-invoice'>
                <div className='create-invoice__title'>Create Invoice</div>
                <form
                    className='create-invoice__form'
                    onSubmit={event => {
                        this.handleSubmit(event);
                    }}
                >
                    <TextField
                        label='Id Number '
                        id='idNumber'
                        name='idNumber'
                        value={this.state.idNumber}
                        onChange={this.handleInputChange}
                        required
                    />
                    <TextField
                        label='Name '
                        id='name'
                        name='name'
                        value={this.state.name}
                        onChange={this.handleInputChange}
                        required
                    />
                    <TextField
                        label='Amount '
                        id='amount'
                        name='amount'
                        value={this.state.amount}
                        onChange={this.handleInputChange}
                        required
                    />
                    <div className='actions'>
                        <PrimaryButton className='actions__button' text="Create" onClick={event => this.handleSubmit(event)}/>
                    </div>
                </form>
            </div>
        );
    }
}

export default CreateInvoice;