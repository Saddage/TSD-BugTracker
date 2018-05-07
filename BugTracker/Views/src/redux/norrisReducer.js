import { FETCHED_NORRIS_JOKE } from "./actions";

export const norrisReducer = (state = {}, { type, joke }) => {
    switch (type) {
        case FETCHED_NORRIS_JOKE:
            console.log("FETCH_NORRIS_JOKE ACTION");
            return joke;
        default:
            return state;
    }
};

export default norrisReducer;
