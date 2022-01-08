import React from "react";
import Header from './header';
import NewsSubmit from './news-submit'
import Register from './register-form'
import { BrowserRouter, Route, Routes } from "react-router-dom";


const App = () => {
    return (
        <div className="container">
            <Header />
            <BrowserRouter>
                <Routes>
                    <Route exact path="/" element = {<NewsSubmit/>} />
                    <Route exact path="/register" element={<Register/>}/>
                </Routes>
            </BrowserRouter>
        </div>
    );
}

export default App;

