
function AjaxParameter(parameters) {
    var retorno = false;
    var dataType = (parameters.dataType) ? parameters.dataType : "";
    var type = (parameters.type) ? parameters.type : "get";
    var url = (parameters.url) ? parameters.url : "";
    var dados = (parameters.dados) ? parameters.dados : "";
    var callback = (parameters.callback) ? parameters.callback : "";
    var async = (parameters.async) ? parameters.async : false;
    var contentType = (parameters.type == "POST") ? "" : "charset=utf-8";

    $.ajax({
        type: type,
        headers: {
            'Accept': 'application/json'
        },
        data: dados,
        url: url,
        async: false,
        success: function (result) {
            if (result) {
                retorno = result;
                if (callback) {
                    callback(result);
                    retorno = result;
                }
                
            } 
        },
        error: function (result) {
            notification({ messageText: "Falha na comunicação com o servidor", messageTitle: "Desculpe!", fix: false, type: "warning", icon: "thumbs-down" });
        }

    });

    //$.ajax({
    //    type: type,
    //    headers: {
    //        'Accept': 'application/json',
    //        'Content-Type': 'text/plain'
    //    },
    //    url: url,
    //    async: async,
    //    success: function (result) {
    //        if (result) {
    //            retorno = result;
    //            if (callback) {
    //                callback(result);
    //                retorno = result;
    //            }
    //            notification({ messageTitle: "", messageText: "", fix: false, type: "ok", icon: "thumbs-up" });
    //        } else {
    //            notification({ messageTitle: "", messageText: "", fix: false, type: "warning", icon: "thumbs-down" });
    //        }
    //    },
    //    error: function (result) {
    //        notification({ messageText: "Falha na comunicação com o servidor", messageTitle: "Desculpe!", fix: false, type: "warning", icon: "thumbs-down" });

    //    }
    //});

    return retorno;
}
