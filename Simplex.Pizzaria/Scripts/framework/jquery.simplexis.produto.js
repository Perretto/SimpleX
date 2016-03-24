function salvarProduto() {
    var id = "form-produto";

    var parameters = new Object();
    parameters.dataType = "";
    parameters.type = "POST";
    parameters.url = "http://" + window.location.host + "/Produto/Produto/salvarProduto";
    parameters.callback = "";
    parameters.async = false;
    //parameters.type = "application/json; charset=utf-8";
    parameters.dados = $("#" + id).serialize();

    parameters.callback = function (result) {
        if (result.Sucesso == true) {
            notification({ messageTitle: "OK", messageText: result.MensagemGeral, fix: false, type: "ok", icon: "thumbs-up" });

            if (result.Campos.length > 0) {
                var idProduto = result.Campos[0].Mensagem;
                window.location = "http://" + window.location.host + "/Produto/Produto/ProdutoCadastroEdicao?idProduto=" + idProduto;
            } else {
                location.reload();
            }
        } else {
            notification({ messageTitle: "Ops", messageText: result.MensagemGeral, fix: false, type: "Ops", icon: "thumbs-down" });
        }
    };

    AjaxParameter(parameters);

}

function cancelarProduto() {
    window.location = "http://" + window.location.host + "/Produto/Produto/ProdutoListagem";
}

function limpaFormProduto() {
    window.location = "http://" + window.location.host + "/Produto/Produto/ProdutoCadastro";
    //$("input[type=text], textarea, input[type=hidden]").val("");
}

function excluirProduto(idProduto) {
    var parameters = new Object();
    parameters.dataType = "";
    parameters.type = "get";
    parameters.url = "http://" + window.location.host + "/Produto/Produto/ExcluirProduto?idProduto=" + idProduto;
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
