var cusertypeid = 3;
var rusetypeid = 4;
var wastestartstopArry = [];
var machinestartstopArry = [];



function GetTimeInfoWaste(timetype) {
    return wastestartstopArry.filter(x => x.Type == timetype);
}

function GetTimeInfoMachine(timetype) {
    return machinestartstopArry.filter(x => x.Type == timetype);
}

function FillVerlustart(callback) {
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#verlustart");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "VerlustartName";
    dropdowninfo.dropdownval = "VerlustartId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";

    ajaxrequest.Type = "GET";
    ajaxrequest.URL = apiurl.verlustartsbyusertype + usertypeid;
    SendAjaxRequest(ajaxrequest, "dropdownfill", true, dropdowninfo,callback);

    //callback();
}

function FillTechnikApprovers(callback) {//Repair Approver
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#repairapprover");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "UserName";
    dropdowninfo.dropdownval = "UserId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";

    ajaxrequest.Type = "GET";
    ajaxrequest.URL = apiurl.usersbyusertype + rusetypeid
    SendAjaxRequest(ajaxrequest, "dropdownfill", true, dropdowninfo,callback);

    //callback();

}

function FillReinigungApprovers(callback) {//Cleaning Approver
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#cleaningapprover");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "UserName";
    dropdowninfo.dropdownval = "UserId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";

    ajaxrequest.Type = "GET";
    ajaxrequest.URL = apiurl.usersbyusertype + cusertypeid;
    SendAjaxRequest(ajaxrequest, "dropdownfill", true, dropdowninfo,callback);

}

function FillLocation(callback) {//Bereich
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#location");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "LocationName";
    dropdowninfo.dropdownval = "LocationId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";


    ajaxrequest.Type = "GET";
    ajaxrequest.URL = apiurl.locationsbylineusertype + lineid + "/" + usertypeid;
    SendAjaxRequest(ajaxrequest, "dropdownfill", true, dropdowninfo,callback);
    //callback()
}

function FillMachine(locationid) {//Maschine
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#machine");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "MachineName";
    dropdowninfo.dropdownval = "MachineId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";
     
    ajaxrequest.Type = "GET";
    ajaxrequest.URL = apiurl.machinesbylocation + locationid;
    SendAjaxRequest(ajaxrequest, "dropdownfill", true, dropdowninfo);

    //$("#machine").attr("disabled", false);

}

function FillModule(machineid) {//Baugruppe
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#module");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "ModuleName";
    dropdowninfo.dropdownval = "ModuleId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";

    ajaxrequest.Type = "GET";
    ajaxrequest.URL = apiurl.modulesbymachine + machineid;
    SendAjaxRequest(ajaxrequest, "dropdownfill", true, dropdowninfo);
    //$("#module").attr("disabled", false);
}

function FillComponents(moduleid) {//Komponente
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#component");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "ComponentName";
    dropdowninfo.dropdownval = "ComponentId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";

    ajaxrequest.Type = "GET";
    ajaxrequest.URL = apiurl.componentsbymodule + moduleid;
    SendAjaxRequest(ajaxrequest, "dropdownfill", true, dropdowninfo);
    //$("#component").attr("disabled", false);

}

function FillParts(componentid) {//Bauteil
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#parts");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "PartName";
    dropdowninfo.dropdownval = "PartId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";

    ajaxrequest.Type = "GET";
    ajaxrequest.URL = apiurl.partsbycomponent + componentid;
    SendAjaxRequest(ajaxrequest, "dropdownfill", true, dropdowninfo);
    //$("#parts").attr("disabled", false);
}

function FillWasteTypes() {//Ausschussart

    console.log("fillwastetypes")
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#wastetype");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "WasteTypeName";
    dropdowninfo.dropdownval = "WasteTypeId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";

    ajaxrequest.Type = "GET";
    ajaxrequest.URL = apiurl.wastetypesbyusertype + usertypeid;
    SendAjaxRequest(ajaxrequest, "dropdownfill", true, dropdowninfo);
}

function FillReasons(verlustartid) {//Verlustgrund
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#reasons");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "ReasonName";
    dropdowninfo.dropdownval = "ReasonId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";

    ajaxrequest.Type = "GET";
    ajaxrequest.URL = apiurl.reasonsbyverlustart + verlustartid;
    SendAjaxRequest(ajaxrequest, "dropdownfill", true, dropdowninfo);
}

function runFunctionWasteFirstTime(callback) {
    FillVerlustart(function () {
        FillLocation(function () {
            FillTechnikApprovers(function () {
                FillReinigungApprovers(function () {
                    FillWasteTypes();
                });
            });
        });
    });
}


