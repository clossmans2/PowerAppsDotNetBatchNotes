import Playlist from "./playlist";
import Song from "./song";

interface Person {
    Id: number;
    FirstName: string;
    LastName: string;
    Birthday: Date;
    FavoriteSong: Song[];
    LikedPlaylists: Playlist[];
    OwnedPlaylists: Playlist[];
}

export default Person;