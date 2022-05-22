import { AxiosResponse } from 'axios';
import React, { ChangeEvent } from 'react';
import { Form, Button, Container } from 'react-bootstrap';
import withRouter, { RoutedProps } from '../../components/utility/routed-props';
import Playlist, { PlaylistToAdd } from '../../models/playlist';
import APIService from '../../services/apiService';

type NewPlaylistViewProps = RoutedProps;
type NewPlaylistViewState = {
    Title: string;
    Description: string;
}

export class NewPlaylistView extends React.Component<NewPlaylistViewProps, NewPlaylistViewState> {
    constructor(props: NewPlaylistViewProps){
        super(props);
        this.state = {
            Title: '',
            Description: ''
        }
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
        let playlistChanged: PlaylistToAdd = {
            Title: this.state.Title,
            Description: this.state.Description
        };
        this.handleUpdateModel(playlistChanged);
        this.handleCloseClick();
    }

    handleSaveChangesClick = (event: React.MouseEvent<HTMLButtonElement>) => {
        event.preventDefault();
        let playlistChanged: PlaylistToAdd = {
            Title: this.state.Title,
            Description: this.state.Description
        };
        this.handleUpdateModel(playlistChanged);
        this.handleCloseClick();
    }

    handleCloseClick = () => {
        this.props.history.goBack();
    }

    handleUpdateModel = (playlist: PlaylistToAdd) => {
        APIService.createPlaylist(playlist)
        .then((response: AxiosResponse<Playlist>) => {
            let p = response.data;
            console.log(`Successfully added ${p}`);
        })
       .catch((err) => {
            console.log(err);
        });
    }

    render(): React.ReactNode {
        return (
            <>
                <div className='appContainer'>
                    <div className="jumbotron">
                        <h2>Add New Playlist</h2>
                    </div>
                    <Container>
                    <Form onSubmit={this.handleFormSubmit}>
                            <Form.Group className="mb-3" controlId="playlistId">
                                <Form.Label>Id</Form.Label>
                                <Form.Control placeholder="Disabled input" disabled />
                            </Form.Group>
                            <Form.Group className="mb-3" controlId="artistName">
                                <Form.Label>Title</Form.Label>
                                <Form.Control type="text" value={this.state.Title} onChange={this.handleTitleChange} />
                            </Form.Group>
                            <Form.Group className="mb-3" controlId="albumTitle">
                                <Form.Label>Description</Form.Label>
                                <Form.Control type="text" value={this.state.Description} onChange={this.handleDescriptionChange} />
                            </Form.Group>
                            <Form.Group>
                                <Button variant='secondary' onClick={this.handleCloseClick}>Close</Button>
                                <Button variant='primary' onClick={this.handleSaveChangesClick}>Save</Button>
                            </Form.Group>
                        </Form>
                    </Container>
                </div>
            </>
        );
    }
}

export default withRouter(NewPlaylistView);