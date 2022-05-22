export interface Song {
    Id: number;
    Title: string;
    Artist: string;
    Length: string;
    AlbumTitle: string; 
}

export interface SongToAdd {
    Title: string;
    Artist: string;
    Length: string;
    AlbumTitle: string; 
}

export interface SongToUpdate {
    Id: number;
    Title: string;
    Artist: string;
    Length: string;
    AlbumTitle: string; 
}

export default Song;