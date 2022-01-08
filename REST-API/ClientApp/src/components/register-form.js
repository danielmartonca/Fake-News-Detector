import React, {useState} from "react";
import axios from 'axios';

const RegisterForm = () => {
    const [username, setUsername] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [errorPassword, setErrorPassword] = useState("");

    const checkPasswords = (event) => {
        console.log(event.target.value, password);
        if(event.target.value !== password){
            setErrorPassword("The passwords do not match.");
        } else {
            setErrorPassword("");
        }
    }

    const onSubmit = async (event, value) => {
        event.preventDefault();
        const response = await axios.put("/api/1/User/create",{
            Username: username,
            Email: email,
            Password: password,
        });
        window.location.href = "/";
    }
    
    return (
        <div className="container " style={{ padding: "40px" }}>
            <div className>
                <div className="text-center">
                    <h3>Please fill in this form to create an account!</h3>
                </div>
                <div className="row justify-content-center align-items-center">
                    <div className="col-10 col-md-10 col-lg-6">
                        <form className="card" onSubmit={onSubmit} style={{ padding: "10px" }}>
                            <div className="form-group">
                                <label for="username">Username:</label>
                                <input 
                                    type="text" 
                                    className="form-control username" 
                                    id="username" 
                                    name="username"
                                    onChange={(e) => {
                                        setUsername(e.target.value);
                                    }} />
                            </div>
                            <div className="form-group">
                                <label for="username">Email:</label>
                                <input type="text"
                                    className="form-control email"
                                    id="email" 
                                    name="email" 
                                    onChange={(e) => {
                                        setEmail(e.target.value);
                                    }}
                                />
                            </div>
                            <div className="form-group">
                                <label for="password">Password:</label>
                                <input 
                                    type="password" 
                                    className="form-control password" 
                                    id="password" 
                                    name="password" 
                                    onChange={(e) => {
                                        setPassword(e.target.value);
                                    }}
                                />
                            </div>
                            <div className="form-group">
                                <label for="password">Comfirm password:</label>
                                <input 
                                    type="password"
                                    className="form-control comfirmed-pass" 
                                    id="comfirmed-pass" 
                                    name="comfirmed-pass"
                                    onChange={(e) => {
                                        checkPasswords(e);
                                    }} />
                                    <div className="text">
                                        {errorPassword}
                                    </div>
                            </div>
                            <button type="submit" style={{ marginTop: "10px" }} className="btn btn-success btn-customized">Register</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default RegisterForm;