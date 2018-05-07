import { combineReducers } from "redux";
import initialState from "./initialState";

const rootReducer = combineReducers({
    initialBugs: initialState
});

export default rootReducer;
