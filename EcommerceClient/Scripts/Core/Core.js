let $Core = {

    //Método encargado de hacer UpperCase a las keys de un objeto
    PrepareObject: function ($obj) {

        console.log("prepare", $obj.length);

        $obj.keys(o).reduce((c, k) => (c[k.toLowerCase()] = o[k], c), {});

        return $obj;

    },

    Ajax: function ($controller, $action, $data, $callBackSuccess, $callBackError) {

        var settings = {
            type: 'POST',
            url: $controller + '/'+ $action,
            data:  $data ,
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