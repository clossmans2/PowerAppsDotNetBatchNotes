import React from "react";
import { Routes, Route } from "react-router-dom";
import "./App.css";
import NavigationBar from "./components/NavigationBar";
import Person from "./models/person";
import Playlist from "./models/playlist";
import Song from "./models/song";
import APIService from "./services/apiService";
import HomeView from "./views/home/HomeView";
import MusicListView from "./views/music/MusicListView";
import PeopleListView from "./views/people/PeopleListView";
import PlaylistListView from "./views/playlists/PlaylistListView";



type AppProps = {
  songs: Song[];
  people: Person[];
  playlists: Playlist[];
};

type AppState = {};

class App extends React.Component<AppProps, AppState> {
  
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
        <NavigationBar />
        <Routes>
          <Route path="/" element={ <HomeView />} />

          <Route path="/music/*" element={  
                    <React.Suspense fallback={<>...</>}>
                      <MusicListView songs={this.props.songs} />
                    </React.Suspense>} />
          
          <Route path="/people/*" element={ 
            <React.Suspense fallback={<>...</>}>
              <PeopleListView people={this.props.people} />
            </React.Suspense>} />

          <Route path="/playlists/*" element={ 
            <React.Suspense fallback={<>...</>}>
              <PlaylistListView playlists={this.props.playlists}/>
            </React.Suspense>
          } />

        </Routes>
      </main>
    );
  }

  componentDidUpdate() {}

  componentDidCatch() {}

  componentWillUnmount() {}

  // addSong = (song: Song) => {
  //   this.setState((state) => {
  //     state.songList.push(song)
  //   });
  // };
}

export default App;
