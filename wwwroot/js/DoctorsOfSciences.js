google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawVisualization);

function drawVisualization() {
    var data = google.visualization.arrayToDataTable([
        ['Год', 'В вузе', 'Среднее в РФ', 'Среднее в регионе'],
        ['2017', 4.22, 5.1, 3.13],
        ['2018', 4.36, 4.61, 2.84],
        ['2019', 4.7, 4.66, 2.75],
        ['2020', 4.72, 4.73, 2.8],
        ['2021', 4.75, 3.9, 2.82],
        ['2022', 3.82, 4.8, 3.22],
        ['2023', 3.61, 4.91, 3.33]
    ]);

    var options = {
        hAxis: { title: 'Год' },
        seriesType: 'bars',
        series: {
            1: { type: 'line' }
        }
    };

    var chart = new google.visualization.ComboChart(document.getElementById('doctorsOfSciences'));
    chart.draw(data, options);
}