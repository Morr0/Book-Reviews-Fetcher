import './App.css';
import {React, useState} from "react";

import Search from "./components/Search";
import BookReviews from "./components/BookReviews";

function App() {
    const [bookReviews, setBookReviews] = useState([]);

    return (
        <div className="App">
        <header className="App-header">
            <Search update={setBookReviews} />
        </header>
        <main>
            <BookReviews data={bookReviews} />
        </main>
        </div>
    );
}

export default App;
