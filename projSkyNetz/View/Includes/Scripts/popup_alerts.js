// Biblioteca de alertas

// Link https://sweetalert2.github.io/#download

// Swal commum
function swalComum(titulo, texto, icone) {
    Swal.fire({
        title: titulo,
        text: texto,
        icon: icone,
        confirmButtonText: 'Ok'
    })
}

// Swal 
function swalSobre(titulo, texto, icone) {
    Swal.fire({
        title: titulo,
        text: texto,
        icon: icone,
        confirmButtonText: 'Ok'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = 'Sobre.aspx'; 
        }
    })
}