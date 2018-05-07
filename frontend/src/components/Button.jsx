import React from "react";
import classnames from "classnames";

import "./Button.css";

export const Button = ({ primary = false, children }) => (
    <button className={ classnames("button-container", { "button-container--primary": primary }) }>
        { children }
    </button>
);

export default Button;
