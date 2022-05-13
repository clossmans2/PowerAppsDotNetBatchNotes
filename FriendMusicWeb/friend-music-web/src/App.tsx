import React from "react";
import "./App.css";
import FilteredSongTable from "./components/songs/FilteredSongTable";
import Song from "./models/song";
import APIService from "./services/apiService";

type AppProps = {
  
};

type AppState = {
  songList: Song[];
};

class App extends React.Component<AppProps, AppState> {
  state: AppState ={
    songList: []
  };

  componentDidMount() {
    APIService.getSongs()
      .then((response) => {
        this.setState({
          songList: response.data
        });
      })
      .catch((err: Error) => {
        console.log(err);
      });
  }
  
  render() {
    return (
      <main>
        <div className="App container">
          <div className="jumbotron">
            <h2>Songs from 2005</h2>
          </div>
          <FilteredSongTable songs={this.state.songList} />
        </div>
      </main>
    );
  }

  // addSong = (song: Song) => {
  //   this.setState((state) => {
  //     state.songList.push(song)
  //   });
  // };
}

export default App;
