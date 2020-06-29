import React, { Component } from 'react';
import { CommandBar, ICommandBarItemProps } from 'office-ui-fabric-react/lib/CommandBar';


interface INavbarProps {}
interface INavbarState {
    users: [];
    errorMessage: string;
    logged: boolean;
    redirect: boolean;
}

class Navbar extends Component<INavbarProps, INavbarState> {
    constructor(props: INavbarProps) {
        super(props);
        
        this.state = {
            users: [],
            errorMessage: '',
            logged: false,
            redirect: false
        }
    }

    isUserLogged(): boolean {
        const token = localStorage.getItem('token')
        return token && token.length 
            ? true 
            : false;
    }

    logout(){
        localStorage.clear();
        this.setState({redirect: true});
    }

    render (): JSX.Element {
        const items: ICommandBarItemProps[] = [
            {
                key: 'home',
                text: 'Home',
                href: '/',
            },
            {
                key: 'roles',
                text: 'Roles',
                href: '/roles',
            },
            {
                key: 'users',
                text: 'Users',
                href: '/users',
            },
            {
                key: 'invoices',
                text: 'Invoices',
                href: '/invoices',
            },
            {
                key: 'payments',
                text: 'Payments',
                href: '/payments',
            },
            {
                key: 'admin',
                text: 'Admin',
                href: '/admin',
            },
        ];

        const logout: ICommandBarItemProps[] = [
            {
                key: 'logout',
                text: 'Logout',
                href: '/logout',
            },
        ];

        const login: ICommandBarItemProps[] = [
            {
                key: 'login',
                text: 'Login',
                href: '/login',
            }
        ];

        return (
            <CommandBar
                className='navbar'
                items={items}
                farItems={this.isUserLogged() ? logout : login}
            />
        );
    }
}

export default Navbar;