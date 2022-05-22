import { AxiosResponse } from "axios";
import React from "react";
import { Table } from "react-bootstrap";
import { Link } from "react-router-dom";
import Person from "../../models/person";
import APIService from "../../services/apiService";


type PeopleListViewProps = {}

type PeopleListViewState = {
    people: Person[];
}

export class PeopleListView extends React.Component<PeopleListViewProps, PeopleListViewState> {
    /**
     *
     */
    constructor(props: PeopleListViewProps) {
        super(props);
        this.state = {
            people: []
        }        
    }
    componentDidMount() {
        APIService.getPeople()
        .then((response: AxiosResponse<Person[]>) => {
            this.setState({
                people: response.data
            })
        })
        .catch((err) => {
            console.error(err);
        });
    }

    render(): React.ReactNode {
        return (
            <div className="App container">
                <div className="jumbotron">
                    <h2>Friends and Neighbors</h2>
                </div>
                <Table striped bordered hover>
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
                        {this.state.people.map( (person: Person) =>  (           
                            <React.Fragment key={person.Id}>
                            <tr id={"person-" + person.Id}>
                                <td>{person.Id}</td>
                                <td>{person.FirstName}</td>
                                <td>{person.LastName}</td>
                                <td>{person.Birthday}</td>
                                <td>
                                    <Link to={`${person.Id}`} className="btn btn-primary">
                                            Edit
                                    </Link>
                                </td>
                            </tr>
                            </React.Fragment>
                        ))};
                    </tbody>
                </Table>
            </div>
        );
    }
}

export default PeopleListView;