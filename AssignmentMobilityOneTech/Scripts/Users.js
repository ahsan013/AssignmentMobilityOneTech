
    var Popup, dataTable;

        $(document).ready(function () {
        dataTable = $("#UsersTable").DataTable({

            "ajax": {

                "url": "api/UsersAPI/GetAllUsers",
                "type": "GET",
                "datatype": "json",
                "dataSrc": ''
            },

            "columns": [
                { "data": "Name" },
                { "data": "PhoneNumber" },
                { "data": "EmailAddress" },
                { "data": "Password" },
                { "data": "LastLogin" },
                { "data": "CreateDate" },
                { "data": "Suspended" },
                {
                    "data": "Id", "render": function (data) {

                        return "<a class='btn btn-default btn-sm' onclick=PopupEditForm('" + data + "')><i class='fa fa-pencil'></i>Edit</a> <a class='btn btn-danger btn-sm' style='margin-left:5px' onclick=Delete(" + data + ")><i class='fa fa-trash'></i>Delete</a>";
                    },

                    "orderable": false,
                    "searchable": false,
                    "width": "150px"
                }


            ],

            "language": {
                "emptyTable": "No data found please click on <b>Add New </b> Button"
            }

        });
        });

        function PopupForm(url) {

            var formDiv = $('<div />');
            $.get(url)
                .done(function (response) {

        formDiv.html(response);

                    Popup = formDiv.dialog({

        autoOpen: true,
                        resizable: false,
                        title: 'Add Users Details',
                        height: 530,
                        width: 900,
                        close: function () {

        Popup.dialog('destroy').remove();
                        }

                    });

                });
        }
        function PopupEditForm(Id) {

        // alert(Id);

        $.ajax({
            url: "api/UsersAPI/GetUserByID/" + Id,
            typr: "GET",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {

                var formDiv = $('<div/>');
                $.get("Users/LoadEditPopup")
                    .done(function (response) {

                        formDiv.html(response);

                        Popup = formDiv.dialog({

                            autoOpen: true,
                            resizable: false,
                            title: 'Update Users Details',
                            height: 530,
                            width: 900,
                            close: function () {
                                Popup.dialog('close');
                                location.reload();

                            }

                        });

                        $('#Id').val(result[0].Id);
                        $('#Name').val(result[0].Name);
                        $('#PhoneNumber').val(result[0].PhoneNumber);
                        $('#EmailAddress').val(result[0].EmailAddress);
                        $('#Password').val(result[0].Password);
                        $('#LastLogin').val(result[0].LastLogin);
                        $('#CreateDate').val(result[0].CreateDate);
                        if (result[0].Suspended == true) {

                            $('#Suspended').prop('checked', true);

                        }
                        else {
                            $('#Suspended').prop('checked', false);
                        }


                    });


            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });


        }
        function SubmitForm(form) {

        $.validator.unobtrusive.parse(form);
            if ($(form).valid()) {

        $.ajax({
            type: "POST",
            url: "api/UsersAPI/AddUsers",
            data: $(form).serialize(),
            success: function (data) {

                if (data.success) {

                    Popup.dialog('close');
                    dataTable.ajax.reload();

                    $.notify(data.message, {
                        globalPosition: "top center",
                        className: "success"
                    })

                }
                else {

                    $.notify(data.message, {
                        globalPosition: "top center",
                        className: "error"
                    })
                }


            }
        });
            }

            return false;

        }
        function UpdateForm(form) {

        $.validator.unobtrusive.parse(form);
            if ($(form).valid()) {

        $.ajax({
            type: "POST",
            url: "api/UsersAPI/UpdateUsers",
            data: $(form).serialize(),
            success: function (data) {

                if (data.success) {

                    Popup.dialog('close');
                    dataTable.ajax.reload();

                    $.notify(data.message, {
                        globalPosition: "top center",
                        className: "success"
                    })

                }
                else {

                    $.notify(data.message, {
                        globalPosition: "top center",
                        className: "error"
                    })
                }


            }
        });
            }

            return false;

        }

        function Delete(id) {
            if (confirm('Are you sure to Delete this record ?')) {

        $.ajax({

            type: "POST",
            url: 'api/UsersAPI/SingleUserRemove/' + id,
            success: function (data) {

                if (data.success) {

                    dataTable.ajax.reload();

                    $.notify(data.message, {
                        globalPosition: "top center",
                        className: "success"
                    })

                }
            }

        });
                /**/
            }
        }

    