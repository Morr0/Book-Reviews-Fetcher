const getBooksReviews = async (topic) => {
    const response = await fetch(`http://localhost:5000/Book/Reviews?Topic=${topic}`, {
        headers: {
            "Content-Type": "application/json"
        }
    });

    if (response.status === 200){
        const bookReviews = (await response.json()).bookReviews;
        return bookReviews;
    }

    return [];
};

module.exports.getBooksReviews = getBooksReviews;