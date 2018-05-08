import React from "react";

import { columns } from "../shared/consts";

import "./TopBar.css";

export const TopBar = () => (
    <div className="columns-container">
        {
            columns.map((currentColumn) => (
                <div key={ currentColumn.name } className="topbar-column">
                    { currentColumn.name }
                </div>
            ))
        }
    </div>
);

export default TopBar;
