$('#randompassword').click(function ()
{
	var result = '';
	var words = '0123456789qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM';
	var max_position = words.length - 1;
	for (i = 0; i < 10; ++i)
	{
		position = Math.floor(Math.random() * max_position);
		result = result + words.substring(position, position + 1);
	}
	$('#password_1').val(result); 
});

$('#showpassword').change(function ()
{
	if ($('#showpassword').is(':checked'))
	{
		$('#password_1').attr("type", "text");
		
	}
	else
	{
		$('#password_1').attr("type", "password");
		
	}
});




