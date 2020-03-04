var cusertypeid = 3;
var rusetypeid = 4;


function FillVerlustart(callback) {
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#verlustart");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "VerlustartName";
    dropdowninfo.dropdownval = "VerlustartId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";


    ajaxrequest.URL = apiurl.verlustartsbyusertype + usertypeid;
    SendAjaxRequest(ajaxrequest, "dropdownfill", true, dropdowninfo);

    callback();
}

function FillTechnikApprovers(callback) {//Repair Approver
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#repairapprover");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "UserName";
    dropdowninfo.dropdownval = "UserId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";

    ajaxrequest.URL = apiurl.usersbyusertype + rusetypeid
    SendAjaxRequest(ajaxrequest, "dropdownfill", true, dropdowninfo);

    callback();

}

function FillReinigungApprovers() {//Cleaning Approver
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#cleaningapprover");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "UserName";
    dropdowninfo.dropdownval = "UserId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";

    ajaxrequest.URL = apiurl.usersbyusertype + cusertypeid;
    SendAjaxRequest(ajaxrequest, "dropdownfill", true, dropdowninfo);

}

function FillLocation(callback) {//Bereich
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#location");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "LocationName";
    dropdowninfo.dropdownval = "LocationId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";


    
    ajaxrequest.URL = apiurl.locationsbylineusertype + lineid + "/" + usertypeid;
    SendAjaxRequest(ajaxrequest, "dropdownfill", true, dropdowninfo);
    callback()
}

function FillMachine(locationid) {//Maschine
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#machine");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "MachineName";
    dropdowninfo.dropdownval = "MachineId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";

    ajaxrequest.URL = apiurl.machinesbylocation + locationid;
    SendAjaxRequest(ajaxrequest, "dropdownfill", true, dropdowninfo);

}

function FillModule(machineid) {//Baugruppe
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#module");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "ModuleName";
    dropdowninfo.dropdownval = "ModuleId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";

    ajaxrequest.URL = apiurl.modulesbymachine + machineid;
    SendAjaxRequest(ajaxrequest, "dropdownfill", true, dropdowninfo);
}

function FillComponents(moduleid) {//Komponente
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#component");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "ComponentName";
    dropdowninfo.dropdownval = "ComponentId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";

    ajaxrequest.URL = apiurl.componentsbymodule + moduleid;
    SendAjaxRequest(ajaxrequest, "dropdownfill", true, dropdowninfo);

}

function FillParts(componentid) {//Bauteil
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#parts");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "PartName";
    dropdowninfo.dropdownval = "PartId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";

    ajaxrequest.URL = apiurl.partsbycomponent + componentid;
    SendAjaxRequest(ajaxrequest, "dropdownfill", true, dropdowninfo);
}

function FillWasteTypes() {//Ausschussart
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#wastetype");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "WasteTypeName";
    dropdowninfo.dropdownval = "WasteTypeId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";

    ajaxrequest.URL = apiurl.wastetypesbyusertype + userid;
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

    ajaxrequest.URL = apiurl.reasonsbyverlustart + verlustartid;
    SendAjaxRequest(ajaxrequest, "dropdownfill", true, dropdowninfo);
}

function runFunctionWasteFirstTime(callback) {
    FillVerlustart(function () {
        FillLocation(function () {
            FillTechnikApprovers(function () {
                FillReinigungApprovers()
            });
        });
    });
}

function ShowWasteInfo(wastedata) {
    $("#tbwasteinfo").css("display", "block");

    var strwaste = "";

    var productionstatus = wastedata.Produktionsstatus == "1" ? "Stroungsfrei" : "Storung"
    var machinestart = isNullOrEmpty(wastedata.MachineStartTime) ? '-' : wastedata.MachineStartTime
    var machinestop = isNullOrEmpty(wastedata.MachineEndTime) ? '-' : wastedata.MachineEndTime
    var repairstart = isNullOrEmpty(wastedata.RepairStartTime) ? '-' : wastedata.RepairStartTime
    var repairstop = isNullOrEmpty(wastedata.RepairEndTime) ? '-' : wastedata.RepairEndTime
    var cleaningstart = isNullOrEmpty(wastedata.CleaningStartTime) ? '-' : wastedata.CleaningStartTime
    var cleaningstop = isNullOrEmpty(wastedata.CleaningEndTime) ? '-' : wastedata.CleaningEndTime

    var wastetype = isNullOrEmpty(wastedata.WasteType) ? "-" : wastedata.WasteType;
    var verlustart = isNullOrEmpty(wastedata.Verlustart) ? "-" : wastedata.Verlustart;
    var location = wastedata.Location.indexOf("Auswahlen") > -1 ? "-" : wastedata.Location;
    var machine = wastedata.Machine.indexOf("Auswahlen") > -1 ? "-" : wastedata.Machine;
    var module = wastedata.Module.indexOf("Auswahlen") > -1 ? "-" : wastedata.Module;
    var component = wastedata.Component.indexOf("Auswahlen") > -1 ? "-" : wastedata.Component;
    var part = wastedata.Part.indexOf("Auswahlen") > -1 ? "-" : wastedata.Part;
    var reason = wastedata.Reason.indexOf("Auswahlen") > -1 ? "-" : wastedata.Reason;
    var comments = isNullOrEmpty(wastedata.comments) ? "-" : wastedata.comments;

    strwaste+="<tr>"
    strwaste += "<td>" + wastedata.OrderId+"</td>"
    strwaste += "<td>" + productionstatus + "</td>"
    strwaste += "<td>" + wastedata.Verlust + "</td>"
    strwaste += "<td>" + machinestart  +"</td>"
    strwaste += "<td>" + machinestop +"</td>"
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
    strwaste += "<td>" + reason +"</td>"
    strwaste += "<td>" + comments +"</td>"	
    strwaste += "</tr>"

    $("#tbwasteinfo>tbody").prepend(strwaste);
}

