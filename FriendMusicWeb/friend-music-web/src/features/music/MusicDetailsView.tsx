import { AxiosResponse } from 'axios';
import React, { ChangeEvent, MouseEvent } from 'react';
import { Button, Card, Form, ListGroup, Modal } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import withRouter, { RoutedProps } from '../../components/utility/routed-props';
import { Song, SongToUpdate } from '../../models';
import APIService from '../../services/apiService';

interface MusicDetailsParams {
    songId: string;
}

type MusicDetailsViewProps = RoutedProps<MusicDetailsParams>;

type MusicDetailsViewState = {
    Id: number
    AlbumTitle: string,
    Artist: string,
    Length: string,
    Title: string,
    showEditForm: boolean;

};

export class MusicDetailsView extends React.Component<MusicDetailsViewProps, MusicDetailsViewState> {
    constructor(props: MusicDetailsViewProps) {
        super(props);
        this.state = {
            Id: this.props.params.songId as unknown as number,
            AlbumTitle: '',
            Artist: '',
            Length:'',
            Title:'',
            showEditForm: false
        };
    }
    componentDidMount(){
        APIService.getSong(this.props.params.songId as unknown as number)
        .then((response: AxiosResponse<Song>) => {
            let s = response.data;
            this.setState({
                Id: s.Id,
                Artist: s.Artist,
                AlbumTitle: s.AlbumTitle,
                Length: s.Length,
                Title: s.Title,
                showEditForm: false
            });
        })
    }

    handleEditBtnClick = (event: MouseEvent<HTMLButtonElement>) => {
        this.setState({
            showEditForm: true
        });
    }

    handleAlbumChange = (event: ChangeEvent<HTMLInputElement>) => {
        this.setState({
            AlbumTitle: event.target.value
        });
    }

    handleArtistChange = (event: ChangeEvent<HTMLInputElement>) => {
        this.setState({
            Artist: event.target.value
        });
    }

    handleTitleChange = (event: ChangeEvent<HTMLInputElement>) => {
        this.setState({
            Title: event.target.value
        });
    }

    handleLengthChange = (event: ChangeEvent<HTMLInputElement>) => {
        this.setState({
            Length: event.target.value
        });
    }

    handleFormSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        let songChanged: SongToUpdate = {
            Id: this.state.Id,
            Artist: this.state.Artist,
            AlbumTitle: this.state.AlbumTitle,
            Length: this.state.Length,
            Title: this.state.Title
        };
        this.handleUpdateModel(songChanged);
        this.handleCloseClick();
    }

    handleSaveChangesClick = (event: MouseEvent<HTMLButtonElement>) => {
        event.preventDefault();
        let songChanged: SongToUpdate = {
            Id: this.state.Id,
            Artist: this.state.Artist,
            AlbumTitle: this.state.AlbumTitle,
            Length: this.state.Length,
            Title: this.state.Title
        };
        this.handleUpdateModel(songChanged);
        this.handleCloseClick();
    }

    handleCloseClick = () => {
        this.setState({
            showEditForm: false
        });
    }

    handleUpdateModel = (song: SongToUpdate) => {
        APIService.updateSong(song)
        .then((response: AxiosResponse<Song>) => {
            let s = response.data;
            this.setState({
                Id: s.Id,
                AlbumTitle: s.AlbumTitle,
                Artist: s.Artist,
                Length: s.Length,
                Title: s.Title
            });
        }).catch((err) => {
            console.log(err);
        });
    }

    render(): React.ReactNode {
        return(
            <>
                <div className="App container">
                    <Card>
                        <Card.Title>
                            <h4>Song Details</h4>
                        </Card.Title>
                        <Card.Body>
                        <ListGroup>
                            <ListGroup.Item>Id: {this.state.Id}</ListGroup.Item>
                            <ListGroup.Item>Album: {this.state.AlbumTitle}</ListGroup.Item>
                            <ListGroup.Item>Artist: {this.state.Artist}</ListGroup.Item>
                            <ListGroup.Item>Title: {this.state.Title}</ListGroup.Item>
                            <ListGroup.Item>Length: {this.state.Length}</ListGroup.Item>
                        </ListGroup>
                        </Card.Body>
                        <div >

                            <Link to="/music">
                                <Button className="btn btn-danger">&lt; Back</Button>
                            </Link>
                            &nbsp;&nbsp;||&nbsp;&nbsp;
                            <Button className="btn btn-primary" onClick={this.handleEditBtnClick}>Edit</Button>
                        </div>
                    </Card>
                </div>
                <Modal show={this.state.showEditForm} size="lg" aria-labelledby="contained-modal-title-vcenter">
                    <Modal.Header closeButton>
                        <Modal.Title id="contained-modal-title-vcenter">Edit Song</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Form onSubmit={this.handleFormSubmit}>
                            <Form.Group className="mb-3" controlId="songId">
                                <Form.Label>Id</Form.Label>
                                <Form.Control value={this.state.Id}  disabled />
                            </Form.Group>
                            <Form.Group className="mb-3" controlId="artistName">
                                <Form.Label>Artist</Form.Label>
                                <Form.Control type="text" value={this.state.Artist} onChange={this.handleArtistChange} />
                            </Form.Group>
                            <Form.Group className="mb-3" controlId="albumTitle">
                                <Form.Label>Album</Form.Label>
                                <Form.Control type="text" value={this.state.AlbumTitle} onChange={this.handleAlbumChange} />
                            </Form.Group>
                            <Form.Group className="mb-3" controlId="songTitle">
                                <Form.Label>Title</Form.Label>
                                <Form.Control type="text" value={this.state.Title} onChange={this.handleTitleChange} />
                            </Form.Group>
                            <Form.Group className="mb-3" controlId="songLength">
                                <Form.Label>Length</Form.Label>
                                <Form.Control type="text" value={this.state.Length} onChange={this.handleLengthChange} />
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

export default withRouter(MusicDetailsView);