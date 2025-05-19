import React, {useEffect} from 'react';
import { GlobalContext} from "../store/GlobalContext.jsx";
import {Route, Routes} from "react-router-dom";
import Nav from "../components/Nav.jsx";


const Home = () => {

    const {authentication} = React.useContext(GlobalContext);

    useEffect(() => {
        console.log(authentication);
        if (!authentication) {
            window.location.href = "/login";
        }
    }, [authentication]);

    return (
        <>
            <Nav color="cyan"/>
            <Routes>
                <Route path="/user" element={<h1>User</h1>} />
            </Routes>
        </>
    );
};

export default Home