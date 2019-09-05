let $Core = {

    //Método encargado de hacer UpperCase a las keys de un objeto
    PrepareObject: function ($obj) {

        //Comprobamos si es un array
        if (!Array.isArray($obj)) {

            let a = $obj;
            for (var key in a) {
                var temp;
                if (a.hasOwnProperty(key)) {
                    temp = a[key];
                    delete a[key];
                    a[key.charAt(0).toUpperCase() + key.substring(1)] = temp;
                }
            }
            $obj = a;

        } else {

            for (var i = 0; i < $obj.length; i++) {
                var a = $obj[i];
                for (var key in a) {
                    var temp;
                    if (a.hasOwnProperty(key)) {
                        temp = a[key];
                        delete a[key];
                        a[key.charAt(0).toUpperCase() + key.substring(1)] = temp;
                    }
                }
                $obj[i] = a;
            }
        }

    },

    ReloadPage: function () {
        location.reload();
    },

    Notificate: function ($type, $text, $time = 1000) {
        new Noty({
            type: $type,
            progressBar: false,
            timeout: $time,
            text: $text,
            theme: 'metroui',
            animation: {
                open: 'animated bounceInRight', // Animate.css class names
                close: 'animated bounceOutRight', // Animate.css class names
                  speed: 0 // opening & closing animation speed
            }
        }).show();
    },

    //Middleware para las peticiones ajax
    Ajax: function ($controller, $action, $data, $callBackSuccess, $callBackError) {

        console.log($url + '/' + $controller + '/' + $action);
        var settings = {
            type: 'POST',
            // [Ruta absoluta Admin ] / [controler] / [action]
            url: $url+ '/' + $controller + '/' + $action,
            data: $data,
            success: function (response) {
                $callBackSuccess(response);
            },
            error: function (xhr, status, error) {
                $callBackError(error);
            }
        };
        $.ajax(settings);

    }

}