import React from 'react';
import { Link } from 'react-router-dom';
import { Song } from '../../models';

type FavoriteSongProps = {
    song: Song | null;
}

class FavoriteSong extends React.Component<FavoriteSongProps> {
    render(): React.ReactNode {
        let sid = this.props.song?.Id ?? 0;
        if (this.props.song == null || sid === 0) {
            return ('');
        } else {
            console.log(this.props.song)
            return(
            <>
            <dt className="col-sm-2">Favorite Song:</dt>
            <dd className="col-sm-10">
                <Link 
                to={`/music/${this.props.song.Id}`}><b>{this.props.song.Title}</b> - {this.props.song.Artist} off the album {this.props.song.AlbumTitle}</Link>
            </dd>
            </>
            );
        }
    }
}

export default FavoriteSong;