function ajaxContainer(url, idConteudo) {
    var urlCompleta = "http://" + window.location.host + url;
    $.ajax({
        type: "get",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'text/plain'
        },
        url: urlCompleta,
        async: false,
        success: function (result) {
            $('#' + idConteudo).html(result);
        },
        error: function (result) {
            //$('#' + idConteudo).html(result);
            //$('#' + idModal).modal()
        }

    });



}