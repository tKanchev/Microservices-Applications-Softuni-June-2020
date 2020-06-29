import React, { Component } from 'react';
import UserList from '../users-list/users-list';

class Users extends Component {
    render (): JSX.Element {
        return (
            <div className='users'>
                <UserList/>
            </div>
        );
    }
}

export default Users;