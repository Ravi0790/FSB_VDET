var apiurl = new Object()
apiurl.companiesbycountry = "/services/api/companies/country/";
apiurl.plantsbycompany = "/services/api/plants/company/";
apiurl.shiftsbyplant = "/services/api/shifts/plant/";
apiurl.linesbyplant = "/services/api/lines/plant/";
apiurl.usertypesbyplant = "/services/api/usertypes/plant/";
apiurl.usersbyusertype = "/services/api/users/usertype/";
apiurl.productsbyusertype = "/services/api/products/usertype/";
apiurl.productsbyline = "/services/api/products/line/";
apiurl.locationsbylineusertype = "/services/api/locations/line/usertype/";
apiurl.machinesbylocation = "/services/api/machines/location/";
apiurl.modulesbymachine = "/services/api/modules/machine/";
apiurl.componentsbymodule = "/services/api/components/module/";
apiurl.partsbycomponent = "/services/api/parts/component/";
apiurl.verlustsbyusertype = "/services/api/verlusts/usertype/";
apiurl.verlustartsbyusertype = "/services/api/verlustarts/usertype/";
apiurl.wastetypesbyusertype = "/services/api/wastetypes/usertype/";
apiurl.reasonsbyverlustart = "/services/api/reasons/verlustart/";

var ajaxrequest = new Object();
ajaxrequest.Type = "GET";
ajaxrequest.PData = "";
ajaxrequest.DataType = "json";

var hitapi = new Object()

hitapi.country = true;
hitapi.company = true;
hitapi.plants = true;
hitapi.shifts = true;
hitapi.lines = true;
hitapi.usertype = true;
hitapi.user = true;
hitapi.product = true;
hitapi.location = true;
hitapi.machine = true;
hitapi.module = true;
hitapi.component = true;
hitapi.part = true;
hitapi.verlustart = true;
hitapi.verlust = true;
hitapi.wastetype = true;
hitapi.reason = true;

var urlpathname = location.pathname;

function FillDropDown(controlobj, objdata, dropdowntext, dropdownval, dropdownname, selectedval) {
    //alert("hello state")
    //console.log(stateobj)
    //console.log(statedata)
    //var mstatedata = statedata;
    controlobj.empty();
    var stroptions = "";
    stroptions += "<option>--Select " + dropdownname+"--</option>";
    for (var i = 0; i < objdata.length; i++) {
        stroptions += "<option  value='" + objdata[i][dropdownval] + "'>" + objdata[i][dropdowntext] + "</option>";
    }

    //console.log(strstates);

    controlobj.append(stroptions);

    if (selectedval != "") {
        controlobj.val(selectedval)
    }
}

function SendAjaxRequest(arequest, step,controlobj,controltext,controlval,controlname,defaultvalue,isapihit) {
    //alert("step" + step + "\n url=" + arequest.URL);
    //console.log("SendAjaxRequest");
    console.log("Request: " + arequest + " isapihit: " + isapihit);

    var gtype = arequest.Type;
    var gurl = arequest.URL;
    var gdata = arequest.PData;
    var gdataType = arequest.DataType;

    crequest = arequest.PData;

    var obj = {
        type: gtype,
        url: gurl,
        data: gdata,
        dataType: gdataType,
        //contentType: 'application/json; charset=utf-8',
        crossDomain: true,
        success: function (data, status) {

            if (data != null) {

                if (step == "dropdownfill") {
                    result = data;
                    console.log(result)

                    //$("#sptotalpremium").text($.number(result.TotalPremium, 0));

                    FillDropDown(controlobj, result, controltext, controlval, controlname,defaultvalue)

                }


            }
        },
        error: function (jqXHR, err, status) {

            if (step == "dropdownfill") {
                console.log("failure");
                console.log(err);
                console.log(status);
            }


        }

    };

    if (arequest.hasOwnProperty('contentType')) {
        obj.contentType = arequest.contentType;
        delete obj.dataType;
    }

    if (isapihit) {
        $.ajax(obj);
    }

}


