google.charts.load('current', { 'packages': ['line'] });
google.charts.setOnLoadCallback(drawChart);

function drawChart() {

    var data = new google.visualization.DataTable();
    data.addColumn('number', 'Год');
    data.addColumn('number', 'Средний балл ЕГЭ');
    data.addColumn('number', 'Минимальный балл ЕГЭ');
    data.addColumn('number', 'Средний балл в РФ');

    data.addRows([
        [2019, 59.92, 44.22, 59.85],
        [2020, 62.04, 48.22, 62.3],
        [2021, 63.55, 48.86, 63.31],
        [2022, 63.76, 44.11, 63.62],
        [2023, 62.46, 46.58, 63.87]
    ]);

    var options = {
        chart: {
            title: 'Динамика изменения баллов ЕГЭ абитуриентов'
        },
        pointSize: 10,
        pointShape: 'square',
        dataOpacity: 0.2,
        displayAnnotations: true,
        width: 900,
        height: 500
    };

    var chart = new google.charts.Line(document.getElementById('scoresEGE'));

    chart.draw(data, google.charts.Line.convertOptions(options));
}