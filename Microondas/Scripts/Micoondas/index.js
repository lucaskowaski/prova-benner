var _ajax = null;
var _tempoPercorrido = 0;
var _alimento = "";
var _urlBase = "/Microondas/";
$(document).ready(function () {
    $('#micoondasForm').validate({
        rules: {
            'Alimento': {
                required: true,
            },
            'Tempo': {
                required: true,
                number: true,
                min: 1,
                max: 120,
                digits: true
            },
            'Potencia': {
                required: true,
                number: true,
                min: 1,
                max: 10,
                digits: true
            }
        },
        messages: {
            'Alimento': {
                required: 'Por favor Coloque o alimento',
            },
            'Tempo': {
                required: 'Informe o tempo',
                number: 'O tempo deve ser um número válido',
                min: 'O tempo minimo é de 1 segundo',
                max: 'O tempo máximo é de 120 segundos',
                digits: 'O tempo deve ser um numero inteiro'
            },
            'Potencia': {
                required: 'Informe a potência',
                number: 'A potencia deve ser um número válido',
                min: 'A potência minima é 1',
                max: 'A potência máxima é 10',
                digits: 'A potência de ser um número inteiro'
            }
        },

    });
    $('#btnLigar').click(function () {
        if (_tempoPercorrido === 0) {
            ligar();
        }
    })
    $('#btnInicioRapido').click(function () {
        $('#Tempo').val(30);
        $('#Potencia').val(8);
        if (_tempoPercorrido === 0) {
            ligar();
        }
    })
    $('#btnPausar').click(function () {
        if (_tempoPercorrido > 0) {
            var btn = $(this);
            var acao = btn.attr('data-action');
            if (acao === 'pausar') {
                btn.text('Continuar');
                btn.attr('data-action', 'continuar');
                if (_ajax != null) {
                    _ajax.abort();
                }
            } else {
                btn.text('Pausar');
                btn.attr('data-action', 'pausar');
                var form = new FormData($('#micoondasForm')[0]);
                form.delete('Alimento');
                form.append('TempoPercorrido', _tempoPercorrido);
                console.log(_alimento);
                form.append('Alimento', _alimento);
                ligar(form);
            }
        }
    })
    $('#btnCancelar').click(function () {
        _tempoPercorrido = 0;
        cleanMessage();
        if (_ajax != null) {
            _ajax.abort();
        }
    })
    $('#btnPerquisar').click(function () {
        var term = $('#inputPerqTerm').val();
        $.get(_urlBase.concat('Pesquisar'), { term: $('#inputPerqTerm').val() }).done(function (programas) {
            $('#contentTable').html(programas);
        }).fail(function (err) {
            console.log(err)
        })
    })
    $('.iniciarPrograma').click(function (e) {
        var btn = $(e.target);
        $('#Tempo').val(btn.attr('data-tempo'));
        $('#Potencia').val(btn.attr('data-potencia'));
        if ($("#micoondasForm").valid()) {
            var alimentoPermitido = btn.attr('data-alimento');
            var alimento = $('#Alimento').val();
            console.log('alimento', alimento);
            if (alimento.toLowerCase().search(alimentoPermitido.toLowerCase()) != -1) {
                var form = new FormData($('#micoondasForm')[0]);
                form.append('Caractere', btn.attr('data-caractere'))
                ligar(form);
            } else {
                mostarErro('Este alimento não é compatível com o programa selecionado');
            }
        }
    })
    function ligar(form) {
        var form = form ? form : new FormData($('#micoondasForm')[0])
        if ($("#micoondasForm").valid()) {
            _ajax = $.ajax({
                type: 'POST',
                url: _urlBase.concat('Ligar'),
                data: form,
                cache: false,
                contentType: false,
                processData: false,
                success: function (result) {
                    _tempoPercorrido = 0;
                    _alimento = "";
                    $('#alimentoAquecido').html(
                        $('<h1>').text(result)
                    );
                },
                error: function (error) {
                    if (error.statusText !== 'abort') {
                        showAquecimentoError('Ocorreu um erro ao aquecer o alimento!')
                    }
                }
            });
        }
    }
})
function iniciarConexao() {
    var progresso = $.connection.progressHub;
    progresso.client.sendMessage = function (tempoPercorrido, alimento) {
        atualizarProgresso(tempoPercorrido, alimento);
    };
    $.connection.hub.start()
};
function atualizarProgresso(tempoPercorrido, alimento) {
    _alimento = alimento;
    _tempoPercorrido = tempoPercorrido;
    showMessage(_tempoPercorrido)
}
function showMessage(message) {
    $('#alimentoAquecido').html(
        $('<h1>').text(message)
    );
}
function showAquecimentoError(message) {
    $('#alimentoAquecido').html(
        $('<div>', { class: "alert alert-danger" }).text(message)
    );
}
function cleanMessage() {
    $('#alimentoAquecido').empty();
}
iniciarConexao();