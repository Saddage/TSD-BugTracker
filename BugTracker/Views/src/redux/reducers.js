import { combineReducers } from "redux";
import initialState from "./initialState";
import norrisReducer from "./norrisReducer";

const rootReducer = combineReducers({
    norrisJoke: norrisReducer,
    initialBugs: initialState
});

export default rootReducer;
