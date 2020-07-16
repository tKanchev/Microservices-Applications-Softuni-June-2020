import React, { Component } from 'react';
import { DetailsList, DetailsListLayoutMode, IColumn } from 'office-ui-fabric-react/lib/DetailsList';
import InvoiceService from '../../../../services/invoice.service';
import TestService from '../../../../services/test.service';

interface IListInvoicesProps {}
interface IListInvoicesState {
    invoices: [];
    errorMessage: string;
}

class ListInvoices extends Component<IListInvoicesProps, IListInvoicesState> {
    private columns: IColumn[];

    constructor(props: IListInvoicesProps) {
        super(props);
        
        this.state = {
            invoices: [],
            errorMessage: ''
        }

        this.columns = [
            { key: 'number', name: 'Number', fieldName: 'number', minWidth: 60, maxWidth: 70, isResizable: true },
            { key: 'date', name: 'Date', fieldName: 'date', minWidth: 100, maxWidth: 200, isResizable: true },
            { key: 'clientName', name: 'Client', fieldName: 'clientName', minWidth: 100, maxWidth: 200, isResizable: true },
            { key: 'amount', name: 'Amount', fieldName: 'amount', minWidth: 100, maxWidth: 200, isResizable: true },
            { key: 'nationalIdentityNumber', name: 'National Identity Number', fieldName: 'nationalIdentityNumber', minWidth: 150, maxWidth: 300, isResizable: true },
        ];
    }

    componentDidMount() {
        this.setState({errorMessage: ''}, async () => {
            try {
                const invoices = await InvoiceService.all();
                console.log(invoices);
                this.setState({invoices: invoices})
            } catch (error) {
                console.error(error);
            }
        })
    }

    private _onItemInvoked = (item: any): void => {
        alert(`Item invoked: ${item.name}`);
    };

    render (): JSX.Element {
        return (
            <div className='list-invoices'>
                {this.state.invoices.length > 0 
                    ? <DetailsList
                            items={this.state.invoices}
                            columns={this.columns}
                            setKey="set"
                            layoutMode={DetailsListLayoutMode.justified}
                            selectionPreservedOnEmptyClick={true}
                            ariaLabelForSelectionColumn="Toggle selection"
                            ariaLabelForSelectAllCheckbox="Toggle selection for all items"
                            checkButtonAriaLabel="Row checkbox"
                            onItemInvoked={this._onItemInvoked}
                        />
                    : <div>Fakturite pristigat</div>
                }
            </div>
        );
    }
}

export default ListInvoices;