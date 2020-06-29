import React, { Component } from 'react';
import ListInvoices from '../list-invoices/list-invoices';
import { PrimaryButton } from 'office-ui-fabric-react';

class Invoices extends Component {
    constructor(props: any) {
        super(props);
        
        this.state = {}
    }

    render (): JSX.Element {
        return (
            <div className='invoices'>
                <PrimaryButton className='create-button' text="Create new" href='/invoices/create'/>
                <ListInvoices/>
            </div>
        );
    }
}

export default Invoices;