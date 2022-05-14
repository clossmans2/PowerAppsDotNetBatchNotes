import React from "react";
import { Nav } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";
import Person from "../../models/person";


type PeopleListViewProps = {
    people: Person[];
}

export class PeopleListView extends React.Component<PeopleListViewProps> {
    render(): React.ReactNode {
        return (
            <div className="App container">
                <div className="jumbotron">
                    <h2>Friends and Neighbors</h2>
                </div>
                <table className="table table-striped table-bordered table-hover table-highlight">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Birthday</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.props.people.map( (person: Person) =>  (           
                            <React.Fragment key={person.Id}>
                            <tr id={"song-" + person.Id}>
                                <td>{person.Id}</td>
                                <td>{person.FirstName}</td>
                                <td>{person.LastName}</td>
                                <td>{person.Birthday.toISOString()}</td>
                                <td>
                                    <LinkContainer to={"/people/" + person.Id}>
                                        <Nav.Link className="btn btn-primary">
                                            Edit
                                        </Nav.Link>
                                    </LinkContainer>
                                </td>
                            </tr>
                            </React.Fragment>
                        ))};
                    </tbody>
                </table>
            </div>
        );
    }
}

export default PeopleListView;