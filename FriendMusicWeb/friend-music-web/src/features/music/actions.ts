import { createAction } from '@reduxjs/toolkit';
import Song from '../../models/song';


export const createMusic = createAction('music/add', function prepare(title: string, artist: string, album: string, length: string) {
    return {
        payload: {
            Title: title,
            Artist: artist,
            AlbumTitle: album,
            Length: length
        }
    }
});
export const getMusic = createAction('music/all');
export const getSong = createAction('music/get', function prepare(id: number) {
    return {
        payload: {
            Id: id
        }
    }
});
export const updateMusic = createAction('music/update', function prepare(id: number, song: Song) {
    return {
        payload: {
            Id: id,
            Song: song
        }
    }
});
export const deleteMusic = createAction('music/delete', function prepare(id: number) {
    return {
        payload: {
            Id: id
        }
    }
});
export const deleteAllMusic = createAction('music/delete_all');

// export const CREATE_PLAYLIST = "CREATE_PLAYLIST";
// export const GET_PLAYLISTS = "GET_PLAYLISTS";
// export const GET_PLAYLIST = "GET_PLAYLIST";
// export const UPDATE_PLAYLIST = "UPDATE_PLAYLIST";
// export const DELETE_PLAYLIST = "DELETE_PLAYLIST";
// export const DELETE_ALL_PLAYLISTS = "DELETE_ALL_PLAYLISTS";