import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { fetchChuckNorrisJoke } from "../redux/actions";

import BugList from "./BugList";

export default connect(mapStateToProps, mapDispatchToProps)(Joke);

function mapStateToProps(state) {
    return {

    };
}

function mapDispatchToProps(dispatch) {
    return {

    };
}

// placeholders for data from store
