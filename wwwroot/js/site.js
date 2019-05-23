document.addEventListener('DOMContentLoaded', () => {
    
    M.AutoInit(); //materialize js
    CarregarLinkAtivo();
    CarregarPageLoader();
    CarregarFuncaoDeConfirmarSubmit();
    DesabilitarBotaoDeSubmitAposClique();
    
});

function CarregarPageLoader()
{
    var links = document.querySelectorAll('a');
    var btn = document.getElementById('btnModalPageLoader');

    links.forEach((link) => {        
        var linkFalso = (link.href.indexOf('#') > -1) || (link.target == "_blank");

        if (linkFalso) return;            

        link.addEventListener('click', (e) => {
            btn.click();
        });
        
    });
    
}

function CarregarFuncaoDeConfirmarSubmit() {

    var $elementos = document.querySelectorAll('.ConfirmarSubmit');

    $elementos.forEach(element => {
        
        element.addEventListener('click', (event) => {
            
            event.preventDefault();
            var $form = event.target.closest('form');

            Swal.fire({
                title: "Tem certeza?",
                text: "A operação não poderá ser desfeita!",
                type: "warning",
                showCancelButton: true,
                confirmButtonText: 'Sim, quero continuar!',
                cancelButtonText: 'Cancelar'
            })
            .then((result) => {
                if (result.value) {
                    $form.submit();
                }
            });    
        })
    });   
}

function CarregarLinkAtivo() {
    var links = document.querySelectorAll('.sidenav a');

    links.forEach((link) => {
        var linkFalso = (link.href.indexOf('#') > -1);

        if (linkFalso) return;            

        var controllerDoLink = link.href.split('/')[3];
        var controllerAtual = window.location.href.split('/')[3];
        

        if (controllerDoLink == controllerAtual) {
            var li = link.closest('li');            
            li.classList.add('active');
        }
    });
}

function DesabilitarBotaoDeSubmitAposClique() {

    var $forms = document.querySelectorAll('form');

    $forms.forEach(form => {

        form.addEventListener('submit', (e) => {

            var formValido = e.target.checkValidity();

            if (formValido) {                
                var $botoes = e.target.querySelectorAll('[type=submit]');

                $botoes.forEach(b => {
                    b.setAttribute('disabled', true);                    
                });

            }

        });
        
    });
}