function CreateWaste() {
    var wasterequest = new Object()

    wasterequest.OrderId = orderid;
    wasterequest.UserTypeId = usertypeid;
    wasterequest.Verlust = $("#hdverlust").val();
    wasterequest.Verlustart = $("#verlustart").val();
    var cdate = InitiateTime()

    if ($("#chkprodstatus").prop("checked") == false) {

        var machineendtime = cdate.DateTimeFormat;
        var machinestarttime = cdate.DateTimeFormat;
        var cleaningstarttime = cdate.DateTimeFormat;
        var cleaningstoptime = cdate.DateTimeFormat;
        var repairstarttime = cdate.DateTimeFormat;
        var repairstoptime = cdate.DateTimeFormat;
    }


    wasterequest.MachineStartTime = machinestarttime
    wasterequest.MachineEndTime = machineendtime;

    wasterequest.CleaningStartTime = cleaningstarttime;
    wasterequest.CleaningEndTime = cleaningstoptime;

    wasterequest.RepairStartTime = repairstarttime;
    wasterequest.RepairEndTime = repairstoptime;

    wasterequest.MachinDurationMin = 0;
    wasterequest.CleaningDurationMin = 0;
    wasterequest.RepairDuration = 0;
    wasterequest.Produktionsstatus = $("#chkprodstatus").prop("checked") ? 1 : 0;
    wasterequest.Location = $("#location option:selected").text();
    wasterequest.Machine = $("#machine option:selected").text();
    wasterequest.Module = $("#module option:selected").text();
    wasterequest.Component = $("#component option:selected").text();
    wasterequest.Part = $("#parts option:selected").text();
    wasterequest.Reason = $("#reasons option:selected").text();
    wasterequest.CleanerApproverName = $("#cleaningapprover").val();
    wasterequest.RepairApproverName = $("#repairapprover").val();

    wasterequest.WasteType = $("#wastetype").val();

    wasterequest.WasteKg = $("#wastekg").val() == "" ? 0 : $("#wastekg").val();
    wasterequest.WastePieces = $("#wastekg").val() == "" ? 0 : $("#wastekg").val();;
    wasterequest.TimelossPieces = $("#wastekg").val() == "" ? 0 : $("#wastekg").val();;
    wasterequest.comments = $("#repairapprover").val();
    wasterequest.ProblemReason = $("#repairapprover").val();
    wasterequest.ActionTaken = $("#repairapprover").val();
    wasterequest.PreventiveAction = $("#repairapprover").val();


    wasterequest.CreatedDate = cdate.DateTimeFormat;


    console.log("wasterequest")
    console.log(wasterequest)

    ajaxrequest.URL = apiurl.wastedetail;
    ajaxrequest.Type = "POST";
    ajaxrequest.PData = wasterequest;

    SendAjaxRequest(ajaxrequest, "wastecreate", hitapi.waste);
}


$(document).ready(function () {

    //Fill Verlustart,Location,Cleaning and Repair Approver
    //runFunctionWasteFirstTime(function () {
    //    console.log("waste first functions called")
    //});


    //Calling Product Status event

    $("#chkprodstatus").click(function () {

        console.log("prodstatus clicked")
        console.log($(this).prop("checked"))

        if ($(this).prop("checked")) {//if prodstatus checked then disable all fields

            $("#dvverlust").find(".form-control").attr("disabled", true);
            $("#dvmachine").find(".form-control").attr("disabled", true);
            $("button").filter(".start").attr("disabled", true);
            $("button").filter(".stop").attr("disabled", true);
            

        }
        else {
            $("#dvverlust").find(".form-control").attr("disabled", false);
            $("#dvmachine").find(".form-control").attr("disabled", false);
            $("button").filter(".start").attr("disabled", false);
            $("button").filter(".stop").attr("disabled", false);
        }
    })

    /******Verlust***********/

    $(".verlust").click(function () {

        $(".verlust").removeClass("active");
        $(this).addClass("active");

        if ($(this).prop("checked") == true) {
            $("#hdverlust").val($(this).text());
        }
    })

    /***********Machine Start Stopt************/
    $("#btnmachinestop").click(function () {

    });

    $("#btnmachinestart").click(function () {

    });


    $("#location").change(function () {
        var locationid = $(this).val();
        FillMachine(locationid);
    })

    $("#machine").change(function () {
        var machineid = $(this).val();
        FillModule(machineid);
    })

    $("#module").change(function () {
        var modleid = $(this).val();
        FillComponents(moduleid)
    })

    $("#component").change(function () {
        var componentid = $(this).val();
        FillParts(componentid)
    })

    $("#verlustart").change(function () {
        var verlustartid = $(this).val();
        FillReasons(verlustartid);
    })


    $("#btnwaste").click(function () {
        CreateWaste();
    })

})