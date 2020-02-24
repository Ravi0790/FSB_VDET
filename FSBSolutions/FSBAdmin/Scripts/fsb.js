var plantusertypeArray = ["users", "products", "locations", "lines", "machines", "modules", "components", "parts", "verlusts", "verlustarts", "wastetypes", "wastecategories", "users","reasons"]
var plantlineArray = ["products", "locations", "lines", "machines", "modules", "components", "parts"]
var lineusertypeArray = ["locations", "lines", "machines", "modules", "components", "parts"]


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
        for (var i = 0; i < plantusertypeArray.length; i++) {

            var controlaction = plantusertypeArray[i].toLowerCase() + "/create";

            console.log("controlaction",controlaction)

            if (urlpathname.toLowerCase().indexOf(controlaction) > -1) {
                ajaxrequest.URL = apiurl.usertypesbyplant + plantid;
                SendAjaxRequest(ajaxrequest, "dropdownfill", $("#usertypeid"), "UserTypeName", "UserTypeId", "User Type", "", hitapi.plants);
            }
        }


        for (var i = 0; i < plantlineArray.length; i++) {

            var controlaction = plantlineArray[i].toLowerCase() + "/create";

            console.log("controlaction", controlaction)

            if (urlpathname.toLowerCase().indexOf(controlaction) > -1) {
                ajaxrequest.URL = apiurl.linesbyplant + plantid;
                SendAjaxRequest(ajaxrequest, "dropdownfill", $("#lineid"), "LineName", "LineId", "Line", "", hitapi.plants);
            }
        }
    });

    $("#lineid,#usertypeid").change(function () {
        var lineid = $(this).val();
        var usertypeid = $("#usertypeid").val();

        console.log("hi line")
        for (var i = 0; i < lineusertypeArray.length; i++) {
            var controlaction = lineusertypeArray[i].toLowerCase() + "/create";
            console.log("controlaction", controlaction)

            if (controlaction.indexOf("modules") > -1) {
                $("#machineid").empty();
                $("#machineid").append("<option>--Select Machine--</option>");
            }

            if (controlaction.indexOf("components") > -1) {
                $("#moduleid").empty();
                $("#moduleid").append("<option>--Select Module--</option>");
            }

            if (controlaction.indexOf("parts") > -1) {
                $("#componentid").empty();
                $("#componentid").append("<option>--Select Component--</option>");
            }
            
            if (urlpathname.toLowerCase().indexOf(controlaction) > -1) {
                ajaxrequest.URL = apiurl.locationsbylineusertype + lineid + "/" + usertypeid;
                SendAjaxRequest(ajaxrequest, "dropdownfill", $("#locationid"), "LocationName", "LocationId", "Location", "", hitapi.location);
            }
        }


        if (urlpathname.toLowerCase().indexOf("reasons/create") > -1) {
            ajaxrequest.URL = apiurl.verlustartsbyusertype + usertypeid;
            SendAjaxRequest(ajaxrequest, "dropdownfill", $("#verlustartid"), "VerlustartName", "VerlustartId", "Verlustart", "", hitapi.usertype);
        }

    })

    $("#lineid,#usertypeid").change(function () {
        var lineid = $(this).val();
        


        if (urlpathname.toLowerCase().indexOf("reasons/create") > -1) {
            ajaxrequest.URL = apiurl.verlustartsbyusertype + usertypeid;
            SendAjaxRequest(ajaxrequest, "dropdownfill", $("#verlustartid"), "VerlustartName", "VerlustartId", "Verlustart", "", hitapi.usertype);
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
        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#machineid"), "MachineName", "MachineId", "Machine", "", hitapi.machine);
    })

    $("#machineid").change(function () {
        var machineid = $(this).val();
        ajaxrequest.URL = apiurl.modulesbymachine + machineid;
        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#moduleid"), "ModuleName", "ModuleId", "Module", "", hitapi.module);
    })

    $("#moduleid").change(function () {
        var modleid = $(this).val();
        ajaxrequest.URL = apiurl.componentsbymodule + modleid;
        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#componentid"), "ComponentName", "ComponentId", "Component", "", hitapi.component);
    })

    $("#componentid").change(function () {
        var componentid = $(this).val();
        ajaxrequest.URL = apiurl.partsbycomponent + componentid;
        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#partid"), "PartName", "PartId", "Part", "", hitapi.part);
    })

    $("#verlustartid").change(function () {
        var verlustartid = $(this).val();
        ajaxrequest.URL = apiurl.reasonsbyverlustart + verlustartid;
        SendAjaxRequest(ajaxrequest, "dropdownfill", $("#reasonid"), "ReasonName", "ReasonId", "Reason", "", hitapi.component);
    })

    

})