function GetWastesByOrderUserType() {
    ajaxrequest.Type = "GET";
    ajaxrequest.URL = apiurl.wastedetailbyorderusertype + orderid + "/" + usertypeid;
    SendAjaxRequest(ajaxrequest, "getwastesbyorderusertype", true);
}

function ShowWasteInfo(wastedata) {
    $("#tbwasteinfo").css("display", "block");

    var strwaste = "";

    var productionstatus = wastedata.Produktionsstatus == "1" ? "Störungsfrei" : "Störung"
    var machinestart = isNullOrEmpty(wastedata.MachineStartTime) ? '-' : formatDateTime(wastedata.MachineStartTime)
    var machinestop = isNullOrEmpty(wastedata.MachineEndTime) ? '-' : formatDateTime(wastedata.MachineEndTime)
    var repairstart = isNullOrEmpty(wastedata.RepairStartTime) ? '-' : formatDateTime(wastedata.RepairStartTime)
    var repairstop = isNullOrEmpty(wastedata.RepairEndTime) ? '-' : formatDateTime(wastedata.RepairEndTime)
    var cleaningstart = isNullOrEmpty(wastedata.CleaningStartTime) ? '-' : formatDateTime(wastedata.CleaningStartTime)
    var cleaningstop = isNullOrEmpty(wastedata.CleaningEndTime) ? '-' : formatDateTime(wastedata.CleaningEndTime)

    var wastetype = wastedata.WasteType.indexOf("Auswahlen") > -1? "-" : wastedata.WasteType;
    var verlustart = wastedata.Verlustart.indexOf("Auswahlen")>-1 ? "-" : wastedata.Verlustart;
    var location = wastedata.Location.indexOf("Auswahlen") > -1 ? "-" : wastedata.Location;
    var machine = wastedata.Machine.indexOf("Auswahlen") > -1 ? "-" : wastedata.Machine;
    var module = wastedata.Module.indexOf("Auswahlen") > -1 ? "-" : wastedata.Module;
    var component = wastedata.Component.indexOf("Auswahlen") > -1 ? "-" : wastedata.Component;
    var part = wastedata.Part.indexOf("Auswahlen") > -1 ? "-" : wastedata.Part;
    var reason = wastedata.Reason.indexOf("Auswahlen") > -1 ? "-" : wastedata.Reason;
    var comments = isNullOrEmpty(wastedata.comments) ? "-" : wastedata.comments;
    var problemreason = isNullOrEmpty(wastedata.ProblemReason) ? "-" : wastedata.ProblemReason;
    var actiontaken = isNullOrEmpty(wastedata.ActionTaken) ? "-" : wastedata.ActionTaken;
    var preventivemeasure = isNullOrEmpty(wastedata.PreventiveAction) ? "-" : wastedata.PreventiveAction;


    var verlust = wastedata.Produktionsstatus == "1" ? "-" : wastedata.Verlust;

    strwaste+="<tr>"
    strwaste += "<td>" + wastedata.WasteId+"</td>"
    strwaste += "<td>" + productionstatus + "</td>"
    strwaste += "<td>" + verlust + "</td>"
    strwaste += "<td>" + machinestop + "</td>"
    strwaste += "<td>" + machinestart  +"</td>"    
    strwaste += "<td>" + cleaningstart +"</td>"
    strwaste += "<td>" + cleaningstop +"</td>"
    strwaste += "<td>" + repairstart +"</td>"
    strwaste += "<td>" + repairstop +"</td>"
    
    strwaste += "<td><input type='text' class='form-control' value='"+wastedata.WasteKg+"'></td>"
    strwaste += "<td>" + wastetype +"</td>"
    strwaste += "<td>" + verlustart +"</td>"
    strwaste += "<td>" + location +"</td>"
    strwaste += "<td>" + machine +"</td>"
    strwaste += "<td>" + module +"</td>"
    strwaste += "<td>" + component +"</td>"
    strwaste += "<td>" + part +"</td>"
    strwaste += "<td>" + reason + "</td>"
    strwaste += "<td>" + problemreason + "</td>"
    strwaste += "<td>" + actiontaken + "</td>"
    strwaste += "<td>" + preventivemeasure + "</td>"
    strwaste += "<td>" + comments +"</td>"	
    strwaste += "</tr>"

    $("#tbwasteinfo>tbody").prepend(strwaste);

    DisableWasteControlsPartially();
}

