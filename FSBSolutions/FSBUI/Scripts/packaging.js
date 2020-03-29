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
    volumereq.Duration = $("#hdprodmin" + rowid).val();

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

    var dollyheading = $("#masterpackunit").val();
    $("#thdolly").html(dollyheading.toLowerCase().indexOf("pallet") > -1 ? "Pallets" : "Dollies");

    for (var i = 0; i < volumecount; i++) {

        var timeslot = volumelist[i].TimeSlot;
        var dollies = volumelist[i].Dollies;
        var korbe = volumelist[i].Korbe;
        var pieces = volumelist[i].Pieces;
        var geplantemenge = volumelist[i].GeplanteMenge;
        var efficiency = volumelist[i].Efficiency;
        var volumeid = volumelist[i].ProducedVolumeId;
        var displayrowid = volumelist[i].DisplayRowId;
        var duration = "(" + volumelist[i].Duration + " mins)";

        producedquantity += parseInt(pieces);

        effperc += parseInt(efficiency);

        var disabled = i == displayrowid ? "" : "disabled";
        

        strvoltr += "<tr>"
        strvoltr += "<td class='text-center font-weight-bold pl-4'><span id='timeslot" + i +"' >"+timeslot+"</span><br/><span id='prodmin"+i+"' style='font-size:12px'>"+duration+"</span><input type='hidden' id='hdprodmin"+i+"'></td>"
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



function GetOrderById() {
    //console.log("orderinfo");


    ajaxrequest.URL = apiurl.ordercreate + orderid;
    SendAjaxRequest(ajaxrequest, "getorderinfo", hitapi.order);//after this SetOrderValues is called


}

function SetOrderValues(orderdata) {
    SetProductValues(orderdata.Line.Products[0])

    //$("#empperm").val(orderdata.PremanentEmp);
    //$("#emptemp").val(orderdata.TemporaryEmp);
    //$("#empexternal").val(orderdata.ExternalEmp);
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

function CloseOrder(callback) {
    var orderrequest = new Object();

    orderrequest.ProducedQuantity = $("#producedquantity").text();
    orderrequest.UserTypeId = usertypeid;
    orderrequest.OrderId = orderid;
    orderrequest.Status = 1;
    orderrequest.PremanentEmp = $("#empperm").val();
    orderrequest.ExternalEmp = $("#emptemp").val();
    orderrequest.TemporaryEmp = $("#empexternal").val();

    ajaxrequest.URL = apiurl.ordercreate + "update";
    ajaxrequest.Type = "POST";
    ajaxrequest.PData = orderrequest;

    console.log("order request")
    console.log(ajaxrequest)

    SendAjaxRequest(ajaxrequest, "porderclose", hitapi.order,"",callback);


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



function SetProductValues(product) {
    //console.log("productid",product.ProductId)
    //$("#product").val(product.ProductId)
    $("#prodname").text(product.ProductName)
    $("#proddesc").text(product.ProductDesc);
    $("#pockets").text(product.ProductPocket);

    $("#bunweight").text(product.BunWeight);

    $("#speed").text(product.Speed);

    $("#weightunit").text("(" + product.WeightUnit + ")")
    $("#speedunit").text("(" + product.SpeedUnit + ")")

    $("#bunpertray").val(product.BunPerTray);
    $("#bunperdolly").val(product.BunPerDolly);

    $("#masterpackunit").val(product.MasterPackUnit);

}


/***********Product-End***********/





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



function IsPackagingTimeMore(rowid,isbakerystopped) {
    var pgtimestatus = false;
    var pstarttimeobj = InitiateTimeByHourMin($("#timeslot" + rowid).html().trim());
    pstarttime = pstarttimeobj.DateTime;

    

    if (isbakerystopped == 1) {

        var bendtime = new Date($("#bakerystoptime").val());
        pgtimestatus = pstarttime > bendtime ? true : false;
    }
    else {
        endtimeinfo = InitiateTime("prodend", 0)
        pgtimestatus = pstarttime > endtimeinfo.DateTime ? true : false;
    }



    console.log("IsPackagingTimeMore")
    console.log(pgtimestatus)

    return pgtimestatus; 
}


function GetRowDuration(rowid) {//rowid will always start with 1 as zero is calculated with starttime
    var prevrowid = parseInt(rowid) - 1;

    var bakeryendobj = InitiateTime("bakeryend", 0)
    var bakeryendtime = bakeryendobj.DateTime;

    if ($("#isbakerystopped").val() == "1") {
        bakeryendtime = new Date($("#bakerystoptime").val());
    }


    var cpktime = InitiateTimeByHourMin($("#timeslot" + rowid).html().trim())
    var ppktime = InitiateTimeByHourMin($("#timeslot" + prevrowid).html().trim())

    var cpakagintime = cpktime.DateTime;
    var ppakagintime = ppktime.DateTime;

    console.log("bakerytime")
    console.log(bakeryendtime)

    console.log("cpakagintime")
    console.log(cpakagintime)

    console.log("ppakagintime")
    console.log(ppakagintime)

    var rowduration = 0;

    if (rowid != 7) {
        if (bakeryendtime > ppakagintime && bakeryendtime <= cpakagintime) { //bakeryendtime is between
            var rtimeduration = GetTimeDuration(ppakagintime, bakeryendtime);
            rowduration = rtimeduration.split('|')[1];
        }
        else {
            rowduration = 60
        }
    }
    else {//if the last row
        if (bakeryendtime > ppakagintime && bakeryendtime <= cpakagintime) { //bakeryendtime is between
            var rtimeduration = GetTimeDuration(ppakagintime, bakeryendtime);
            rowduration = rtimeduration.split('|')[1];
        }
        else {
            var rtimeduration = GetTimeDuration(cpakagintime, bakeryendtime);
            rowduration = 60 + parseInt(rtimeduration.split('|')[1]);
        }
    }


   
    return rowduration;
    
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
            var endtimeobj = InitiateTimeByHourMin($("#timeslot0").text().trim())
            console.log(endtimeobj)

            var endtime = endtimeobj.DateTime;
            var starttime = new Date(startimeafterpending) //start time of the bakery

            var timeduration = GetTimeDuration(starttime, endtime);

            productionminute = timeduration.split('|')[1];

            console.log("first hour prodminute", productionminute)

        }
        else {


            productionminute=GetRowDuration(rowid)
            
        }

        console.log("volume row duration")
        console.log(productionminute)

        var geplantemenge = pockets * speed * productionminute;//planned quantity per hour
        var efficiency = parseInt((pieces / geplantemenge) * 100);//efficiency per hour


        $("#hdprodmin" + rowid).val(productionminute);
        $("#prodmin" + rowid).text("("+productionminute + " mins)")
        $("#piece" + rowid).html(pieces);
        $("#korbe" + rowid).html(korbe);
        $("#gplant" + rowid).html(geplantemenge);
        $("#eff" + rowid).html(efficiency + "%");

    }
}


function ValidatePackaging() {
    var empperm = $("#empperm");
    var emptemp = $("#emptemp")
    var empexternal = $("#empexternal")

    if (empperm.val() == "" || emptemp.val() == "" || empexternal.val() == "") {
        bootbox.alert("Bitte geben Sie die Anzahl der Mitarbeiter ein")
        empperm.focus();
        return false;
    }

    return true;
}


function ShowEfficiency(prodquantity) {

    console.log("ShowEfficiency", prodquantity);

    $("#producedquantity").text(prodquantity);

    var plannedquantity = $("#plannedquantity").text();

    var effperc = parseInt((prodquantity / parseInt(plannedquantity)) * 100);


    $("#efficiency").text(effperc + "%");
}

function FillOrderCloseModal() {
    var fplannedquantity = $("#plannedquantity").text();
    var fproducedquantity = $("#producedquantity").text();
    var fefficiency = $("#efficiency").text();

    $("#forderid").text(orderid);
    $("#fplannedqauntity").val(fplannedquantity);
    $("#fproducedquantity").val(fproducedquantity);
    $("#fefficiency").val(fefficiency);
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


        if ($(this).prop("disabled") == false) {
            CalculateVolumeRow(rowid);
        }
        
    })

    $(document).on("click", ".btnadd", function () {
        
        
        var rowid = $(this).attr("rowid");
        var nextrowid = parseInt(rowid) + 1;
        var dolly = $("#dolly" + rowid).val();

        var volumeid = $(this).attr("vid");

        if (dolly == "0" || dolly=="") {
            bootbox.alert("Please enter Dollies");
            return false;
        }

                          
        var prodquantity = 0;

        for (var i = 0; i <= rowid; i++) { //max rowid can be 7

            var pieces = $("#piece" + i).html()

            prodquantity = parseInt(prodquantity) + parseInt(pieces);
           
        }

        

        ShowEfficiency(prodquantity)  

        FillOrderCloseModal();

        if ($("#isbakerystopped").val() == "1") {

            if (IsPackagingTimeMore(rowid, 0) == false) {

                if (rowid != 7) {
                    //disable current row
                    $(this).attr("disabled", true);
                    $("#dolly" + rowid).attr("disabled", true);
                    //enable next row
                    $(".btnadd").eq(nextrowid).attr("disabled", false);
                    $("#dolly" + nextrowid).attr("disabled", false);
                    //update volume
                    UpdateVolume(volumeid, rowid);
                }
                else {
                    if (ValidatePackaging()) {

                        //disable current row
                        $(this).attr("disabled", true);
                        $("#dolly" + rowid).attr("disabled", true);

                        //update volume
                        UpdateVolume(volumeid, rowid);

                        //order close
                        $("#finalordermodal").modal({ backdrop: "static" });
                    }
                }
            }
            else {
               

                if (ValidatePackaging()) {

                    //disable current row
                    $(this).attr("disabled", true);
                    $("#dolly" + rowid).attr("disabled", true);

                    //update volume
                    UpdateVolume(volumeid, rowid);

                    //order close
                    $("#finalordermodal").modal({ backdrop: "static" });
                }
            }         
            
        }
        else {

            //check if the last row

            if (IsPackagingTimeMore(rowid, 0) == false) {

                if (rowid != 7) {
                    $(this).attr("disabled", true);
                    $("#dolly" + rowid).attr("disabled", true);
                    //enable the next row
                    $(".btnadd").eq(nextrowid).attr("disabled", false);
                    $("#dolly" + nextrowid).attr("disabled", false);
                    UpdateVolume(volumeid, rowid);
                }
                else {
                    bootbox.alert("Production is still in process. Kindly wait...")
                    return false;
                }
            }
            else {
                bootbox.alert("Production is still in process. Kindly wait...")
                return false;
            }
            

        }
                

        

        
    })


    $("#btnlogout").click(function () {
        CloseOrder(function () {

            location.href = "/login/logout"
        });        
    })

    $("#btnnew").click(function () {

        CloseOrder(function () {

            location.href = "/order/pending"
        });  
        
    })

})