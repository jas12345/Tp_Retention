var General = {

    //En está variable se alamcenará la base de la URL

    BASE_URL: "",

    //En está variable se alamcenará el nombre del usuario logeado

    USER: "",

    //En está variable se alamacenará la instalación seleccionada por el usuario

    INSTALLATION: "",

    //En esta variable se almacenará el perfil del usuario

    PROFILE: "",

    //Obtener los Perfiles del Usuario

    GetProfiles: function () {

        var URL = General.BASE_URL + '/Access/GetProfile';

        $.ajax({

            dataType: 'json',
            type: 'POST',
            data: {},
            async: false,
            url: URL,
            success: function (json) {

                if (json.success == 1) {

                    $("#sProfile").empty();

                    //$("#sProfile").append("<option value=''>SELECT...</option>");

                    for (var i = 0; i < json.oData.Profiles.length; i++) {

                        $("#sProfile").append("<option value='" + json.oData.Profiles[i].Key + "'>" + json.oData.Profiles[i].Value + "</option>");

                    }

                    $('#sProfile').val(General.PROFILE);

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

    //Se utiliza para cambiar el perfil del usuario
    //RZ.20140205 Se retira debido a que ahora el cambio de perfil se hara desde la vista Access/Profiles
    //ChangeProfile: function () {

    //    var profile = $("#sProfile").val();

    //    if (profile != undefined || profile != "") {

    //        window.location = General.BASE_URL + "/Access/SetProfileGET?Profile=" + profile;

    //    }

    //},

    //Muestra un mensaje de error cuando una petición via AJAX falle
    FlashMessage: function (mensaje, cssclass) {
        toast(mensaje, 4000, cssclass);

    },

    //Cierra el mensaje de error
    Close: function () {

        $(".overlay").hide();

        $("#flashmessage").fadeOut(1000);

    },

    //Se utliza en la vista de manejo de Errores para regresar a la vista anterior
    Back: function () {

        //window.location = window.history.go(-1);
        window.location = General.BASE_URL + '/Home/Index';

    },

    //Se cierra la sesión y redirecciona a la pantalla de registro

    SessionClose: function () {

        window.location = General.BASE_URL + '/Access/Close';

    },

    LoadMain: function()
    {

        var URL = General.BASE_URL + '/Base/LoadMain';

        $.ajax({
            dataType: "json",
            type: "POST",
            url: URL,
            async: false,
            success: function (json) {
                console.log(json);
                $("#IdSecondMain").empty();
                
                for (var i in json.oData.Main) {

                    var sModule = json.oData.Main[parseInt(i)]["Module"];

                    if (sModule.length > 0) {
                        if (sModule == "Propensity to Leave") {
                            sModule = "PTL";
                        }

                        content = "<a href='" + General.BASE_URL + "/" + json.oData.Main[parseInt(i)]["Path"] + "' style='margin-right: 5px;' class='waves-effect waves-light btn-medium btn-large " + json.oData.Main[parseInt(i)]["Color"] + "'>";
                        content = content + "   <div>";
                        content = content + "       <div>";
                        content = content + "           <i class='fa " + json.oData.Main[parseInt(i)]["Icon"] + " fa-2x' style='color: #FFFFFF;'></i>";
                        content = content + "       </div>";
                        content = content + "   </div>";
                        content = content + "   <div class='tile-title'>";
                        content = content + "       <span class='tile-text' style='font-size:12px;'>" + sModule + "</span>";
                        content = content + "   </div>";
                        content = content + "</a>";

                        $("#IdSecondMain").append(content);
                    }
                };

                ;

            }
        });

    }    
    
}

//Location dropdown event
//function LocationOnDataBound() {
//    var dataSource = this.dataSource;
//    var data = dataSource.data();

//    if (!this._adding) {
//        this._adding = true;

//        data.splice(0, 0, {
//            "Location_Name": "ALL",
//            "location_ident": "0"
//        });

//        this._adding = false;
//        //$("#Location").data("kendoComboBox").select(0);
//    }
//}

//Position dropdown event
function PositionOnDataBound() {
    var dataSource = this.dataSource;
    var data = dataSource.data();

    if (!this._adding) {
        this._adding = true;

        data.splice(0, 0, {
            "Position_Code_Full_Name": "ALL",
            "Position_Code_Type_Ident": "0"
        });

        this._adding = false;
    }
}

//function riskEditRow(e) {
//    //$("#GridErrorAplServicio").kendoMessage("hide");
//    grid = $("#EmployeeRisksData").data("kendoGrid");
//    grid.editRow($(e).closest("tr"));
//}

//function riskDeleteRow(e) {
//    //$("#GridErrorAplServicio").kendoMessage("hide");
//    grid = $("#EmployeeRisksData").data("kendoGrid");
//    grid.removeRow($(e).closest("tr"));
//}