function ShowWasteInfoAll(wastedata) {
    $("#tbwasteinfo").css("display", "block");

    var strwaste = "";


    for (var i = 0; i < wastedata.length; i++) {


        var productionstatus = wastedata[i].Produktionsstatus == "1" ? "Stroungsfrei" : "Storung"
        var machinestart = isNullOrEmpty(wastedata[i].MachineStartTime) ? '-' : formatDateTime(wastedata[i].MachineStartTime)
        var machinestop = isNullOrEmpty(wastedata[i].MachineEndTime) ? '-' : formatDateTime(wastedata[i].MachineEndTime)
        var repairstart = isNullOrEmpty(wastedata[i].RepairStartTime) ? '-' : formatDateTime(wastedata[i].RepairStartTime)
        var repairstop = isNullOrEmpty(wastedata[i].RepairEndTime) ? '-' : formatDateTime(wastedata[i].RepairEndTime)
        var cleaningstart = isNullOrEmpty(wastedata[i].CleaningStartTime) ? '-' : formatDateTime(wastedata[i].CleaningStartTime)
        var cleaningstop = isNullOrEmpty(wastedata[i].CleaningEndTime) ? '-' : formatDateTime(wastedata[i].CleaningEndTime)

        var wastetype = wastedata[i].WasteType.indexOf("Auswahlen") > -1 ? "-" : wastedata[i].WasteType;
        var verlustart = wastedata[i].Verlustart.indexOf("Auswahlen") > -1 ? "-" : wastedata[i].Verlustart
        var location = wastedata[i].Location.indexOf("Auswahlen") > -1 ? "-" : wastedata[i].Location;
        var machine = wastedata[i].Machine.indexOf("Auswahlen") > -1 ? "-" : wastedata[i].Machine;
        var module = wastedata[i].Module.indexOf("Auswahlen") > -1 ? "-" : wastedata[i].Module;
        var component = wastedata[i].Component.indexOf("Auswahlen") > -1 ? "-" : wastedata[i].Component;
        var part = wastedata[i].Part.indexOf("Auswahlen") > -1 ? "-" : wastedata[i].Part;
        var reason = wastedata[i].Reason.indexOf("Auswahlen") > -1 ? "-" : wastedata[i].Reason;
        var comments = isNullOrEmpty(wastedata[i].comments) ? "-" : wastedata[i].comments;
        var problemreason = isNullOrEmpty(wastedata[i].ProblemReason) ? "-" : wastedata[i].ProblemReason;
        var actiontaken = isNullOrEmpty(wastedata[i].ActionTaken) ? "-" : wastedata[i].ActionTaken;
        var preventivemeasure = isNullOrEmpty(wastedata[i].PreventiveAction) ? "-" : wastedata[i].PreventiveAction;


        var verlust = wastedata[i].Produktionsstatus == "1" ? "-" : wastedata[i].Verlust;

        strwaste += "<tr>"
        strwaste += "<td>" + wastedata[i].WasteId + "</td>"
        strwaste += "<td>" + productionstatus + "</td>"
        strwaste += "<td>" + verlust + "</td>"
        strwaste += "<td>" + machinestop + "</td>"
        strwaste += "<td>" + machinestart + "</td>"        
        strwaste += "<td>" + cleaningstart + "</td>"
        strwaste += "<td>" + cleaningstop + "</td>"
        strwaste += "<td>" + repairstart + "</td>"
        strwaste += "<td>" + repairstop + "</td>"

        strwaste += "<td><input type='text' class='form-control' value='" + wastedata[i].WasteKg + "'></td>"
        strwaste += "<td>" + wastetype + "</td>"
        strwaste += "<td>" + verlustart + "</td>"
        strwaste += "<td>" + location + "</td>"
        strwaste += "<td>" + machine + "</td>"
        strwaste += "<td>" + module + "</td>"
        strwaste += "<td>" + component + "</td>"
        strwaste += "<td>" + part + "</td>"
        strwaste += "<td>" + reason + "</td>"
        strwaste += "<td>" + problemreason + "</td>"
        strwaste += "<td>" + actiontaken + "</td>"
        strwaste += "<td>" + preventivemeasure + "</td>"
        strwaste += "<td>" + comments + "</td>"
        strwaste += "</tr>"
    }

    $("#tbwasteinfo>tbody").append(strwaste);
}

