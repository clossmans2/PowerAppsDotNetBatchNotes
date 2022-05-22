import { createAction } from '@reduxjs/toolkit';
import Playlist from '../../models/playlist';


export const createPlaylist = createAction('playlists/add', function prepare(fName: string,lName: string, bday: string) {
    return {
        payload: {
            FirstName: fName,
            LastName: lName,
            Birthday: bday
        }
    }
});
export const getPlaylists = createAction('playlists/all');
export const getPlaylist = createAction('playlists/get', function prepare(id: number) {
    return {
        payload: {
            Id: id
        }
    }
});
export const updatePlaylist = createAction('playlists/update', function prepare(id: number, plist: Playlist) {
    return {
        payload: {
            Id: id,
            Playlist: plist
        }
    }
});
export const deletePlaylist = createAction('playlists/delete', function prepare(id: number) {
    return {
        payload: {
            Id: id
        }
    }
});
export const deletePlaylists = createAction('playlists/delete_all');

// export const CREATE_PLAYLIST = "CREATE_PLAYLIST";
// export const GET_PLAYLISTS = "GET_PLAYLISTS";
// export const GET_PLAYLIST = "GET_PLAYLIST";
// export const UPDATE_PLAYLIST = "UPDATE_PLAYLIST";
// export const DELETE_PLAYLIST = "DELETE_PLAYLIST";
// export const DELETE_ALL_PLAYLISTS = "DELETE_ALL_PLAYLISTS";