import React from 'react';
import { BarChart, Bar, CartesianGrid, XAxis, YAxis } from 'recharts';


class BarchartComp extends React.Component {

// Sample data
data = [
{name: 'June', power: 400},
{name: 'July', power: 500},
{name: 'August', power: 350},
{name: 'September', power: 450}
];


render() {
    return (
		<>
        <div  className='title-content'>
            Power Consumption
        </div>
       <BarChart width={400} height={300} data={this.data}>
	     <Bar dataKey="power" fill="skyblue" />
	     {/* // <CartesianGrid stroke="#ccc" /> */}
	     <XAxis dataKey="name" />
	     <YAxis dataKey="power"/>
         </BarChart>
		 </>
       );

}
}
export  default BarchartComp;