
function buscarProduto() {
    $("#produtoID_autocomplete").autocomplete({
        minLength: 1,
        source: function (request, response) {

            $.ajax({
                url: "/Venda/Venda/buscarProduto",
                data: { Filtro: request.term },
                dataType: 'json',
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.nome,
                            id: item.ID
                        }
                    }));

                },
                error: function () {

                }
            })

        },
        select: function (event, ui) {

            $("#produtoID").val(ui.item.id);

        }
    });
}

function cancelarVendaProduto() {
    window.location = "" + window.location.href;
}