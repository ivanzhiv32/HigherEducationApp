google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawVisualization);

function drawVisualization() {
    var data = google.visualization.arrayToDataTable([
        ['Год', 'В вузе', 'Среднее в РФ', 'Среднее в регионе'],
        ['2017', 163060, 844847, 216200],
        ['2018', 157710, 748992, 259384],
        ['2019', 198840, 1089779, 264250],
        ['2020', 218510, 541920, 286200],
        ['2021', 220210, 405727, 272300],
        ['2022', 204670, 554643, 269222],
        ['2023', 204050, 1205300, 247000]
    ]);

    var options = {
        vAxis: { title: 'Доход, руб.' },
        hAxis: { title: 'Год' },
        seriesType: 'bars',
        series: {
            1: { type: 'line' }
        }
    };

    var chart = new google.visualization.ComboChart(document.getElementById('financeIncome'));
    chart.draw(data, options);
}