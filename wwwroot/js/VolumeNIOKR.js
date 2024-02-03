google.charts.load('current', { 'packages': ['bar'] });
google.charts.setOnLoadCallback(drawChart);

function drawChart() {
    var data = google.visualization.arrayToDataTable([
        ['Год', 'Объем'],
        ['2019', 92.986],
        ['2020', 101.428],
        ['2021', 99.751],
        ['2022', 42.542],
        ['2023', 48.741]
    ]);

    var options = {
        chart: {
            title: 'Объем НИОКР, тыс.руб.'
        }
    };

    var chart = new google.charts.Bar(document.getElementById('volumeNIOKR'));

    chart.draw(data, google.charts.Bar.convertOptions(options));
}