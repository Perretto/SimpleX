function salvarFornecedor() {
    var id = "form-fornecedor";

    var parameters = new Object();
    parameters.dataType = "";
    parameters.type = "POST";
    parameters.url = "http://" + window.location.host + "/fornecedor/fornecedor/salvarFornecedor";
    parameters.callback = "";
    parameters.async = false;
    //parameters.type = "application/json; charset=utf-8";
    parameters.dados = $("#" + id).serialize();

    parameters.callback = function (result) {
        if (result.Sucesso == true) {
            notification({ messageTitle: "OK", messageText: result.MensagemGeral, fix: false, type: "ok", icon: "thumbs-up" });

            if (result.Campos.length > 0) {
                var idFornecedor = result.Campos[0].Mensagem;
                window.location = "http://" + window.location.host + "/fornecedor/fornecedor/fornecedorCadastroEdicao?idFornecedor=" + idFornecedor;
            } else {
                location.reload();
            }
        } else {
            notification({ messageTitle: "Ops", messageText: result.MensagemGeral, fix: false, type: "Ops", icon: "thumbs-down" });
        }
    };

    AjaxParameter(parameters);

}

function salvarFornecedorEndereco() {
    var id = "form-fornecedorendereco";

    var parameters = new Object();
    parameters.dataType = "";
    parameters.type = "POST";
    parameters.url = "http://" + window.location.host + "/fornecedor/fornecedor/salvarFornecedorEndereco";
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


function salvarFornecedorContato() {
    var id = "form-fornecedorcontato";

    var parameters = new Object();
    parameters.dataType = "";
    parameters.type = "POST";
    parameters.url = "http://" + window.location.host + "/fornecedor/fornecedor/salvarFornecedorContato";
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

function cancelarFornecedor() {
    window.location = "http://" + window.location.host + "/fornecedor/fornecedor/fornecedorListagem";
}

function cancelarFornecedorEndereco() {
    location.reload();
}

function cancelarFornecedorContato() {
    location.reload();
}

function limpaFormFornecedor() {
    window.location = "http://" + window.location.host + "/fornecedor/fornecedor/fornecedorCadastro";
    //$("input[type=text], textarea, input[type=hidden]").val("");
}

function excluirFornecedor(idFornecedor) {
    var parameters = new Object();
    parameters.dataType = "";
    parameters.type = "get";
    parameters.url = "http://" + window.location.host + "/fornecedor/fornecedor/excluirFornecedor?idFornecedor=" + idFornecedor;
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

function excluirFornecedorEndereco(idFornecedorEndereco) {
    var parameters = new Object();
    parameters.dataType = "";
    parameters.type = "get";
    parameters.url = "http://" + window.location.host + "/fornecedor/fornecedor/excluirFornecedorEndereco?idFornecedorEndereco=" + idFornecedorEndereco;
    //parameters.callback = "";
    parameters.async = false;
    //parameters.type = "application/json; charset=utf-8";
    //parameters.dados = "idFornecedorEndereco=" + idFornecedorEndereco;

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


function excluirFornecedorContato(idFornecedorContato) {
    var parameters = new Object();
    parameters.dataType = "";
    parameters.type = "get";
    parameters.url = "http://" + window.location.host + "/fornecedor/fornecedor/excluirFornecedorContato?idFornecedorContato=" + idFornecedorContato;
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
