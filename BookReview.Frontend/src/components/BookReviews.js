import {React} from "react";
import BookReview from "./BookReview";

function BookReviews({data}){
    return (
        <ul>
            {data.length > 0 
            ? data.map(bookReview => <BookReview bookReview={bookReview} key={`${bookReview.book.title}${bookReview.book.published}`} />)
            : <span>No content, please search for something</span>}
        </ul>
    );
}

export default BookReviews;