import React, { Component } from 'react';
import AuthenticationService from '../../../../services/authentication.service';
import UsersList from '../../users/users-list/users-list';

interface IAdminProps {}
interface IAdminState {
    isAdmin: boolean;
    errorMessage: string;
    redirect: boolean;
}

class Admin extends Component<IAdminProps, IAdminState> {
    constructor(props: IAdminProps) {
        super(props);
        
        this.state = {
            isAdmin: false,
            errorMessage: '',
            redirect: false
        }
    }

    componentDidMount(){
        this.setState({errorMessage: ''}, async () => {
            try {
                const isAdmin = await AuthenticationService.isAdmin();
                this.setState({isAdmin: isAdmin})
            } catch (error) {
                console.error(error);
            }
        })
    }

    render (): JSX.Element {
        const { isAdmin } = this.state;

        if (!isAdmin) {
            return <div>Not Authorized</div>
        }

        return (
            <div className='admin'>
                <UsersList/>
            </div>
        );
    }
}

export default Admin;