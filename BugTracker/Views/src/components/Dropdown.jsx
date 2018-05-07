import React from "react";
import classnames from "classnames";

import "./Dropdown.css";

export const Dropdown = ({ primary = false, children }) => (
    <div className={ classnames("dropdown-container", { "dropdown-container--primary": primary }) }>
        { children }
        <i className="material-icons icon">keyboard_arrow_down</i>
    </div>
);

export default Dropdown;
