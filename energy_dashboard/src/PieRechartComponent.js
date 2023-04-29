import React from "react";
import { PieChart, Pie, Cell, Tooltip, Legend } from "recharts";

class PieRechartComponent extends React.Component {
   COLORS = ["#8884d8", "#82ca9d", "#FFBB28", "#FF8042","#AF19FF", "#ff4361"];
   pieData = [
      {
         name: "AC",
         value: 2.4
      },
      {
         name: "Washing Machne",
         value: 1.6
      },
      {
         name: "Heater",
         value: 1.0
      },
      {
         name: "Lights",
         value: 0.9
      },
      {
         name: "Fans",
         value: 1.2
      },
      {
         name: "Others",
         value: 1.5
      }
   ];
   CustomTooltip = ({ active, payload, label }) => {
      if (active) {
         return (
         <div
            className="custom-tooltip"
            style={{
               backgroundColor: "#ffff",
               padding: "5px",
               border: "1px solid #cccc"
            }}
         >
            <label>{`${payload[0].name} : ${payload[0].value} KW`}</label>
         </div>
      );
   }
   return null;
};
render() {
   return (
      <>
<div className="title-content">
Power Consumption
</div>
      <PieChart width={730} height={300}>
      <Pie
         data={this.pieData}
         color="#000000"
         dataKey="value"
         nameKey="name"
         cx="50%"
         cy="50%"
         outerRadius={120}
         fill="#8884d8"
      >
         {this.pieData.map((entry, index) => (
            <Cell
               fill={this.COLORS[index % this.COLORS.length]}
               key={entry.name - entry.value}
            />
         ))}
      </Pie>
      <Tooltip content={<this.CustomTooltip/>} />
      <Legend />
      </PieChart>
      </>
      );
   }
}
export default PieRechartComponent;