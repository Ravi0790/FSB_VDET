var orderid = 0;
var startimeafterpending = "";
var setintervalid = 0;


function CheckProdTimeAfterPending() {

    var endtimeinfo = InitiateTime("prodend", 0)
    var starttimeinfo = new Date(startimeafterpending);

    var strtimeduration = GetTimeDuration(starttimeinfo, endtimeinfo.DateTime);


    $("#prodendtime").text(endtimeinfo.TimeDisplay);

    var timeduration = strtimeduration.split('|')[0];
    var timedurationmin = strtimeduration.split('|')[1];

    $("#prodduration").text(timeduration);

    $("#proddurationmin").text("(" + timedurationmin + " mins)")

    var speed = $("#speed").text();
    var pockets = $("#pockets").text();

    var plannedquantity = parseInt(timedurationmin) * parseInt(speed) * parseInt(pockets);
    $("#plannedquantity").text(plannedquantity);



}

function ShowVolumesAfterPending() {
    var strvoltr = "";

    var timeinfo = new Date(startimeafterpending);
    var currenthour = parseInt(timeinfo.getHours());

    //var i = 1;
    for (var i = 1; i <= 8; i++) {



        var nexthour = currenthour + i;

        //currenthour = nexthour == 24 ? 0 : currenthour;

        nexthour = nexthour > 24 ? nexthour - 24 : nexthour;

        //console.log("nexthour",nexthour)
        //console.log("currenthour", currenthour);
        strvoltr += "<tr>"
        strvoltr += "<td class='text-left font-weight-bold pl-4' > " + nexthour + ": 00</td>"
        strvoltr += "<td class='text-center'>-</td> "
        strvoltr += "<td class='text-center'>-</td> "
        strvoltr += "<td class='text-center'>-</td> "
        strvoltr += "<td class='text-center'>-</td> "
        strvoltr += "<td class='text-center pr-3'>-</td> "
        strvoltr += "</tr>"

        //i++;
    }

    $("#tblvolume > tbody").empty();

    $("#tblvolume > tbody").append(strvoltr);
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

    var speed = selectedproductinfo[0].Speed;
    var pockets = selectedproductinfo[0].ProductPocket;

    var plannedquantity = parseInt(timedurationmin) * parseInt(speed) * parseInt(pockets);
    $("#plannedquantity").text(plannedquantity);

}

function ValidateOrder() {
    var product = $("#product");
    var sapnumber = $("#sapnumber");
    var empperm = $("#empperm");
    var emptemp = $("#emptemp")
    var empexternal = $("#empexternal")

    if (product.val() == "") {
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
        strvoltr += "<td class='text-center'>-</td> "
        strvoltr += "<td class='text-center'>-</td> "
        strvoltr += "<td class='text-center'>-</td> "
        strvoltr += "<td class='text-center'>-</td> "
        strvoltr += "<td class='text-center pr-3'>-</td> "
        strvoltr += "</tr>"

        //i++;
    }

    $("#tblvolume > tbody").empty();

    $("#tblvolume > tbody").append(strvoltr);
}

function CreateOrder() {
    var timeinfo = startstoptimeArray.filter(x => x.Type == "prodstart");
    var orderrequest = new Object();
    var userid = $("#userid").val();
    var usertypeid = $("#usertypeid").val();
    var lineid = $("#lineid").val();
    var productid = $("#product").val();
    var orderstartime = timeinfo[0].DateTimeFormat;
    var plannedquantity = 0;
    var saprefnumber = $("#sapnumber").val();
    var createddate = timeinfo[0].DateTimeFormat;
    var shiftid = $("#shifts").val();

    



    orderrequest.SAPReferenceNumber = saprefnumber;
    orderrequest.UserTypeId = usertypeid;
    orderrequest.UserId = userid;
    orderrequest.ShiftId = shiftid;
    orderrequest.LineId = lineid;
    orderrequest.ProductId = productid;
    orderrequest.OrderStartTime = orderstartime;
    orderrequest.PlannedQuantity = plannedquantity;
    orderrequest.PremanentEmp = $("#empperm").val();
    orderrequest.TemporaryEmp = $("#emptemp").val();
    orderrequest.ExternalEmp = $("#empexternal").val();
    orderrequest.CreatedDate = createddate;

    console.log("orderrequest")
    console.log(orderrequest)

    ajaxrequest.URL = apiurl.ordercreate;
    ajaxrequest.Type = "POST";
    ajaxrequest.PData = orderrequest;

    SendAjaxRequest(ajaxrequest, "ordercreate", hitapi.order);

}




