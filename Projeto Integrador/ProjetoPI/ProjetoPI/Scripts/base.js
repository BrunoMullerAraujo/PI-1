var CooperalDatePicker = function (seletor)
{
    this.datePicker = $(seletor);
}

CooperalDatePicker.prototype = {

    AtualizaData: function (data) {
        this.datePicker.datetimepicker('update', new Date(data));
    },

    AtualizaData2: function (data) {
        this.datePicker.datetimepicker('update', data);
    }
}

function AplicaMascaras() {
    $("input[data-format='Int2']").mask("9?9");
    $("input[data-format='CNPJ']").mask("99.999.999/9999-99");
    $("input[data-format='CPF']").mask("999.999.999-99");
    $("input[data-format='Data']").mask("99/99/9999");
    $("input[data-format='CEP']").mask("99999-999");

    $.each($("input[data-format='telefone']"), function (index, input) {
        if ($(input).val().length == 11) {
            $(input).mask("(99) 99999-999?9");
        } else {
            $(input).mask('(99) 9999-9999?9');
        }
    })

    ConfiguraMascaraTelefone();
}

function ConfiguraMascaraTelefone() {
    $("input[data-format='telefone']").change(function (event) {
        if ($(this).val().length == 15) {
            $(this).mask("(99) 99999-999?9");
        } else {
            $(this).mask('(99) 9999-9999?9');
        }
    });
}

// Formatting Functions
function formatWithComma(x, precision, seperator) {
    if (!x) {
        return "";
    }
    var options = {
        precision: precision || 2,
        seperator: seperator || ','
    }
    var formatted = parseFloat(x, 10).toFixed(options.precision);
    var regex = new RegExp(
            '^(\\d+)[^\\d](\\d{' + options.precision + '})$');
    formatted = formatted.replace(
        regex, '$1' + options.seperator + '$2');
    return formatted;
}

function reverseFormat(x, precision, seperator) {
    var options = {
        precision: precision || 2,
        seperator: seperator || ','
    }

    var regex = new RegExp(
        '^(\\d+)[^\\d](\\d+)$');
    var formatted = x.replace(regex, '$1.$2');
    return parseFloat(formatted);
}

function removeCurrency(value) {
    var retorno = value.replace("R$", "");
    retorno = retorno.replace(",", ".").replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.");
    return retorno.toLocaleString();
}

function formatCurrency(value) {
    //return "R$ " + value.toFixed(2);
    value = parseFloat(value).toFixed(2);
    return "R$ " + (value.replace(".", ",").replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.")).toLocaleString();
}

AplicaMascaras();


function removeAllButLast(string, token) {
    var parts = string.split(token);
    if (parts[1] === undefined)
        return string;
    else
        return parts.slice(0, -1).join('') + token + parts.slice(-1)
}