google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawVisualization);

function drawVisualization() {
    var data = google.visualization.arrayToDataTable([
        ['Год', 'В вузе', 'Среднее в РФ', 'Среднее в регионе'],
        ['2017', 475, 332, 267],
        ['2018', 417, 462, 381],
        ['2019', 361, 307, 387],
        ['2020', 504, 316, 372],
        ['2021', 434, 321, 446],
        ['2022', 794, 334, 509],
        ['2023', 480, 364, 579]
    ]);

    var options = {
        vAxis: { title: 'Количество публикаций' },
        hAxis: { title: 'Год' },
        seriesType: 'bars',
        series: {
            1: { type: 'line' }
        }
    };

    var chart = new google.visualization.ComboChart(document.getElementById('articles'));
    chart.draw(data, options);
}