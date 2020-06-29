import React, { Component } from 'react';
import { Link } from 'office-ui-fabric-react/lib/Link';
import { TextField, PrimaryButton } from 'office-ui-fabric-react';
import AuthenticationService from '../../../services/authentication.service';
import {Redirect} from 'react-router-dom';

interface ILoginProps {}
interface ILoginState {
    email: string;
    password: string;
    errorMessage: string;
    redirect: boolean;
}

class Login extends Component<ILoginProps, ILoginState> {
    constructor(props: ILoginProps) {
        super(props);
        
        this.state = {
            email: '',
            password: '',
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
                    password: this.state.password
                }
                const result = await AuthenticationService.login(user);

                if (result && result.token) {
                    localStorage.removeItem('token');
                    localStorage.setItem('token', result.token);
                    localStorage.removeItem('userId');
                    localStorage.setItem('userId', result.userId);
                    
                    this.setState({redirect: true}, () => {window.location.reload()});
                }
            } catch (error) {
                console.error(error);
            }
        })
    }

    render (): JSX.Element {
        const { redirect } = this.state;

        if (redirect) {
            return <Redirect to='/'/>;
        }
        return (
            <div className='login'>
                <div className='login__title'>Login</div>
                <form
                    className='login__form'
                    onSubmit={event => {
                        this.handleSubmit(event);
                    }}
                >
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
                        <PrimaryButton className='actions__login-button' text="Login" onClick={event => this.handleSubmit(event)}/>
                        <Link href='register'>Register</Link>
                    </div>
                </form>
            </div>
        );
    }
}

export default Login;