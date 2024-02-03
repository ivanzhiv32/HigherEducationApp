google.charts.load('current', { 'packages': ['bar'] });
google.charts.setOnLoadCallback(drawStuff);

function drawStuff() {
    var x = "@ViewBag.Branches";
    var data = new google.visualization.arrayToDataTable([
        ['Отрасль науки', 'Кол-во студентов'],
        ["Математические и естественные науки", 72],
        ["Инженерное дело, технологии и технические науки", 3281],
        ["Здравоохранение и медицинские науки", 0],
        ["Сельское хозяйство и сельскохозяйственные науки", 0],
        ['Науки об обществе', 208],
        ["Образование и педагогические науки", 38],
        ["Гуманитарные науки", 0],
        ["Искусство и культура", 0]
    ]);

    var options = {
        title: 'Распределение контингента студентов организации',
        width: 900,
        legend: { position: 'none' },
        chart: {
            title: 'Распределение контингента студентов организации',
        },
        bars: 'horizontal', // Required for Material Bar Charts.
        axes: {
            x: {
                0: { side: 'top', label: 'Количество студентов' } // Top x-axis.
            }
        },
        bar: { groupWidth: "90%" }
    };

    var chart = new google.charts.Bar(document.getElementById('distributionOfStudents'));
    chart.draw(data, options);
};