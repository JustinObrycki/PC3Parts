
google.charts.load('current', { packages: ['corechart'] });


function myPieChartTotals() {

    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Category');
    data.addColumn('number', 'Total');
    var x = document.getElementById("mydata").innerHTML;
    x = x.trim();
    if (x.charAt(0) == ",") {
        x = x.substring(1);
    }
    
    var z = x.replace(/"/g, "!"); 
    x = z.replace(/'/g, "~"); 

    z = x.replace(/~/g, '"'); 
    x = z.replace(/!/g, "'");
    
    var myChartData = JSON.parse("[" + x + "]");

    data.addRows(myChartData); 

    
    var options_pie = {
        title: 'Total Spent By Customer',
        width: 700, height: 700
    };
    
    var options_bar = {
        title: 'Total Spent By Customer',
        width: 700, height: 700
    };
    
    var options_line = {
        curveType: 'function',
        legend: { position: 'bottom' }
    };
    
    var chart = new google.visualization.ScatterChart(document.getElementById('myScatterChart'));
    chart.draw(data, options_line);
    
    var chartBar = new google.visualization.BarChart(document.getElementById('myBarChart'));
    chartBar.draw(data, options_bar);
    
    var chartPie = new google.visualization.PieChart(document.getElementById('myPieChart'));
    chartPie.draw(data, options_pie);
}