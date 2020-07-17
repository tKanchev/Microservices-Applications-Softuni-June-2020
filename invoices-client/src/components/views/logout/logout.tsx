import React, { Component } from 'react';
import {Redirect} from 'react-router-dom';

interface ILogoutProps {}
interface ILogoutState {
    redirect: boolean;
}

class Logout extends Component<ILogoutProps, ILogoutState> {
    constructor(props: any) {
        super(props);
        
        this.state = {
            redirect: false
        }
    }

    componentDidMount() {
        localStorage.clear();
        this.setState({redirect: true}, () => {window.location.reload()});
    }

    render (): JSX.Element {
        const { redirect } = this.state;

        if (redirect) {
            return <Redirect to='/'/>;
        }

        return <div>Logging out...</div>
    }
}

export default Logout;