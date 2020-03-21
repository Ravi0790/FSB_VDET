var orderid = 0;
var startimeafterpending = "";
var setintervalid = 0;



/**********Production Time-Start********/


function CheckProdTimeAfterPending() {

    var starttimeinfo = new Date(startimeafterpending);

    var endtimeinfo = new Object();

    if ($("#isbakerystopped").val() == "1") { //if bakery time stopped
        endtimeinfo.DateTime = new Date($("#bakerystoptime").val())        

        var ggendtime = $("#bakerystoptime").val();
        var gendtime = ggendtime.split('T')[1];

        var nendtime = gendtime.split(':');
        var endtime = nendtime[0] + ":" + nendtime[1];

        $("#prodendtime").text(endtime); //bakery stop time will be displayed
    }
    else {
        endtimeinfo = InitiateTime("prodend", 0)

        $("#prodendtime").text(endtimeinfo.TimeDisplay);
    }

    
    

    var strtimeduration = GetTimeDuration(starttimeinfo, endtimeinfo.DateTime);


    

    var timeduration = strtimeduration.split('|')[0];
    var timedurationmin = strtimeduration.split('|')[1];

    $("#prodduration").text(timeduration);

    $("#proddurationmin").text("(" + timedurationmin + " mins)")

    var speed = $("#speed").text();
    var pockets = $("#pockets").text();

    var plannedquantity = parseInt(timedurationmin) * parseInt(speed) * parseInt(pockets);
    $("#plannedquantity").text(plannedquantity);

    var producedquantity = parseInt($("#producedquantity").text())

    var effperc = parseInt((producedquantity / plannedquantity) * 100);

    $("#efficiency").text(effperc + "%");



}
/**********Production Time-Stop********/



/***********Volume-Start****************/
function CreateVolumes(vhour) {

    console.log("volume create started")
    //console.log(vhour)

    var volumearr = []

    var ctimeinfo = InitiateTime("currenttime", 0)

    var createdate = ctimeinfo.DateTimeFormat;

    for (var i = 0; i < vhour.length; i++) {
        var volumeobj = new Object();
        volumeobj.OrderId = orderid;
        volumeobj.TimeSlot = vhour[i];
        volumeobj.CreatedDate = createdate;

        volumearr.push(volumeobj);
    }

    //console.log("volumearr")
    console.log(volumearr)

    var ordervolumelist = new Object();

    ordervolumelist.OrderVolume = volumearr;

    ajaxrequest.URL = apiurl.ordervolume + "all";
    ajaxrequest.Type = "POST";
    ajaxrequest.PData = ordervolumelist



    console.log("volume ajax request")
    console.log(ajaxrequest.PData)

    SendAjaxRequest(ajaxrequest, "ordervolcreate", hitapi.order);


}

