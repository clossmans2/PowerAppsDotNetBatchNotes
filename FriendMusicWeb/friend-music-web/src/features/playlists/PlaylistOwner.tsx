import React from 'react';
import { Link } from 'react-router-dom';
import { Person } from '../../models';

type PlaylistOwnerProps = {
    owner: Person;
}

export class PlaylistOwner extends React.Component<PlaylistOwnerProps> {
    render(): React.ReactNode {
        if (this.props.owner === null) {
            return (
                <>
                    <td></td>
                </>
            );
        } else {
            return (
                <>
                    <td><Link to={`{person/${this.props.owner.Id}`}>{this.props.owner.FirstName} {this.props.owner.LastName}</Link></td>
                </>
            );
        }
    }
}