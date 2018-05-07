import React from "react";

import Dropdown from "../components/Dropdown";
import Joke from "../norrisJoke/connect";

import "./Sidebar.css"

export const Sidebar = () => (
    <div className="sidebar-container">
    <div className="sidebar-bug-details">
        Issue details
    </div>
    <Joke />
        { /*<Dropdown primary>
            Essa
        </Dropdown> */}
    </div>
);

export default Sidebar;
