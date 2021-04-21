var Users = {

    Get_Employee_Detail: function () {

        if ($("#EI_validationMessage").css("display") == "block") {

            $("#EI_validationMessage").css("display", "none");

        }

        var URL = General.BASE_URL + '/Users/Get_Employee_Detail';

        var Employee_Ident = $("#txtEmployee").val();
        var RegExNumber = /^\d+$/;

        if (Employee_Ident.length > 0 && Employee_Ident.match(RegExNumber)) {

            $.ajax({
                dataType: "html",
                type: "POST",
                url: URL,
                data: { "Employee_Ident": Employee_Ident },
                async: false,
                success: function (data) {
                    if (!$.isEmptyObject(data)) {
                        $("#EmployeeDetails").html(data); // HTML DOM replace
                    } else {
                        $('#EmployeeDetails').append('<p>Sorry, the employee are you looking for does not exist or something wrong happened. Check your input and try again.</p>');
                    }
                }
            });

        } else {

            General.FlashMessage('Invalid input', 'red darken-3');

        }

    },

    Get_Employee_Profile: function () {

        var URL = General.BASE_URL + '/Users/Get_Employee_Profile';

        var Employee_Ident = $("#txtEmployee").val();

        $.ajax({

            dataType: 'json',
            type: 'POST',
            data: { "Employee_Ident": Employee_Ident },
            async: false,
            url: URL,
            success: function (json) {

                if (json.success == 1) {

                    for (var i = 0; i <= json.oData.Profiles.length - 1; i++) {

                        content = "<div class='row'><div class='section'>";

                        if (json.oData.Profiles[i].Assign == true) {

                            //content = content + "<input  type='checkbox' name='profile' value='" + json.oData.Profiles[i].Profile_Id + "' checked>" + json.oData.Profiles[i].Profile + "</input>";
                            content = content + "<div class='switch'><label><input type='checkbox' id='" + json.oData.Profiles[i].Profile + "' value='" + json.oData.Profiles[i].Profile_Id + "' checked='checked' /><span class='lever'></span></label>" + json.oData.Profiles[i].Profile + "</div>";

                        } else {

                            //content = content + "<input type='checkbox' name='profile' value='" + json.oData.Profiles[i].Profile_Id + "'>" + json.oData.Profiles[i].Profile + "</input>";
                            content = content + "<div class='switch'><label><input type='checkbox' id='" + json.oData.Profiles[i].Profile + "' value='" + json.oData.Profiles[i].Profile_Id + "'/><span class='lever'></span></label>" + json.oData.Profiles[i].Profile + "</div>";

                        }

                        content = content + "</div></div>";

                        $("#lstProfiles").append(content);

                    }

                } else if (json.failure == 1) {

                    General.FlashMessage(json.oData.Error);

                } else if (json.noLogin == 1) {

                    window.location = General.BASE_URL + "/Access/Index";

                }

            },
            error: function (request, status, error) {

                General.FlashMessage('Error');

            }

        });

    },

    UpdateProfile: function () {

        var URL = General.BASE_URL + '/Users/Update_Profile';

        var Employee_Ident = $("#txtEmployee").val();

        var Profiles = new Array();

        $("#FormProfiles input").each(function (index) {

            var result = $(this).is(":checked");

            if (result == true) {

                Profiles.push($(this).val());

            }

        });

        $.ajax({

            dataType: 'json',
            type: 'POST',
            traditional: true,
            data: { "Employee_Ident": Employee_Ident, "Profiles": Profiles },
            async: false,
            url: URL,
            success: function (json) {

                if (json.success == 1) {

                    $("#result").show();

                    $("#result").fadeOut(3000);

                } else if (json.failure == 1) {

                    //General.FlashMessage(json.oData.Error);

                } else if (json.noLogin == 1) {

                    window.location = General.BASE_URL + "/Access/Index";

                }

            },
            error: function (request, status, error) {

                //General.FlashMessage('Error');

            }

        });


    }



}