var HRReportPrinting = {

    Update: function (Id) {
        if (Id) {

            var URL = General.BASE_URL + '/ExportReports/PrintigUpdate';

            $.ajax({

                dataType: "json",
                type: 'POST',
                data: {
                    "HRReportId": Id
                },
                async: false,
                url: URL,
                success: function (json) {

                    if (json.success == 1) {

                        toast('Se ha realizado la exportación.', 5000, 'green white-text');

                    } else if (json.failure == 1) {

                        toast('Ha ocurrido un problema.', 5000, 'red white-text');

                    } else if (json.noLogin == 1) {

                        window.location = General.BASE_URL + "/Access/Index";

                    }

                },
                error: function (request, status, error) {

                    toast('Error', 5000, 'red white-text');

                }

            });
        }
    }
}