function CreateWaste() {
    var wasterequest = new Object()
    var machineduration = 0;
    var repairduration = 0;
    var cleaningduration = 0;

    var machinestoptime = "";
    var machinestarttime = "";

    var cleaningstarttime = "";
    var cleaningstoptime = "";

    var repairstarttime = "";
    var repairstoptime = "";

    var timestartobj = null;
    var timestopobj = null;
    var timeduration = 0;

    var bunweight = parseFloat($("#bunweight").text());
    var speed = parseInt($("#speed").text());
    var pocket = parseInt($("#pockets").text());

   
    

    

    wasterequest.OrderId = orderid;
    wasterequest.UserTypeId = usertypeid;
    wasterequest.Verlust = $("#hdverlust").val();
    wasterequest.Verlustart = $("#verlustart option:selected").text();
    var cdate = InitiateTime("misc", 0, true);


    

        /*****check machine time*****/

        if ($("#machinestop").val() != "") {
            timestartobj = GetTimeInfoMachine("machinestart");
            timestopobj = GetTimeInfoMachine("machinestop");
            timeduration = GetTimeDuration(timestopobj[0].DateTime, timestartobj[0].DateTime);

            machinestoptime = timestopobj[0].DateTimeFormat;
            machinestarttime = timestartobj[0].DateTimeFormat;
            machineduration = timeduration.split('|')[1];
        }
        else {
            machinestoptime = cdate.DateTimeFormat;
            machinestarttime = cdate.DateTimeFormat;
            machineduration = 0;
        }


        /*****check repair time*****/

        if ($("#repairstart").val() != "") {
            timestartobj = GetTimeInfoWaste("repairstart");
            timestopobj = GetTimeInfoWaste("repairstop");
            timeduration = GetTimeDuration(timestartobj[0].DateTime, timestopobj[0].DateTime);

            repairstoptime = timestopobj[0].DateTimeFormat;
            repairstarttime = timestartobj[0].DateTimeFormat;
            repairduration = timeduration.split('|')[1];
        }
        else {
            repairstoptime = cdate.DateTimeFormat;
            repairstarttime = cdate.DateTimeFormat;
            repairduration = 0;
        }

        /*****clening time*****/

        if ($("#cleaningstart").val() != "") {
            timestartobj = GetTimeInfoWaste("cleaningstart");
            timestopobj = GetTimeInfoWaste("cleaningstop");
            timeduration = GetTimeDuration(timestartobj[0].DateTime, timestopobj[0].DateTime);

            cleaningstoptime = timestopobj[0].DateTimeFormat;
            cleaningstarttime = timestartobj[0].DateTimeFormat;
            cleaningduration = timeduration.split('|')[1];
        }
        else {
            cleaningstoptime = cdate.DateTimeFormat;
            cleaningstarttime = cdate.DateTimeFormat;
            cleaningduration = 0;
        }



    var wastekg = $("#wastekg").val() == "" ? 0 : $("#wastekg").val();
    var wastepieces = Math.round(((parseInt(wastekg) / bunweight) * 1000));
    var timelosspieces = parseInt(machineduration) * speed * pocket;
    
    wasterequest.MachineStartTime = machinestarttime
    wasterequest.MachineEndTime = machinestoptime;

    wasterequest.CleaningStartTime = cleaningstarttime;
    wasterequest.CleaningEndTime = cleaningstoptime;

    wasterequest.RepairStartTime = repairstarttime;
    wasterequest.RepairEndTime = repairstoptime;

    wasterequest.MachinDurationMin = machineduration;
    wasterequest.CleaningDurationMin = cleaningduration;
    wasterequest.RepairDuration = repairduration;

    wasterequest.Produktionsstatus = $("#chkprodstatus").prop("checked") ? 1 : 0;
    wasterequest.Location = $("#location option:selected").text();
    wasterequest.Machine = $("#machine option:selected").text();
    wasterequest.Module = $("#module option:selected").text();
    wasterequest.Component = $("#component option:selected").text();
    wasterequest.Part = $("#parts option:selected").text();
    wasterequest.Reason = $("#reasons option:selected").text();
    wasterequest.CleanerApproverName = $("#cleaningapprover option:selected").text();
    wasterequest.RepairApproverName = $("#repairapprover option:selected").text();

    wasterequest.WasteType = $("#wastetype option:selected").text();

    wasterequest.WasteKg = wastekg;
    wasterequest.WastePieces = wastepieces;
    wasterequest.TimelossPieces = timelosspieces
    wasterequest.comments = $("#comments").val();
    wasterequest.ProblemReason = $("#problemreason").val();
    wasterequest.ActionTaken = $("#actiontaken").val();
    wasterequest.PreventiveAction = $("#preventiveaction").val();
    wasterequest.Efficiency = efficiency;


    wasterequest.CreatedDate = cdate.DateTimeFormat;


    console.log("wasterequest")
    console.log(wasterequest)

    ajaxrequest.URL = apiurl.wastedetail;
    ajaxrequest.Type = "POST";
    ajaxrequest.PData = wasterequest;

    SendAjaxRequest(ajaxrequest, "wastecreate", hitapi.waste);

    
}

