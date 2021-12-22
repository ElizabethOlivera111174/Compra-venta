// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(document).on('submit', '#SetDetalle', function(e){
    e.preventDefault();
    if(!$('#SetEncabezado').valid())
    {
        return false;
    }
    $.ajax({
        type: 'POST',
        url: '/Compras/SetEncabezado/',
        data: $('#SetEncabezado').serialize(),
        success: function(data)
        {
            if(data.estado){
                console.log("funciona");
                $('#SetEncabezado #Item1_IdCompra').val(data.resultado);
                $('#SetDetalle #Item2_IdCompra').val(data.resultado);
                $.ajax({
                    type: 'POST',
                    url: '/Compras/SetDetalle/',
                    data: $('#SetDetalle').serialize(),
                    success: function(data)
                    {
                        var tbl = $('#tbl-detalle-compra tbody');
                        var detalle = data.resultado;
                        tbl.append('<tr><td>'+detalle.producto.marca + ' - ' + detalle.producto.modelo+'</td>'+
                                        '<td>'+detalle.producto.descripcion+'</td>'+
                                        '<td>'+detalle.cantidad+'</td>'+
                                        '<td>$'+detalle.precio+'</td>'+
                                        '<td>$'+detalle.iva+'</td>'+
                                        '<td>$'+detalle.total+'</td>'+
                                        '</tr>');
                    }
                });
            }
            else
            {
                alert(data.mensaje);
            }
        }
    });
})