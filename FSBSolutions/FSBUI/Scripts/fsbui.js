var startstoptimeArray = [];

var starthour = "";
var selectedproductinfo = null;


function GetTimeInfo(timetype) {
    return startstoptimeArray.filter(x => x.Type == timetype);
}

function GetTimeDuration(startime, endtime) {
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

    return hh + ":" + mm;
    //console.log("Time Diff- " + hh + ":" + mm + ":" + ss);
}

function InitiateStartTime(timetype,callback) {

    var d = new Date();
    var starthour = d.getHours()
    var startmin = d.getMinutes();
    var startyear = d.getFullYear();
    var startmonth = d.getMonth();
    var rightmonth = parseInt(startmonth) + 1;
    var startdate = d.getDate();

    var startdatetime =rightmonth + "/" + startdate + "/" + startyear + " " + starthour + ":" + startmin;

    var starttimedisplay = starthour + ":" + startmin;

    var timeobj = new Object();

    timeobj.StartHour = starthour;
    timeobj.StartMinute = startmin;
    timeobj.StartYear = startyear;
    timeobj.StartMonth = rightmonth;
    timeobj.StartDate = startdate;
    timeobj.StartDateTime = startdatetime;
    timeobj.StartTimeDisplay = starttimedisplay;
    timeobj.EndDateTime = startdatetime;
    timeobj.Type = timetype;

    startstoptimeArray.push(timeobj);

    callback();
    //timeobject.val(starttimedisplay);
}


function InitiateEndTime(timetype, callback) {

    var d = new Date();
    var endhour = d.getHours()
    var endmin = d.getMinutes();
    var endyear = d.getFullYear();
    var endmonth = d.getMonth();
    var rightmonth = parseInt(endmonth) + 1;
    var enddate = d.getDate();

    var enddatetime = rightmonth + "/" + enddate + "/" + endyear + " " + endhour + ":" + endmin;

    var endtimedisplay = endhour + ":" + endmin;

    var timeobj = new Object();

    timeobj.StartHour = starthour;
    timeobj.StartMinute = startmin;
    timeobj.StartYear = startyear;
    timeobj.StartMonth = rightmonth;
    timeobj.StartDate = startdate;
    timeobj.StartDateTime = startdatetime;
    timeobj.StartTimeDisplay = starttimedisplay;
    timeobj.EndDateTime = startdatetime;
    timeobj.Type = timetype;

    startstoptimeArray.push(timeobj);

    callback();
    //timeobject.val(starttimedisplay);
}

function CheckTime() {

    console.log("checktime started")
    var d = new Date();
    var endhour = d.getHours()
    var endmin = d.getMinutes();
    var endyear = d.getFullYear();
    var endmonth = d.getMonth();
    var enddate = d.getDate();

    var endtime = endhour + ":" + endmin;

    var enddatetime = new Date(endyear, endmonth, enddate, endhour, endmin);

    console.log("prodendtime", enddatetime);

    



    $("#endtime").text(endtime);
    $("#duration").text(hh + ":" + mm);
    var durationinmin = parseInt(hh) * 60 + parseInt(mm);
    $("#durationmin").text("(" + durationinmin + " mins)")

    var cutpermin = selectedproductinfo[0].CutPerMinute;
    var pockets = selectedproductinfo[0].ProductPocket;

    var plannedquantity = parseInt(durationinmin) * parseInt(cutpermin) * parseInt(pockets);
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
    var currenthour = parseInt(starthour);

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
    var orderstartime = $("#prodstarttime").val();
    var plannedquantity = 0;
    var saprefnumber = $("#sapnumber").val();
    var createddate = $("#prodstarttime").val();

    orderrequest.SAPReferenceNumber = saprefnumber;
    orderrequest.UserTypeId = usertypeid;
    orderrequest.UserId = userid;
    orderrequest.ShiftId = 1;
    orderrequest.LineId = lineid;
    orderrequest.ProductId = productid;
    orderrequest.OrderStartTime = orderstartime;
    orderrequest.PlannedQuantity = 0;
    orderrequest.PremanentEmp = 0;
    orderrequest.TemporaryEmp = 0;
    orderrequest.ExternalEmp = 0;
    orderrequest.CreatedDate = orderstartime;

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

            
            
            InitiateStartTime("production", function () {
                var timeinfo = GetTimeInfo("Production")


                $("#starttime").text(timeinfo[0].StartTimeDisplay);
                $("#endtime").text(timeinfo[0].StartTimeDisplay);
                $("#duration").text("00:00");
                $("#durationmin").text("(0 mins)")

            })

            

            
            
            $(this).addClass("btn-disabled");
            $(this).attr("disabled", true);

            $("#btnend").removeClass("btn-disabled");        
            $("#btnend").attr("disabled", false);
            
            
            
            $("#product").attr("disabled", true);
            $("#sapnumber").attr("disabled", true);

            setInterval(CheckTime, 30000);

            ShowVolumes();
            //CreateOrder();
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