function EnableWasteControls() {
    //$("#chkprodstatus").attr("disabled", false);

    console.log("enablewastecontrols")

    $("#dvverlust").find(".form-control").attr("disabled", false);
    $("#dvmachine").find(".form-control").attr("disabled", false);
    $("button").filter(".start").attr("disabled", false);
    $("button").filter(".stop").attr("disabled", false);
    $("#btnwaste").attr("disabled", false);

    

}

function DisableWasteControlsPartially() {
    //$("#chkprodstatus").attr("disabled", false);

    console.log("enablewastecontrolsp")


    //disable all controls except start stop button
    $("#dvverlust").find(".form-control").attr("disabled", true);
    $("#dvmachine").find(".form-control").attr("disabled", true);

    //disable all start stop button
    $("button").filter(".start").attr("disabled", true);
    $("button").filter(".stop").attr("disabled", true);

    
    //set the values to initial
    $("#dvverlust").find(".form-control").val("");
    $("#dvmachine").find(".form-control").val("");


    $("#btnwaste").attr("disabled", false);
    
    //Enable only machine stop
    $("#machinestop").attr("disabled", false);
    $("#btnmachinestop").attr("disabled", false);


    $("#machinestart").attr("disabled", false);
    $("#btnmachinestart").attr("disabled", false);

    //Enable Verlustart,reason,comments,problemreason,preventivemeasure,action
    $("#verlustart").attr("disabled", false);
    $("#wastetype").attr("disabled", false);
    $("#location").attr("disabled", false);
    $("#reasons").attr("disabled", false);
    $("#comments").attr("disabled", false);
    $("#problemreason").attr("disabled", false);
    $("#actiontaken").attr("disabled", false);
    $("#preventiveaction").attr("disabled", false);

    

}


function DisableWasteControls() {

    //$("#chkprodstatus").attr("disabled", true);
    $("#dvverlust").find(".form-control").attr("disabled", true);
    $("#dvmachine").find(".form-control").attr("disabled", true);
    $("button").filter(".start").attr("disabled", true);
    $("button").filter(".stop").attr("disabled", true);
    //$("#btnwaste").attr("disabled", true);
}


function EnableTechnik() {
    

    $("#dvverlust").find(".form-control").attr("disabled", false);
    $("#dvmachine").find(".form-control").attr("disabled", false);
    $("button").filter(".start").attr("disabled", false);
    $("button").filter(".stop").attr("disabled", false);
    $("#btnwaste").attr("disabled", false);
}

function DisableTechnik() {

    $("#chkprodstatus").attr("disabled", true);
    $("#dvverlust").find(".form-control").attr("disabled", true);
    $("#dvmachine").find(".form-control").attr("disabled", true);
    $("button").filter(".start").attr("disabled", true);
    $("button").filter(".stop").attr("disabled", true);
    $("#btnwaste").attr("disabled", true);
}



function WasteCheck1(gtype) {
    var verlust = $("#hdverlust").val();//verlust/loss type
    var verlustart = $("#verlustart option:selected").text();//verlustart/breakdown




    if (verlust != "Recept/Parameter") {

        if (gtype == "machine") {

            if (verlust == "Ausschuss") {
                return true;
            }
            else {
                if (verlustart == "Technisch" || verlustart == "Produktion" || verlustart == "Reinigung") {
                    return true;
                }
            }

        }

        if (gtype == "module") {
            if (verlustart == "Technisch") {
                return true;
            }

        }

        if (gtype == "component") {
            return true;

        }

        if (gtype == "parts") {
            return true;

        }
    }
}

function ValidateStartStop() {

}

