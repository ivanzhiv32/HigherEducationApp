google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawChart);

function drawChart() {
    var data = google.visualization.arrayToDataTable([
        ['Год', '%'],
        ['2019', 23.18],
        ['2020', 6.09],
        ['2021', 10],
        ['2022', 7.78],
        ['2023', 0]
    ]);

    var options = {
        title: 'Доля студентов, необеспеченных общежитием, %',
        hAxis: { title: 'Год', titleTextStyle: { color: '#333' } },
        vAxis: { minValue: 0 }
    };

    var chart = new google.visualization.AreaChart(document.getElementById('dormitory'));
    chart.draw(data, options);
}