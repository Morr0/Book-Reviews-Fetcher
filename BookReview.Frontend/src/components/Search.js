import {React, useState} from "react";
import {getBooksReviews} from "../api/api";

function Search(props){
    const [topic, setTopic] = useState("");

    const onSubmit = (event) => {
        event.preventDefault();

        getBooksReviews(topic)
        .then((data) => {
            props.update(data);
        });
    };

    return (
        <form onSubmit={onSubmit} method="GET">
            <input type="text" id="topic" required minLength="1" value={topic} onChange={(e) => setTopic(e.target.value)} />
            <button type="submit">Get</button>
        </form>
    );
}

export default Search;