function CheckVerlustart(gval) {

    var verlust = $("#hdverlust").val();

    if (verlust == "Stillstand") {
        if (gval == "Technisch") {
            $("#cleaningstart").attr("disabled", false);
            $("#btncleaningstart").attr("disabled", false);
            $("#cleaningapprover").attr("disabled", false);


            $("#repairstart").attr("disabled", false);
            $("#btnrepairstart").attr("disabled", false);
            $("#repairapprover").attr("disabled", false);

            $("#wastekg").attr("disabled", false);

        }

        if (gval == "Reinigung") {
            $("#cleaningstart").attr("disabled", false);
            $("#btncleaningstart").attr("disabled", false);
            $("#cleaningapprover").attr("disabled", false);

            $("#repairstart").attr("disabled", true);
            $("#btnrepairstart").attr("disabled", true);
            $("#repairapprover").attr("disabled", true);
            $("#wastekg").attr("disabled", true);
        }


        if (gval != "Technisch" && gval != "Reinigung") {
            $("#cleaningstart").attr("disabled", true);
            $("#btncleaningstart").attr("disabled", true);
            $("#cleaningapprover").attr("disabled", true);

            $("#repairstart").attr("disabled", true);
            $("#btnrepairstart").attr("disabled", true);
            $("#repairapprover").attr("disabled", true);

            $("#wastekg").attr("disabled", true);
        }
    }


    if (verlust == "Ausschuss") {
        $("#wastekg").attr("disabled", false);
    }
}

function CheckVerlust(gval) {
    //$("#chkprodstatus").attr("disabled", false);

    console.log("validate verlust")


    //disable all controls except start stop button
    $("#dvverlust").find(".form-control").attr("disabled", true);
    //$("#dvmachine").find(".form-control").attr("disabled", true);

    //disable all start stop button
    $("button").filter(".start").attr("disabled", true);
    $("button").filter(".stop").attr("disabled", true);

    $("#machinestart").attr("disabled", $("#machinestart").prop("disabled") == true ? true :false);
    $("#btnmachinestart").attr("disabled", $("#machinestart").prop("disabled") == true ? true : false);
    $("#machinestop").attr("disabled", $("#machinestop").prop("disabled") == true ? true : false);
    $("#btnmachinestop").attr("disabled", $("#machinestop").prop("disabled") == true ? true : false);

    //set the values to initial
    $("#dvverlust").find(".form-control").val("");
    


    $("#btnwaste").attr("disabled", false);

     

    //Enable Verlustart,reason,comments,problemreason,preventivemeasure,action
    $("#verlustart").attr("disabled", false);
    $("#wastetype").attr("disabled", false);
    $("#location").attr("disabled", false);
    $("#reasons").attr("disabled", false);
    $("#comments").attr("disabled", false);
    $("#problemreason").attr("disabled", false);
    $("#actiontaken").attr("disabled", false);
    $("#preventiveaction").attr("disabled", false);

    if (gval == "Recept/Parameter") {
        $("#verlustart").attr("disabled", true);
        $("#wastetype").attr("disabled", true);
        $("#reasons").attr("disabled", true);
    }

}


