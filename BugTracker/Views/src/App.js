import React from 'react';
import configureStore from "./redux/configureStore";
import { Provider } from "react-redux";

import Sidebar from "./sidebarMenu/Sidebar";
import BugList from "./bugList/BugList";

import './App.css';

const store = configureStore();

const App = () => (
    <Provider store={ store }>
        <div className="App">
            <header className="App-header">TSD - Bugtracker project</header>
            <Sidebar />
            <BugList />
            { /* <p className="App-authors">written by Aleksander Sadaj, Jakub Pięta and Milan Sawicki.</p> */ }
        </div>
    </Provider>
);

export default App;