function CreateOrderInfo(gorderid) {
    var orderinforequest = new Object();
    orderinforequest.OrderId = gorderid;
    orderinforequest.UserTypeId =usertypeid;
    orderinforequest.UserId =userid;
    orderinforequest.OrderStatus =0;
    orderinforequest.LoggedinTime = GetCurrentTime();
    orderinforequest.UpdatedLoggedinTime = GetCurrentTime();
    
    console.log("orderinforequest")
    console.log(orderinforequest)

    ajaxrequest.URL = apiurl.orderinfo;
    ajaxrequest.Type = "POST";
    ajaxrequest.PData = orderinforequest;

    SendAjaxRequest(ajaxrequest, "orderinfo", hitapi.order);
}



function GetOrderById() {
    console.log("orderinfo");
    

    ajaxrequest.URL = apiurl.ordercreate + orderid;
    SendAjaxRequest(ajaxrequest, "getorderinfo", hitapi.order);

    
}

function GetLineById(callback) {

    console.log("GetLineById")

    ajaxrequest.URL = apiurl.lines + lineid;
    SendAjaxRequest(ajaxrequest, "linebyid", hitapi.lines,"",callback);

    
}


function GetProductsByLine(callback) {

    console.log("productfunc")
    /************Get Products by Line and UserType -- Start */
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#product");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "ProductName";
    dropdowninfo.dropdownval = "ProductId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";

    ajaxrequest.URL = apiurl.productsbylineusertype + lineid + "/" + usertypeid;

    SendAjaxRequest(ajaxrequest, "dropdownfill", hitapi.lines, dropdowninfo,callback);

    //callback()

    /************Get Products by Line and UserType -- End */
}


function GetShiftByPlant(callback) {
    console.log("shiftfunc")
    /************Get Shift by Plant -- Start */
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#shifts");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "ShiftName";
    dropdowninfo.dropdownval = "ShiftId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";

    ajaxrequest.URL = apiurl.shiftsbyplant + plantid;

    SendAjaxRequest(ajaxrequest, "dropdownfill", hitapi.shifts, dropdowninfo,callback);

    //callback();

    /************Get Products by Shift -- End */
}


function SetProductValues(product) {
    console.log("productid",product.ProductId)
    $("#product").val(product.ProductId)
    $("#proddesc").text(product.ProductDesc);
    $("#pockets").text(product.ProductPocket);

    $("#bunweight").text(product.BunWeight);

    $("#speed").text(product.Speed);
}


function SetOrderValues(orderdata) {
    SetProductValues(orderdata.Line.Products[0])

    $("#empperm").val(orderdata.PremanentEmp);
    $("#emptemp").val(orderdata.TemporaryEmp);
    $("#empexternal").val(orderdata.ExternalEmp);
    $("#sapnumber").val(orderdata.SAPReferenceNumber);
    startimeafterpending = orderdata.OrderStartTime;

    
    var gstartime = orderdata.OrderStartTime.split('T')[1];

    var nstarttime = gstartime.split(':');
    var startime = nstarttime[0] + ":" + nstarttime[1];

    $("#prodstarttime").text(startime);

    $("#shifts").val(orderdata.ShiftId);

    setintervalid=setInterval(CheckProdTimeAfterPending, 3000);

    $("#dvorder").find(".form-control").attr("disabled", true)

    $("#btnstart").addClass("btn-disabled");
    $("#btnstart").attr("disabled", true);

    $("#btnend").removeClass("btn-disabled");
    $("#btnend").attr("disabled", false);

    ShowVolumesAfterPending();
}

function ShowTeigteileruhr(gcallback) {
    bootbox.prompt({
        title: "Dauer der Teigteileruhr (Minuten)",
        centerVertical: true,
        callback: function (result) {
            
            if (result != null) {
                $("#ttduration").val(result);
                gcallback()
            }
            
        }
    });
}


