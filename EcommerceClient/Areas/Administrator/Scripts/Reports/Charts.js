function initChart($model, tipo = 0) {

    // Cargamos el core de gráficas de google
    google.charts.load('current', { 'packages': ['corechart'] });

    //Establecemos el callBack para realizar la gráfica
    if (tipo == 0)
        google.charts.setOnLoadCallback(function () { DibujarGrafica($model) });
    if (tipo == 1)
        google.charts.setOnLoadCallback(function () { DibujarGraficaBarras($model) });
    if (tipo == 2)
        google.charts.setOnLoadCallback(function () { DibujarGraficaDonut($model) });

}

//Creamos el callback que dibujará la gráfica
function DibujarGrafica($model) {

    console.log("llegó el modelo =>", $model);

    //Obtenemos solo la data necesaria
    $data = $model.selledByCityData;

    // Create la tabla con la data
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Producto');
    data.addColumn('number', 'Ventas');

    let $arrayData = [];

    $.each($data, function (idx, obj) {

        var $arrayObj = [obj.nombreBroducto, obj.quantity];

        $arrayData.push($arrayObj)
    });


    data.addRows(
        $arrayData
    );


    //añadimos opciones visuales
    var options = {
        'title': 'Ventas en totales en esta ciudad: ',
        'width': 800,
        'height': 600
    };

    // Instantiate and draw our chart, passing in some options.
    var chart = new google.visualization.PieChart(document.getElementById('grafica'));
    chart.draw(data, options);

}

function DibujarGraficaBarras($model) {

    //Obtenemos solo la data necesaria
    $data = $model.selledByCategoryData;

    let $arrayData = [];

    $.each($data, function (idx, obj) {

        var $arrayObj = [obj.nombreBroducto, obj.quantity, ""];

        $arrayData.push($arrayObj)
    });

    console.log("data google", $arrayData);

    var data = google.visualization.arrayToDataTable([
        ["Element", "Ventas", { role: "style" }],
        ["Juguetería", 7, ""]
    ]);

    data.addRows($arrayData);


    var view = new google.visualization.DataView(data);
    view.setColumns([0, 1,
        {
            calc: "stringify",
            sourceColumn: 1,
            type: "string",
            role: "annotation"
        },
        2]);

    var options = {
        title: "Comparación de ventas por categoría",
        width: 1100,
        height: 500,
        bar: { groupWidth: "30%" },
        legend: { position: "none" },
    };
    var chart = new google.visualization.ColumnChart(document.getElementById("grafica"));
    chart.draw(view, options);

}

function DibujarGraficaDonut($model) {

    // Create la tabla con la data
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Producto');
    data.addColumn('number', 'Ventas');


    //Obtenemos solo la data necesaria
    $data = $model.selledByProductData;


    let $arrayData = [];

    $.each($data, function (idx, obj) {

        var $arrayObj = [obj.nombreBroducto, obj.quantity];

        $arrayData.push($arrayObj)
    });


    data.addRows(
        $arrayData
    );


    var options = {
        title: 'Ventas de productos',
        is3D: true,
        'width': 800,
        'height': 500
    };

    var chart = new google.visualization.PieChart(document.getElementById('grafica'));
    chart.draw(data, options);

}


function changeUrl() {

    let idCity = $("select#citygraph option:selected").val();

    location.href = ($url + "/Reports/ByCity?idCity=") + idCity;

}