function ShowVolumes() {
    var strvoltr = "";

    var timeinfo = startstoptimeArray.filter(x => x.Type == "prodstart");
    var currenthour = parseInt(timeinfo[0].Hour);

    var volumhour = [];

    //var i = 1;
    for (var i = 1; i <= 8; i++) {



        var nexthour = currenthour + i;

        //currenthour = nexthour == 24 ? 0 : currenthour;

        nexthour = nexthour > 24 ? nexthour - 24 : nexthour;

        nexthour = String(nexthour).length == 1 ? "0" + nexthour : nexthour;

        volumhour.push(nexthour + ":00")

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

    CreateVolumes(volumhour);
}

function GetVolumes() {
    ajaxrequest.Type = "GET";
    ajaxrequest.URL = apiurl.ordervolumebyorder + orderid;
    SendAjaxRequest(ajaxrequest, "getordervolume", hitapi.order);//after this ShowVolumesAftePending is called
}

function UpdateVolume(volumeid,rowid) {

    var volumereq = new Object();

    //volumereq.TimeSlot = $("#timeslot" + volumeid).html();
    volumereq.ProducedVolumeId = volumeid;
    volumereq.Dollies = $("#dolly" + rowid).val();
    volumereq.Korbe = $("#korbe" + rowid).html();
    volumereq.Pieces = $("#piece" + rowid).html();
    volumereq.GeplanteMenge = $("#gplant" + rowid).html();

    var eff = $("#eff" + rowid).html();
    volumereq.Efficiency = eff.replace("%",""); 

    var displayrowid = -1;

    if (IsPackagingTimeMore(rowid) == false) {
        displayrowid = parseInt(rowid) + 1;
    }



    volumereq.DisplayRowId = displayrowid;
    volumereq.OrderId = orderid;


    ajaxrequest.Type = "POST";
    ajaxrequest.URL = apiurl.ordervolume + "update";
    ajaxrequest.PData = volumereq;

    console.log("volume update request")
    console.log(ajaxrequest)


    SendAjaxRequest(ajaxrequest, "updatevolume", hitapi.order);
}

function ShowVolumesAfterPending(volumelist) {

    console.log("start showvolumepending")

    var strvoltr = "";
    var producedquantity = 0;
    var effperc = 0;

    var volumecount = volumelist.length;

    for (var i = 0; i < volumecount; i++) {

        var timeslot = volumelist[i].TimeSlot;
        var dollies = volumelist[i].Dollies;
        var korbe = volumelist[i].Korbe;
        var pieces = volumelist[i].Pieces;
        var geplantemenge = volumelist[i].GeplanteMenge;
        var efficiency = volumelist[i].Efficiency;
        var volumeid = volumelist[i].ProducedVolumeId;
        var displayrowid = volumelist[i].DisplayRowId;

        producedquantity += parseInt(pieces);

        effperc += parseInt(efficiency);

        var disabled = i == displayrowid ? "" : "disabled";
        

        strvoltr += "<tr>"
        strvoltr += "<td class='text-left font-weight-bold pl-4' id='timeslot"+i+"' > " + timeslot + "</td>"
        strvoltr += "<td class='text-center'><input type='text' class='form-control dollies' " + disabled + " value='" + dollies + "' id='dolly" + i + "' rowid='" + i +"' onfocus='CheckZero(this)' ></td>"
        strvoltr += "<td class='text-center' id='korbe"+i+"'>" + korbe + "</td> "
        strvoltr += "<td class='text-center' id='piece" + i +"'>" + pieces + "</td> "
        strvoltr += "<td class='text-center' id='gplant" + i +"'>" + geplantemenge + "</td> "
        strvoltr += "<td class='text-center pr-3' id='eff" + i +"'>" + efficiency + "%</td> "
        strvoltr += "<td class='text-right pr-small-1 pr-3'> <button type='button' class='btn btn-primary btn-small btn-orange hvr-float ripple text-uppercase font-weight-bold btnadd' " + disabled + " vid='" + volumeid+"' rowid='"+i+"'>Add</button></td>"	
        strvoltr += "</tr>"


    }



    $("#tblvolume > tbody").empty();

    $("#tblvolume > tbody").append(strvoltr);


    

    $("#producedquantity").text(producedquantity);
    //var plannedquantity = $("#plannedquantity").text();
    //effperc = parseInt((producedquantity / parseInt(plannedquantity)) * 100);    
    //$("#efficiency").text(effperc + "%");

    GetOrderStatus(CheckOrderStatus);//check for status of bakery

}
/***********Volume-End****************/


/***********Order-Start****************/

function ValidateOrder() {
    var product = $("#product");
    var sapnumber = $("#sapnumber");
    var shift = $("#shifts")
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
    else {
        if (!sappatten.test(sapnumber.val())) {
            bootbox.alert("Ungültige SAP-Referenznummer")
            sapnumber.focus();
            return false;
        }
    }


    if (shift.val() == "") {
        bootbox.alert("Bitte Schichten auswählen")
        product.focus();
        return false;
    }




    if (empperm.val() == "" || emptemp.val() == "" || empexternal.val() == "") {
        bootbox.alert("Bitte geben Sie die Anzahl der Mitarbeiter ein")
        empperm.focus();
        return false;
    }

    return true;

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

    //console.log("orderrequest")
    //console.log(orderrequest)

    ajaxrequest.URL = apiurl.ordercreate;
    ajaxrequest.Type = "POST";
    ajaxrequest.PData = orderrequest;

    SendAjaxRequest(ajaxrequest, "ordercreate", hitapi.order);

}

function CreateOrderInfo(gorderid) {
    var orderinforequest = new Object();
    orderinforequest.OrderId = gorderid;
    orderinforequest.UserTypeId = usertypeid;
    orderinforequest.UserId = userid;
    orderinforequest.OrderStatus = 0;
    orderinforequest.LoggedinTime = GetCurrentTime();
    orderinforequest.UpdatedLoggedinTime = GetCurrentTime();

    //console.log("orderinforequest")
    //console.log(orderinforequest)

    ajaxrequest.URL = apiurl.orderinfo;
    ajaxrequest.Type = "POST";
    ajaxrequest.PData = orderinforequest;

    SendAjaxRequest(ajaxrequest, "orderinfo", hitapi.order);
}

function GetOrderById() {
    //console.log("orderinfo");


    ajaxrequest.URL = apiurl.ordercreate + orderid;
    SendAjaxRequest(ajaxrequest, "getorderinfo", hitapi.order);//after this SetOrderValues is called


}

function SetOrderValues(orderdata) {
    SetProductValues(orderdata.Line.Products[0])

    $("#empperm").val(orderdata.PremanentEmp);
    $("#emptemp").val(orderdata.TemporaryEmp);
    $("#empexternal").val(orderdata.ExternalEmp);
    $("#sapnumber").text(orderdata.SAPReferenceNumber);
    startimeafterpending = orderdata.OrderStartTime;


    var gstartime = orderdata.OrderStartTime.split('T')[1];

    var nstarttime = gstartime.split(':');
    var startime = nstarttime[0] + ":" + nstarttime[1];

    $("#prodstarttime").text(startime);

    $("#shifts").val(orderdata.ShiftId);

    $("#linename").text(orderdata.Line.LineName);

    

    $("#dvorder").find(".form-control").attr("disabled", true)

    $("#btnstart").addClass("btn-disabled");
    $("#btnstart").attr("disabled", true);

    $("#btnend").removeClass("btn-disabled");
    $("#btnend").attr("disabled", false);

    

    GetVolumes();
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


function GetOrderStatus(callback) {
    ajaxrequest.URL = apiurl.orderinfobyorder + orderid;
    SendAjaxRequest(ajaxrequest, "getorderstatus", hitapi.order, "", callback);
}

function CheckOrderStatus(orderinfo, usertypeid,callback) {

    var orderinfo = orderinfo.filter(x => x.UserTypeId == usertypeid);

    console.log("inside checkorderstatus")
    console.log(orderinfo)

    var orderstatus = orderinfo[0].OrderStatus == 1 ? "closed" : "open";

    callback(orderstatus);

}

function SetOrderTime(orderstatus) {

    console.log("inside setorderstatus")
    console.log(orderstatus)
    if (orderstatus== "open") {


        setintervalid = setInterval(CheckProdTimeAfterPending, 2000);
    }
    else {
        

        $("#prodendtime").addClass("bakery-alert");
        $("#isbakerystopped").val("1");

        clearInterval(setintervalid)

        CheckProdTimeAfterPending();

        //bootbox.alert("Bakery production has been completed");

    }
}

/***********Order-End****************/


/***********Product-Start***********/

function GetProductsByLine(callback) {

    //console.log("productfunc")
    /************Get Products by Line and UserType -- Start */
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#product");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "ProductName";
    dropdowninfo.dropdownval = "ProductId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";

    ajaxrequest.URL = apiurl.productsbylineusertype + lineid + "/" + usertypeid;

    SendAjaxRequest(ajaxrequest, "dropdownfill", hitapi.lines, dropdowninfo, callback);

    //callback()


}

function SetProductValues(product) {
    //console.log("productid",product.ProductId)
    $("#product").val(product.ProductId)
    $("#proddesc").text(product.ProductDesc);
    $("#pockets").text(product.ProductPocket);

    $("#bunweight").text(product.BunWeight);

    $("#speed").text(product.Speed);

    $("#weightunit").text("(" + product.WeightUnit + ")")
    $("#speedunit").text("(" + product.SpeedUnit + ")")

    $("#bunpertray").val(product.BunPerTray);
    $("#bunperdolly").val(product.BunPerDolly);

}


/***********Product-End***********/


function GetLineById(callback) {

    //console.log("GetLineById")

    ajaxrequest.URL = apiurl.lines + lineid;
    SendAjaxRequest(ajaxrequest, "linebyid", hitapi.lines, "", callback);


}

function GetShiftByPlant(callback) {
    //console.log("shiftfunc")
    /************Get Shift by Plant -- Start */
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#shifts");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "ShiftName";
    dropdowninfo.dropdownval = "ShiftId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";

    ajaxrequest.URL = apiurl.shiftsbyplant + plantid;

    SendAjaxRequest(ajaxrequest, "dropdownfill", hitapi.shifts, dropdowninfo, callback);

    //callback();

    /************Get Products by Shift -- End */
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


//function runFunctionAfterPending(callback) {
//    GetProductsByLine(function () {
//        GetLineById(function () {
//            GetShiftByPlant(function () {
//                GetOrderById()
//            });
//        });
//    });
//}
function IsPackagingTimeMore(rowid) {
    var pgtimestatus = false;

    if ($("#isbakerystopped").val() == "1") {

        var bendtime = new Date($("#bakerystoptime").val());
        var pstarttimeobj = InitiateTimeByHourMin($("#timeslot" + rowid).html().trim())
        pstarttime = pstarttimeobj.DateTime;

        console.log("bakeryendtime")
        console.log(bendtime)

        console.log("packaginstarttime")
        console.log(pstarttime)


        pgtimestatus= pstarttime > bendtime ? true : false;
            
        
    }

    console.log("IsPackagingTimeMore")
    console.log(pgtimestatus)

    return pgtimestatus; 
}


function CalculateVolumeRow(rowid) {

    var dollies = $(".dollies").eq(rowid).val();


    if (dollies != "0") {

        var bunpertray = $("#bunpertray").val();
        var bunperdolly = $("#bunperdolly").val();
        var pockets = $("#pockets").text();
        var speed = $("#speed").text();
        var pieces = parseInt(dollies) * parseInt(bunperdolly);//produced quantity per hour
        var korbe = parseInt(pieces) / parseInt(bunpertray);//korbe per hour

        /*********Calculate production duration for first hour*********/
        var productionminute = 60;

        if (rowid == "0") {
            var endtimeobj = InitiateTimeByHourMin($("#timeslot0").html().trim())
            console.log(endtimeobj)

            var endtime = endtimeobj.DateTime;
            var starttime = new Date(startimeafterpending) //start time of the bakery

            var timeduration = GetTimeDuration(starttime, endtime);

            productionminute = timeduration.split('|')[1];

            console.log("first hour prodminute", productionminute)

        }

        

        if (IsPackagingTimeMore(rowid)) { 

            var bendtime = new Date($("#bakerystoptime").val());
            //var pstarttime = InitiateTimeByHourMin($("#timeslot" + rowid).html().trim())


            //var ftimeduration = GetTimeDuration(pstarttime.DateTime, bendtime);
            //productionminute = ftimeduration.split('|')[1];
            productionminute = bendtime.getMinutes();

        }

        console.log("volume row duration")
        console.log(productionminute)

        var geplantemenge = pockets * speed * productionminute;//planned quantity per hour
        var efficiency = parseInt((pieces / geplantemenge) * 100);//efficiency per hour



        $("#piece" + rowid).html(pieces);
        $("#korbe" + rowid).html(korbe);
        $("#gplant" + rowid).html(geplantemenge);
        $("#eff" + rowid).html(efficiency + "%");

    }
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



    

    orderid = $("#orderid").text();

    if (orderid != 0) {

        //console.log("orderid",orderid)
        GetOrderById(); //GetOrderInformation

        //Fill Verlustart,Location,Cleaning and Repair Approver
        runFunctionWasteFirstTime(function () {
            console.log("waste first functions called")
        });

        DisableWasteControlsPartially();
        EnableMachine();

        GetWastesByOrderUserType();//Get Waste Details based on OrderId and UserType

        $("#loginstatus").val("pending");

    }
    
             

    //Events

    $(document).on("blur mouseleave", ".dollies", function () {

        $(this).val($(this).val() == "" ? "0" : $(this).val());

        console.log("hello dolly")
        
        var rowid = $(this).attr("rowid"); 

        CalculateVolumeRow(rowid);
    })

    $(document).on("click", ".btnadd", function () {
        //console.log("hello dolly")
        var volumeid = $(this).attr("vid");
        var rowid = $(this).attr("rowid");

        var dolly = $("#dolly" + rowid).val();

        if (dolly == "0" || dolly=="") {
            bootbox.alert("Please enter Dollies");
            return false;
        }

                          

        var rowcount = parseInt(rowid) + 1;
        var prodquantity = 0;

        for (var i = 0; i <= rowcount; i++) { //max rowcount can be 7

            var pieces = $("#piece" + i).html()

            prodquantity = parseInt(prodquantity) + parseInt(pieces);
           
        }

        console.log("producedquantity", prodquantity);

        $("#producedquantity").text(prodquantity);

        var plannedquantity = $("#plannedquantity").text();        

        var effperc = parseInt((prodquantity / parseInt(plannedquantity)) * 100);

        //console.log("effperc")
        //console.log(effperc)

        $("#efficiency").text(effperc + "%");



        

        $(this).attr("disabled", true);
        $("#dolly" + rowid).attr("disabled", true);

        

        if (IsPackagingTimeMore(rowid) == false) {
            var nextrowid = parseInt(rowid) + 1;

            $(".btnadd").eq(nextrowid).attr("disabled", false);
            $("#dolly" + nextrowid).attr("disabled", false);

            if (rowid == 7) {
                $("#finalordermodal").modal();
            }
        }
        else {

            var fplannedquantity = $("#plannedquantity").text();
            var fproducedquantity = $("#producedquantity").text();
            var fefficiency = $("#efficiency").text();

            $("#forderid").text(orderid);
            $("#fplannedqauntity").val(fplannedquantity);
            $("#fproducedquantity").val(fproducedquantity);
            $("#fefficiency").val(fefficiency);

            $("#finalordermodal").modal();

        }

        UpdateVolume(volumeid, rowid);

        
    })


    $("#btnok").click(function () {

        //alert("orderclose");
        var orderrequest = new Object();

        orderrequest.ProducedQuantity = $("#producedquantity").text();
        orderrequest.UserTypeId = usertypeid;
        orderrequest.OrderId = orderid;
        orderrequest.Status = 1;

        ajaxrequest.URL = apiurl.ordercreate + "update";
        ajaxrequest.Type = "POST";
        ajaxrequest.PData = orderrequest;

        console.log("order request")
        console.log(ajaxrequest)

        SendAjaxRequest(ajaxrequest, "porderclose", hitapi.order);
    })

})