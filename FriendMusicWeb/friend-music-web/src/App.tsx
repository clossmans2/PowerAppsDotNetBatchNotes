import { AxiosResponse } from "axios";
import React, { Component, useState } from "react";
import "./App.css";
import FilteredSongTable from "./components/songs/FilteredSongTable";
import Song from "./models/song";
import APIService from "./services/apiService";

type AppProps = {
  
};

type AppState = {
  songList: Song[];
};

class App extends Component<AppProps, AppState> {
  state: AppState = {
    songList: [],
  };
  
  render() {
    APIService.getSongs()
      .then((response) => {
        response.data.forEach((song: Song) => {
          this.addSong(song);
        });
      })
      .catch((err: Error) => {
        console.log(err);
      });
    return (
      <div className="App">
        <FilteredSongTable Songs={this.state.songList} />
      </div>
    );
  }

  addSong = (song: Song) => {
    this.setState((state) => {
      state.songList.push(song)
    });
  };
}

export default App;
