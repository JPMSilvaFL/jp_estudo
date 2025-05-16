import React, {useEffect} from 'react';
import { GlobalContext} from "../store/GlobalContext.jsx";


const Home = () => {

    const {token} = React.useContext(GlobalContext);

    useEffect(() => {
        if (!token) {
            window.location.href = "/login";
        }
    }, [token]);
    
    return <h1>This is a home</h1>;
};

export default Home