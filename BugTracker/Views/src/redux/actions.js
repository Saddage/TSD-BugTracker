export const FETCH_BUG_DETAILS = "fetchBugDetails";
export const FETCHED_NORRIS_JOKE = "fetchNorrisJoke";

export const receiveChuckNorrisJoke = (joke) => {
    return { type: FETCHED_NORRIS_JOKE, joke };
};

export const fetchChuckNorrisJoke = () => (dispatch) => {
    const norrisURL = "https://api.chucknorris.io/jokes/random";

    return fetch(norrisURL).then((response) => {
        response.json().then((jokeData) => {
            const jokeValue = jokeData.value;

            dispatch(receiveChuckNorrisJoke(jokeValue));
        })
    });
};
