//google.charts.load('current', { 'packages': ['corechart'] });
//google.charts.setOnLoadCallback(drawVisualization);

//function drawVisualization() {
//    var data = google.visualization.arrayToDataTable([
//        ['Год', 'Количество статей', 'Среднее в РФ'],
//        ['2017', 11, 14],
//        ['2018', 14, 21],
//        ['2019', 23, 22],
//        ['2020', 35, 25],
//        ['2021', 28, 27],
//        ['2022', 34, 31],
//        ['2023', 16, 24]
//    ]);

//    var options = {
//        vAxis: { title: 'Количество статей' },
//        hAxis: { title: 'Год' },
//        seriesType: 'bars',
//        series: { 1: { type: 'line' } }
//    };

//    var chart = new google.visualization.ComboChart(document.getElementById('countArticlesForeigners'));
//    chart.draw(data, options);
//}

google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawChart);

function drawChart() {
    var data = google.visualization.arrayToDataTable([
        ['Год', 'В вузе', 'Среднее в РФ'],
        ['2017', 11, 14],
        ['2018', 14, 21],
        ['2019', 23, 22],
        ['2020', 35, 25],
        ['2021', 28, 27],
        ['2022', 34, 31],
        ['2023', 16, 24]
    ]);

    var options = {
        vAxis: { title: 'Количество статей' },
        hAxis: { title: 'Год' },
        isStacked: true
    };

    var chart = new google.visualization.SteppedAreaChart(document.getElementById('countArticlesForeigners'));

    chart.draw(data, options);
}