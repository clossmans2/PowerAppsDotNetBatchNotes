import Person from "./person";
import Song from "./song";

interface Playlist {
    Id: number;
    Title: string;
    Description: string;
    Owner: Person;
    Songs: Song[];
    LikedBy: Person[];
    TotalTracks: number;
}

export default Playlist;