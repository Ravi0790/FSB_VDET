var apiurl = new Object()
var linebyid = "";
apiurl.companiesbycountry = "/services/api/companies/country/";
apiurl.plantsbycompany = "/services/api/plants/company/";
apiurl.shiftsbyplant = "/services/api/shifts/plant/";
apiurl.linesbyplant = "/services/api/lines/plant/";
apiurl.lines = "/services/api/lines/";
apiurl.usertypesbyplant = "/services/api/usertypes/plant/";
apiurl.usersbyusertype = "/services/api/users/usertype/";
apiurl.productsbyusertype = "/services/api/products/usertype/";
apiurl.productsbyline = "/services/api/products/line/";

apiurl.productsbylineusertype = "/services/api/products/line/usertype/";
apiurl.locationsbylineusertype = "/services/api/locations/line/usertype/";
apiurl.machinesbylocation = "/services/api/machines/location/";
apiurl.modulesbymachine = "/services/api/modules/machine/";
apiurl.componentsbymodule = "/services/api/components/module/";
apiurl.partsbycomponent = "/services/api/parts/component/";
apiurl.verlustsbyusertype = "/services/api/verlusts/usertype/";
apiurl.verlustartsbyusertype = "/services/api/verlustarts/usertype/";
apiurl.wastetypesbyusertype = "/services/api/wastetypes/usertype/";
apiurl.reasonsbyverlustart = "/services/api/reasons/verlustart/";
apiurl.ordercreate = "/services/api/OrderDetails";

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
hitapi.order = true;

var urlpathname = location.pathname;

var bakeryinfo = new Object();


function FillDropDown(dropdowninfo) {
    //alert("hello state")
    //console.log(stateobj)
    //console.log(statedata)
    //var mstatedata = statedata;
    var dropdownobj = dropdowninfo.controlobj;
    dropdownobj.empty();
    var stroptions = "";
    stroptions += "<option value='0'>--Select " + dropdowninfo.dropdownname+"--</option>";
    for (var i = 0; i < dropdowninfo.objdata.length; i++) {
        stroptions += "<option  value='" + dropdowninfo.objdata[i][dropdowninfo.dropdownval] + "'>" + dropdowninfo.objdata[i][dropdowninfo.dropdowntext] + "</option>";
    }

    //console.log(strstates);

    dropdownobj.append(stroptions);

    if (dropdowninfo.selectedval != "") {
        dropdownobj.val(dropdowninfo.selectedval)
    }
}

function SendAjaxRequest(arequest, step,isapihit,dropdowninfo) {
    //alert("step" + step + "\n url=" + arequest.URL);
    //console.log("SendAjaxRequest");
    console.log("Request: " + arequest, " isapihit: " + isapihit,"dropdowninfo" + dropdowninfo);

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
                    dropdowninfo.objdata = result;

                    if (dropdowninfo.dropdownname.toLowerCase() == "product") {
                        bakeryinfo.ProductInfo = result;
                        localStorage.setItem("bakeryinfo", JSON.stringify(bakeryinfo));
                    }

                    FillDropDown(dropdowninfo)

                }

                if (step == "linebyid") {

                    console.log("lineinfo");
                    console.log(data);


                    bakeryinfo.LineInfo = data;
                    localStorage.setItem("bakeryinfo", JSON.stringify(bakeryinfo));


                    if (urlpathname.toLowerCase().indexOf("bakery") > -1) {
                        $("#spline").text(data.LineName);
                        $("#plantid").val(data.Plant.PlantId);
                    }
                }

                if (step == "ordercreate") {

                    console.log("orderdetail");
                    console.log(data);

                    $("#orderid").text(data.OrderId);

                    
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


