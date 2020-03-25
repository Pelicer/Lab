$(function () {
    $(document).ready(function () {
        $.ajax({
            url: '/contact/generatetoken',
            type: 'POST',
            dataType: 'json',
            success: function (contactsJsonPayload) {
                $(contactsJsonPayload).each(function (i, item) {
                    $('#contacts').append('<li>' + item.Email + '</li>');
                });
            },
            error: function () { alert('boo!'); },
            beforeSend: setHeader
        });
    });

    function setHeader(xhr) {
        xhr.setRequestHeader('Authorization', 'Basic MTpFRTc4QTUzQS02NUI1LTQzMjYtODU2QS1DRTIyMEI4MzdCQzY=');
    }

    $.getJSON('/contact/listcontacts', function (contactsJsonPayload) {
        $(contactsJsonPayload).each(function (i, item) {
            $('#contacts').append('<li>' + item.Email + '</li>');
        });
    });
    $('#saveContact').click(function () {
        $.post("/contact/savecontact",
            $("#saveContactForm").serialize(),
            function (value) {
                $('#contacts').append('<li>' + value.Email + '</li>');
            },
            "json"
        );
    });
});