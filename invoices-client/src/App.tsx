import React  from 'react';
import './App.scss';
import Navbar from './components/navbar/navbar';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import Register from './components/views/register/register';
import Login from './components/views/login/login';
import Roles from './components/views/roles/roles/roles';
import Users from './components/views/users/users/users';
import Invoices from './components/views/invoices/invoices/invoices';
import Home from './components/views/home/home';
import CreateInvoice from './components/views/invoices/create-invoice/create-invoice';
import CreateRole from './components/views/roles/create-role/create-role';
import Logout from './components/views/logout/logout';
import Admin from './components/views/admin/admin/admin';
import { Link, MessageBar, MessageBarType } from 'office-ui-fabric-react';
import * as signalR from '@microsoft/signalr';
import { initializeIcons } from '@uifabric/icons';
initializeIcons();

function App() {
	const [state, setState] = React.useState({
        showNotification: false,
        notificationText: ''
    });
    
    const token = localStorage.getItem('token');
	const options = {
		accessTokenFactory: () : string | Promise<string> => {
            return token 
                ? token 
                : '';
		},
	};

	const hubConnection = new signalR.HubConnectionBuilder()
		.withUrl('https://localhost:5008/notifications', options)
		.build();

    hubConnection
        .start()
        .then(() => console.log('Connection started'))
        .catch(err => console.log('Error while starting connection: ' + err));
    
    hubConnection.on('receiveNotification', (message) => {
        setState({
            showNotification: true,
            notificationText: `You have a new invoice for ${message.amount} leva! Go to Invoices to view it `
        });
    });

	const closeNotification = () => {
		setState({showNotification: false, notificationText: '' });
    };
    
	return (
		<div className='App'>
			<Navbar />
			{state.showNotification && (
				<MessageBar
					className='notification'
					messageBarType={MessageBarType.success}
					isMultiline={false}
					onDismiss={closeNotification}
					dismissButtonAriaLabel='Close'
				>
					{state.notificationText}
					<Link href='/invoices'>Invoices</Link>
				</MessageBar>
			)}
			<BrowserRouter>
				<Switch>
					<Route exact path='/' component={Home} />
					<Route exact path='/login' component={Login} />
					<Route exact path='/logout' component={Logout} />
					<Route exact path='/register' component={Register} />
					<Route exact path='/roles' component={Roles} />
					<Route exact path='/roles/create' component={CreateRole} />
					<Route exact path='/users' component={Users} />
					<Route exact path='/invoices' component={Invoices} />
					<Route exact path='/invoices/create' component={CreateInvoice} />
					<Route exact path='/payments' component={Invoices} />
					<Route exact path='/admin' component={Admin} />
				</Switch>
			</BrowserRouter>
		</div>
	);
}

export default App;
