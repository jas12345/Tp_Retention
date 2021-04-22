var HeadCounts = {

    EmployeeRisksDetails: function (Employee_Ident) {

        var URL = General.BASE_URL + '/HeadCounts/GetEmployeeRiskData';

        $.ajax({

            dataType: 'json',
            type: 'POST',
            data: { "Employee_Ident": Employee_Ident },
            async: false,
            url: URL,
            success: function (json) {

                if (json.success == 1) {

                    var Data = json.oData.EmployeeRisk;

                    if (!$.isEmptyObject(Data)) {
                        $("#gridEmployeeRisksDetails").kendoGrid({
                            dataSource: {
                                type: "odata",
                                data: Data,
                                schema: {
                                    model: {
                                        fields: {
                                            Employee_Ident: { type: "integer" },
                                            RiskList_Id: { type: "integer" },
                                            sRiskDate: { type: "string" },
                                            RiskStatus_Id: { type: "integer" },
                                            RiskStatus: { type: "string" },
                                            RiskListType: { type: "string" },
                                            Category: { type: "string" },
                                            sReviewDate: { type: "string" },
                                            EstimacionRiesgo_Id : {type: "string"}
                                        }
                                    }
                                },
                                pageSize: 10,
                                serverPaging: false,
                                serverSorting: false,
                                serverFiltering: false
                            },
                            height: 200,
                            filterable: true,
                            sortable: true,
                            resizable: true,
                            selectable: "row",
                            pageable: {
                                refresh: true,
                                pageSizes: true,
                                buttonCount: 5
                            },
                            columns: [{
                                field: "sRiskDate",
                                title: "Date",
                                width: 50,
                                filterable: true,
                                attributes: {
                                    style: "font-size: 11px"
                                }
                            }, {
                                field: "RiskStatus",
                                title: "PTL Status",
                                width: 60,
                                attributes: {
                                    style: "font-size: 11px"
                                }
                            }, {
                                field: "RiskListType",
                                title: "Attrition Type",
                                width: 80,
                                attributes: {
                                    style: "font-size: 11px"
                                }
                            }, {
                                field: "Category",
                                title: "Category",
                                width: 150,
                                attributes: {
                                    style: "font-size: 11px"
                                }
                            }, {
                                field: "sReviewDate",
                                title: "Review Date",
                                width: 50,
                                attributes: {
                                    style: "font-size: 11px"
                                }
                            }, {
                                field: "EstimacionRiesgo",
                                title: "RiskEstimation",
                                width: 50,
                                attributes: {
                                    style: "font-size: 11px"
                                }
                            }, {
                                field: "Employee_Ident",
                                title: "Options",
                                //template: "<div style='width:100%; text-align:center;cursor:pointer;'>" + "#if (RiskStatus_Id == 1 || RiskStatus_Id == 4){#" + "<i class='fa fa-pencil fa-2x' style='color:green;' onclick='HeadCounts.ModalEmployeeRisksEditor(" + "#= Employee_Ident #" + "," + "#= RiskList_Id #" + ");'></i>" + "#}#" + "</div>",
                                    template: "<div style='width:100%; text-align:center;cursor:pointer;'>" + "#if (RiskStatus_Id == 1 || RiskStatus_Id == 4){#" + "<i class='fa fa-pencil fa-2x' style='color:green;' onclick='HeadCounts.ModalEmployeeRisksEditor(" + "#= Employee_Ident #" + "," + "#= RiskList_Id #" + ");'></i>" + "#}#" + "#if (RiskStatus_Id==2 || RiskStatus_Id==3){#" + "<i class='fa fa-eye fa-2x' style='color:gray;' onclick='HeadCounts.ModalEmployeeRisksView(" + "#= Employee_Ident #" + "," + "#= RiskList_Id #" + ");'></i>" + "#}#" + "</div> ",
                                filterable: false,
                                width: 40,
                                attributes: {
                                    style: "font-size: 11px"
                                }
                            }]
                        });

                        HeadCounts.GoOverGrid();
                    } else {
                        //$('#addRiskButton').remove();
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

    GoOverGrid: function () {

        $("#gridEmployeeRisksDetails tbody tr").each(function (i, row) {

            var $row = $(row);

            var cont = 0;

            var status = $row.children("td:eq(1)").text();

            var cont = cont + 1;

            if ((status.toUpperCase().trim() == "AT RISK" || status.toUpperCase().trim() == "ATTRITION") && cont == 1) {

                $("#addRiskButton").hide();

            }

            //if (status.toUpperCase().trim() != "AT RISK") {

            //    $td = $row.children("td:eq(5)");

            //    //Si no hay rows en el empleado no es necesario remover
            //    if (typeof $td.children("a")[0] === "undefined") {
            //        return;
            //    }

            //    $td.children("a:first-child").remove();

            //    if (a != 1) {

            //        $td.children("a:first-child").remove();

            //    }

            //}

        });

    },

    SaveActionLog: function () {
        var riesgoId = $('#RiskList_Id').val();
        var employee_ident = $('#Employee_Ident_Editor').val();
        var estatusRiesgoId = $("#RiskStatus_Id").data("kendoDropDownList").value();
        var accionRetencion = $("#AccionRetencion").val();

        var URL = General.BASE_URL + '/HeadCounts/InsertActionLog';

        if (parseInt(riesgoId) > 0 && typeof employee_ident != 'undefined'
                && accionRetencion.length > 0) {
            $.ajax({
                type: "POST",
                url: URL,
                data: JSON.stringify({
                    "ListaRiesgo_Id": riesgoId,
                    "AccionRetencion": accionRetencion,
                    "EstatusRiesgo_Id": estatusRiesgoId
                }),
                dataType: "json",
                contentType: "application/json",
                succes: function (json) {

                    if (json.succes == 1) {

                        //popupNotification.show({
                        //    title: "Success",
                        //    message: json.oData.Error
                        //}, "Sucesss");

                        //HeadCounts.ReloadActionLog(riesgoId, employee_ident);

                    } else if (json.failure == 1) {
                        //popupNotification.show({
                        //    title: "Error",
                        //    message: json.oData.Error
                        //}, "error");
                        toast(json.oData.Error, 4000, 'rounded yellow darken-2');
                    } else if (json.noLogin == 1) {

                        window.location = General.BASE_URL + "/Access/Index";

                    }
                },
                error: function (request, status, error) {

                    //popupNotification.show({
                    //    title: "Error",
                    //    message: "Something is wrong..."
                    //}, "error");
                    toast('Something is wrong...', 4000, 'rounded yellow darken-2');

                }
            });

            $("#listViewActionLog").data("kendoListView").dataSource.read();
            $("#listViewActionLog").data("kendoListView").refresh();
            $("#AccionRetencion").val("");
        }
        else {
            if (accionRetencion.length == 0) {
                toast('The Action Field is required', 4000, 'rounded yellow darken-2');
            }

            if (parseInt(riesgoId) == 0) {
                toast('Save the risk before add actions', 4000, 'rounded yellow darken-2');
            }
        }
    },

    SaveInteractionLog: function () {
        var riesgoId = $('#RiskList_Id').val();
        var employee_ident = $('#Employee_Ident_Editor').val();
        var estatusRiesgoId = $("#RiskStatus_Id").data("kendoDropDownList").value();
        var interaction = $("#Interaction").val();

        var param = {
            ListaRiesgo_Id: riesgoId,
            Interaction: interaction,
            EstatusRiesgo_Id: estatusRiesgoId
        };

        var URL = General.BASE_URL + '/HeadCounts/InsertInteractionLog'

        var popupNotification = $("#popupNotificationInteractionLog").kendoNotification({
            position: {
                top: 60,
                right: 30,
                pinned: true
            },
            autoHideAfter: 5000,
            stacking: "down",
            templates: [{
                type: "error",
                template: $("#errorTemplate").html()
            }]
        }).data("kendoNotification");

        if (parseInt(riesgoId) > 0 && typeof employee_ident != 'undefined'
                && interaction.length > 0) {
            $.ajax({
                type: "POST",
                url: URL,
                data: JSON.stringify(param),
                dataType: "html",
                contentType: "application/json",
                succes: function (json) {

                    if (json.succes == 1) {

                        //popupNotification.show({
                        //    title: "Success",
                        //    message: json.oData.Error
                        //}, "Sucesss");

                        //HeadCounts.ReloadActionLog(riesgoId, employee_ident);

                    } else if (json.failure == 1) {
                        popupNotification.show({
                            title: "Error",
                            message: json.oData.Error
                        }, "error");
                    } else if (json.noLogin == 1) {

                        window.location = General.BASE_URL + "/Access/Index";

                    }
                },
                error: function (request, status, error) {

                    popupNotification.show({
                        title: "Error",
                        message: "Something is wrong..."
                    }, "error");

                }
            });

            $("#listViewInteractionLog").data("kendoListView").dataSource.read();
            $("#listViewInteractionLog").data("kendoListView").refresh();
            $("#Interaction").val("");
        }
        else {
            if (interaction.length == 0) {
                popupNotification.show({
                    title: "Required!",
                    message: "The Interaction Field is required"
                }, "error");
            }

            if (parseInt(riesgoId) == 0) {
                popupNotification.show({
                    title: "New Risk",
                    message: "Save the risk before add interactions"
                }, "error");
            }
        }
    },

    ModalEmployeeRisksEditor: function (Employee_Id, RiskList_Id) {

        var URL = General.BASE_URL + '/HeadCounts/GetEmployeeRisksEditor';

        $.ajax({

            dataType: "html",
            type: 'POST',
            data: { "Employee_Id": Employee_Id, "RiskList_Id": RiskList_Id },
            async: false,
            url: URL,
            success: function (data) {
                if (data.search("/Access/Authentication") < 0) {
                    $("#ModalEmployeeRisksEditor").empty();

                    $("#ModalEmployeeRisksEditor").html(data);

                    $("#ModalEmployeeRisksEditor").data("kendoWindow").center().open();
                } else {
                    window.location = General.BASE_URL + "/Access/Index";
                }
            },
            error: function (request, status, error) {

                General.FlashMessage('Error');

            }

        });

    },

    ModalEmployeeRisksAdd: function (Employee_Id) {

        var URL = General.BASE_URL + '/HeadCounts/GetEmployeeRisksAdd';

        $.ajax({

            dataType: "html",
            type: 'POST',
            data: { "Employee_Id": Employee_Id },
            async: false,
            url: URL,
            success: function (data) {
                if (data.search("/Access/Authentication") < 0) {
                    $("#ModalEmployeeRisksEditor").empty();

                    $("#ModalEmployeeRisksAdd").html(data);

                    $("#ModalEmployeeRisksAdd").data("kendoWindow").center().open();
                }
                else {
                    window.location = General.BASE_URL + "/Access/Index";
                }
            },
            error: function (request, status, error) {

                General.FlashMessage('Error');

            }

        });

    },

    ModalEmployeeRisksView: function (Employee_Id, RiskList_Id) {
        var URL = General.BASE_URL + '/HeadCounts/GetEmployeeRisksView';

        $.ajax({

            dataType: "html",
            type: 'POST',
            data: { "Employee_Id": Employee_Id, "RiskList_Id": RiskList_Id },
            async: false,
            url: URL,
            success: function (data) {
                if (data.search("/Access/Authentication") < 0) {
                    $("#ModalEmployeeRisksView").empty();

                    $("#ModalEmployeeRisksView").html(data);

                    $("#ModalEmployeeRisksView").data("kendoWindow").center().open();
                } else {
                    window.location = General.BASE_URL + "/Access/Index";
                }
            },
            error: function (request, status, error) {

                General.FlashMessage('Error');

            }

        });
    },

    EmployeeRisksData_Create: function () {

        var validator = $("#FormRisksAdd").kendoValidator().data("kendoValidator");

        var RiskStatus_Id = $("#RiskStatus_Id").val();
        var RiskListType_Id = $("#RiskListType_Id").val();
        var Category_Id = $("#Category_Id").val();
        var RiskDescription = $("#RiskDescription").val();
        var RiskDate = $("#RiskDate").val();
        var ResignationDate = $("#dpResignationDate").val();
        var ReviewDate = $("#dpReviewDate").val();
        var accionRetencion = $("#AccionRetencion").val();
        var EstimacionRiesgo_Id = $("#EstimacionRiesgo_Id").val();

        if (validator.validate()) {

            var URL = General.BASE_URL + '/HeadCounts/EmployeeRisksData_Create';

            var Employee_Ident = $("#Employee_Ident_Add").val();
            var Manager_Ident = $("#Manager_Ident_Editor").val();
            var Program_Ident = $("#Program_Ident_Editor").val();

            $.ajax({

                dataType: "json",
                type: 'POST',
                data: {
                    "Employee_Ident": Employee_Ident, "RiskDate": RiskDate, "RiskStatus_Id": RiskStatus_Id,
                    "RiskListType_Id": RiskListType_Id, "ResignationDate": ResignationDate, "ReviewDate": ReviewDate,
                    "Category_Id": Category_Id, "RiskDescription": RiskDescription, "Manager_Ident": Manager_Ident,
                    "Program_Ident": Program_Ident, "RetentionAction": accionRetencion,"EstimacionRiesgo_Id": EstimacionRiesgo_Id
                },
                async: false,
                url: URL,
                success: function (json) {

                    if (json.success == 1) {

                        var dialog = $("#ModalEmployeeRisksAdd").data("kendoWindow").close();

                        HeadCounts.EmployeeRisksDetails(Employee_Ident);

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
    },

    EmployeeRisksData_Update: function () {

        var validator = $("#FormRiskEdit").kendoValidator().data("kendoValidator");

        var RiskStatus_Id = $("#RiskStatus_Id").val();
        var RiskListType_Id = $("#RiskListType_Id").val();
        var Category_Id = $("#Category_Id").val();
        var RiskDescription = $("#RiskDescription").val();
        var RiskDate = $("#RiskDate").val();
        var ResignationDate = $("#dpResignationDate").val();
        var ReviewDate = $("#dpReviewDate").val();
        var EstimacionRiesgo_Id = $("#EstimacionRiesgo_Id").val();

        if (validator.validate()) {

            var URL = General.BASE_URL + '/HeadCounts/EmployeeRisksData_Update';

            var RiskList_Id = $("#RiskList_Id").val();
            var Employee_Ident = $("#Employee_Ident_Editor").val();

            $.ajax({

                dataType: "json",
                type: 'POST',
                data: {
                    "RiskList_Id": RiskList_Id,
                    "Employee_Ident": Employee_Ident, "RiskDate": RiskDate, "RiskStatus_Id": RiskStatus_Id,
                    "RiskListType_Id": RiskListType_Id, "ResignationDate": ResignationDate, "ReviewDate": ReviewDate,
                    "Category_Id": Category_Id, "RiskDescription": RiskDescription, "EstimacionRiesgo_Id":EstimacionRiesgo_Id
                },
                async: false,
                url: URL,
                success: function (json) {

                    if (json.success == 1) {

                        var dialog = $("#ModalEmployeeRisksEditor").data("kendoWindow").close();

                        HeadCounts.EmployeeRisksDetails(Employee_Ident);

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
    },

    isEmpty: function (a) {

        var res = true;

        for (var i = 0; i <= a.length - 1; i++) {

            if (a[i].length == 0) {

                res = false;
                break;

            } else if (a[i] == "") {

                res = false;
                break;

            } else if (a[i] == 0) {

                res = false;
                break;

            }
        }

        return res;

    },

    ReloadActionLog: function (ListaRiesgo_Id, Employee_Ident) {

        var URL = General.BASE_URL + '/HeadCounts/GetActionLog';

        $.ajax({
            type: "POST",
            url: URL,
            data: { "ListaRiesgo_Id": ListaRiesgo_Id, "Employee_Ident": Employee_Ident },
            dataType: "html",
            contentType: "application/json",
            success: function (data) {
                if (data.search("/Access/Authentication") < 0) {
                    $("#Employee_OnRisk_ActionLog").empty();

                    $("#Employee_OnRisk_ActionLog").html(data);
                } else {
                    window.location = General.BASE_URL + "/Access/Index";
                }

            }
        });

    },

    EmployeeReportDetails: function (Employee_Ident) {

        var URL = General.BASE_URL + '/HeadCounts/GetEmployeeReportData';

        $.ajax({

            dataType: 'json',
            type: 'POST',
            data: { "Employee_Ident": Employee_Ident },
            async: false,
            url: URL,
            success: function (json) {

                var empId = $('#empid').val();

                if (!empId) {
                    $('#tabStripDetails').remove();
                    return;
                }

                if (json.success == 1) {

                    var Data = json.oData.EmployeeReport;
                    if (!$.isEmptyObject(Data)) {

                        $("#gridEmployeeReportDetails").kendoGrid({
                            dataSource: {
                                type: "odata",
                                data: Data,
                                schema: {
                                    model: {
                                        fields: {
                                            Employee_Ident: { type: "integer" },
                                            HRreport_Id: { type: "integer" },
                                            ReportDate: { type: "date" },
                                            PrintedBy: { type: "integer" },
                                            PrintingDate: { type: "date" },
                                            ReportType: { type: "string" },
                                            SubReportType: { type: "string" },
                                            dateOfEvent: { type: "date" },
                                            //ReasonId: { type: "integer" },
                                            //SpecificCause_Id: { type: "integer" }
                                        }
                                    }
                                },
                                pageSize: 10,
                                serverPaging: false,
                                serverSorting: false,
                                serverFiltering: false
                            },
                            height: 200,
                            filterable: true,
                            sortable: true,
                            resizable: true,
                            selectable: "row",
                            pageable: {
                                refresh: true,
                                pageSizes: true,
                                buttonCount: 5
                            },
                            columns: [
                                {
                                    field: "ReportDate",
                                    title: "Date",
                                    template: "#= kendo.toString(kendo.parseDate(ReportDate, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
                                    width: 50,
                                    filterable: true,
                                    attributes: {
                                        style: "font-size: 11px"
                                    }
                                }, {
                                    field: "ReportType",
                                    title: "Report Type",
                                    width: 80,
                                    attributes: {
                                        style: "font-size: 11px"
                                    }
                                }, {
                                    field: "SubReportType",
                                    title: "SubReport Type",
                                    width: 80,
                                    filterable: true,
                                    attributes: {
                                        style: "font-size: 11px"
                                    }
                                }, {
                                    field: "PrintedBy",
                                    title: "Printed By",
                                    width: 50,
                                    attributes: {
                                        style: "font-size: 11px"
                                    }
                                }, {
                                    field: "PrintingDate",
                                    title: "Printing Date",
                                    template: "#= (PrintingDate==null) ? '' : kendo.toString(kendo.parseDate(PrintingDate, 'yyyy-MM-dd'), 'MM/dd/yyyy')#",
                                    width: 50,
                                    filterable: true,
                                    attributes: {
                                        style: "font-size: 11px"
                                    }
                                }
                                , {
                                    field: "Employee_Ident",
                                    title: "Options",
                                    template: "<div style='width:100%; text-align:center;cursor:pointer;'>" + "#if (PrintedBy == null || PrintingDate == null){#" + "<i class='fa fa-pencil fa-2x' style='color:green;' onclick='HeadCounts.ModalEmployeeReportEditor(" + "#= Employee_Ident #" + "," + "#= HRreport_Id #" + ");'></i>" + "#}#" + "&nbsp;<i class='fa fa-print fa-2x' style='color:rgb(40,53,147);' onclick='HeadCounts.ModalEmployeeReportPrint(" + "#= Employee_Ident #" + "," + "#= HRreport_Id #" + ");'></i>" + "&nbsp; #if (General.PROFILE == 3){# <i class='fa fa-trash-o fa-2x' style='color:red;' onclick='HeadCounts.ModalEmployeeReportRemove(" + "#= Employee_Ident #" + "," + "#= HRreport_Id #" + ");'></i>" + "#}#" + "</div>",
                                    filterable: false,
                                    width: 40,
                                    attributes: {
                                        style: "font-size: 11px"
                                    }

                                }
                                , {
                                    field: "dateOfEvent",
                                    title: "dateOfEvent",
                                    template: "#= kendo.toString(kendo.parseDate(dateOfEvent, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
                                    width: 50,
                                    filterable: true,
                                    attributes: {
                                        style: "font-size: 11px"
                                    }
                                }
                            ]
                        });
                    } else {
                        //$('#addReportButton').remove();
                        //$('#tabStripDetails').remove();
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

    ModalEmployeeReportAdd: function (Employee_Id) {

        var URL = General.BASE_URL + '/HeadCounts/GetEmployeeReportAdd';

        $.ajax({

            dataType: "html",
            type: 'POST',
            data: { "Employee_Id": Employee_Id },
            async: false,
            url: URL,
            success: function (data) {
                if (data.search("/Access/Authentication") < 0) {
                    $("#ModalEmployeeReportAdd").empty();
                    $("#ModalEmployeeReportEditor").empty();

                    $("#ModalEmployeeReportAdd").html(data);

                    $("#ModalEmployeeReportAdd").data("kendoWindow").center().open();
                }
                else {
                    window.location = General.BASE_URL + "/Access/Index";
                }
            },
            error: function (request, status, error) {

                General.FlashMessage('Error');

            }

        });

    },

    ModalEmployeeReportRemove: function (Employee_Id, HRreport_Id) {
        var URL = General.BASE_URL + '/HeadCounts/GetEmployeeReportRemove';

        $.ajax({

            dataType: "html",
            type: 'POST',
            data: { "Employee_Id": Employee_Id, "HRreport_Id": HRreport_Id },
            async: false,
            url: URL,
            success: function (data) {
                if (data.search("/Access/Authentication") < 0) {
                    $("#ModalEmployeeReportAdd").empty();
                    $("#ModalEmployeeReportEditor").empty();
                    $("#ModalEmployeeReportRemove").empty();

                    $("#ModalEmployeeReportRemove").html(data);

                    $("#ModalEmployeeReportRemove").data("kendoWindow").center().open();
                }
                else {
                    window.location = General.BASE_URL + "/Access/Index";
                }
            },
            error: function (request, status, error) {

                General.FlashMessage('Error');

            }

        });
    },

    GoBackRemove: function () {
        $("#ModalEmployeeReportRemove").empty();
        $("#ModalEmployeeReportRemove").data("kendoWindow").close();
    },

    DoHRReportRemove: function (Employee_Id, HRreport_Id) {
        if (Employee_Id && HRreport_Id) {

            var URL = General.BASE_URL + '/HeadCounts/EmployeeReportData_Remove';

            $.ajax({

                dataType: "json",
                type: 'POST',
                data: {
                    "Employee_Id": Employee_Id, "HRreport_Id": HRreport_Id
                },
                async: false,
                url: URL,
                success: function (json) {

                    if (json.success == 1) {

                        $("#ModalEmployeeReportRemove").data("kendoWindow").close();

                        HeadCounts.EmployeeReportDetails(Employee_Id);

                        General.FlashMessage('HR Report with Id ' + HRreport_Id + ' has been removed.')

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
    },

    EmployeeReportData_Create: function () {

        var validator = $("#FormReportAdd").kendoValidator().data("kendoValidator");

        var ReportDate = $("#dpReportDate").val();
        var ReportType_Id = $("#ReportType_IdAdd").val();
        var SubReportType_Id = $("#SubReportType_IdAdd").val();

        //var Interaction = $('#Interaction').is(":checked");
        //var Delivered = $('#Delivered').is(":checked");

        var ReportDescription = $("#ReportDescription").val();
        var EmployeeCommitment = $("#EmployeeCommitment").val();

        var Employee_Ident = $("#Employee_Ident_AddReport").val();
        var Manager_Ident = $("#Manager_Ident_Editor").val();
        var Program_Ident = $("#Program_Ident_Editor").val();
        var CollegeId = $("#CollegeId_Add").val();
        var dateOfEvent = $("#dpdateOfEvent").val();

        var ReasonId = $("#ReasonReport_IdAdd").val();
        var SpecificCause_Id = $("#SpecificCause_IdAdd").val();

        if (validator.validate()) {

            var URL = General.BASE_URL + '/HeadCounts/EmployeeReportData_Create';

            $.ajax({

                dataType: "json",
                type: 'POST',
                data: {
                    "Employee_Ident": Employee_Ident, "ReportDate": ReportDate, "ReportType_Id": ReportType_Id,
                    "SubReportType_Id": SubReportType_Id, "EmployeeCommitment": EmployeeCommitment,
                    "ReportDescription": ReportDescription, "Manager_Ident": Manager_Ident, "Program_Ident": Program_Ident, "CollegeId": CollegeId, "dateOfEvent": dateOfEvent,
                    "ReasonId": ReasonId, "SpecificCause_Id": SpecificCause_Id
                },
                async: false,
                url: URL,
                success: function (json) {

                    if (json.success == 1) {

                        var dialog = $("#ModalEmployeeReportAdd").data("kendoWindow").close();

                        HeadCounts.EmployeeReportDetails(Employee_Ident);

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
    },

    ModalEmployeeReportEditor: function (Employee_Id, HRreport_Id) {

        var URL = General.BASE_URL + '/HeadCounts/GetEmployeeReportEditor';

        $.ajax({

            dataType: "html",
            type: 'POST',
            data: { "Employee_Id": Employee_Id, "HRreport_Id": HRreport_Id },
            async: false,
            url: URL,
            success: function (data) {
                if (data.search("/Access/Authentication") < 0) {
                    $("#ModalEmployeeReportEditor").empty();
                    $("#ModalEmployeeReportAdd").empty();

                    $("#ModalEmployeeReportEditor").html(data);

                    $("#ModalEmployeeReportEditor").data("kendoWindow").center().open();
                } else {
                    window.location = General.BASE_URL + "/Access/Index";
                }
            },
            error: function (request, status, error) {

                General.FlashMessage('Error');

            }

        });

    },

    EmployeeReportData_Update: function () {

        var validator = $("#FormReportEdit").kendoValidator().data("kendoValidator");

        var ReportDate = $("#dpReportDate").val();
        var ReportType_Id = $("#ReportType_IdEdit").val();
        var SubReportType_Id = $("#SubReportType_IdEdit").val();

        var Interaction = $('#Interaction').is(":checked");
        var Delivered = $('#Delivered').is(":checked");

        var ReportDescription = $("#ReportDescription").val();
        var EmployeeCommitment = $("#EmployeeCommitment").val();
        var CommitmentDate = $("#dpCommitmentDate").val();
        var Acknowledgment = $("#Acknowledgment").val();
        var FutureImplications = $("#FutureImplications").val();
        var AcknowledgmentDate = $("#dpAcknowledgmentDate").val();

        var Employee_Ident = $("#Employee_Ident_EditReport").val();
        var HRreport_Id = $("#HRreport_Id_EditReport").val();
        var Manager_Ident = $("#Manager_Ident_Editor").val();
        var Program_Ident = $("#Program_Ident_Editor").val();
        var CollegeId = $("#CollegeId_Edit").val();
        var dateOfEvent = $("#dpdateOfEvent").val();

        var ReasonId = $("#ReasonReport_IdEdit").val();
        var SpecificCause_Id = $("#SpecificCause_IdEdit").val();

        if (validator.validate()) {

            var URL = General.BASE_URL + '/HeadCounts/EmployeeReportData_Update';

            $.ajax({

                dataType: "json",
                type: 'POST',
                data: {
                    "Employee_Ident": Employee_Ident, "ReportDate": ReportDate, "ReportType_Id": ReportType_Id, "HRreport_Id": HRreport_Id,
                    "SubReportType_Id": SubReportType_Id, "Interaction": Interaction, "Delivered": Delivered,
                    "EmployeeCommitment": EmployeeCommitment, "ReportDescription": ReportDescription, "Manager_Ident": Manager_Ident, "AcknowledgmentDate": AcknowledgmentDate,
                    "Program_Ident": Program_Ident, "CommitmentDate": CommitmentDate, "Acknowledgment": Acknowledgment, "FutureImplications": FutureImplications, "CollegeId": CollegeId
                    , "dateOfEvent": dateOfEvent, "ReasonId": ReasonId, "SpecificCause_Id": SpecificCause_Id
                },
                async: false,
                url: URL,
                success: function (json) {

                    if (json.success == 1) {

                        var dialog = $("#ModalEmployeeReportEditor").data("kendoWindow").close();

                        HeadCounts.EmployeeReportDetails(Employee_Ident);

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
    },

    ModalEmployeeReportPrint: function (Employee_Id, HRreport_Id) {
        var URL = General.BASE_URL + '/HeadCounts/PrintEmployeeReport';

        $.ajax({

            dataType: "html",
            type: 'POST',
            data: { "Employee_Id": Employee_Id, "HRreport_Id": HRreport_Id },
            async: false,
            url: URL,
            success: function (data) {
                if (data.search("/Access/Authentication") < 0) {
                    $("#ModalEmployeeReportPrint").empty();

                    $("#ModalEmployeeReportPrint").html(data);

                    var dialog = $("#ModalEmployeeReportPrint").data("kendoWindow").center().open();
                } else {
                    window.location = General.BASE_URL + "/Access/Index";
                }
            },
            error: function (request, status, error) {

                General.FlashMessage('Error');

            }

        });
    },

    Load_Info_Employee: function () {
        var EmployeeId = $('#txtEmployee').val();
        var queryDate = $('#queryDate').val();

        var RegExNumber = /^\d+$/;

        if (EmployeeId.length > 0 && EmployeeId.match(RegExNumber)) {
            HeadCounts.Get_Header_EmployeeDetail(EmployeeId, queryDate);
            HeadCounts.Get_Content_PTLItems(EmployeeId);
        } else {
            General.FlashMessage('Invalid input', 'red darken-3');
        }

    },

    Get_Header_EmployeeDetail: function (x, y) {
        var URL = General.BASE_URL + '/HeadCounts/GetHeaderRisksEmployee';

        $.ajax({
            dataType: 'html',
            type: 'POST',
            url: URL,
            data: { "employeeIdent": parseInt(x), "queryDate": y },
            async: false,
            success: function (data) {
                if (data.search("/Access/Authentication") < 0) {
                    $("#EmployeeDetails").html(data);
                } else {
                    window.location = General.BASE_URL + "/Access/Index";
                }
            }
        });
    },

    Get_Content_PTLItems: function (x) {
        var URL = General.BASE_URL + '/HeadCounts/GetContentRisksEmployee';

        $.ajax({
            dataType: 'html',
            type: 'POST',
            url: URL,
            data: { "Employee_Ident": parseInt(x) },
            async: false,
            success: function (data) {
                if (data.search("/Access/Authentication") < 0) {
                    $("#EmployeeRiskDetails").html(data);
                } else {
                    window.location = General.BASE_URL + "/Access/Index";
                }
            }
        });
    },

    ModalEmployeeNeutralAdd: function (Employee_Id) {

        var URL = General.BASE_URL + '/HeadCounts/GetEmployeeNeutralAdd';

        $.ajax({

            dataType: "html",
            type: 'POST',
            data: { "Employee_Id": Employee_Id },
            async: false,
            url: URL,
            success: function (data) {
                if (data.search("/Access/Authentication") < 0) {
                   
                    $("#ModalEmployeeNeutralEditor").empty();
                   
                    $("#ModalEmployeeNeutralAdd").html(data);

                    $("#ModalEmployeeNeutralAdd").data("kendoWindow").center().open();
                }
                else {
                    window.location = General.BASE_URL + "/Access/Index";
                }
            },
            error: function (request, status, error) {

                General.FlashMessage('Error');

            }

        });

    },

    ModalEmployeeSatisfiedAdd: function (Employee_Id) {

        var URL = General.BASE_URL + '/HeadCounts/GetEmployeeSatisfiedAdd';

        $.ajax({

            dataType: "html",
            type: 'POST',
            data: { "Employee_Id": Employee_Id },
            async: false,
            url: URL,
            success: function (data) {
                if (data.search("/Access/Authentication") < 0) {
                    $("#ModalEmployeeSatisfiedEditor").empty();

                    $("#ModalEmployeeSatisfiedAdd").html(data);
                    alert('si entro');
                    $("#ModalEmployeeSatisfiedAdd").data("kendoWindow").center().open();
                }
                else {
                    window.location = General.BASE_URL + "/Access/Index";
                }
            },
            error: function (request, status, error) {

                General.FlashMessage('Error');

            }

        });

    },
    
    ModalEmployeeNAAdd: function (Employee_Id) {

        var URL = General.BASE_URL + '/HeadCounts/GetEmployeeNAAdd';

        $.ajax({

            dataType: "html",
            type: 'POST',
            data: { "Employee_Id": Employee_Id },
            async: false,
            url: URL,
            success: function (data) {
                if (data.search("/Access/Authentication") < 0) {
                    $("#ModalEmployeeNAEditor").empty();
                    
                    $("#ModalEmployeeNAAdd").html(data);

                    $("#ModalEmployeeNAAdd").data("kendoWindow").center().open();
                }
                else {
                    window.location = General.BASE_URL + "/Access/Index";
                }
            },
            error: function (request, status, error) {

                General.FlashMessage('Error');

            }

        });

    },

    EmployeeData_Create: function (Param) {
       
        var forma = '#Form' + Param + "Add";
        
        var validator = $(forma).kendoValidator().data("kendoValidator");

        var RiskStatus_Id   = $("#RiskStatus_Id").val();
        var RiskDate        = $("#RiskDate").val();     
        var RiskListType_Id = $("#RiskListType_Id").val();
        var Category_Id     = $("#Category_Id").val();        
        var Barometer_Id = $("#Barometer_Id").val();  
        var Barometer = Param;
        var ReviewDate      = $("#dpReviewDate").val();
        var accionRetencion = null;
       

        if (validator.validate()) {

            var URL = General.BASE_URL + '/HeadCounts/EmployeeData_Create';

            var Employee_Ident = $("#Employee_Ident_Add").val();
            var Manager_Ident = $("#Manager_Ident_Editor").val();
            var Program_Ident = $("#Program_Ident_Editor").val();

            $.ajax({

                dataType: "json",
                type: 'POST',
                data: {
                    "Employee_Ident": Employee_Ident,
                    "RiskDate": RiskDate, 
                    "RiskListType_Id": RiskListType_Id,                   
                    "Category_Id": Category_Id,  
                    "Barometer_Id": Barometer_Id,
                    "Barometer": Barometer,
                    "Manager_Ident": Manager_Ident,
                    "Program_Ident": Program_Ident,
                    "RetentionAction": accionRetencion,                    
                },
                async: false,
                url: URL,
                success: function (json) {

                    if (json.success == 1) {                      

                        var modal = "#ModalEmployee" + Param + "Add";                       
                        var dialog = $(modal).data("kendoWindow").close();                      
                        

                        HeadCounts.EmployeeBarometersDetails(Employee_Ident,Param);

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
    },

    EmployeeBarometersDetails: function (Employee_Ident, Barometer) {

        var URL = General.BASE_URL + '/HeadCounts/GetEmployeeBarometerData';
        var details = "#gridEmployee" + Barometer + "Details";
        $.ajax({

            dataType: 'json',
            type: 'POST',
            data: { "Employee_Ident": Employee_Ident, "Barometer": Barometer },
            async: false,
            url: URL,
            success: function (json) {

                if (json.success == 1) {

                    var Data = json.oData.EmployeeRisk;

                    if (!$.isEmptyObject(Data)) {
                        $(details).kendoGrid({
                            dataSource: {
                                type: "odata",
                                data: Data,
                                schema: {
                                    model: {
                                        fields: {
                                            Employee_Ident: { type: "integer" },
                                            RiskList_Id: { type: "integer" },
                                            sRiskDate: { type: "string" },                                          
                                            RiskListType: { type: "string" },
                                            Category: { type: "string" },
                                            Barometer_Id: { type: "integer" },
                                            Barometer: { type: "string" },
                                        }
                                    }
                                },
                                pageSize: 10,
                                serverPaging: false,
                                serverSorting: false,
                                serverFiltering: false
                            },
                            height: 200,
                            filterable: true,
                            sortable: true,
                            resizable: true,
                            selectable: "row",
                            pageable: {
                                refresh: true,
                                pageSizes: true,
                                buttonCount: 5
                            },
                            columns: [{
                                field: "sRiskDate",
                                title: "Date",
                                width: 50,
                                filterable: true,
                                attributes: {
                                    style: "font-size: 11px"
                                }
                            },  {
                                field: "RiskListType",
                                title: "Attrition Type",
                                width: 150,
                                attributes: {
                                    style: "font-size: 11px"
                                }
                            }, {
                                field: "Category",
                                title: "Category",
                                width: 150,
                                attributes: {
                                    style: "font-size: 11px"
                                        }
                                },
                                {
                                    field: "Barometer_Id",
                                    title: "Barometer Id",
                                    width: 60,
                                    
                                    attributes: {
                                        style: "font-size: 11px; text-align:center " 
                                    }
                                },
                                {
                                    field: "Barometer",
                                    title: "Barometer",
                                    width: 60,
                                    attributes: {
                                        style: "font-size: 11px"
                                    }
                                },

                                {
                                field: "Employee_Ident",
                                title: "Options",
                                ////template: "<div style='width:100%; text-align:center;cursor:pointer;'>" + "#if (RiskStatus_Id == 1 || RiskStatus_Id == 4){#" + "<i class='fa fa-pencil fa-2x' style='color:green;' onclick='HeadCounts.ModalEmployeeRisksEditor(" + "#= Employee_Ident #" + "," + "#= RiskList_Id #" + ");'></i>" + "#}#" + "</div>",
                                    template: "<div style='width:100%; text-align:center;cursor:pointer;'>" + "#if (RiskList_Id == 1 || RiskList_Id == 4){#" 
                                                                                                            + "<i class='fa fa-pencil fa-2x' style='color:green;' onclick='HeadCounts.ModalEmployeeNaturalEditor("
                                                                                                            + "#= Employee_Ident #"
                                                                                                            + ","
                                                                                                            + "#= RiskList_Id #"
                                                                                                            + ");'></i>" + "#}#"
                                                                                                            + "#if (RiskList_Id==2 || RiskList_Id==3){#"
                                                                                                            + "<i class='fa fa-eye fa-2x' style='color:gray;' onclick='HeadCounts.ModalEmployeeNaturalView("
                                                                                                            + "#= Employee_Ident #"
                                                                                                            + "," + "#= RiskList_Id #"
                                                                                                            + ");'></i>" + "#}#"
                                                                                                            + "</div> ",
                                filterable: false,
                                width: 40,
                                attributes: {
                                    style: "font-size: 11px"
                                }
                            }]
                        });

                        //HeadCounts.GoOverGrid();
                    } else {
                        //$('#addRiskButton').remove();
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

}