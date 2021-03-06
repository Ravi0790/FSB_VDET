﻿var ajaxrequest = new Object();
var apiurl = new Object()


var startstoptimeArray = [];
var selectedproductinfo = null;

var lineid = "";
var plantid = "";
var userid = "";
var usertypeid = "";

/***Regex Patterns**********/

var sappatten = /^[0-9]{6,12}$/;


ajaxrequest.Type = "GET";
ajaxrequest.PData = "";
ajaxrequest.DataType = "json";




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
apiurl.verlustartsbyplant = "/services/api/verlustarts/plant/";
apiurl.wastetypesbyusertype = "/services/api/wastetypes/usertype/";
apiurl.reasonsbyverlustart = "/services/api/reasons/verlustart/";
apiurl.reasonsbyverlustartusertype = "/services/api/reasons/verlustart/usertype/";
apiurl.ordercreate = "/services/api/orderdetails/";
apiurl.wastedetail = "/services/api/wastedetails/";
apiurl.wastedetailbyorderusertype = "/services/api/wastedetails/order/usertype/";
apiurl.orderinfo = "/services/api/orderinfoes"
apiurl.orderinfobyorder = "/services/api/orderinfoes/order/"
apiurl.ordervolume = "/services/api/ordervolumes/"
apiurl.ordervolumebyorder = "/services/api/ordervolumes/order/"
apiurl.fusioncharts = "/services/api/fusioncharts/"



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

    console.log(dropdowninfo);
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

        if (dropdowninfo.isconcatetext == 1) {
            var contactinatedtext = dropdowninfo.objdata[i][dropdowninfo.dropdowntext] + "-" + dropdowninfo.objdata[i][dropdowninfo.concatetext];
            stroptions += "<option  value='" + dropdowninfo.objdata[i][dropdowninfo.dropdownval] + "'>" + contactinatedtext + "</option>";

        }
        else {
            stroptions += "<option  value='" + dropdowninfo.objdata[i][dropdowninfo.dropdownval] + "'>" + dropdowninfo.objdata[i][dropdowninfo.dropdowntext] + "</option>";
        }
    }

    //console.log(strstates);

    dropdownobj.append(stroptions);

    if (dropdowninfo.selectedval != "") {
        dropdownobj.val(dropdowninfo.selectedval)
    }
}

