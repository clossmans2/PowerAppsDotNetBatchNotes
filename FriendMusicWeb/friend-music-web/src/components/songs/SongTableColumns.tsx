import React from "react";

const SongTableColumns = (props: any): JSX.Element => {
    
    return (
        <>
            <tr>
                <th>Album Title</th>
                <th>Artist</th>
                <th>Length</th>
                <th>Title</th>
            </tr>
        </>            
    );
};

export default SongTableColumns;