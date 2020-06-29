import React, { Component } from 'react';
import AuthenticationService from '../../../../services/authentication.service';

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
                Dobre doshal we kaput
            </div>
        );
    }
}

export default Admin;