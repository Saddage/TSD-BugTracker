import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { fetchChuckNorrisJoke } from "../redux/actions";

import BugList from "./BugList";

export default connect(mapStateToProps, mapDispatchToProps)(Joke);

function mapStateToProps(state) {
    return {
        joke: state.norrisJoke
    };
}

function mapDispatchToProps(dispatch) {
    return {
        getJoke: bindActionCreators(fetchChuckNorrisJoke, dispatch)
    };
}

//  /bugs,
