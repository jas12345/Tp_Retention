var Access = {

    //Se procesa la información del proceso de registro del usuario

    Authentication: function () {

        var form = $("#Form");

        var result = form.valid();

        if (result == true) {

            var URL = General.BASE_URL + '/Access/Authentication';

            var userID = $("#userID").val();

            var pass = $("#pass").val();

            $.ajax({

                dataType: 'json',
                type: 'POST',
                data: { "userID": userID, "pass": pass },
                async: false,
                url: URL,
                success: function (json) {

                    if (json.success == 1) {

                        window.location = General.BASE_URL + '/Access/Profiles';

                    } else if (json.failure == 1) {

                        General.FlashMessage(json.oData.Error);

                    } else if (json.noLogin == 1) {

                        window.location = General.BASE_URL + "/Access/Index";

                    }

                },
                error: function (request, status, error) {

                    General.FlashMessage("User or Password incorrect");

                }

            });
        }
    }
}