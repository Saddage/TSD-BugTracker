import React from "react";

import "./Bug.css";

export const Bug = ({ bugTitle, assignee, priority="low" }) => (
    <div className="bug-container">
        <div className="bug-type-color-bar"></div>
        <div className="bug-title">
            { bugTitle }
        </div>
        <div className="bug-assignee">
            Assignee: { assignee }
        </div>
        bug
    </div>
);

export default Bug;
