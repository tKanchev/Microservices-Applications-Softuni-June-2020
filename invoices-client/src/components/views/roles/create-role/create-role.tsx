import React, { Component } from 'react';
import { TextField, PrimaryButton } from 'office-ui-fabric-react';
import RoleService from '../../../../services/role.service';

interface IRoleProps {}
interface IRoleState {
    name: string;
    errorMessage: string;
}

class CreateRole extends Component<IRoleProps, IRoleState> {
    constructor(props: IRoleProps) {
        super(props);
        
        this.state = {
            name: '',
            errorMessage: ''
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
                const role = {
                    name: this.state.name
                }

                const result = await RoleService.create(role);

                console.log(result);
            } catch (error) {
                console.error(error);
            }
        })
    }

    render (): JSX.Element {
        return (
            <div className='create-role'>
                <div className='create-role__title'>Create Role</div>
                <form
                    className='create-role__form'
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
                    <div className='actions'>
                        <PrimaryButton className='actions__create-button' text="Create" onClick={event => this.handleSubmit(event)}/>
                    </div>
                </form>
            </div>
        );
    }
}

export default CreateRole;