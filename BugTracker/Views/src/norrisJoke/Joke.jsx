import React, { Component } from "react";
import { isEmpty } from "lodash";

export default class Joke extends Component {
    constructor() {
        super();
    }

    componentWillMount() {
        this.props.getJoke();
    }

    render() {
        const joke = isEmpty(this.props.joke) ? "" : this.props.joke;

        return (
            <div>
                Joke of the day: <div>{ joke }</div>
            </div>
        );
    }
}
