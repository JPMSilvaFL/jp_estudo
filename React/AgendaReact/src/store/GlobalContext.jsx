import React, {useState} from 'react';

export const GlobalContext = React.createContext();

export const GlobalStorage = ({children} ) => {
    const [authentication, setAuthentication] = useState(null);

    return <GlobalContext.Provider value={{authentication, setAuthentication}}>{ children }</GlobalContext.Provider>;
}

