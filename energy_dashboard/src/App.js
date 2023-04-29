import './App.css';
import React from 'react';
import PieRechartComponent from "./PieRechartComponent";
// import {barchartComponent} from "./barchartComponent";
import BarchartComp from "./BarchartComp";
import Donut from "./Donut";


function App() {
  return (
    <div className="App">
      <header className="App-header">
        Energy Monitoring System
      </header>
      <div className="applyflex">
        <div className="Content-border">
        <BarchartComp/>
        </div>
        <div className="Content-border">
      <PieRechartComponent/>
        </div>
    </div>
        <div className="Content-border">
<Donut/>
</div>
      </div>
  );
}

export default App;