function ValidateWaste() {

    var prodstatus = $("#chkprodstatus")

    var verlust = $("#hdverlust");//verlust/loss type
    var verlustart = $("#verlustart option:selected").text();//verlustart/breakdown
    //productionstatus = document.getElementById("ctl00_content1_lblProductionID");
    var machinestart = $("#machinestart");
    var machineend = $("#machinestop");
    var cleaningstart = $("#cleaningstart");
    var cleaningend = $("#cleaningstop");
    var repairstart = $("#repairstart");
    var repairend = $("#repairstop");
    var wastekg = $("#wastekg");
    var wastetype = $("#wastetype");


    var glocation = $("#location");
    var machine = $("#machine");
    var module = $("#module");
    var component = $("#component");
    var parts = $("#parts");
    var reason = $("#reasons");
    var comments = $("#comments");



    if (prodstatus.prop("checked") == false) {

        if (machineend.prop("disabled") == false) {
            if (machineend.val() == "") {
                bootbox.alert("Bitte den Stillstand / die Unterbrechung der Maschine beenden");
                machineend.focus();
                return false;
            }
        }

        if (verlust.val() !="Recept/Parameter") {
            if (verlustart == "--Auswahlen--") {
                bootbox.alert("Bitte ein Ausschuss auswählen");
                $("#verlustart").focus()
                return false;

            }
        }



        if (verlustart == "Technisch") {

            if (cleaningstart.prop("disabled") == false && repairstart.prop("disabled") == false) {
                if (cleaningstart.val() == "" || repairstart.val() == "") {
                    bootbox.alert("Bitte die Reinigungs / Reparaturzeit starten");
                    cleaningstart.focus();
                    return false;
                }
            }



            if (glocation.prop("disabled") == false) {
                if (glocation.val() == "") {
                    bootbox.alert("Bitte einen Bereich auswählen");
                    glocation.focus()
                    return false;

                }
            }

            if (machine.prop("disabled") == false) {
                if (machine.val() == "") {
                    bootbox.alert("Bitte eine Maschine auswählen");
                    machine.focus()
                    return false;

                }
            }

            if (module.prop("disabled") == false) {
                if (module.val() == "") {
                    bootbox.alert("Bitte eine Baugruppe auswählen");
                    module.focus()
                    return false;

                }
            }

            if (component.prop("disabled") == false) {
                if (component.val() == "") {
                    bootbox.alert("Bitte eine Komponente auswählen");
                    component.focus()
                    return false;

                }
            }

            if (parts.prop("disabled") == false) {
                if (parts.val() == "") {
                    bootbox.alert("Bitte ein Bauteil auswählen");
                    parts.focus()
                    return false;
                     
                }
            }

            if (repairend.prop("disabled") == false) {
                if (repairstart.val() != "") {
                    if (repairend.val() == "") {
                        bootbox.alert("Bitte die Reparaturzeit stoppen");
                        repairend.focus();
                        return false;
                    }
                }
            }


            if (cleaningend.prop("disabled") == false) {
                if (cleaningstart.val() != "") {
                    if (cleaningend.val() == "") {
                        bootbox.alert("Bitte die Reinigungszeit stoppen");
                        cleaningend.focus();
                        return false;
                    }
                }
            }


            if (verlust.val() == "Stillstand") {
                if (wastekg.val() == "") {
                    bootbox.alert("Bitte die Ausschussmenge eingeben");
                    wastekg.focus();
                    return false;
                }
            }


        }

        if (verlustart != "Technisch") {

            if (glocation.prop("disabled") == false) {
                if (glocation.val() == "") {
                    bootbox.alert("Bitte einen Bereich auswählen");
                    glocation.focus()
                    return false;

                }
            }

            if (machine.prop("disabled") == false) {
                if (machine.val() == "") {
                    bootbox.alert("Bitte eine Maschine auswählen");
                    machine.focus()
                    return false;

                }
            }


        }


        if (verlustart == "Reinigung") {



            if (cleaningstart.prop("disabled") == false) {
                if (cleaningstart.val() == "") {
                    bootbox.alert("Bitte die Reinigungs / Reparaturzeit starten");
                    cleaningstart.focus();
                    return false;
                }
            }

        }



        if (verlust.val() != "Recept/Parameter") {

            if (wastetype.prop("disabled") == false) {
                if (wastetype.val() == "") {
                    bootbox.alert("Bitte eine Ausschussart auswählen");
                    wastetype.focus()
                    return false;

                }
            }
        }



        if (wastekg.prop("disabled") == false) {
            if (wastekg.val() == "") {
                bootbox.alert("Bitte den Ausschussmenge betreten");
                wastekg.focus();
                return false;
            }
            //else {
            //    var chkstr = CheckNum(wastekg.val(), 'Ausschussmenge');
            //    if (chkstr == false) {
            //        wastekg.focus();
            //        return false;
            //    }
            //}
        }


        if (verlust.val() != "Recept/Parameter") {
            if (reason.prop("disabled") == false) {
                if (reason.val() == "") {
                    bootbox.alert("Bitte eine Verlustgrund auswählen");
                    reason.focus()
                    return false;

                }
            }
        }

        //comments1 = removeSpaces(comments.val())

        if (verlustart == "Reinigung") {
            if (cleaningend.prop("disabled") == false) {
                if (cleaningstart.val() != "") {
                    if (cleaningend.val() == "") {
                        bootbox.alert("Bitte die Reinigungs / Reparaturzeit stoppen");
                        cleaningend.focus();
                        return false;
                    }
                }
            }
        }

        if (machinestart.prop("disabled") == false) {
            if (machinestart.val() == "") {
                bootbox.alert("Bitte den Stillstand / die Unterbrechung der Maschine starten");
                machinestart.focus();
                return false;
            }
        }


    }


    var gpstatus = prodstatus.prop("checked") == true ? '1' : '0';
    efficiency = verlust.val() == "Ausschuss" ? '1' : '0';

    if (verlust.val() == "Recept/Parameter") {
        efficiency = "3";
    }

    if (gpstatus == "1") {
        efficiency = "2";
    }

    return true;
}


function MachineStop() {
    var timeinfo = InitiateTime("machinestop", 0)
    $("#machinestop").val(timeinfo.TimeDisplay);
    $("#machinestop").attr("disabled", true);
    $(this).attr("disabled", true);

    machinestartstopArry.push(timeinfo);

    $("#machinestart").attr("disabled", false);
    $("#btnmachinestart").attr("disabled", false);
}

