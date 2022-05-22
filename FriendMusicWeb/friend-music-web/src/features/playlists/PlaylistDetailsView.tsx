import { AxiosResponse } from 'axios';
import React, { ChangeEvent, MouseEvent } from 'react';
import { Button, Form, Modal } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import withRouter, { RoutedProps } from '../../components/utility/routed-props';
import { Playlist, PlaylistToUpdate } from '../../models';
import APIService from '../../services/apiService';

interface PlaylistDetailsParams {
    playlistId: string;
}

type PlaylistDetailsViewProps = RoutedProps<PlaylistDetailsParams>;

type PlaylistDetailsViewState = {
    Id: number;
    Title: string;
    Description: string;
    OwnerId: number;
    OwnerFirstName: string;
    OwnerLastName: string;    
    TotalTracks: number;
    showEditForm: boolean;
};

export class PlaylistDetailsView extends React.Component<PlaylistDetailsViewProps, PlaylistDetailsViewState> {
    constructor(props: PlaylistDetailsViewProps) {
        super(props);
        this.state = {
            Id: this.props.params.playlistId as unknown as number,
            Title: '',
            Description: '',
            OwnerId: 0,
            OwnerFirstName: '',
            OwnerLastName: '',
            TotalTracks: 0,
            showEditForm: false
        };
    }
    componentDidMount(){
        APIService.getPlaylist(this.props.params.playlistId as unknown as number)
        .then((response: AxiosResponse<Playlist>) => {
            let p = response.data;
            this.setState({
                Id: p.Id,
                Title: p.Title,
                Description: p.Description,
                OwnerId: p.Owner.Id,
                OwnerFirstName: p.Owner.FirstName,
                OwnerLastName: p.Owner.LastName,
                TotalTracks: p.TotalTracks,
            });
        })
    }

    handleEditBtnClick = (event: MouseEvent<HTMLButtonElement>) => {
        this.setState({
            showEditForm: true
        });
    }

    handleTitleChange = (event: ChangeEvent<HTMLInputElement>) => {
        this.setState({
            Title: event.target.value
        });
    }

    handleDescriptionChange = (event: ChangeEvent<HTMLInputElement>) => {
        this.setState({
            Description: event.target.value
        });
    }

    handleFormSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        let playlistChanged: PlaylistToUpdate = {
            Id: this.state.Id,
            Title: this.state.Title,
            Description: this.state.Description
        };
        this.handleUpdateModel(playlistChanged);
        this.handleCloseClick();
    }

    handleSaveChangesClick = (event: MouseEvent<HTMLButtonElement>) => {
        event.preventDefault();
        let playlistChanged: PlaylistToUpdate = {
            Id: this.state.Id,
            Title: this.state.Title,
            Description: this.state.Description
        };
        this.handleUpdateModel(playlistChanged);
        this.handleCloseClick();
    }

    handleCloseClick = () => {
        this.setState({
            showEditForm: false
        });
    }

    handleUpdateModel = (playlist: PlaylistToUpdate) => {
        APIService.updatePlaylist(playlist)
        .then((response: AxiosResponse<Playlist>) => {
            let p = response.data;
            this.setState({
                Id: p.Id,
                Title: p.Title,
                Description: p.Description,
                OwnerId: p.Owner.Id,
                OwnerFirstName: p.Owner.FirstName,
                OwnerLastName: p.Owner.LastName,
                TotalTracks: p.TotalTracks
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
                        <h4>Playlist Details</h4>
                    </div>
                    <hr />
                    <dl className="row">
                        <dt className="col-sm-2">Id:</dt><dd className="col-sm-10">{this.state.Id}</dd>
                        <dt className="col-sm-2">Title:</dt><dd className="col-sm-10">{this.state.Title}</dd>
                        <dt className="col-sm-2">Description:</dt><dd className="col-sm-10">{this.state.Description}</dd>
                        <dt className="col-sm-2">Owner:</dt><dd className="col-sm-10"><Link to={`people/${this.state.OwnerId}`}>{this.state.OwnerFirstName} {this.state.OwnerLastName}</Link></dd>
                        <dt className="col-sm-2">Total Tracks:</dt><dd className="col-sm-10">{this.state.TotalTracks}</dd>
                    </dl>
                    <div>
                        <Link to="/music">
                            <Button className="btn btn-danger">&lt; Back</Button>
                        </Link>
                        <Button className="btn btn-primary" onClick={this.handleEditBtnClick}>Edit</Button>
                    </div>
                </div>
                <Modal show={this.state.showEditForm} size="lg" aria-labelledby="contained-modal-title-vcenter" centered>
                    <Modal.Header closeButton>
                        <Modal.Title id="contained-modal-title-vcenter">Edit Playlist</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Form onSubmit={this.handleFormSubmit}>
                            <Form.Group className="mb-3" controlId="playlistId">
                                <Form.Label>Id</Form.Label>
                                <Form.Control value={this.state.Id}  disabled />
                            </Form.Group>
                            <Form.Group className="mb-3" controlId="artistName">
                                <Form.Label>Title</Form.Label>
                                <Form.Control type="text" value={this.state.Title} onChange={this.handleTitleChange} />
                            </Form.Group>
                            <Form.Group className="mb-3" controlId="albumTitle">
                                <Form.Label>Description</Form.Label>
                                <Form.Control type="text" value={this.state.Description} onChange={this.handleDescriptionChange} />
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

export default withRouter(PlaylistDetailsView);