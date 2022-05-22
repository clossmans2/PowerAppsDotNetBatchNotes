import React from "react";
import { Routes, Route } from "react-router-dom";
import "./App.css";
import NavigationBar from "./components/NavigationBar";
import HomeView from "./features/home/HomeView";
import {Music} from "./features/music";
import {People} from "./features/people";
import {Playlist} from "./features/playlists";

type AppProps = {

};

type AppState = {};

class App extends React.Component<AppProps, AppState> {
  render() {
    return (
      <main>
        <NavigationBar />
        <Routes>
          <Route path="/" element={ <HomeView />} />
          <Route path="music/*" element={<Music />} />                  
          <Route path="people/*" element={ <People />} />
          <Route path="playlists/*" element={<Playlist />} />
        </Routes>
      </main>
    );
  }
}

export default App;
