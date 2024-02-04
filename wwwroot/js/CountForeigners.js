google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawVisualization);

function drawVisualization() {
    // Some raw data (not necessarily accurate)
    var data = google.visualization.arrayToDataTable([
        ['Год', 'Количество студентов', 'Среднее в РФ'],
        ['2017', 298, 264],
        ['2018', 335, 200],
        ['2019', 336, 218],
        ['2020', 346, 244],
        ['2021', 416, 260],
        ['2022', 467, 270],
        ['2023', 520, 293]
    ]);

    var options = {
        vAxis: { title: 'Количество студентов' },
        hAxis: { title: 'Год' },
        seriesType: 'bars',
        series: { 1: { type: 'line' } }
    };

    var chart = new google.visualization.ComboChart(document.getElementById('countForeigners'));
    chart.draw(data, options);
}