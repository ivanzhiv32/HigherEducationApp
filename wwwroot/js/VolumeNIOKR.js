google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawVisualization);

function drawVisualization() {
    var data = google.visualization.arrayToDataTable([
        ['Год', 'В вузе', 'Средний объем в РФ'],
        ['2017', 92986, 47732],
        ['2018', 92986, 69105],
        ['2019', 92986, 78398],
        ['2020', 101428, 85618],
        ['2021', 99751, 82810],
        ['2022', 42542, 92908],
        ['2023', 48741, 110865]
    ]);

    var options = {
        vAxis: { title: 'Объем НИКОР, тыс.руб.' },
        hAxis: { title: 'Год' },
        seriesType: 'bars',
        series: { 1: { type: 'line' } }
    };

    var chart = new google.visualization.ComboChart(document.getElementById('volumeNIOKR'));
    chart.draw(data, options);
}