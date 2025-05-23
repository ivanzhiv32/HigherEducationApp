﻿google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawChart);

function drawChart() {
    $ajax({
        url: '/api/DistributionBranches',
        type: 'GET',
        data: { idInstitution: idInstitution, year: year},
        dataType: "json",

        success: function (result, status, xhr) {
            if (result != null) {
                var data = google.visualization.arrayToDataTable([
                    ['Направление', 'Кол-во студентов'],
                    ['Гуманитарные науки', 90000],
                    ['Искусство и культура', 89226],
                    ['Оборона и безопасность государства, военные науки', 64],
                    ['Математические и естественные науки', 172926],
                    ['Инженерное дело, технологии и технические науки', 901026],
                    ['Здравоохранение и медицинские науки', 335333],
                    ['Сельское хозяйство и сельскохозяйственные науки', 111652],
                    ['Науки об обществе', 793967],
                    ['Образование и педагогические науки', 262305]
                ]);

                var options = {
                    title: 'My Daily Activities',
                    sliceVisibilityThreshold: .00001
                };

                var chart = new google.visualization.PieChart(document.getElementById('piechart'));

                chart.draw(data, options);
            }
        }
    })

    
}