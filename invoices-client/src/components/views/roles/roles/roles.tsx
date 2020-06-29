import React, { Component } from 'react';
import { PrimaryButton } from 'office-ui-fabric-react';

class Roles extends Component {
    constructor(props: any) {
        super(props);
        
        this.state = {}
    }

    render (): JSX.Element {
        return (
            <div className='roles'>
                <PrimaryButton className='create-button' text="Create new" href='/roles/create'/>
            </div>
        );
    }
}

export default Roles;