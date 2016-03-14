function salvarCliente() {

}

function excluirCliente(idCliente) {
    var parameters;
    parameters.dataType="";
    parameters.type="get";
    parameters.url = "http://" + window.location.host + "/Cliente/Cliente/ExcluirCliente?idCliente=" + idCliente;
    parameters.callback="";
    parameters.async=false;
    parameters.type="application/json; charset=utf-8";

    AjaxParameter(parameters);
}