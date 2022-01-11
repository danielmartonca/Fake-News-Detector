function add(a, b) {
    return (a + b);
}

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

function isInputValid(title, author, date, text) {
    if (title == null || author == null || date == null || text == null)
        return false;
    if (typeof (title) != 'string' || typeof (author) != 'string' || typeof (text) != 'string')
        return false;
    if (date.localeCompare(" ") === 0) return false;
    return true;
}

function checkIfUserIsLogged (isLogged) {
    var userIsLogged = isLogged;

    if (userIsLogged === null) {
        //window.localStorage.setItem("userLogged", "false");
        return false;
    }

    if (userIsLogged === "false") {
        //deleteCookie("sessionID");
        //deleteCookie("username");
        return false;
    }
    else
        if (userIsLogged === "true") {
            //window.localStorage.setItem("userLogged", "true");
            return true;
        }
}