import React, { Component } from "react";
import { columns } from "../shared/consts";

import Column from "../components/Column";

import "./BugList.css";

export default class BugList extends Component {
    constructor() {
        super();
    }

    componentWillMount() {
        // placeholder for future initial render api call for issues list
    }

    render() {
        return (
            <div className="buglist-container">
                <div className="buglist-content">
                    {
                        columns.map((currentColumn) => (
                            <Column key={ currentColumn.name } >
                                { currentColumn.name }
                            </Column>
                        ))
                    }
                </div>
            </div>
        );
    }
}
