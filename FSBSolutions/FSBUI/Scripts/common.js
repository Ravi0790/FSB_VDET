var ajaxrequest = new Object();

ajaxrequest.Type = "GET";
ajaxrequest.PData = "";
ajaxrequest.DataType = "json";

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
apiurl.ordercreate = "/services/api/OrderDetails/";
apiurl.wastedetail = "/services/api/WasteDetails/";
apiurl.orderinfo ="/services/api/OrderInfoes"



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
hitapi.waste = true;

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
    if (dropdowninfo.dropdownname == "") {
        stroptions += "<option value=''>--Auswahlen--</option>";
    }
    else {
        stroptions += "<option value=''>--Auswahlen " + dropdowninfo.dropdownname + "--</option>";
    }
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
                        //$("#plantid").val(data.Plant.PlantId);
                    }
                }

                if (step == "ordercreate") {

                    console.log("orderdetail");
                    console.log(data);

                    

                    $("#orderid").text(data.OrderId);


                    CreateOrderInfo(data.OrderId)
                }

                if (step == "orderinfo") {

                    console.log("orderinfo created");
                    console.log(data);

                    bootbox.alert({

                        title: "Auftragserstellung",
                        message: "Ihre Auftragsnummer : " + data.OrderId
                    })
                    
                }


                if (step == "getorderinfo") {

                    console.log("getorderinfo")

                    console.log(data)

                    SetOrderValues(data)

                    

                }

                if (step == "wastecreate") {

                    console.log("wastedetails");
                    console.log(data);



                    //$("#orderid").text(data.OrderId);


                    ShowWasteInfo(data)
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


var startstoptimeArray = [];
var selectedproductinfo = null;

var lineid = "";
var plantid = "";
var userid = "";
var usertypeid = "";


function GetTimeInfo(timetype) {
    return startstoptimeArray.filter(x => x.Type == timetype);
}

function GetTimeDuration(startime, endtime) {

    //console.log("starttime", startime)
    //console.log("endtime", endtime)
    var timeDiff = Math.abs(startime - endtime);

    var hh = Math.floor(timeDiff / 1000 / 60 / 60);
    if (hh < 10) {
        hh = '0' + hh;
    }
    timeDiff -= hh * 1000 * 60 * 60;
    var mm = Math.floor(timeDiff / 1000 / 60);
    if (mm < 10) {
        mm = '0' + mm;
    }
    timeDiff -= mm * 1000 * 60;
    var ss = Math.floor(timeDiff / 1000);
    if (ss < 10) {
        ss = '0' + ss;
    }

    var durationinmin = parseInt(hh) * 60 + parseInt(mm);

    return hh + ":" + mm + "|" + durationinmin;
    //console.log("Time Diff- " + hh + ":" + mm + ":" + ss);
}


function GetCurrentTime() {
    var d = new Date();
    var hour = d.getHours()
    var min = d.getMinutes();
    var year = d.getFullYear();
    var month = d.getMonth();
    var rightmonth = parseInt(month) + 1;
    var date = d.getDate();

    //var datetime = new Date(year, month, date, hour, min);

    var datetimeformat = rightmonth + "/" + date + "/" + year + " " + hour + ":" + min;

    return datetimeformat;
}

function InitiateTime(timetype, timeindex) {

    var d = new Date();
    var hour = d.getHours()
    var min = d.getMinutes();
    var year = d.getFullYear();
    var month = d.getMonth();
    var rightmonth = parseInt(month) + 1;
    var date = d.getDate();

    var datetime = new Date(year, month, date, hour, min);

    var datetimeformat = rightmonth + "/" + date + "/" + year + " " + hour + ":" + min;

    var timedisplay = hour + ":" + min;

    var timeobj = new Object();

    timeobj.Hour = hour;
    timeobj.Minute = min;
    timeobj.Year = year;
    timeobj.Month = rightmonth;
    timeobj.Date = date;
    timeobj.DateTime = datetime;
    timeobj.DateTimeFormat = datetimeformat;
    timeobj.TimeDisplay = timedisplay;
    timeobj.Type = timetype;
    timeobj.TimeIndex = timeindex

    //startstoptimeArray.push(timeobj);

    //callback();
    //timeobject.val(starttimedisplay);
    return timeobj;
}


function isNullOrEmpty(s) {
    return (s == null || s === "");
}


