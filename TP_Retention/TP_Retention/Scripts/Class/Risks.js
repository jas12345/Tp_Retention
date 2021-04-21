var Risks = {
    EnableField: function (idElement) {

        var cbElement = '#cb' + idElement;
        var divElement = '#div' + idElement;

        if ($(cbElement).is(":checked")) {
            $(divElement).css('visibility', 'visible');
            if (idElement == "Clients") {
                $('#divProgram').css('visibility', 'visible');
                $('#divProgramLabel').css('visibility', 'visible');
            }
        }
        else {
            $(divElement).css('visibility', 'hidden');
            if (idElement == "Clients") {
                $('#divProgram').css('visibility', 'hidden');
                $('#divProgramLabel').css('visibility', 'hidden');
            }
        }
    },

    Search_Reports_Details: function () {
        var form = $('#FiltersForm');

        var result = form.valid();

        var checkBoxesChecked = false;

        if (result == true) {
            //var popupNotification = $("#popupNotification").kendoNotification({
            //    position: {
            //        top: 60,
            //        right: 30,
            //        pinned: true
            //    },
            //    autoHideAfter: 5000,
            //    stacking: "down",
            //    templates: [{
            //        type: "error",
            //        template: $("#errorTemplate").html()
            //    }]
            //}).data("kendoNotification");

            var URL = General.BASE_URL + '/Risks/RiskReportGrid_Read';
            var riskStatus_Id = $("#EstatusRiesgo_Id").data("kendoDropDownList").value();
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
            var program_Ident = null;
            var employee_Ident = null;

            if ($('#cbRiskDate').is(":checked")) {
                riskDateStart = $("#dpRiskDateStart").val();
                riskDateEnd = $("#dpRiskDateEnd").val();
                var oRiskDateStart = new Date(riskDateStart);
                var oRiskDateEnd = new Date(riskDateEnd);
                checkBoxesChecked = true;
                if (!riskDateEnd || !riskDateStart) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Must select a valid date for filter results [Registration Date]"
                    //}, "error");
                    toast('Must select a valid date for filter results [Registration Date]', 4000, 'rounded yellow darken-2');

                    result = false;
                }

                if (oRiskDateEnd < oRiskDateStart) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Registration Date: Second date must be more recent than the first"
                    //}, "error");
                    toast('Registration Date: Second date must be more recent than the first', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbManagers').is(":checked")) {
                manager_Ident = $("#Manager_Ident").data("kendoDropDownList").value();
                checkBoxesChecked = true;
                if (!manager_Ident) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Must select a manager for filter results"
                    //}, "error");
                    toast('Must select a manager for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            //RZ.20141028 Se retira filtro de Payroll
            //if ($('#cbPayRoll').is(":checked")) {
            //    payRoll = $("#PayRoll").val();
            //    checkBoxesChecked = true;
            //    if (!payRoll) {
            //        popupNotification.show({
            //            title: "Check values",
            //            message: "Must type a payroll for filter results"
            //        }, "error");

            //        result = false;
            //    }
            //}

            if ($('#cbReviewDate').is(":checked")) {
                reviewDateStart = $("#dpReviewDateStart").val();
                reviewDateEnd = $("#dpReviewDateEnd").val();
                oReviewDateStart = new Date(reviewDateStart);
                oReviewDateEnd = new Date(reviewDateEnd);
                checkBoxesChecked = true;
                if (!reviewDateStart || !reviewDateEnd) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Must select a valid date for filter results [Review Date]" 
                    //}, "error");
                    toast('Must select a valid date for filter results [Review Date]', 4000, 'rounded yellow darken-2');
                    result = false;
                }

                if (oReviewDateEnd < oReviewDateStart) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Review Date: Second date must be more recent than the first"
                    //}, "error");
                    toast('Review Date: Second date must be more recent than the first', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbFloorManagers').is(":checked")) {
                floorManager_Ident = $("#FloorManager_Ident").data("kendoDropDownList").value();
                checkBoxesChecked = true;
                if (!floorManager_Ident) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Must select a floor manager for filter results"
                    //}, "error");
                    toast('Must select a floor manager for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbCCMS_User').is(":checked")) {
                CCMS_User = $("#CCMS_User").val();
                checkBoxesChecked = true;
                if (!CCMS_User) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Must type a CCMS user for filter results"
                    //}, "error");
                    toast('Must type a CCMS user for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbLocation').is(":checked")) {
                location_Ident = $("#Location_Ident").data("kendoDropDownList").value();
                checkBoxesChecked = true;
                if (!location_Ident) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Must select a site for filter results"
                    //}, "error");
                    toast('Must select a site for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbClients').is(":checked")) {
                client_Ident = $('#Client_Ident').data('kendoDropDownList').value();
                checkBoxesChecked = true;
                if (!client_Ident) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Must select a client for filter results"
                    //}, "error");
                    toast('Must select a client for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }

                program_Ident = $('#Program_Ident').data('kendoDropDownList').value();
            }

            if ($('#cbEmployee').is(':checked')) {
                employee_Ident = $('#Employee_Ident').val();
                checkBoxesChecked = true;
                if (!employee_Ident) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Must type an CCMSID for filter results"
                    //}, "error");
                    toast('Must type an CCMSID for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbEmployeeName').is(':checked')) {
                checkBoxesChecked = true;
                if ($('#empid_selected').val() != 0) {
                    employee_Ident = $('#empid_selected').val();
                } else {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Must select an employee name for filter results"
                    //}, "error");
                    toast('Must select an employee name for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbEmployee').is(':checked') && $('#cbEmployeeName').is(':checked')) {
                //popupNotification.show({
                //    title: "Only one option",
                //    message: "Just choose one option to find employees by Name or CCMSID"
                //}, "error");
                toast('Just choose one option to find employees by Name or CCMSID', 4000, 'rounded yellow darken-2');
                result = false;
            }

            var FiltersRisk = {
                EstatusRiesgo_Id: riskStatus_Id,
                FechaRiesgoIni: riskDateStart,
                FechaRiesgoFin: riskDateEnd,
                Manager_Ident: manager_Ident,
                PayRoll: payRoll,
                FechaRevisionIni: reviewDateStart,
                FechaRevisionFin: reviewDateEnd,
                FloorManager_Ident: floorManager_Ident,
                CCMS_User: CCMS_User,
                Location_Ident: location_Ident,
                Client_Ident: client_Ident,
                Program_Ident: program_Ident,
                Employee_Ident: employee_Ident
            }

            if (!checkBoxesChecked) {
                //popupNotification.show({
                //    title: "Check values",
                //    message: "Must select at least one checkbox"
                //}, "error");
                toast('Must select at least one checkbox', 4000, 'rounded yellow darken-2');
            }

            if (result && checkBoxesChecked) {
                $.ajax({
                    dataType: 'json',
                    type: 'POST',
                    //traditional: true,
                    data: JSON.stringify(FiltersRisk),
                    async: false,
                    url: URL,
                    //url: '@Url.Action("GetEmployeeData", "HeadCounts")',
                    success: function (json) {
                        if (json.success == 1) {

                            var grid = $("#RiskReportGrid").data("kendoGrid");

                            var dataSource = new kendo.data.DataSource({

                                data: json.oData.ResultRisks

                            });

                            grid.setDataSource(dataSource);
                            grid.dataSource.read();

                            if (json.oData.ResultRisks.length == 0) {
                                //popupNotification.show({
                                //    title: "No records to display",
                                //    message: ""
                                //}, "error");
                                toast('No records to display', 4000, 'rounded yellow darken-2');
                            }
                            else {
                                $("#btnExport").css('visibility', 'visible');
                            }

                            $("#RiskReportGrid table tbody tr").each(function (i, row) {

                                var $row = $(row);

                                $row.click(function () {
                                    var employee_ident = $row.children("td:eq(1)").text();
                                    Risks.Load_Info_RisksModal(employee_ident);

                                })
                            });

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
            }
        }
    },

    Load_Info_RisksModal: function (employee_ident) {
        Risks.Get_Header_RisksModal(employee_ident);
        Risks.Get_Content_RisksModal(employee_ident);
        //abrir modal despues de cargar la informacion
        var modalWindowRisks = $("#modalWindowRisks").data("kendoWindow");
        modalWindowRisks.open();
    },

    Get_Header_RisksModal: function (x) {
        var URL = General.BASE_URL + '/Risks/GetHeaderRisksEmployee';

        $.ajax({
            dataType: 'html',
            type: 'POST',
            url: URL,
            data: { "Employee_Ident": parseInt(x) },
            async: false,
            success: function (data) {
                if (data.search("/Access/Authentication") < 0) {
                    $("#RiskDetailsHeader").html(data); //HMTL DOM replace
                } else {
                    window.location = General.BASE_URL + "/Access/Index";
                }
            }
        });
    },

    Get_Content_RisksModal: function (x) {
        var URL = General.BASE_URL + '/Risks/GetContentRisksEmployee';

        $.ajax({
            dataType: 'html',
            type: 'POST',
            url: URL,
            data: { "Employee_Ident": parseInt(x) },
            async: false,
            success: function (data) {
                if (data.search("/Access/Authentication") < 0) {
                    $("#RiskDetailsContent").html(data); //HMTL DOM replace
                } else {
                    window.location = General.BASE_URL + "/Access/Index";
                }
            }
        });
    },

    Export_Result_Report: function () {
        var form = $('#FiltersForm');

        var result = form.valid();

        if (result == true) {
            var URL = General.BASE_URL + '/Risks/ExportToXLS';
            var checkBoxesChecked = false;
            //var popupNotification = $("#popupNotification").kendoNotification({
            //    position: {
            //        top: 60,
            //        right: 30,
            //        pinned: true
            //    },
            //    autoHideAfter: 5000,
            //    stacking: "down",
            //    templates: [{
            //        type: "error",
            //        template: $("#errorTemplate").html()
            //    }]
            //}).data("kendoNotification");


            var riskStatus_Id = $("#EstatusRiesgo_Id").data("kendoDropDownList").value();
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
            var program_Ident = null;
            var employee_Ident = null;

            if ($('#cbRiskDate').is(":checked")) {
                riskDateStart = $("#dpRiskDateStart").val();
                riskDateEnd = $("#dpRiskDateEnd").val();
                var oRiskDateStart = new Date(riskDateStart);
                var oRiskDateEnd = new Date(riskDateEnd);
                checkBoxesChecked = true;
                if (!riskDateEnd || !riskDateStart) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Must select a valid date for filter results [Registration Date]"
                    //}, "error");
                    toast('Must select a valid date for filter results [Registration Date]', 4000, 'rounded yellow darken-2');

                    result = false;
                }

                if (oRiskDateEnd < oRiskDateStart) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Registration Date: Second date must be more recent than the first"
                    //}, "error");
                    toast('Registration Date: Second date must be more recent than the first', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbManagers').is(":checked")) {
                manager_Ident = $("#Manager_Ident").data("kendoDropDownList").value();
                checkBoxesChecked = true;
                if (!manager_Ident) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Must select a manager for filter results"
                    //}, "error");
                    toast('Must select a manager for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            //RZ.20141028 Se retira filtro de Payroll
            //if ($('#cbPayRoll').is(":checked")) {
            //    payRoll = $("#PayRoll").val();
            //    checkBoxesChecked = true;
            //    if (!payRoll) {
            //        popupNotification.show({
            //            title: "Check values",
            //            message: "Must type a payroll for filter results"
            //        }, "error");

            //        result = false;
            //    }
            //}

            if ($('#cbReviewDate').is(":checked")) {
                reviewDateStart = $("#dpReviewDateStart").val();
                reviewDateEnd = $("#dpReviewDateEnd").val();
                oReviewDateStart = new Date(reviewDateStart);
                oReviewDateEnd = new Date(reviewDateEnd);
                checkBoxesChecked = true;
                if (!reviewDateStart || !reviewDateEnd) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Must select a valid date for filter results [Review Date]" 
                    //}, "error");
                    toast('Must select a valid date for filter results [Review Date]', 4000, 'rounded yellow darken-2');
                    result = false;
                }

                if (oReviewDateEnd < oReviewDateStart) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Review Date: Second date must be more recent than the first"
                    //}, "error");
                    toast('Review Date: Second date must be more recent than the first', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbFloorManagers').is(":checked")) {
                floorManager_Ident = $("#FloorManager_Ident").data("kendoDropDownList").value();
                checkBoxesChecked = true;
                if (!floorManager_Ident) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Must select a floor manager for filter results"
                    //}, "error");
                    toast('Must select a floor manager for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbCCMS_User').is(":checked")) {
                CCMS_User = $("#CCMS_User").val();
                checkBoxesChecked = true;
                if (!CCMS_User) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Must type a CCMS user for filter results"
                    //}, "error");
                    toast('Must type a CCMS user for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbLocation').is(":checked")) {
                location_Ident = $("#Location_Ident").data("kendoDropDownList").value();
                checkBoxesChecked = true;
                if (!location_Ident) {
                    location_Ident = $("#Location_Ident").data("kendoDropDownList").value();
                    checkBoxesChecked = true;
                    if (!location_Ident) {
                        //popupNotification.show({
                        //    title: "Check values",
                        //    message: "Must select a site for filter results"
                        //}, "error");
                        toast('Must select a site for filter results', 4000, 'rounded yellow darken-2');
                        result = false;
                    }
                }
            }

            if ($('#cbClients').is(":checked")) {
                client_Ident = $('#Client_Ident').data('kendoDropDownList').value();
                checkBoxesChecked = true;
                if (!client_Ident) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Must select a client for filter results"
                    //}, "error");
                    toast('Must select a client for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }

                program_Ident = $('#Program_Ident').data('kendoDropDownList').value();
            }

            if ($('#cbClients').is(":checked")) {
                client_Ident = $('#Client_Ident').data('kendoDropDownList').value();
                checkBoxesChecked = true;
                if (!client_Ident) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Must select a client for filter results"
                    //}, "error");
                    toast('Must select a client for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }

                program_Ident = $('#Program_Ident').data('kendoDropDownList').value();
            }

            if ($('#cbEmployee').is(':checked')) {
                employee_Ident = $('#Employee_Ident').val();
                checkBoxesChecked = true;
                if (!employee_Ident) {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Must type an CCMSID for filter results"
                    //}, "error");
                    toast('Must type an CCMSID for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbEmployeeName').is(':checked')) {
                checkBoxesChecked = true;
                if ($('#empid_selected').val() != 0) {
                    employee_Ident = $('#empid_selected').val();
                } else {
                    //popupNotification.show({
                    //    title: "Check values",
                    //    message: "Must select an employee name for filter results"
                    //}, "error");
                    toast('Must select an employee name for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbEmployee').is(':checked') && $('#cbEmployeeName').is(':checked')) {
                //popupNotification.show({
                //    title: "Only one option",
                //    message: "Just choose one option to find employees by Name or CCMSID"
                //}, "error");
                toast('Just choose one option to find employees by Name or CCMSID', 4000, 'rounded yellow darken-2');
                result = false;
            }

            //var FiltersRisk = {
            //    EstatusRiesgo_Id: riskStatus_Id,
            //    FechaRiesgoIni: riskDateStart,
            //    FechaRiesgoFin: riskDateEnd,
            //    Manager_Ident: manager_Ident,
            //    PayRoll: payRoll,
            //    FechaRevisionIni: reviewDateStart,
            //    FechaRevisionFin: reviewDateEnd,
            //    FloorManager_Ident: floorManager_Ident,
            //    CCMS_User: CCMS_User,
            //    Location_Ident: location_Ident,
            //    Client_Ident: client_Ident,
            //    Program_Ident: program_Ident,
            //    Employee_Ident: employee_Ident
            //}

            if (!checkBoxesChecked) {
                //popupNotification.show({
                //    title: "Check values",
                //    message: "Must select at least one checkbox"
                //}, "error");
                toast('Must select at least one checkbox', 4000, 'rounded yellow darken-2');
            }

            if (result && checkBoxesChecked) {
                var data = 'EstatusRiesgo_Id=' + riskStatus_Id + '&FechaRiesgoIni=' + riskDateStart
                + '&FechaRiesgoFin=' + riskDateEnd + '&Manager_Ident=' + manager_Ident + '&PayRoll=' + payRoll
                + '&FechaRevisionIni=' + reviewDateStart + '&FechaRevisionFin=' + reviewDateEnd
                + '&FloorManager_Ident=' + floorManager_Ident + '&CCMS_User=' + CCMS_User + '&Location_Ident=' + location_Ident
                + '&Client_Ident=' + client_Ident + '&Program_Ident=' + program_Ident + '&Employee_Ident=' + employee_Ident;
                //plug in de jquery para poder hacer descarga de un excel via post
                $.download(URL, data, 'post');
            }
        }
    },

    ManagersOnDataBound: function () {
        var dataSource = this.dataSource;
        var data = dataSource.data();

        if (!this._adding) {
            this._adding = true;

            data.splice(0, 0, {
                "manager_name": "Select...",
                "manager_ident": "0"
            });

            this._adding = false;
            $("#Manager_Ident").data("kendoDropDownList").select(0);
        }
    }
}
