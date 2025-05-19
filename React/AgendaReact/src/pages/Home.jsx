import React from 'react';
import { GlobalContext} from "../store/GlobalContext.jsx";
import {BrowserRouter, Route, Routes} from "react-router-dom";
import Nav from "../components/Nav.jsx";


const Home = () => {
    //
    // const {token} = React.useContext(GlobalContext);
    //
    // useEffect(() => {
    //     if (!token) {
    //         window.location.href = "/login";
    //     }
    // }, [token]);
    //
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