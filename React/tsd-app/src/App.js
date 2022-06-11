import { Route, Routes } from "react-router-dom";
import Home from "./components/Home.jsx"
import Counter from "./components/Counter"
import TicTacToe from "./components/TicTacToe"

function App() {
  return (
    <div className="App">
      <Routes>
            <Route path="/" exact element={<Home />} />
            <Route path="/counter" exact element={<Counter />} />
            <Route path="/tic-tac-toe" exact element={<TicTacToe />} />
        </Routes>
      
    </div>
  );
}

export default App;
