import Playlist from "./playlist";
import Song from "./song";

export interface Person {
    Id: number;
    FirstName: string;
    LastName: string;
    Birthday: string;
    FavoriteSong: Song;
    LikedPlaylists: Playlist[];
    OwnedPlaylists: Playlist[];
}

export interface PersonToAdd {
    FirstName: string;
    LastName: string;
    Birthday: string;
}

export interface PersonToUpdate {
    Id: number;
    FirstName: string;
    LastName: string;
    Birthday: string;
}



export default Person;