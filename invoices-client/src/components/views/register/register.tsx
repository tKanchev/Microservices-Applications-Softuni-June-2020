import React, { Component } from 'react';
import { TextField, PrimaryButton } from 'office-ui-fabric-react';
import AuthenticationService from '../../../services/authentication.service';
import { Link } from 'office-ui-fabric-react/lib/Link';
import {Redirect} from 'react-router-dom';

interface IRegisterProps {}
interface IRegisterState {
    email: string;
    password: string;
    name: string;
    nationalIdentityNumber: string;
    errorMessage: string;
    redirect: boolean;
}

class Register extends Component<IRegisterProps, IRegisterState> {
    constructor(props: IRegisterProps) {
        super(props);
        
        this.state = {
            email: '',
            password: '',
            name: '',
            nationalIdentityNumber: '',
            errorMessage: '',
            redirect: false
        }

        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    private handleInputChange(event: any) {
        const target = event.target;
        const value = target.value;
        const name = target.name;
        this.setState(prevState => ({
            ...prevState,
            [name]: value
        }));
    }

    private handleSubmit(event: any) {
        event.preventDefault();
        this.setState({errorMessage: ''}, async () => {
            try {
                const user = {
                    email: this.state.email,
                    password: this.state.password,
                    name: this.state.name,
                    nationalIdentityNumber: this.state.nationalIdentityNumber
                }

                await AuthenticationService.register(user);
                
                this.setState({redirect: true})
            } catch (error) {
                console.error(error);
            }
        })
    }

    render (): JSX.Element {
        const { redirect } = this.state;

        if (redirect) {
            return <Redirect to='/login'/>;
        }

        return (
            <div className='register'>
                <div className='register__title'>Register</div>
                <form
                    className='register__form'
                    onSubmit={event => {
                        this.handleSubmit(event);
                    }}
                >
                    <TextField
                        label='Name '
                        id='name'
                        name='name'
                        value={this.state.name}
                        onChange={this.handleInputChange}
                        required
                    />
                    <TextField
                        label='National Identity Number '
                        id='nationalIdentityNumber'
                        name='nationalIdentityNumber'
                        value={this.state.nationalIdentityNumber}
                        onChange={this.handleInputChange}
                        required
                    />
                    <TextField
                        label='Email '
                        id='email'
                        name='email'
                        value={this.state.email}
                        onChange={this.handleInputChange}
                        required
                    />
                    <TextField
                        label='Password '
                        type='password'
                        id='password'
                        name='password'
                        value={this.state.password}
                        onChange={this.handleInputChange}
                        required
                    />
                    <div className='actions'>
                        <PrimaryButton className='actions__register-button' text="Register" onClick={event => this.handleSubmit(event)}/>
                        <Link href='login'>Login</Link>
                    </div>
                </form>
            </div>
        );
    }
}

export default Register;