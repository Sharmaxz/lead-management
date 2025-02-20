import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Leads from "./pages/lead/Leads";

const App = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Leads />} />
            </Routes>
        </Router>
    );
};

export default App;