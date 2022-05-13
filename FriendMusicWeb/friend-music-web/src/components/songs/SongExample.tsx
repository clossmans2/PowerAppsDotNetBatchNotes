/* eslint-disable @typescript-eslint/no-useless-constructor */
import { AxiosResponse } from "axios";
import React from "react";
import Song from "../../models/song";
import APIService from "../../services/apiService";


class SongExample extends React.Component {
    constructor(props: any) {
        super(props)
        this.state ={
            myStateVariable: 0,
            songList: []
        }
    }

    componentDidMount() {
        let rows = APIService.getSongs()
            .then((res: AxiosResponse<Song[]>) => {
                this.setState({
                    songList: res.data
                });
            })
    }

    render() {
        return (
            <React.Fragment>
                <h1>Cards!</h1>
                <div className="card">
                    <img src="" alt="" />
                    <div className="card-body">
                        <h5 className="card-title">Title text</h5>
                        <p className="card-text">Some example text as a placeholder, Lorem ipsum dolor sit.</p>
                        <a href="https://www.google.com" className="btn btn-primary">Button Press Me!</a>
                    </div>
                </div>
            </React.Fragment>
        );
    }

    componentDidUpdate() {

    }

    componentWillUnmount() {

    }


}

export default SongExample;