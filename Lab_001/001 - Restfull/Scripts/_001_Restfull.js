$(function () {
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