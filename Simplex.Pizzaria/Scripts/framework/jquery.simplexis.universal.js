
function AjaxParameter(parameters) {
    var retorno = false;
    var dataType = (parameters.dataType) ? parameters.dataType : "";
    var type = (parameters.type) ? parameters.type : "get";
    var url = (parameters.url) ? parameters.url : "";
    var dados = (parameters.dados) ? parameters.dados : "";
    var callback = (parameters.callback) ? parameters.callback : "";
    var async = (parameters.async) ? parameters.async : false;
    var contentType = (parameters.type == "POST") ? "application/json; charset=utf-8" : "";

    $.ajax({
        type: type,
        url: url,
        dataType: dataType,
        contentType: contentType,
        async: async,
        crossDomain: true,
        data: dados,
        success: function (result) {
            if (result) {
                retorno = result;
                if (callback) {
                    callback(result);
                    retorno = result;
                }
                notification({ messageTitle: "", messageText: "", fix: false, type: "ok", icon: "thumbs-up" });
            } else {
                notification({ messageTitle: "", messageText: "", fix: false, type: "warning", icon: "thumbs-down" });
            }
        },
        error: function (result) {
            notification({ messageText: "Falha na comunicação com o servidor", messageTitle: "Desculpe!", fix: false, type: "warning", icon: "thumbs-down" });

        }
    });

    return retorno;
}
