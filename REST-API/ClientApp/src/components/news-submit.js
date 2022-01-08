import React from "react";
import NewsForm from './news-form';
import LinkNewsForm from './link-form';

const NewsSubmit = () => {
    return (
        <div className="container">
            <NewsForm />
            <LinkNewsForm />
        </div>
    );
}

export default NewsSubmit;

