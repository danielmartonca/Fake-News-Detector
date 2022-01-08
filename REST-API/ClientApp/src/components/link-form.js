import axios from 'axios';
import React, { useState } from 'react';

const LinkNewsForm = () => {
    const [inputURL, setURL] = useState("");
    const [response, setResponse] = useState("");

    function isValidHttpUrl(string) {
        if (string === " ") return false;
        let url;
        try {
            url = new URL(string);
        } catch (_) {
            return false;
        }

        return url.protocol === "http:" || url.protocol === "https:";
    }

    const onSubmit = async (event, value) => {
        event.preventDefault();
        if (isValidHttpUrl(inputURL)) {
            const response = await axios.post("/api/1/News/link", {
                InputURL: inputURL
            });
            setResponse(response.data);
        }
        else
            setResponse("Your URL is invalid.");
    }


    const parseURL = (url) => {

        if (isValidHttpUrl(url)) {
            setResponse(" ");
            setURL(url);
        }
        else {
            setResponse("Your URL is invalid.");
            setURL(" ");
        }
    }

    return (
        <div className="container" style={{ padding: "10px", margin: "20px 0px 60px 0px" }}>
            <div id="title1" style={{ textAlign: "center" }}>
                <h3> You can get a result by completing the bellow field</h3>
            </div>
            <div className="row">
                <form onSubmit={onSubmit} style={{ padding: "10px" }} className="card col-md-9">
                    <input
                        required
                        className="form-control mt-3"
                        type="text"
                        placeholder="Link"
                        onChange={(e) => {
                            parseURL(e.target.value);
                        }}
                    />
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

export default LinkNewsForm;