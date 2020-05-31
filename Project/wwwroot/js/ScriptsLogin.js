$(document).ready(function ()
{
    $('#enter').attr('disabled', true);
});



$('input[type="text"]').change(function ()
{

    var text_input_em = $('input[type="text"]:first').val();
    var text_input_pass = $('input[type="text"]:last').val();
    if (text_input_em.length != 0 && text_input_pass.length != 0)
    {
        $('#enter').attr('disabled', false);
    }
    
});