import Song, { SongToAdd, SongToUpdate } from '../models/song';
import axios from "axios";
import Playlist, { PlaylistToAdd, PlaylistToUpdate } from '../models/playlist';
import Person, { PersonToAdd, PersonToUpdate } from '../models/person';


export const http = axios.create({
    baseURL: "https://localhost:7072",
    headers: {
        'Content-Type': 'application/json'
    }
});

const getSongs = () => {
    return http.get<Array<Song>>("/api/Music");
};

const getSong = (id: number) => {
    return http.get<Song>(`api/Music/${id}`);
}

const createSong = (song: SongToAdd) => {
    return http.post<Song>("api/Music", song);
};

const updateSong = (song: SongToUpdate) => {
    return http.put<Song>(`api/Music/${song.Id}`, song);
};

const deleteSong = (id: number) => {
    return http.delete<Song>(`api/Music/${id}`);
};

const getPlaylists = () => {
    return http.get<Array<Playlist>>("/api/Playlists");
};

const getPlaylist = (id: number) => {
    return http.get<Playlist>(`api/Playlists/${id}`);
}

const createPlaylist = (Playlist: PlaylistToAdd) => {
    return http.post<Playlist>("api/Playlists", Playlist);
};

const updatePlaylist = (Playlist: PlaylistToUpdate) => {
    return http.put<Playlist>(`api/Playlists/${Playlist.Id}`, Playlist);
};

const deletePlaylist = (id: number) => {
    return http.delete<Playlist>(`api/Playlists/${id}`);
};

const getPeople = () => {
    return http.get<Array<Person>>("/api/People");
};

const getPerson = (id: number) => {
    return http.get<Person>(`api/People/${id}`);
}

const createPerson = (person: PersonToAdd) => {
    return http.post<Person>("api/People", person);
};

const updatePerson = (person: PersonToUpdate) => {
    return http.put<Person>(`api/People/${person.Id}`, person);
};

const deletePerson = (id: number) => {
    return http.delete<Person>(`api/People/${id}`);
}
const APIService = {
    getSongs,
    getSong,
    createSong,
    updateSong,
    deleteSong,
    getPeople,
    getPerson,
    createPerson,
    updatePerson,
    deletePerson,
    getPlaylists,
    getPlaylist,
    createPlaylist,
    updatePlaylist,
    deletePlaylist
};

export default APIService;