function SendAjaxRequest(arequest, step,isapihit,dropdowninfo,callback) {
    //alert("step" + step + "\n url=" + arequest.URL);
    //console.log("SendAjaxRequest");
    //console.log("requestobj")
    //console.log(arequest)
    //console.log(" isapihit: " + isapihit,"step-" + step,"dropdowninfo-" + dropdowninfo);

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
                    //console.log(result)

                    //$("#sptotalpremium").text($.number(result.TotalPremium, 0));
                    dropdowninfo.objdata = result;

                    if (dropdowninfo.dropdowntext.toLowerCase().indexOf("product")>-1) {
                        bakeryinfo.ProductInfo = result;
                        localStorage.setItem("bakeryinfo", JSON.stringify(bakeryinfo));
                    }

                    console.log("dropdown")
                    //console.log(result.length);

                    if (result.length > 0) {
                        $cobj = dropdowninfo.controlobj;
                        $cobj.attr("disabled", false);

                    }
                    else {
                        $cobj = dropdowninfo.controlobj;
                        $cobj.attr("disabled", true);
                    }
                    

                    FillDropDown(dropdowninfo)

                    if (callback != null) {
                        callback();
                    }

                }

                if (step == "linebyid") {

                    console.log("lineinfo");

                    bakeryinfo.LineInfo = data;
                    localStorage.setItem("bakeryinfo", JSON.stringify(bakeryinfo));

                    $("#linename").text(data.LineName);


                    //console.log("callback function")
                    //console.log(callback);

                    if (callback != null) {
                        callback();
                    }
                }

                if (step == "ordercreate") {

                    console.log("order created");

                    $("#orderid").text(data.OrderId);
                    orderid = data.OrderId;

                    CreateOrderInfo(data.OrderId)
                }

                if (step == "orderinfo") {

                    console.log("orderinfo created");
                    
                    bootbox.alert({

                        title: "Auftragserstellung",
                        message: "Ihre Auftragsnummer : " + data.OrderId,
                        callback: function () {
                            ShowVolumes();
                        }
                    })


                    
                    
                }


                if (step == "getorderinfo") {

                    console.log("getorderinfo")
                    console.log(data)
                    SetOrderValues(data)
                    

                }

                if (step == "wastecreate") {

                    console.log("wastedetails");

                    wastestartstopArry = [];
                    machinestartstopArry = [];
                    
                    $("#chkprodstatus").prop("checked", false);
                     ShowWasteInfo(data)
                }

                if (step == "getwastesbyorderusertype") {

                    console.log("getwastesbyorderusertype");
                    
                    ShowWasteInfoAll(data)
                }

                if (step == "orderclose") {

                    console.log("orderclose")

                    ajaxrequest.Type = "GET";
                    ajaxrequest.URL = "packaging/bakerystop/" + orderid;
                    SendAjaxRequest(ajaxrequest, "alertpackaging", true);

                    $("#closemsg").html("Your order " + orderid + " has been closed");
                    $("#bakeryclose").modal({ backdrop: "static" });
                    //bootbox.alert("Your order " + orderid+" has been closed", function () {
                    //    location.href = "login/logout"
                    //});
                    
                }

                if (step == "ordervolcreate") {
                    console.log("ordervolcreate")
                    //console.log(data)
                }

                if (step == "getordervolume") {
                    console.log("getordervolume");

                    console.log(data)

                    ShowVolumesAfterPending(data)
                }

                if (step == "updatevolume") {
                    console.log("updatevolume");

                    //console.log(data)
                    ajaxrequest.Type = "GET";
                    ajaxrequest.URL = "bakery/packaging/" + orderid;
                    SendAjaxRequest(ajaxrequest, "hitbakery", true);
                }

                if (step == "getorderstatus") {
                    console.log("getorderstatus");
                    console.log(data)

                    $("#bakerystoptime").val(data.OrderEndTime);



                    callback(data.OrderInfos, 1, SetOrderTime);//check bakery status;
                }

                if (step == "hitbakery") {

                    console.log("volumedata sent to bakery page")
                }

                if (step == "alertpackaging") {

                    console.log("packaging alerted for bakery time stop")
                }


                if (step == "porderclose") {

                    console.log("porderclose")
                    //location.href = "login/logout"
                    callback();
                    
                    //bootbox.alert("Your order has been closed", function () {
                    //    location.href = "login/logout"
                    //});

                }

                if (step == "graph1") {
                    console.log("graph data")
                    console.log(data)
                    var chartConfigs = data;

                    $("#chart-container").insertFusionCharts(chartConfigs);
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





function GetTimeInfo(timetype) {
    return startstoptimeArray.filter(x => x.Type == timetype);
}


function formatDateTime(gdate) {
    var monthAry = ["Jan", "Feb", "Mar", "April", "May", "Jun", "July", "Aug", "Sep", "Oct", "Nov", "Dec"];

    var cdate = new Date(gdate);

    var gyear = cdate.getFullYear();
    var gmonth = cdate.getMonth();
    var gdate = cdate.getDate();
    var ghour = cdate.getHours();
    var gmin = cdate.getMinutes();

    gdate = String(gdate).length <= 1 ? "0" + gdate : gdate;

    var formatedtime = (String(ghour).length <= 1 ? "0" + ghour : ghour) + ":" + (String(gmin).length <= 1 ? "0" + gmin : gmin);
    var formatedate = gdate + " " + monthAry[gmonth] + " " + gyear + "<br>" + formatedtime;

    return formatedate
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

function InitiateTime(timetype, timeindex, iszerohour) {

    var d = new Date();
    var hour = d.getHours()
    var min = d.getMinutes();
    var year = d.getFullYear();
    var month = d.getMonth();
    var rightmonth = parseInt(month) + 1;
    var date = d.getDate();

    hour = iszerohour == true ? 0 : hour;
    min = iszerohour == true ? 0 : min;

    var datetime = new Date(year, month, date, hour, min);

    var datetimeformat = rightmonth + "/" + date + "/" + year + " " + hour + ":" + min;

    var timedisplay = (String(hour).length <= 1 ? "0" + hour : hour) + ":" + (String(min).length <= 1 ? "0" + min : min);

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

function InitiateTimeByHourMin(hourmin) {

    var d = new Date();
    var hour = hourmin.split(':')[0];
    var min = hourmin.split(':')[1];
    var year = d.getFullYear();
    var month = d.getMonth();
    var rightmonth = parseInt(month) + 1;
    var date = d.getDate();    

    var datetime = new Date(year, month, date, hour, min);

    var datetimeformat = rightmonth + "/" + date + "/" + year + " " + hour + ":" + min;

    var timedisplay = (String(hour).length <= 1 ? "0" + hour : hour) + ":" + (String(min).length <= 1 ? "0" + min : min);

    var timeobj = new Object();

    timeobj.Hour = hour;
    timeobj.Minute = min;
    timeobj.Year = year;
    timeobj.Month = rightmonth;
    timeobj.Date = date;
    timeobj.DateTime = datetime;
    timeobj.DateTimeFormat = datetimeformat;
    timeobj.TimeDisplay = timedisplay;
    //timeobj.Type = timetype;
    //timeobj.TimeIndex = timeindex

    //startstoptimeArray.push(timeobj);

    //callback();
    //timeobject.val(starttimedisplay);
    return timeobj;
}


function isNullOrEmpty(s) {
    return (s == null || s === "");
}

function CheckZero(obj) {
    var objcontrol = $(obj);

    
    objcontrol.val(objcontrol.val() == "0" ? "" : objcontrol.val())
    
}


function CheckEmpty(obj) {
    var objcontrol = $(obj);


    objcontrol.val(objcontrol.val() == "" ? "0" : objcontrol.val())

}


function EnableMachine() {
    $("#machinestop").attr("disabled", false);
    $("#btnmachinestop").attr("disabled", false);


    $("#machinestart").attr("disabled", false);
    $("#btnmachinestart").attr("disabled", false);
}

function ShowGraphProduction() {
    var pdate = $("#pdate").val();
    ajaxrequest.URL = apiurl.fusioncharts + "dailyproduction?cdate=" + pdate + "&lineid=" + lineid + "";
    SendAjaxRequest(ajaxrequest, "graph1", hitapi.order);
}

$(document).ajaxStart(function () {
    $(".fixedLoaderWrap").show()
});

$(document).ajaxComplete(function () {
    $(".fixedLoaderWrap").hide()
});


