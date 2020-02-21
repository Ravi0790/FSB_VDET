var usertypeArray = ["users", "verlusts", "verlustarts", "wastetypes", "wastecategories", "users", "products"]
var lineArray = ["products", "locations", "lines", "machines", "modules", "components", "parts"]


$(document).ready(function () {


    $("#countryid").change(function () {
        var countryid = $(this).val();
        ajaxrequest.URL = apiurl.companiesbycountry + countryid;
        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#companyid"), "CompanyName", "CompanyId", "Company", "", hitapi.country);
    })

    $("#companyid").change(function () {
        var companyid = $(this).val();
        ajaxrequest.URL = apiurl.plantsbycompany + companyid;
        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#plantid"), "PlantName", "PlantId", "Plant", "",hitapi.company);
    })

    //$("#plantid").change(function () {
    //    var plantid = $(this).val();

    //    if (urlpathname.toLowerCase().indexOf("line/create")>-1) {
    //        ajaxrequest.URL = apiurl.linesbyplant + plantid;
    //        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#lineid"), "LineName", "LineId", "Line", "", hitapi.plant);
    //    }
    //    if (urlpathname.toLowerCase().indexOf("shifts/create")>-1) {
    //        ajaxrequest.URL = apiurl.shiftsbyplant + plantid;
    //        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#shiftid"), "ShiftName", "ShiftId", "Shift", "", hitapi.plant);
    //    }
    //    if (urlpathname.toLowerCase().indexOf("usertypes/create")>-1) {
    //        ajaxrequest.URL = apiurl.usertypesbyplant + plantid;
    //        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#usertypeid"), "UserTypeName", "UserTypeId", "User Type", "", hitapi.plant);
    //    }
    //})

    //$("#lineid").change(function () {
    //    var lineid = $(this).val();

    //    if (urlpathname.toLowerCase().indexOf("products/create") > -1) {
    //        ajaxrequest.URL = apiurl.productsbyline + lineid;
    //        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#productid"), "ProductName", "ProductId", "Product", "", hitapi.line);
    //    }
    //    if (urlpathname.toLowerCase().indexOf("locations/create") > -1) {
    //        ajaxrequest.URL = apiurl.locationsbyline + lineid;
    //        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#locationid"), "LocationName", "LocationId", "Location", "", hitapi.line);
    //    }
        
    //})


    $("#plantid").change(function () {
        var plantid = $(this).val();
        console.log("hi plant")
        for (var i = 0; i < usertypeArray.length; i++) {

            var controlaction = usertypeArray[i] + "/create";

            console.log("controlaction",controlaction)

            if (urlpathname.toLowerCase().indexOf(controlaction) > -1) {
                ajaxrequest.URL = apiurl.usertypesbyplant + plantid;
                SendAjaxRequest(ajaxrequest, "dropdownfill", $("#usertypeid"), "UserTypeName", "UserTypeId", "User Type", "", hitapi.plants);
            }
        }


        for (var i = 0; i < lineArray.length; i++) {

            var controlaction = lineArray[i] + "/create";

            if (urlpathname.toLowerCase().indexOf(controlaction) > -1) {
                ajaxrequest.URL = apiurl.linesbyplant + plantid;
                SendAjaxRequest(ajaxrequest, "dropdownfill", $("#lineid"), "LineName", "LineId", "Line", "", hitapi.plants);
            }
        }
    });

    $("#lineid").change(function () {
        var lineid = $(this).val();

       
        if (urlpathname.toLowerCase().indexOf("locations/create") > -1) {
            ajaxrequest.URL = apiurl.locationsbyline + lineid;
            SendAjaxRequest(ajaxrequest, "dropdownfill", $("#locationid"), "LocationName", "LocationId", "Location", "", hitapi.line);
        }

    })


    //$("#usertypeid").change(function () {
    //    var usertypeid = $(this).val();

    //    if (urlpathname.toLowerCase().indexOf("users/create") > -1) {
    //        ajaxrequest.URL = apiurl.usersbyusertype + usertypeid;
    //        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#userid"), "UserName", "UserId", "User Name", "", hitapi.usertype);
    //    }
    //    if (urlpathname.toLowerCase().indexOf("products/create") > -1) {
    //        ajaxrequest.URL = apiurl.productsbyusertype + usertypeid;
    //        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#productid"), "ProductName", "ProductId", "Product", "", hitapi.usertype);
    //    }

    //    if (urlpathname.toLowerCase().indexOf("verlusts/create") > -1) {
    //        ajaxrequest.URL = apiurl.verlustsbyusertype + usertypeid;
    //        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#verlustid"), "VerlustName", "VerlustId", "Verlust", "", hitapi.usertype);
    //    }

    //    if (urlpathname.toLowerCase().indexOf("verlustarts/create") > -1) {
    //        ajaxrequest.URL = apiurl.verlustartsbyusertype + usertypeid;
    //        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#verlustartid"), "VerlustartName", "VerlustartId", "Verlustart", "", hitapi.usertype);
    //    }

    //    if (urlpathname.toLowerCase().indexOf("wastetypes/create") > -1) {
    //        ajaxrequest.URL = apiurl.wastetypesbyusertype + usertypeid;
    //        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#wastetypeid"), "WasteTypeName", "WasteTypeId", "WasteType", "", hitapi.usertype);
    //    }

    //})

    $("#locationid").change(function () {
        var locationid = $(this).val();
        ajaxrequest.URL = apiurl.machinesbylocation + locationid;
        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#machineid"), "MachineName", "MachineId", "Machine", "", hitapi.location);
    })

    $("#machineid").change(function () {
        var machineid = $(this).val();
        ajaxrequest.URL = apiurl.modulesbymachine + machineid;
        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#moduleid"), "ModuleName", "ModuleId", "Module", "", hitapi.machine);
    })

    $("#moduleid").change(function () {
        var modleid = $(this).val();
        ajaxrequest.URL = apiurl.componentsbymodule + modleid;
        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#componentid"), "ComponentName", "ComponentId", "Component", "", hitapi.module);
    })

    $("#componentid").change(function () {
        var componentid = $(this).val();
        ajaxrequest.URL = apiurl.partsbycomponent + componentid;
        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#partid"), "PartName", "PartId", "Part", "", hitapi.component);
    })

    $("#verlustartid").change(function () {
        var verlustartid = $(this).val();
        ajaxrequest.URL = apiurl.reasonsbyverlustart + verlustartid;
        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#reasonid"), "ReasonName", "ReasonId", "Reason", "", hitapi.component);
    })

    

})