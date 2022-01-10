import axios from 'axios';
import * as React from 'react';

/**
 * This function's purpose is to create a new cookie with the parameters specified.
 * @param cookieName the name of the cookie
 * @param cookieValue the value of the cooke
 * @param expireMinutes an expiration date on minutes. Default no expiry date (session cookie)
 * @param path the path. Default all files ("/")
 */
function setCookie(cookieName, cookieValue, expireMinutes = null, path = "/") {
    let expires;
    if (expireMinutes != null) {
        const d = new Date();
        d.setTime(d.getTime() + (expireMinutes * 60 * 60 * 1000));
        expires = "expires=" + d.toUTCString();
    }
    document.cookie = cookieName + "=" + cookieValue + ";" + expires + ';path=' + path + ';';
}

/**
 * This function's purpose is to return a string with the cookie named cookieName or null if no cookie exists with that name
 * @param cookieName the name of the cookie
 * @returns {string|null} a string containing the cookie OR null if no cookies exists with that name
 */
function getCookie(cookieName) {
    const name = cookieName + "=";
    const ca = document.cookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) === ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) === 0) {
            return c.substring(name.length, c.length);
        }
    }
    return null;
}

/**
 * This function's purpose is to delete a certain cookie.
 * @param cookieName the cookie to be deleted
 */
function deleteCookie(cookieName) {
    document.cookie = cookieName + "= ; expires = Thu, 01 Jan 1970 00:00:00 GMT";
}


export default function Header() {
    const [username, setUsername] = React.useState("");
    const [password, setPassword] = React.useState("");

    const postSessionIdRequest = async (username, sessionID) => {
        let returnValue = false;
        await axios.post("/api/1/User/sessionID", {
            ID: sessionID,
            Username: username,
            SessionId: sessionID
        }).then((response) => {
            switch (response.status) {
                case 200: {//OK
                    console.log(response.data);
                    returnValue = true;
                    break;
                }
                default: {
                    alert("UNKNOWN RESPONSE STATUS");
                }
            }
        }).catch((response) => {
            switch (response.status) {
                case 401: {//Unauthorized
                    alert(response.data);
                    deleteCookie("sessionID");
                    deleteCookie("username");
                    window.localStorage.setItem("userLogged", "false")
                    break;
                }
                default: {
                    alert("UNKNOWN RESPONSE STATUS");
                }
            }
        });
        return returnValue;
    }

    const checkSessionIDCookie = () => {
        let sessionID = getCookie("sessionID");
        let username = getCookie("username");
        if (sessionID === null || username === null)
            return false;

        let returnValue = false;
        returnValue = postSessionIdRequest(username, sessionID);
        return returnValue;
    }

    // eslint-disable-next-line
    const onSubmit = async (event, value) => {
        event.preventDefault();
        await axios.post("/api/1/User/login", {
            Username: username,
            Password: password,
            Email: ""
        }).then((response) => {
            switch (response.status) {
                case 200: {//OK
                    let sessionID = (response.data.sessionId);
                    deleteCookie("sessionID");
                    deleteCookie("username")
                    setCookie("sessionID", sessionID, 10);
                    setCookie("username", username, 10);
                    window.localStorage.setItem("userLogged", "true");
                    window.location.reload();
                    break;
                }
                default: {
                    alert("UNKNOWN RESPONSE STATUS");
                }
            }
        }).catch((response) => {
            switch (response.status) {
                case 401: {//Unauthorized
                    alert(response.data);
                    break;
                }
                default: {
                    alert("UNKNOWN RESPONSE STATUS");
                }
            }
        });
    }

    const logout = () => {
        let sessionID = getCookie("sessionID");
        let username = getCookie("username");
        if (username != null & sessionID != null)
            axios.delete("/api/1/User/sessionID", {
                data:{
                ID: sessionID,
                Username: username,
                SessionId: sessionID
                }
            }).then((response) => {
                switch (response.status) {
                    case 200: {//OK
                        window.localStorage.setItem("userLogged", "false");
                        deleteCookie("sessionID");
                        deleteCookie("username");
                        window.location.reload();
                        break;
                    }
                    default: {
                        alert("UNKNOWN RESPONSE STATUS");
                    }
                }
            }).catch((response) => {
                switch (response.status) {
                    case 400: {//BAD REQUEST
                        console.log(response.data);
                        window.localStorage.setItem("userLogged", "false");
                        deleteCookie("sessionID");
                        deleteCookie("username");
                        break;
                    }
                    default: {
                        alert("UNKNOWN RESPONSE STATUS");
                    }
                }
            })
    }

    const loginForm = () => {
        var userIsLogged = window.localStorage.getItem("userLogged");

        if (userIsLogged === "false")
            return < form className="navbar-nav float-left" onSubmit={onSubmit}>
                <input className="form-control me-2"
                    type="text"
                    placeholder="Username"
                    onChange={(e) => { setUsername(e.target.value); }} />
                <input className="form-control me-2"
                    type="password"
                    placeholder="Password"
                    onChange={(e) => { setPassword(e.target.value); }} />
                <button className="btn btn-success" type="submit" >Login</button>
            </form>
        else {
            return <button className="btn btn-success" type="submit" onClick={logout}>Logout</button>
        }
    }

    const checkIfUserIsLogged = () => {
        var userIsLogged = window.localStorage.getItem("userLogged");

        if (userIsLogged === null)
            window.localStorage.setItem("userLogged", "false");

        if (userIsLogged === "false") {
            deleteCookie("sessionID");
            deleteCookie("username");
        }
        else
            if (checkSessionIDCookie() === true)
                window.localStorage.setItem("userLogged", "true");
    }

    checkIfUserIsLogged();

    return (
        <div >
            <nav className="navbar navbar-expand-lg navbar-light bg-light m-10" >
                <div className="container-fluid">

                    <a className="navbar-brand btn btn-outline-success" href="/">
                        Fake News Detector
                    </a>
                    <a className="navbar-brand btn btn-outline-success" href="/#title1">
                        Link
                    </a>
                    <button
                        className="navbar-toggler"
                        type="button"
                        data-bs-toggle="collapse"
                        data-bs-target="#navbarSupportedContent"
                        aria-controls="navbarSupportedContent"
                        aria-expanded="false"
                        aria-label="Toggle navigation"
                    >
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div
                        className="collapse navbar-collapse"
                        id="navbarSupportedContent"
                    >
                        <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                            <li className="nav-item">
                                <a className="nav-link active" href="/">
                                    Home
                                </a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link active" href="/register">
                                    Register
                                </a>
                            </li>
                        </ul>
                    </div>
                    {loginForm()}
                </div>
            </nav>
        </div>
    );
}