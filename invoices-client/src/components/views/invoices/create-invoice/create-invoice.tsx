import React, { Component } from 'react';
import { TextField, PrimaryButton } from 'office-ui-fabric-react';
import InvoiceService from '../../../../services/invoice.service';
import { Dropdown, IDropdownOption } from 'office-ui-fabric-react/lib/Dropdown';

interface ICreateinvoiceProps {}
interface ICreateInvoiceState {
    clients: IDropdownOption[];
    client: string;
    amount: string;
    errorMessage: string;
}

class CreateInvoice extends Component<ICreateinvoiceProps, ICreateInvoiceState> {
    constructor(props: ICreateinvoiceProps) {
        super(props);
        
        this.state = {
            clients: [],
            client: '',
            amount: '',
            errorMessage: ''
        }

        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleDropdownChange = this.handleDropdownChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    componentDidMount() {
        this.setState({errorMessage: ''}, async () => {
            try {
                const clientsResult = await InvoiceService.allClients() as [];
                const clients = clientsResult.map((c: any) => {return { key: c.userId, text: c.name }});
                
                this.setState({clients: clients})
                
                console.log(clients)
            } catch (error) {
                console.error(error);
            }
        })
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

    private handleDropdownChange(event: React.FormEvent<HTMLDivElement>, option?: IDropdownOption | undefined) {
        const target = event.target;
        const client = option as any;
        console.log(target)
        console.log(client.key)
        this.setState(prevState => ({
            ...prevState,
            client: client.key
        }));
    }

    private handleSubmit(event: any) {
        event.preventDefault();
        this.setState({errorMessage: ''}, async () => {
            try {
                const invoice = {
                    userId: this.state.client,
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
                    <Dropdown
                        placeholder="Select an option"
                        label='Client '
                        id='client'
                        options={this.state.clients}
                        selectedKey={this.state.client}
                        onChange={this.handleDropdownChange}
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