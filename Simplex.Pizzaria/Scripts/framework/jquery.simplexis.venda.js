function salvarVenda() {
    var id = "form-venda";

    var parameters = new Object();
    parameters.dataType = "";
    parameters.type = "POST";
    parameters.url = "http://" + window.location.host + "/Venda/Venda/salvarVenda";
    parameters.callback = "";
    parameters.async = false;
    //parameters.type = "application/json; charset=utf-8";
    parameters.dados = $("#" + id).serialize();

    parameters.callback = function (result) {
        if (result.Sucesso == true) {
            notification({ messageTitle: "OK", messageText: result.MensagemGeral, fix: false, type: "ok", icon: "thumbs-up" });

            if (result.Campos.length > 0) {
                var idVenda = result.Campos[0].Mensagem;
                window.location = "http://" + window.location.host + "/Venda/Venda/movimentacaoVenda?idVenda=" + idVenda;
            } else {
                location.reload();
            }
        } else {
            notification({ messageTitle: "Ops", messageText: result.MensagemGeral, fix: false, type: "Ops", icon: "thumbs-down" });
        }
    };

    AjaxParameter(parameters);

}

function cancelarVenda() {
    window.location = "http://" + window.location.host + "/Venda/Venda/vendaInicio";
}

function limpaFormVenda() {
    window.location = "" + window.location.href;
    //$("input[type=text], textarea, input[type=hidden]").val("");
}

function excluirVenda(idVenda) {
    var parameters = new Object();
    parameters.dataType = "";
    parameters.type = "get";
    parameters.url = "http://" + window.location.host + "/Venda/Venda/excluirVenda?idVenda=" + idVenda;
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




function salvarVendaProduto(idVenda) {
    var id = "form-vendaproduto";

    var parameters = new Object();
    parameters.dataType = "";
    parameters.type = "POST";
    parameters.url = "http://" + window.location.host + "/Venda/Venda/salvarVendaProduto";
    parameters.callback = "";
    parameters.async = false;
    //parameters.type = "application/json; charset=utf-8";
    parameters.dados = $("#" + id).serialize();

    parameters.callback = function (result) {
        if (result.Sucesso == true) {
            notification({ messageTitle: "OK", messageText: result.MensagemGeral, fix: false, type: "ok", icon: "thumbs-up" });

            if (result.Campos.length > 0) {
                var idVendaProduto = result.Campos[0].Mensagem;
                window.location = "http://" + window.location.host + "/Venda/Venda/movimentacaoVenda?idVenda=" + idVenda;
            } else {
                location.reload();
            }
        } else {
            notification({ messageTitle: "Ops", messageText: result.MensagemGeral, fix: false, type: "Ops", icon: "thumbs-down" });
        }
    };

    AjaxParameter(parameters);

}
