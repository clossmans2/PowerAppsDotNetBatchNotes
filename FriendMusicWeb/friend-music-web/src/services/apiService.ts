import Song from '../models/song';
import axios from "axios";


const http = axios.create({
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

const createSong = (song: Song) => {
    return http.post<Song>("api/Music", song);
};

const updateSong = (song: Song) => {
    return http.put<Song>(`api/Music/${song.Id}`, song);
};

const deleteSong = (id: number) => {
    return http.delete<Song>(`api/Music/${id}`);
};

const APIService = {
    getSongs,
    getSong,
    createSong,
    updateSong,
    deleteSong
};

export default APIService;