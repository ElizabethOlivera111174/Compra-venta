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
                        Swal.fire(
                            'Good job!',
                            'El Producto se ha guardado correctamente!',
                            'success'
                          )
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
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Something went wrong!',
                    footer: '<a href="">Why do I have this issue?</a>'
                  })
            }
        }
    });
})
// $(document).on('submit', '#SetDetalle', function(e){
//     $.ajax({
//         beforeSend: function () {
//             $('#SetDetalle button[type=submit]').prop('disabled', true);
//         },
//         type: 'post',
//         url: 'https://prod-22.brazilsouth.logic.azure.com:443/workflows/786cbfa170464f0894ad71f42d1666c7/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=UIfwAcz48ENQHZDHu0Ws3O2wnU4VU9EnnIP0LBG9ClM',
//         dataType : 'json',
//         data:  $('#SetDetalle').serialize(),
//         success: function (data) {
//             alert(data.Response);
//         },
//         error: function (xhr, status) {
//             Swal.fire(
//                 'Good job!',
//                 'Ha sido enviado Correctamente!',
//                 'success'
//             )           
//         },
//         complete: function () {
//             $('#SetDetalle button[type=submit]').prop('disabled', false);
//         }
//     });
// })

$(document).on('submit', '#Registrar', function (e) {
    e.preventDefault();
    $.ajax({
        beforeSend: function () {
            $('#Registrar button[type=submit]').prop('disabled', true);
        },
        type: 'POST',
        url: "/Home/Registrar/",
        data: $("#Registrar").serialize(),
        success: function (data) {
            // alert('Bienvenido ' + data.firstname);
            window.location='/Home/';
        },
        error: function (xhr, status) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'El Usuario o contraseña son incorrectas!',
                footer: '<a href="">Why do I have this issue?</a>'
              })
        },
        complete: function () {
            $('#Registrar button[type=submit]').prop('disabled', false);
        }
    });
});
$(document).on('submit', '#Login', function (e) {
    e.preventDefault();
    $.ajax({
        beforeSend: function () {
            $('#Login button[type=submit]').prop('disabled', true);
        },
        type: this.method,
        url: this.action,
        data: $(this).serialize(),
        success: function (data) {
            const Toast = Swal.mixin({
                toast: true,
                position: 'top-end',
                showConfirmButton: false,
                timer: 3000,
                timerProgressBar: true,
                didOpen: (toast) => {
                  toast.addEventListener('mouseenter', Swal.stopTimer)
                  toast.addEventListener('mouseleave', Swal.resumeTimer)
                }
              })
              
              Toast.fire({
                icon: 'success',
                title: 'Signed in successfully'
              })
            window.location='/Home/'
        },
        error: function (xhr, status) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Error Usuario o contraseña incorrecto!',
            })
            
        },
        complete: function () {
            $('#Login button[type=submit]').prop('disabled', false);
        }
    });
});

    $(document).on('submit', '#Power', function (e) {
         $.ajax({
            beforeSend: function () {
                $('#Power button[type=submit]').prop('disabled', true);
            },
            type: 'post',
            url: 'https://prod-22.brazilsouth.logic.azure.com:443/workflows/786cbfa170464f0894ad71f42d1666c7/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=UIfwAcz48ENQHZDHu0Ws3O2wnU4VU9EnnIP0LBG9ClM',
            dataType : 'json',
            data: $("#Power").serialize(),
            success: function (data) {
                Swal.fire(
                    'Good job!',
                    'Ha sido enviado Correctamente!',
                    'success',
                    
                  )
                  console.log(data);
                // window.location='/Compras/Nuevo/1';
            },
            error: function (xhr, status) {
                e.preventDefault();
                Swal.fire(
                    'Good job!',
                    'Ha sido enviado Correctamente!',
                    'success'
                  )
                //   window.location='/Compras/Nuevo/1';   
                
            },
            complete: function () {
                $('#Power button[type=submit]').prop('disabled', false);
            }
        });
    });

    $(document).on('submit', '#Registrar', function (e) {
        // e.preventDefault();
        // let FirstName= $('#FirstName').val();
        // let LastName= $('#LastName').val();
        // let Email= $('#Email').val();
        //         EnviarBienvenida(FirstName,LastName,Email);
        // function EnviarBienvenida(FirstName,LastName,Email)
        // {
        //     comando= {
        //         "FirstName": FirstName,
        //         "LastName": LastName,
        //         "Email": Email,
        //     }
        // }

        $.ajax({
            beforeSend: function () {
                $('#Registrar button[type=submit]').prop('disabled', true);
            },
            type: 'post',
            url: 'https://prod-16.brazilsouth.logic.azure.com:443/workflows/c5c9bbd0a99e45a19cb6f2cab7b34072/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=ckZDnvOLsERUKBxIodmkf7vgjAD1RX0nNtfppIppzuw',
            dataType : 'json',
            data: $("#Registrar").serialize(),
            success: function (data) {
                alert(data.Response);
                // window.location='/Compras/Nuevo/1';
            },
            error: function (xhr, status) {
                alert("Se envio correctamente");
                // window.location='/Compras/Nuevo/1';                
            },
            complete: function () {
                $('#Registrar button[type=submit]').prop('disabled', false);
            }
        });
    });