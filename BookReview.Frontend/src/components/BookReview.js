import {React} from "react";

function BookReview({bookReview}){
    const subtitle = bookReview.book.subtitle ? (<li>Subtitle: {bookReview.book.subtitle}</li>) : (<></>);
    const authors = bookReview.book.authors.length > 0 
        ? (<li>Authors: <ul>{bookReview.book.authors.map((author) => <li key={author}>{author}</li>)}</ul></li>)
        : (<></>);

    return (
        <li>
            <ul>
                <li>Book: {bookReview.book.title}</li>
                {subtitle}
                <li>Description <p>{bookReview.book.description}</p></li>
                {authors}
                <li>Since: {bookReview.book.published}</li>
                <li>
                    Reviews:
                    <ul>
                        {bookReview.videos.map((video) => <li key={video.url}><a href={video.url} target="_blank" rel="noreferrer">
                            {video.title}
                        </a></li>)}
                    </ul>
                </li>
            </ul>
        </li>
    );
}

export default BookReview;