function CloseOrder() {
    var plannedquantity = $("#plannedquantity").text();


    var orderrequest = new Object();

    var endtimeinfo = InitiateTime("prodend", 0)
    var starttimeinfo = "";

    var loginstatus = $("#loginstatus").val();

    if (loginstatus == "pending") {
        starttimeinfo = new Date(startimeafterpending);
    }
    else {
        var timeinfo = startstoptimeArray.filter(x => x.Type == "prodstart");
        starttimeinfo = timeinfo[0].DateTime;
    }

    var strtimeduration = GetTimeDuration(starttimeinfo, endtimeinfo.DateTime);
    var timeduration = strtimeduration.split('|')[0];
    var timedurationmin = strtimeduration.split('|')[1];
     

    orderrequest.PlannedQuantity = plannedquantity;

    orderrequest.OrderId = orderid;
    orderrequest.TeigteileruhrDurationMin = $("#ttduration").val() == "" ? 0 : $("#ttduration").val();
    orderrequest.UserTypeId = usertypeid;
    orderrequest.OrderEndTime = endtimeinfo.DateTimeFormat;
    orderrequest.OrderDurationMin = timedurationmin;
    orderrequest.Status = 1;

    ajaxrequest.URL = apiurl.ordercreate + "update";
    ajaxrequest.Type = "POST";
    ajaxrequest.PData = orderrequest;

    SendAjaxRequest(ajaxrequest, "orderclose", hitapi.order);


}


function runFunctionAfterPending(callback) {
    GetProductsByLine(function () {
        GetLineById(function () {
            GetShiftByPlant(function () {
                GetOrderById()
            });
        });
    });
}

function runFunctionBeforePending(callback) {
    GetProductsByLine(function () {
        GetLineById(function () {
            GetShiftByPlant(function () {
            });
        });
    });
}

$(document).ready(function () {

        $(document).ajaxStart(function () {
            $(".fixedLoaderWrap").show()
        });

        $(document).ajaxComplete(function () {
            $(".fixedLoaderWrap").hide()
        });


    
    
    lineid = $("#lineid").val();
    usertypeid = $("#usertypeid").val();
    plantid = $("#plantid").val();
    userid = $("#userid").val();



    /******Check for OrderId (checking if the user is coming from pending page*********************/

    orderid = $("#orderid").text();

    if (orderid != 0) {

        console.log("orderid",orderid)
        runFunctionAfterPending(function () {
            console.log("function callfinished")
        });

        //Fill Verlustart,Location,Cleaning and Repair Approver
        runFunctionWasteFirstTime(function () {
            console.log("waste first functions called")
        });

        DisableWasteControlsPartially();

        GetWastesByOrderUserType();//Get Waste Details based on OrderId and UserType

        $("#loginstatus").val("pending");
        
    }
    else {
        runFunctionBeforePending(function () {
            console.log("function callfinished")
        });

        DisableWasteControlsPartially();
        $("#dvwastedetail").hide();//hiding waste information before order is created
        //DisableWasteControls()
        $("#loginstatus").val("firsttime");
    }



    


    //Calling product change event

    $("#product").change(function () { 
        var gbakerydetail = JSON.parse(localStorage.getItem("bakeryinfo"));
        var productid = $(this).val();

        
        selectedproductinfo = gbakerydetail.ProductInfo.filter((product) => product.ProductId == productid);

        SetProductValues(selectedproductinfo[0])

                      
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
            
            $("#dvorder").find(".form-control").attr("disabled", true)      
            $("#product").attr("disabled", true);
            $("#sapnumber").attr("disabled", true);

            setintervalid=setInterval(CheckProdTime, 3000);

            ShowVolumes();
            CreateOrder();
            //Fill Verlustart,Location,Cleaning and Repair Approver
            runFunctionWasteFirstTime(function () {
                console.log("waste first functions called")
            });

            DisableWasteControlsPartially();
            $("#dvwastedetail").show()
        }
    })


    $("#btnend").click(function () {

        ShowTeigteileruhr(function () {

            clearInterval(setintervalid)

            CloseOrder()
        })
        
    })


   
})