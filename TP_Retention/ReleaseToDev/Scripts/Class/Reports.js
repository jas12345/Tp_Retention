var Reports = {
    //Recibe como parametros parte del id del elemento y dependiendo del estado
    //de un checkbox oculta o deja visible el div que contiene el filtro para el reporte.
    EnableField: function (idElement) {

        var cbElement = '#cb' + idElement;
        var divElement = '#div' + idElement;

        if ($(cbElement).is(":checked")) {
            $(divElement).css('visibility', 'visible');
        }
        else {
            $(divElement).css('visibility', 'hidden');
        }
    },

    //Armar la peticion para la busqueda en base a los filtros seleccionados.
    Search_Reports_Details: function () {
        var form = $('#FiltersForm');

        var result = form.valid();

        if (result == true) {
            var riskStatus_Id = $("#EstatusRiesgo").data("kendoDropDownList").value();
            var riskDateStart = null;
            var riskDateEnd = null;
            var manager_Ident = null;
            var payRoll = null;
            var reviewDateStart = null;
            var reviewDateEnd = null;
            var floorManager_Ident = null;
            var location_Ident = null;
            var CCMS_User = null;
            var client_Ident = null;
            var employee_Ident = null;

            if ($('#cbRiskDate').is(":checked")) {
                riskDateStart = $("#FechaRiesgoIni").val();
                riskDateEnd = $("#FechaRiesgoFin").val();
            }

            if ($('#cbManagers').is(":checked")) {
                manager_Ident = $("#Manager_Ident").data("kendoDropDownList").value();
            }

            if ($('#cbPayRoll').is(":checked")) {
                payRoll = $("#PayRoll").val();
            }

            if ($('#cbReviewDate').is(":checked")) {
                reviewDateStart = $("#FechaRevisionIni").val();
                reviewDateEnd = $("#FechaRevisionFin").val();
            }

            if ($('#cbFloorManagers').is(":checked")) {
                floorManager_Ident = $("#FloorManager_Name").data("kendoDropDownList").value();
            }

            if ($('#cbCCMS_User').is(":checked")) {
                CCMS_User = $("#CCMS_User").val();
            }

            if ($('#cbLocation').is(":checked")) {
                location_Ident = $("#Location_Name").data("kendoDropDownList").value();
            }

            if ($('#cbClients').is(":checked")) {
                client_Ident = $('#Client_Name').data('kendoDropDownList').value();
            }

            if ($('#cbEmployee').is(':checked')) {
                employee_Ident = $('#Employee_Ident').val();
            }
        }
    }
}

