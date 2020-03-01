var startstoptimeArray = [];

var starthour = "";
var selectedproductinfo = null;


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

function InitiateTime(timetype,timeindex) {

    var d = new Date();
    var hour = d.getHours()
    var min = d.getMinutes();
    var year = d.getFullYear();
    var month = d.getMonth();
    var rightmonth = parseInt(month) + 1;
    var date = d.getDate();

    var datetime = new Date(year, month, date, hour, min);

    var datetimeformat =rightmonth + "/" + date + "/" + year + " " + hour + ":" + min;

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




function CheckProdTime() {

    var endtimeinfo = InitiateTime("prodend",0)
    var starttimeinfo = GetTimeInfo("prodstart");
    
    var strtimeduration=GetTimeDuration(starttimeinfo[0].DateTime, endtimeinfo.DateTime);


    $("#prodendtime").text(endtimeinfo.TimeDisplay);

    var timeduration = strtimeduration.split('|')[0];
    var timedurationmin = strtimeduration.split('|')[1];

    $("#prodduration").text(timeduration);
    
    $("#proddurationmin").text("(" + timedurationmin + " mins)")

    var cutpermin = selectedproductinfo[0].CutPerMinute;
    var pockets = selectedproductinfo[0].ProductPocket;

    var plannedquantity = parseInt(timedurationmin) * parseInt(cutpermin) * parseInt(pockets);
    $("#plannedquantity").text(plannedquantity);

}

function ValidateOrder() {
    var product = $("#product");
    var sapnumber = $("#sapnumber");
    var empperm = $("#empperm");
    var emptemp = $("#emptemp")
    var empexternal = $("#empexternal")

    if (product.val() == "0") {
        //toastr.error("Please select Product");
        bootbox.alert("Bitte Produkt auswählen")
        product.focus();
        return false;
    }

    if (sapnumber.val() == "") {
        //toastr.error("Please enter SAP Number");
        bootbox.alert("Bitte geben Sie die SAP-Referenznummer ein")
        sapnumber.focus();
        return false;
    }


    if (empperm.val() == "" || emptemp.val() == "" || empexternal.val() == "") {
        bootbox.alert("Bitte geben Sie die Anzahl der Mitarbeiter ein")
        empperm.focus();
        return false;
    }

    return true;

}


function ShowVolumes() {
    var strvoltr = "";

    var timeinfo = startstoptimeArray.filter(x => x.Type == "prodstart");
    var currenthour = parseInt(timeinfo[0].Hour);

    //var i = 1;
    for (var i = 1; i <= 8; i++) {



        var nexthour = currenthour + i;

        //currenthour = nexthour == 24 ? 0 : currenthour;

        nexthour = nexthour > 24 ? nexthour - 24 : nexthour;

        //console.log("nexthour",nexthour)
        //console.log("currenthour", currenthour);
        strvoltr += "<tr>"
        strvoltr += "<td class='text-left font-weight-bold pl-4' > " + nexthour + ": 00</td>"
        strvoltr += "<td class='text-right'>-</td> "
        strvoltr += "<td class='text-right'>-</td> "
        strvoltr += "<td class='text-right pr-4'>-</td> "
        strvoltr += "</tr>"

        //i++;
    }

    $("#tblvolume > tbody").empty();

    $("#tblvolume > tbody").append(strvoltr);
}

function CreateOrder() {
    var orderrequest = new Object();
    var userid = $("#userid").val();
    var usertypeid = $("#usertypeid").val();
    var lineid = $("#lineid").val();
    var productid = $("#product").val();
    //var orderstartime = $("#prodstarttime").val();
    var plannedquantity = 0;
    var saprefnumber = $("#sapnumber").val();
    var createddate = $("#prodstarttime").val();

    var timeinfo = startstoptimeArray.filter(x => x.Type == "prodstart");



    orderrequest.SAPReferenceNumber = saprefnumber;
    orderrequest.UserTypeId = usertypeid;
    orderrequest.UserId = userid;
    orderrequest.ShiftId = 1;
    orderrequest.LineId = lineid;
    orderrequest.ProductId = productid;
    orderrequest.OrderStartTime = timeinfo[0].DateTimeFormat;
    orderrequest.PlannedQuantity = 0;
    orderrequest.PremanentEmp = 0;
    orderrequest.TemporaryEmp = 0;
    orderrequest.ExternalEmp = 0;
    orderrequest.CreatedDate = timeinfo[0].DateTimeFormat;

    console.log("orderrequest")
    console.log(orderrequest)

    ajaxrequest.URL = apiurl.ordercreate;
    ajaxrequest.Type = "POST";
    ajaxrequest.PData = orderrequest;

    SendAjaxRequest(ajaxrequest, "ordercreate", hitapi.order);

}




$(document).ready(function () {

        $(document).ajaxStart(function () {
            $(".fixedLoaderWrap").show()
        });

        $(document).ajaxComplete(function () {
            $(".fixedLoaderWrap").hide()
        });




    /************Get Lines by LineID -- Start */
    var lineid = $("#lineid").val();
    var usertypeid = $("#usertypeid").val();
    ajaxrequest.URL = apiurl.lines + lineid;
    SendAjaxRequest(ajaxrequest, "linebyid", hitapi.lines);

    /************Get Lines by LineID -- End */


    /************Get Products by Line and UserType -- Start */
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#product");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "ProductName";
    dropdowninfo.dropdownval = "ProductId";
    dropdowninfo.dropdownname = "Product";
    dropdowninfo.selectedval = "";

    ajaxrequest.URL = apiurl.productsbylineusertype + lineid + "/" + usertypeid;

    SendAjaxRequest(ajaxrequest, "dropdownfill", hitapi.lines, dropdowninfo);

    /************Get Products by Line and UserType -- End */


    //Calling product change event

    $("#product").change(function () { 
        var bakerydetail = JSON.parse(localStorage.getItem("bakeryinfo"));
        var productid = $(this).val();

        //var productinfo = bakerydetail.ProductInfo.filter(function (product) {
        //    return product.ProductId == productid;
        //});

        selectedproductinfo = bakerydetail.ProductInfo.filter((product) => product.ProductId == productid);

        console.log(selectedproductinfo);

        $("#proddesc").text(selectedproductinfo[0].ProductDesc);
        $("#doughtweight").text(selectedproductinfo[0].ProductPocket);

        $("#bunweight").text(selectedproductinfo[0].BunWeight);

        

        $("#cutperminute").text(selectedproductinfo[0].CutPerMinute);

        
    })    
    
    //Calling starttime event

    $("#btnstart").click(function () {

        var ordervalid = ValidateOrder(); //Validate Order Fields

        if (ordervalid) {            
            
            
            var timeinfo = InitiateTime("prodstart",0)


            $("#prodstarttime").text(timeinfo.TimeDisplay);
            $("#prodendtime").text(timeinfo.TimeDisplay);
            $("#prodduration").text("00:00");
            $("#proddurationmin").text("(0 mins)")

            startstoptimeArray.push(timeinfo);
            
            $(this).addClass("btn-disabled");
            $(this).attr("disabled", true);

            $("#btnend").removeClass("btn-disabled");        
            $("#btnend").attr("disabled", false);
            
            
            
            $("#product").attr("disabled", true);
            $("#sapnumber").attr("disabled", true);

            setInterval(CheckProdTime, 5000);

            ShowVolumes();
            CreateOrder();
        }
    })

    //Calling Product Status event

    $("#chkprodstatus").click(function () {

        console.log("prodstatus clicked")
        console.log($(this).prop("checked"))

        if ($(this).prop("checked")) {//if prodstatus checked then disable all fields

            $("#dvverlust").find(".form-control").attr("disabled", true);

        }
        else {
            $("#dvverlust").find(".form-control").attr("disabled", false);
        }
    })

    $("#btnmachinestop").click(function () {

    });
    
})