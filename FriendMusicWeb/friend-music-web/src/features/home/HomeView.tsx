import React from "react";
import Song from "../../models/song";


class HomeView extends React.Component {
    render(): React.ReactNode {
        return (
            <div className="App container">
                <div className="jumbotron">
                    <h2>Welcome to the App!</h2>
                </div>
            </div>
        );
    };
};

export default HomeView;