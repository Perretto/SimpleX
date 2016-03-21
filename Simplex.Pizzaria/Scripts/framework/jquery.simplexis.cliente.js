function salvarCliente() {
    var id = "form-cliente";

    var parameters = new Object();
        parameters.dataType = "";
        parameters.type = "POST";
        parameters.url = "http://" + window.location.host + "/Cliente/Cliente/SalvarCliente";
        parameters.callback = "";
        parameters.async = false;
        //parameters.type = "application/json; charset=utf-8";
        parameters.dados =$("#" + id).serialize();
        
        parameters.callback = function (result) {
            if (result.Sucesso == true) {
                notification({ messageTitle: "OK", messageText: result.MensagemGeral, fix: false, type: "ok", icon: "thumbs-up" });

                if (result.Campos.length > 0) {
                    var idCliente = result.Campos[0].Mensagem;
                    window.location = "http://" + window.location.host + "/Cliente/Cliente/ClienteCadastroEdicao?idCliente=" + idCliente;
                } else {
                    location.reload();
                }
            } else {
                notification({ messageTitle: "Ops", messageText: result.MensagemGeral, fix: false, type: "Ops", icon: "thumbs-down" });
            }
        };

        AjaxParameter(parameters);

}

function salvarClienteEndereco() {
    var id = "form-clienteendereco";

    var parameters = new Object();
    parameters.dataType = "";
    parameters.type = "POST";
    parameters.url = "http://" + window.location.host + "/Cliente/Cliente/SalvarClienteEndereco";
    parameters.callback = "";
    parameters.async = false;
    //parameters.type = "application/json; charset=utf-8";
    parameters.dados = $("#" + id).serialize();

    parameters.callback = function (result) {
        if (result.Sucesso == true) {
            notification({ messageTitle: "OK", messageText: result.MensagemGeral, fix: false, type: "ok", icon: "thumbs-up" });

            location.reload();
        } else {
            notification({ messageTitle: "Ops", messageText: result.MensagemGeral, fix: false, type: "Ops", icon: "thumbs-down" });
        }
    };

    AjaxParameter(parameters);

}


function salvarClienteContato() {
    var id = "form-clientecontato";

    var parameters = new Object();
    parameters.dataType = "";
    parameters.type = "POST";
    parameters.url = "http://" + window.location.host + "/Cliente/Cliente/SalvarClienteContato";
    parameters.callback = "";
    parameters.async = false;
    //parameters.type = "application/json; charset=utf-8";
    parameters.dados = $("#" + id).serialize();

    parameters.callback = function (result) {
        if (result.Sucesso == true) {
            notification({ messageTitle: "OK", messageText: result.MensagemGeral, fix: false, type: "ok", icon: "thumbs-up" });

            location.reload();
        } else {
            notification({ messageTitle: "Ops", messageText: result.MensagemGeral, fix: false, type: "Ops", icon: "thumbs-down" });
        }
    };

    AjaxParameter(parameters);

}

function cancelarCliente() {
    window.location = "http://" + window.location.host + "/Cliente/Cliente/ClienteListagem";
}

function cancelarClienteEndereco() {
    location.reload();
}

function cancelarClienteContato() {
    location.reload();
}

function limpaFormCliente() {
    window.location = "http://" + window.location.host + "/Cliente/Cliente/ClienteCadastro";
    //$("input[type=text], textarea, input[type=hidden]").val("");
}

function excluirCliente(idCliente) {
    var parameters = new Object();
    parameters.dataType = "";
    parameters.type = "get";
    parameters.url = "http://" + window.location.host + "/Cliente/Cliente/ExcluirCliente?idCliente=" + idCliente;
    parameters.callback = "";
    parameters.async = false;
    //parameters.type = "application/json; charset=utf-8";
    parameters.callback = function (result) {
        if (result.Sucesso == true) {
            notification({ messageTitle: "OK", messageText: result.MensagemGeral, fix: false, type: "ok", icon: "thumbs-up" });

            location.reload();
        } else {
            notification({ messageTitle: "Ops", messageText: result.MensagemGeral, fix: false, type: "Ops", icon: "thumbs-down" });
        }
    };

    AjaxParameter(parameters);
}

function excluirClienteEndereco(idClienteEndereco) {
    var parameters = new Object();
    parameters.dataType = "";
    parameters.type = "get";
    parameters.url = "http://" + window.location.host + "/Cliente/Cliente/ExcluirClienteEndereco?idClienteEndereco=" + idClienteEndereco;
    //parameters.callback = "";
    parameters.async = false;
    //parameters.type = "application/json; charset=utf-8";
    //parameters.dados = "idClienteEndereco=" + idClienteEndereco;

    parameters.callback = function (result) {
        if (result.Sucesso == true) {
            notification({ messageTitle: "OK", messageText: result.MensagemGeral, fix: false, type: "ok", icon: "thumbs-up" });

            location.reload();
        } else {
            notification({ messageTitle: "Ops", messageText: result.MensagemGeral, fix: false, type: "Ops", icon: "thumbs-down" });
        }
    };


    AjaxParameter(parameters);
}


function excluirClienteContato(idClienteContato) {
    var parameters = new Object();
    parameters.dataType = "";
    parameters.type = "get";
    parameters.url = "http://" + window.location.host + "/Cliente/Cliente/ExcluirClienteContato?idClienteContato=" + idClienteContato;
    //parameters.callback = "";
    parameters.async = false;
    //parameters.type = "application/json; charset=utf-8";
    //parameters.dados = "idClienteEndereco=" + idClienteEndereco;

    parameters.callback = function (result) {
        if (result.Sucesso == true) {
            notification({ messageTitle: "OK", messageText: result.MensagemGeral, fix: false, type: "ok", icon: "thumbs-up" });

            location.reload();
        } else {
            notification({ messageTitle: "Ops", messageText: result.MensagemGeral, fix: false, type: "Ops", icon: "thumbs-down" });
        }
    };


    AjaxParameter(parameters);
}
