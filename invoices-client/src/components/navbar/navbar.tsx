import React, { Component } from 'react';
import { CommandBar, ICommandBarItemProps } from 'office-ui-fabric-react/lib/CommandBar';
import { Redirect} from 'react-router-dom';


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

    componentDidMount() {
        this.setState({errorMessage: ''}, async () => {
            try {

                
            } catch (error) {
                console.error(error);
            }
        })
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

        // if (this.state.redirect) {
        //     return <Redirect to={{ pathname: '/' }} />
        // }

        return (
            <CommandBar
                className='navbar'
                items={items}
                farItems={this.isUserLogged() ? logout : login}
            />
            // <Pivot className='navbar'>
                
            //     {/* <PivotItem headerText="Login" onClick={() => this.navigate('maika ti')}>
            //     </PivotItem>
            //     <PivotItem headerText="Register">
            //         <Register/>
            //     </PivotItem>
            //     <PivotItem headerText="Create Role">
            //         <CreateRole/>
            //     </PivotItem>
            //     <PivotItem headerText="Users">
            //         <UserList/>
            //     </PivotItem>
            //     <PivotItem headerText="Invoices">
            //         <Invoices/>
            //     </PivotItem>
            //     <PivotItem headerText="Logout">
            //         <PrimaryButton className='logout-button' text="Logout" onClick={event => this.logout()}/>
            //     </PivotItem> */}
            // </Pivot>
        );
    }
}

export default Navbar;