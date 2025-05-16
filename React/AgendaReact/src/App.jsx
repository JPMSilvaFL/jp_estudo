import {BrowserRouter, Route, Routes} from "react-router-dom";
import { GlobalStorage} from "./store/GlobalContext.jsx";
import Login from "./pages/Login.jsx";
import Home from "./pages/Home.jsx";


function App() {
  return (
          <BrowserRouter>
              <GlobalStorage>
                    <Routes>
                        <Route path="/" element={<Home />} />
                        <Route path="/login/*" element={<Login />} />
                    </Routes>
              </GlobalStorage>
          </BrowserRouter>
  )
}

export default App
