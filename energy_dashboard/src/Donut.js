import React from 'react';
import { BarChart, Bar, CartesianGrid, XAxis, YAxis } from 'recharts';
import DonutChart from "react-donut-chart";



class Donut extends React.Component {

     data = [
        {
          label: "Gas",
          value: 100
        },
        {
          label: "Electricity",
          value: 500
        },
        {
          label: "Solar",
          value: 200
        }
      ];
  
     colors = [  "#8884d8","#FF8042", "#60b644"];


render() {
    return (
        <>
        <div className="title-content">
            Energy
        </div>
		<div>
        <DonutChart colors={this.colors} data={this.data} height={300} width={400}/>
		 </div>
        </>
       );

}
}
export default Donut;