import {BrowserRouter, Route, Routes} from "react-router-dom";
import { GlobalStorage} from "./store/GlobalContext.jsx";
import Login from "./pages/Login.jsx";
import Home from "./pages/Home.jsx";
import '@mantine/core/styles.css'
import {MantineProvider} from '@mantine/core';



function App() {
  return (
      <MantineProvider>
          <BrowserRouter>
              <GlobalStorage>
                  <Routes>
                      <Route path="/login" element={<Login />} />
                      <Route path="/*" element={<Home />} />
                  </Routes>
              </GlobalStorage>
          </BrowserRouter>
      </MantineProvider>
  )
}

export default App
