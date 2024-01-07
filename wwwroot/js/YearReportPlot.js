google.charts.load('current', {'packages':['corechart']});
google.charts.setOnLoadCallback(drawChart);

function drawChart() {

    var data = google.visualization.arrayToDataTable([
        ['Направление', 'Кол-во студентов'],
        ['Гуманитарные науки',     147284],
        ['Искусство и культура',      89226],
        ['Оборона и безопасность государства, военные науки',  64],
        ['Математические и естественные науки', 172926],
        ['Инженерное дело, технологии и технические науки', 901026],
        ['Здравоохранение и медицинские науки', 335333],
        ['Сельское хозяйство и сельскохозяйственные науки', 111652],
        ['Науки об обществе', 793967],
        ['Образование и педагогические науки', 262305]
    ]);

    var options = {
        title: 'Распределение студентов по отраслям наук',
        sliceVisibilityThreshold: .00001
    };

    var chart = new google.visualization.PieChart(document.getElementById('piechart'));

    chart.draw(data, options);
}