function MachineStart() {

    if ($("#machinestop").val() == "") {
        bootbox.alert("Bitte den Stillstand / die Unterbrechung der Maschine beenden");
        return false;
    }

    var timeinfo = InitiateTime("machinestart", 0)
    $("#machinestart").val(timeinfo.TimeDisplay);
    $("#machinestart").attr("disabled", true);
    $(this).attr("disabled", true);
    machinestartstopArry.push(timeinfo);
}



$(document).ready(function () {

    //Fill Verlustart,location,Cleaning and Repair Approver
    //runFunctionWasteFirstTime(function () {
    //    console.log("waste first functions called")
    //});


    //Calling Product Status event

    $("#chkprodstatus").click(function () {

        console.log("prodstatus clicked")
        console.log($(this).prop("checked"))

        if ($(this).prop("checked")) {//if prodstatus checked then disable all fields

            
            DisableWasteControls();

            $("#machinestart").val("");
            $("#machinestop").val("");

            $("#btnwaste").attr("disabled", false);//enable the waste submit button
            

        }
        else {
            DisableWasteControlsPartially();
        }
    })

    /******Verlust***********/

    $(".verlust").click(function () {

        $(".verlust").removeClass("active");
        $(this).addClass("active");

        $("#hdverlust").val($(this).text());

        CheckVerlust($(this).text())

        //if ($(this).prop("checked") == true) {
            
        //}
    })

    /***********Machine Start Stopt************/
    $("#btnmachinestop").click(function () {
       
        MachineStop();
    });

    $("#btnmachinestart").click(function () {

        MachineStart();
        
    });

    /***********Technik Start Stopt************/
    $("#btnrepairstart").click(function () {
        var timeinfo = InitiateTime("repairstart", 0)
        $("#repairstart").val(timeinfo.TimeDisplay);
        $("#repairstart").attr("disabled", true);
        $(this).attr("disabled", true);
        wastestartstopArry.push(timeinfo);

        $("#repairstop").attr("disabled", false);
        $("#btnrepairstop").attr("disabled", false);
    });

    $("#btnrepairstop").click(function () {
        var timeinfo = InitiateTime("repairstop", 0)
        $("#repairstop").val(timeinfo.TimeDisplay);
        $("#repairstop").attr("disabled", true);
        $(this).attr("disabled", true);
        wastestartstopArry.push(timeinfo);
    });


    /***********Reinigung Start Stopt************/
    $("#btncleaningstart").click(function () {
        var timeinfo = InitiateTime("cleaningstart", 0)
        $("#cleaningstart").val(timeinfo.TimeDisplay);
        $("#cleaningstart").attr("disabled", true);
        $(this).attr("disabled", true);
        wastestartstopArry.push(timeinfo);
        $("#cleaningstop").attr("disabled", false);
        $("#btncleaningstop").attr("disabled", false);
    });

    $("#btncleaningstop").click(function () {
        var timeinfo = InitiateTime("cleaningstop", 0)
        $("#cleaningstop").val(timeinfo.TimeDisplay);
        $("#cleaningstop").attr("disabled", true);
        $(this).attr("disabled", true);
        wastestartstopArry.push(timeinfo);
    });


    $("#location").change(function () {

        if (WasteCheck1("machine")) {
            var locationid = $(this).val();
            FillMachine(locationid);
        }
    })

    $("#machine").change(function () {
        if (WasteCheck1("module")) {
            var machineid = $(this).val();
            FillModule(machineid);
        }
    })

    $("#module").change(function () {

        if (WasteCheck1("component")) {
            var moduleid = $(this).val();
            FillComponents(moduleid)
        }
    })

    $("#component").change(function () {

        if (WasteCheck1("parts")) {
            var componentid = $(this).val();
            FillParts(componentid)
        }
    })

    $("#verlustart").change(function () {

        var verlustarttext = $("#verlustart option:selected").text();
        CheckVerlustart(verlustarttext)
        var verlustartid = $(this).val();
        FillReasons(verlustartid);
        //DisableWasteControlsPartially();

        //$(this).val($(this).val())
    })


    $("#btnwaste").click(function () {

        var vstatus = ValidateWaste()

        if (vstatus == true) {
            CreateWaste();
        }
    })

    $(document).keydown(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        var prodstatus = $("#chkprodstatus")


        if (prodstatus.prop("checked") == false) {
            if (keycode == '119') {//f8

                if ($("#btnmachinestop").prop("disabled") == false) {
                    MachineStop();
                }

            }

            if (keycode == '120') {//f9
                if ($("#btnmachinestop").prop("disabled") == false) {
                    MachineStart();
                }
            }
        }
               
    });

})