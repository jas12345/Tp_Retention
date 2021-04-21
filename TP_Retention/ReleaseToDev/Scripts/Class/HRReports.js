var HRReports = {
    EnableField: function (idElement) {

        var cbElement = '#cb' + idElement;
        var divElement = '#div' + idElement;

        if ($(cbElement).is(":checked")) {
            $(divElement).css('visibility', 'visible');
            if (idElement == "ReportType") {
                $('#divSubReportTypeLabel').css('visibility', 'visible');
                $('#divSubReportType').css('visibility', 'visible');
            }

            if (idElement == "Clients") {
                $('#divProgram').css('visibility', 'visible');
                $('#divProgramLabel').css('visibility', 'visible');
            }
        }
        else {
            $(divElement).css('visibility', 'hidden');
            if (idElement == "ReportType") {
                $('#divSubReportTypeLabel').css('visibility', 'hidden');
                $('#divSubReportType').css('visibility', 'hidden');
            }

            if (idElement == "Clients") {
                $('#divProgram').css('visibility', 'hidden');
                $('#divProgramLabel').css('visibility', 'hidden');
            }
        }
    },

    Search_HRReports_Details: function () {
        var form = $('#FiltersHRReportsForm');

        var result = form.valid();

        var checkBoxesChecked = false;

        if (result == true) {

            var URL = General.BASE_URL + '/HRReports/HRReportsReportGrid_Read';

            var location_Ident;
            var reportDateStart;
            var reportDateEnd;
            var employee_Ident;
            var CCMS_User;
            var client_Ident;
            var program_Ident;
            var floorManager_Ident ;
            var reportType_Id = $("#ReportType_Id").data("kendoDropDownList").value();
            var subReportType_Id = $("#SubReportType_Id").data("kendoDropDownList").value();
            var manager_Ident;

            if ($('#cbReportDate').is(":checked")) {
                reportDateStart = $("#dpReportDateStartFilter").val();
                reportDateEnd = $("#dpReportDateEndFilter").val();
                var oreportDateStart = new Date(reportDateStart);
                var oreportDateEnd = new Date(reportDateEnd);
                checkBoxesChecked = true;
                if (!reportDateEnd || !reportDateStart) {
                    toast('Report Date: Must select a valid date for filter results', 4000, 'rounded yellow darken-2');

                    result = false;
                }

                if (oreportDateEnd < oreportDateStart) {
                    toast('Report Date: Second date must be more recent than the first', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbManagers').is(":checked")) {
                manager_Ident = $("#Manager_Ident").data("kendoDropDownList").value();
                checkBoxesChecked = true;
                if (!manager_Ident) {
                    toast('Must select a manager for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbFloorManagers').is(":checked")) {
                floorManager_Ident = $("#FloorManager_Ident").data("kendoDropDownList").value();
                checkBoxesChecked = true;
                if (!floorManager_Ident) {
                    toast('Must select a floor manager for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbCCMS_User').is(":checked")) {
                CCMS_User = $("#CCMS_User").val();
                checkBoxesChecked = true;
                if (!CCMS_User) {
                    toast('Must type a CCMS user for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbLocation').is(":checked")) {
                location_Ident = $("#Location_Ident").data("kendoDropDownList").value();
                checkBoxesChecked = true;
                if (!location_Ident) {
                    toast('Must select a site for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbClients').is(":checked")) {
                client_Ident = $('#Client_Ident').data('kendoDropDownList').value();
                checkBoxesChecked = true;
                if (!client_Ident) {
                    toast('Must select a client for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }

                program_Ident = $('#Program_Ident').data('kendoDropDownList').value();
            }

            if ($('#cbReportType').is(":checked")) {
                reportType_Id = $('#ReportType_Id').data('kendoDropDownList').value();
                checkBoxesChecked = true;
                if (!reportType_Id) {
                    toast('Must select a report type for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }

                subReportType_Id = $('#SubReportType_Id').data('kendoDropDownList').value();
            }

            if ($('#cbEmployee').is(':checked')) {
                employee_Ident = $('#Employee_Ident').val();
                checkBoxesChecked = true;
                if (!employee_Ident) {
                    toast('Must type an CCMSID for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbEmployeeName').is(':checked')) {
                checkBoxesChecked = true;
                if ($('#empid_selected').val() != 0) {
                    employee_Ident = $('#empid_selected').val();
                } else {
                    toast('Must select an employee name for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbEmployee').is(':checked') && $('#cbEmployeeName').is(':checked')) {
                toast('Just choose one option to find employees, only by Name or by CCMSID', 4000, 'rounded yellow darken-2');
                result = false;
            }

            if (!checkBoxesChecked) {
                toast('Must select at least one checkbox', 4000, 'rounded yellow darken-2');
            }

            if (result && checkBoxesChecked) {
                $.ajax({
                    dataType: 'json',
                    type: 'POST',
                    data: {
                        "Location_Ident": location_Ident,
                        "ReportDateStart": reportDateStart,
                        "ReportDateEnd": reportDateEnd,
                        "Employee_Ident": employee_Ident,
                        "CCMS_User": CCMS_User,
                        "Client_Ident": client_Ident,
                        "Program_Ident": program_Ident,
                        "FloorManager_Ident": floorManager_Ident,
                        "ReportType_Id": reportType_Id,
                        "SubReportType_Id": subReportType_Id,
                        "Manager_Ident": manager_Ident
                    },
                    async: false,
                    url: URL,
                    success: function (json) {
                        if (json.success == 1) {

                            var grid = $("#HRReportGrid").data("kendoGrid");

                            var dataSource = new kendo.data.DataSource({

                                data: json.oData.ResultReports

                            });

                            grid.setDataSource(dataSource);
                            grid.dataSource.read();

                            if (json.oData.ResultReports.length == 0) {
                                toast('No records to display', 4000, 'rounded yellow darken-2');
                            }
                            else {
                                $("#btnExport").css('visibility', 'visible');
                            }

                            $("#HRReportGrid table tbody tr").each(function (i, row) {

                                var $row = $(row);

                                $row.click(function () {
                                    var employee_ident = $row.children("td:eq(1)").text();
                                    HRReports.Load_Info_HRReportsModal(employee_ident);

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

    Export_Result_Report: function () {
        var form = $('#FiltersHRReportsForm');

        var result = form.valid();

        var checkBoxesChecked = false;

        if (result == true) {

            var URL = General.BASE_URL + '/HRReports/ExportToXLS';

            var location_Ident;
            var reportDateStart;
            var reportDateEnd;
            var employee_Ident;
            var CCMS_User = null;
            var client_Ident;
            var program_Ident;
            var floorManager_Ident;
            var reportType_Id = $("#ReportType_Id").data("kendoDropDownList").value();
            var subReportType_Id = $("#SubReportType_Id").data("kendoDropDownList").value();
            var manager_Ident;

            if ($('#cbReportDate').is(":checked")) {
                reportDateStart = $("#dpReportDateStartFilter").val();
                reportDateEnd = $("#dpReportDateEndFilter").val();
                var oreportDateStart = new Date(reportDateStart);
                var oreportDateEnd = new Date(reportDateEnd);
                checkBoxesChecked = true;
                if (!reportDateEnd || !reportDateStart) {
                    toast('Report Date: Must select a valid date for filter results', 4000, 'rounded yellow darken-2');

                    result = false;
                }

                if (oreportDateEnd < oreportDateStart) {
                    toast('Report Date: Second date must be more recent than the first', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbManagers').is(":checked")) {
                manager_Ident = $("#Manager_Ident").data("kendoDropDownList").value();
                checkBoxesChecked = true;
                if (!manager_Ident) {
                    toast('Must select a manager for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbFloorManagers').is(":checked")) {
                floorManager_Ident = $("#FloorManager_Ident").data("kendoDropDownList").value();
                checkBoxesChecked = true;
                if (!floorManager_Ident) {
                    toast('Must select a floor manager for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbCCMS_User').is(":checked")) {
                CCMS_User = $("#CCMS_User").val();
                checkBoxesChecked = true;
                if (!CCMS_User) {
                    toast('Must type a CCMS user for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbLocation').is(":checked")) {
                location_Ident = $("#Location_Ident").data("kendoDropDownList").value();
                checkBoxesChecked = true;
                if (!location_Ident) {
                    toast('Must select a site for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbClients').is(":checked")) {
                client_Ident = $('#Client_Ident').data('kendoDropDownList').value();
                checkBoxesChecked = true;
                if (!client_Ident) {
                    toast('Must select a client for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }

                program_Ident = $('#Program_Ident').data('kendoDropDownList').value();
            }

            if ($('#cbReportType').is(":checked")) {
                reportType_Id = $('#ReportType_Id').data('kendoDropDownList').value();
                checkBoxesChecked = true;
                if (!reportType_Id) {
                    toast('Must select a report type for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }

                subReportType_Id = $('#SubReportType_Id').data('kendoDropDownList').value();
            }

            if ($('#cbEmployee').is(':checked')) {
                employee_Ident = $('#Employee_Ident').val();
                checkBoxesChecked = true;
                if (!employee_Ident) {
                    toast('Must type an CCMSID for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbEmployeeName').is(':checked')) {
                checkBoxesChecked = true;
                if ($('#empid_selected').val() != 0) {
                    employee_Ident = $('#empid_selected').val();
                } else {
                    toast('Must select an employee name for filter results', 4000, 'rounded yellow darken-2');
                    result = false;
                }
            }

            if ($('#cbEmployee').is(':checked') && $('#cbEmployeeName').is(':checked')) {
                toast('Just choose one option to find employees, only by Name or by CCMSID', 4000, 'rounded yellow darken-2');
                result = false;
            }

            if (!checkBoxesChecked) {
                toast('Must select at least one checkbox', 4000, 'rounded yellow darken-2');
            }

            if (result && checkBoxesChecked) {
                var data = 'Location_Ident=' + location_Ident + '&ReportDateStart=' + reportDateStart
                + '&ReportDateEnd=' + reportDateEnd + '&Employee_Ident=' + employee_Ident + '&CCMS_User=' + CCMS_User
                + '&Client_Ident=' + client_Ident + '&Program_Ident=' + program_Ident
                + '&FloorManager_Ident=' + floorManager_Ident + '&ReportType_Id=' + reportType_Id + '&SubReportType_Id=' + subReportType_Id
                + '&Manager_Ident=' + manager_Ident;
                //plug in de jquery para poder hacer descarga de un excel via post
                $.download(URL, data, 'post');
            }
        }
    },

    Load_Info_HRReportsModal: function (employee_ident) {
        HRReports.Get_Header_HRReportsModal(employee_ident);
        HRReports.Get_Content_HRReportsModal(employee_ident);
        //abrir modal despues de cargar la informacion
        var modalWindowHRReports = $("#modalWindowHRReports").data("kendoWindow");
        modalWindowHRReports.open();
    },

    Get_Header_HRReportsModal: function (x) {
        var URL = General.BASE_URL + '/Risks/GetHeaderRisksEmployee';

        $.ajax({
            dataType: 'html',
            type: 'POST',
            url: URL,
            data: { "Employee_Ident": parseInt(x) },
            async: false,
            success: function (data) {
                if (data.search("/Access/Authentication") < 0) {
                    $("#HRReportDetailsHeader").html(data);
                } else {
                    window.location = General.BASE_URL + "/Access/Index";
                }
            }
        });
    },

    Get_Content_HRReportsModal: function (x) {
        var URL = General.BASE_URL + '/Risks/GetContentRisksEmployee';

        $.ajax({
            dataType: 'html',
            type: 'POST',
            url: URL,
            data: { "Employee_Ident": parseInt(x) },
            async: false,
            success: function (data) {
                if (data.search("/Access/Authentication") < 0) {
                    $("#HRReportDetailsContent").html(data);
                } else {
                    window.location = General.BASE_URL + "/Access/Index";
                }
            }
        });
    }
}