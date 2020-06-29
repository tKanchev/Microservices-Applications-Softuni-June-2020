import React, { Component } from 'react';
import UserService from '../../../../services/user.service';
import { DetailsList, DetailsListLayoutMode, IColumn } from 'office-ui-fabric-react/lib/DetailsList';
import { PrimaryButton } from 'office-ui-fabric-react';

interface IUsersListProps {}
interface IUsersListState {
    users: [];
    errorMessage: string;
}

class UserList extends Component<IUsersListProps, IUsersListState> {
    private columns: IColumn[];

    constructor(props: IUsersListProps) {
        super(props);
        
        this.state = {
            users: [],
            errorMessage: ''
        }

        this.columns = [
            
            { key: 'name', name: 'Name', fieldName: 'name', minWidth: 100, maxWidth: 200, isResizable: true },
            { key: 'email', name: 'Email', fieldName: 'email', minWidth: 100, maxWidth: 200, isResizable: true },
            { key: 'nationalIdentityNumber', name: 'NationalIdentityNumber', fieldName: 'nationalIdentityNumber', minWidth: 100, maxWidth: 200, isResizable: true },
            {
                key: 'changePass',
                name: '',
                onRender: user => (
                    user && user.name !== 'Admin' && <PrimaryButton text="Change password" onClick={() => this.changePassword(user)}/>
                ),
            } as IColumn,
        ];
    }

    private changePassword = (user: any) => {
        this.setState({errorMessage: ''}, async () => {
            try {
                console.log(user, 'change password');
                // await UserService
                //     .delete(user.id)
                //     .then(async () => {
                //         const users =  await UserService.all();
                //         this.setState({users: users})
                //     });
            } catch (error) {
                console.error(error);
            }
        })
    };

    componentDidMount() {
        this.setState({errorMessage: ''}, async () => {
            try {
                const users = await UserService.all();
                this.setState({users: users})
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
            <div className='users-list'>
                {this.state.users.length > 0 
                    ? <DetailsList
                            items={this.state.users}
                            columns={this.columns}
                            setKey="set"
                            layoutMode={DetailsListLayoutMode.justified}
                            selectionPreservedOnEmptyClick={true}
                            ariaLabelForSelectionColumn="Toggle selection"
                            ariaLabelForSelectAllCheckbox="Toggle selection for all items"
                            checkButtonAriaLabel="Row checkbox"
                            onItemInvoked={this._onItemInvoked}
                        />
                    : <div>You have to be logged in</div>
                }
            </div>
        );
    }
}

export default UserList;