import { AxiosResponse } from 'axios';
import React, { ChangeEvent, MouseEvent } from 'react';
import { Button, Form, Modal } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import withRouter, { RoutedProps } from '../../components/utility/routed-props';
import { Person, PersonToUpdate, Playlist, Song } from '../../models';
import APIService from '../../services/apiService';
import FavoriteSong from './FavoriteSong';
import PlaylistTableDisplay from './PlaylistTableDisplay';

interface PeopleDetailsParams {
    personId: string;
}

type PersonDetailsViewProps = RoutedProps<PeopleDetailsParams>;

type PersonDetailsViewState = {
    Id: number;
    FirstName: string;
    LastName: string;
    Birthday: string;
    FavoriteSong: Song;
    LikedPlaylists: Playlist[];
    OwnedPlaylists: Playlist[];
    showEditForm: boolean;  
};

export class PersonDetailsView extends React.Component<PersonDetailsViewProps, PersonDetailsViewState> {
    constructor(props: PersonDetailsViewProps) {
        super(props);
        this.state = {
            Id: this.props.params.personId as unknown as number,
            FirstName: '',
            LastName: '',
            Birthday:'',
            FavoriteSong: {
                Id: 0,
                AlbumTitle: '',
                Artist: '',
                Title: '',
                Length: ''
            },
            LikedPlaylists: [],
            OwnedPlaylists: [],
            showEditForm: false
        };
    }

    componentDidMount(){
        APIService.getPerson(this.props.params.personId as unknown as number)
        .then((response: AxiosResponse<Person>) => {
            let s = response.data;
            this.setState({
                Id: s.Id,
                FirstName: s.FirstName,
                LastName: s.LastName,
                Birthday: s.Birthday,
                FavoriteSong: s.FavoriteSong ?? {},
                LikedPlaylists: s.LikedPlaylists ?? [],
                OwnedPlaylists: s.OwnedPlaylists ?? []               
            });
        })
    }

    handleEditBtnClick = (event: MouseEvent<HTMLButtonElement>) => {
        this.setState({
            showEditForm: true
        });
    }

    handleFirstNameChange = (event: ChangeEvent<HTMLInputElement>) => {
        this.setState({
            FirstName: event.target.value
        });
    }

    handleLastNameChange = (event: ChangeEvent<HTMLInputElement>) => {
        this.setState({
            LastName: event.target.value
        });
    }

    handleBirthdayChange = (event: ChangeEvent<HTMLInputElement>) => {
        this.setState({
            Birthday: event.target.value
        });
    }

    handleFormSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        let personChanged: PersonToUpdate = {
            Id: this.state.Id,
            FirstName: this.state.FirstName,
            LastName: this.state.LastName,
            Birthday: this.state.Birthday,
        };
        this.handleUpdateModel(personChanged);
        this.handleCloseClick();
    }

    handleSaveChangesClick = (event: MouseEvent<HTMLButtonElement>) => {
        event.preventDefault();
        let personChanged: PersonToUpdate = {
            Id: this.state.Id,
            FirstName: this.state.FirstName,
            LastName: this.state.LastName,
            Birthday: this.state.Birthday
        };
        this.handleUpdateModel(personChanged);
        this.handleCloseClick();
    }

    handleCloseClick = () => {
        this.setState({
            showEditForm: false
        });
    }

    handleUpdateModel = (person: PersonToUpdate) => {
        APIService.updatePerson(person)
        .then((response: AxiosResponse<Person>) => {
            let p = response.data;
            this.setState({
                Id: p.Id,
                FirstName: p.FirstName,
                LastName: p.LastName,
                Birthday: p.Birthday
            });
        }).catch((err) => {
            console.log(err);
        });
    }

    render(): React.ReactNode {
        return(
            <>
                <div className="App container">
                    <div className="jumbotron">
                        <h4>Person Details</h4>
                    </div>
                    <hr />
                    <dl className="row">
                        <dt className="col-sm-2">Id:</dt><dd className="col-sm-10">{this.state.Id}</dd>
                        <dt className="col-sm-2">First Name:</dt><dd className="col-sm-10">{this.state.FirstName}</dd>
                        <dt className="col-sm-2">Last Name:</dt><dd className="col-sm-10">{this.state.LastName}</dd>
                        <dt className="col-sm-2">Birthday:</dt><dd className="col-sm-10">{this.state.Birthday}</dd>
                        <FavoriteSong song={this.state.FavoriteSong} />
                        <PlaylistTableDisplay title={"Liked Playlists"} playlists={this.state.LikedPlaylists} />
                        <PlaylistTableDisplay title={"Owned Playlists"} playlists={this.state.OwnedPlaylists} />
                    </dl>
                    <div>
                        <Link to="/music">
                            <Button className="btn btn-danger">&lt; Back</Button>
                        </Link>
                        <Button className="btn btn-primary" onClick={this.handleEditBtnClick}>Edit</Button>
                    </div>
                    <hr />
                    <div>

                    </div>
                </div>
                <Modal show={this.state.showEditForm} size="lg" aria-labelledby="contained-modal-title-vcenter" centered>
                    <Modal.Header closeButton>
                        <Modal.Title id="contained-modal-title-vcenter">Edit Person</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Form onSubmit={this.handleFormSubmit}>
                            <Form.Group className="mb-3" controlId="personId">
                                <Form.Label>Id</Form.Label>
                                <Form.Control value={this.state.Id} disabled />
                            </Form.Group>
                            <Form.Group className="mb-3" controlId="firstName">
                                <Form.Label>First Name:</Form.Label>
                                <Form.Control type="text" value={this.state.FirstName} onChange={this.handleFirstNameChange} />
                            </Form.Group>
                            <Form.Group className="mb-3" controlId="lastName">
                                <Form.Label>Last Name:</Form.Label>
                                <Form.Control type="text" value={this.state.LastName} onChange={this.handleLastNameChange} />
                            </Form.Group>
                            <Form.Group className="mb-3" controlId="birthday">
                                <Form.Label>Birthday</Form.Label>
                                <Form.Control type="text" value={this.state.Birthday} onChange={this.handleBirthdayChange} />
                            </Form.Group>
                        </Form>
                        

                    </Modal.Body>
                    <Modal.Footer>
                        <Button variant='secondary' onClick={this.handleCloseClick}>Close</Button>
                        <Button variant='primary' onClick={this.handleSaveChangesClick}>Save</Button>
                    </Modal.Footer>

                </Modal>
            </>
        );
    }
}

export default withRouter(PersonDetailsView);