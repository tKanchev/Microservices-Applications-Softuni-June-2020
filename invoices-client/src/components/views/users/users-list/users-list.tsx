import React, { Component } from 'react';
import UserService from '../../../../services/user.service';
import { DetailsList, DetailsListLayoutMode, IColumn } from 'office-ui-fabric-react/lib/DetailsList';
import { Dialog, DialogType, DialogFooter } from 'office-ui-fabric-react/lib/Dialog';
import { PrimaryButton, DefaultButton } from 'office-ui-fabric-react/lib/Button';
import { TextField } from 'office-ui-fabric-react';


interface IUsersListProps {}
interface IUsersListState {
    users: [];
    toggleHideChangePassDialog: boolean;
    toggleHideDeleteDialog: boolean;
    editUser: any;
    editPassword: string;
    errorMessage: string;
}

class UserList extends Component<IUsersListProps, IUsersListState> {
    private columns: IColumn[];

    constructor(props: IUsersListProps) {
        super(props);
        
        this.state = {
            users: [],
            toggleHideChangePassDialog: true,
            toggleHideDeleteDialog: true,
            editUser: {},
            editPassword: '',
            errorMessage: ''
        }

        this.columns = [
            
            { key: 'name', name: 'Name', fieldName: 'name', minWidth: 150, maxWidth: 200, isResizable: true },
            { key: 'email', name: 'Email', fieldName: 'email', minWidth: 150, maxWidth: 200, isResizable: true },
            { key: 'nationalIdentityNumber', name: 'NationalIdentityNumber', fieldName: 'nationalIdentityNumber', minWidth: 160, maxWidth: 200, isResizable: true },
            {
                key: 'changePass',
                name: '',
                onRender: user => (
                    user && user.name !== 'Admin' && <PrimaryButton text="Change password" onClick={() => this.openChangePasswordModal(user)}/>
                ),
                minWidth: 150
            } as IColumn,
            {
                key: 'delete',
                name: '',
                onRender: user => (
                    user && user.name !== 'Admin' && <PrimaryButton text="Delete" onClick={() => this.openDeletedModal(user)}/>
                ),
                minWidth: 100
            } as IColumn,
        ];
    }

    private openChangePasswordModal = (user: any) => {
        this.setState(prevState =>{
            return{
                 ...prevState,
                 toggleHideChangePassDialog : !prevState.toggleHideChangePassDialog,
                 editUser: user
            }
         })
    };

    private openDeletedModal = (user: any) => {
        this.setState(prevState =>{
            return{
                 ...prevState,
                 toggleHideDeleteDialog : !prevState.toggleHideDeleteDialog,
                 editUser: user
            }
         })
    };

    private changePassword = () => {
        this.setState({errorMessage: ''}, async () => {
            try {
                const changePasswordinput = {
                    userId: this.state.editUser.id,
                    password: this.state.editPassword
                };

                await UserService
                    .changePassword(changePasswordinput)
                    .then(async () => {
                        this.toggleHideChangePassDialog()
                        console.log('Pass Changed!')
                    });
            } catch (error) {
                console.error(error);
            }
        })
    };

    private deleteUser = () => {
        this.setState({errorMessage: ''}, async () => {
            try {
                await UserService
                    .delete(this.state.editUser.id)
                    .then(async () => {
                        const users =  await UserService.all();
                        this.setState(prevState =>{
                            return{
                                 ...prevState,
                                 users: users,
                                 toggleHideDeleteDialog : !prevState.toggleHideDeleteDialog
                            }
                         })
                    });
            } catch (error) {
                console.error(error);
            }
        })
    };

    private toggleHideChangePassDialog = () => {
        this.setState(prevState =>{
            return{
                 ...prevState,
                 toggleHideChangePassDialog : !prevState.toggleHideChangePassDialog
            }
         })
    };

    private toggleHideDeleteDialog = () => {
        this.setState(prevState =>{
            return{
                 ...prevState,
                 toggleHideDeleteDialog : !prevState.toggleHideDeleteDialog
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

    private handleInputChange = (event: any) => {
        const target = event.target;
        const value = target.value;
        const name = target.name;
        this.setState(prevState => ({
            ...prevState,
            [name]: value
        }));
    }

    render (): JSX.Element {
        const changePasswordContentProps = {
            type: DialogType.normal,
            title: `Change Password`,
            subText: this.state.editUser.email
        };

        const deleteContentProps = {
            type: DialogType.normal,
            title: 'Delete User',
            subText: `Are you sure you want to delete ${this.state.editUser.email}`
        };

        return (
            <div className='users-list'>
                <Dialog
                    hidden={this.state.toggleHideChangePassDialog}
                    onDismiss={this.toggleHideChangePassDialog}
                    dialogContentProps={changePasswordContentProps}
                >
                    <TextField
                        label='Password '
                        id='editPassword'
                        name='editPassword'
                        value={this.state.editPassword}
                        onChange={this.handleInputChange}
                        required
                    />
                    <DialogFooter>
                        <PrimaryButton onClick={() => this.changePassword()} text="Send" />
                        <DefaultButton onClick={() => this.toggleHideChangePassDialog()} text="Cancel" />
                    </DialogFooter>
                </Dialog>
                <Dialog
                    hidden={this.state.toggleHideDeleteDialog}
                    onDismiss={this.toggleHideDeleteDialog}
                    dialogContentProps={deleteContentProps}
                >
                    <DialogFooter>
                        <PrimaryButton onClick={() => this.deleteUser()} text="Delete" />
                        <DefaultButton onClick={() => this.toggleHideDeleteDialog()} text="Cancel" />
                    </DialogFooter>
                </Dialog>
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