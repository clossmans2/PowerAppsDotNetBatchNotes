import Person from "./person";

export interface Playlist {
    Id: number;
    Title: string;
    Description: string;
    Owner: Person;
    TotalTracks: number;
}

export interface PlaylistToAdd {
    Title: string;
    Description: string;
}


export interface PlaylistToUpdate {
    Id: number;
    Title: string;
    Description: string;
}


export default Playlist;