import React from "react";
import { Nav, Navbar, Container } from "react-bootstrap";
import { LinkContainer } from 'react-router-bootstrap';

class NavigationBar extends React.Component {
    render(): React.ReactNode {
        return (
            <Navbar sticky="top" bg="primary" variant="dark" expand="lg">
                <Container>
                    <LinkContainer to="/">
                        <Navbar.Brand>Friend Music</Navbar.Brand>
                    </LinkContainer>
                    <Navbar.Toggle aria-controls="basic-navbar-nav" />
                    <Navbar.Collapse id="basic-navbar-nav">
                        <Nav className="me-auto">
                            <LinkContainer to="/">
                                <Nav.Link>Home</Nav.Link>
                            </LinkContainer>
                            
                            <LinkContainer to="/music">
                                <Nav.Link>Music</Nav.Link>
                            </LinkContainer>
                            
                            <LinkContainer to="/people">
                                <Nav.Link>People</Nav.Link>
                            </LinkContainer>
                            
                            <LinkContainer to="/playlists">
                                <Nav.Link>Playlists</Nav.Link>
                            </LinkContainer>
                        </Nav>
                    </Navbar.Collapse>
                </Container>
            </Navbar>
        );
    }
}

export default NavigationBar;