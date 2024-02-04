google.charts.load("current", { packages: ["corechart"] });
google.charts.setOnLoadCallback(drawChart);
function drawChart() {
    var data = google.visualization.arrayToDataTable([
        ['Источник дохода', 'Доход'],
        ['Внебюджетные источники', 26.91],
        ['Федеральный бюджет', 73.09]
    ]);

    var options = {
        pieHole: 0.4,
    };

    var chart = new google.visualization.PieChart(document.getElementById('financeIncomeDonut'));
    chart.draw(data, options);
}