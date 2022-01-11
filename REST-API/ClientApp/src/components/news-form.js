import axios from 'axios';
import React, { useState } from 'react';

const NewsForm = () => {
    const [title, setTitle] = useState(" ");
    const [author, setAuthor] = useState(" ");
    const [date, setDate] = useState(" ");
    const [text, setText] = useState(" ");
    const [response, setResponse] = useState(" ");

    const isInputValid = () => {
        if (title == null || author == null || date == null || text == null)
            return false;
        if (typeof (title) != 'string' || typeof (author) != 'string' || typeof (text) != 'string')
            return false;
        if (date.localeCompare(" ")===0) return false;
        return true;
    }

    const onSubmit = async (event, value) => {
        event.preventDefault();
        if (isInputValid()) {
            const rsp = await axios.post("/api/1/News", {
                Title: title,
                Author: author,
                Text: text,
                Date: date
            });
            setResponse(rsp.data);
        }
        else
            setResponse("Invalid input! Check your fields again.");
    }

    return (
        <div className="container" style={{ padding: "10px", margin:"20px 0px 60px 0px"}}>
            <div id="title" style={{ textAlign: "center" }}>
                <h3> You can get a result by completing the bellow fields</h3>
            </div>
            <div className="row">
                <form onSubmit={onSubmit} style={{ padding: "10px" }} className="card col-md-9">
                    <input
                        required
                        className="form-control mt-3"
                        type="text"
                        placeholder="Title"
                        onChange={(e) => {
                            setResponse(" ");
                            setTitle(e.target.value);
                        }}
                    />
                    <input
                        required
                        className="form-control mt-3"
                        type="text"
                        placeholder="Author"
                        onChange={(e) => {
                            setResponse(" ");
                            setAuthor(e.target.value);
                        }}
                    />
                    <input
                        className="form-control mt-3"
                        type="date"
                        placeholder="Date"
                        onChange={(e) => {
                            setResponse(" ");
                            setDate(e.target.value);
                        }}
                    />
                    <textarea
                        required
                        className="form-control mt-3"
                        placeholder="News text"
                        style={{ height: "300px" }}
                        onChange={(e) => {
                            setResponse(" ");
                            setText(e.target.value);
                        }}
                    ></textarea>
                    <button type="submit" className="btn btn-success mt-3 float-right">
                        Submit
                    </button>
                </form>
                <div className="card col">
                    <h4>Response:</h4>
                    <h5>{response}</h5>
                </div>
            </div>
        </div>
    )
}

export default NewsForm;