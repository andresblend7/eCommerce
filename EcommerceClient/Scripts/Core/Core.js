let $Core = {

    Ajax: function ($controller, $action, $data, $callBackSuccess, $callBackError) {

        var settings = {
            type: 'POST',
            url: $controller + '/'+ $action,
            data: { $data },
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