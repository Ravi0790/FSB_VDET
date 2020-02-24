var prodstartdatetime = "";
var prodenddatetime = "";
var starthour = "";

function checktime() {

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

    var timeDiff = Math.abs(prodstartdatetime - enddatetime);

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

    console.log("Time Diff- " + hh + ":" + mm + ":" + ss);

    $("#endtime").text(endtime);
    $("#duration").text(hh + ":" + mm);
    var durationinmin = parseInt(hh) * 60 + parseInt(mm);
    $("#durationmin").text("(" + durationinmin+" mins)")

}


$(document).ready(function () {

        $(document).ajaxStart(function () {
            $(".fixedLoaderWrap").show()
        });

        $(document).ajaxComplete(function () {
            $(".fixedLoaderWrap").hide()
        });




    var lineid = $("#lineid").val();
    var usertypeid = $("#usertypeid").val();
    ajaxrequest.URL = apiurl.lines + lineid;
    SendAjaxRequest(ajaxrequest, "linebyid", hitapi.lines);

    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#product");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "ProductName";
    dropdowninfo.dropdownval = "ProductId";
    dropdowninfo.dropdownname = "Product";
    dropdowninfo.selectedval = "";

    ajaxrequest.URL = apiurl.productsbylineusertype + lineid + "/" + usertypeid;

    SendAjaxRequest(ajaxrequest, "dropdownfill", hitapi.lines, dropdowninfo);


    $("#product").change(function () {
        var bakerydetail = JSON.parse(localStorage.getItem("bakeryinfo"));
        var productid = $(this).val();

        //var productinfo = bakerydetail.ProductInfo.filter(function (product) {
        //    return product.ProductId == productid;
        //});

        var productinfo = bakerydetail.ProductInfo.filter((product) => product.ProductId == productid);

        console.log(productinfo);

        $("#proddesc").text(productinfo[0].ProductDesc);
        $("#doughtweight").text(productinfo[0].DoughWeight);

        $("#bunweight").text(productinfo[0].BunWeight);
        $("#cutperminute").text(productinfo[0].CutPerMinute);

        
    })

    
    function ValidateOrder(){
        var product = $("#product");
        var sapnumber = $("#sapnumber");

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

        return true;

    }
    

    function ShowVolumes() {
        var strvoltr = "";
        var currenthour = parseInt(starthour);

        for (var i = 1; i <= 8; i++) {

            var nexthour = currenthour + i;

            currenthour = nexthour == 24 ? 0 : currenthour;

            console.log("nexthour",nexthour)
            console.log("currenthour", currenthour);
            strvoltr += "<tr>"
            strvoltr += "<td class='text-left font-weight-bold pl-4' > "+nexthour+": 00</td>"
            strvoltr += "<td class='text-right'>-</td> "
            strvoltr += "<td class='text-right'>-</td> "
            strvoltr += "<td class='text-right pr-4'>-</td> "
            strvoltr += "</tr>"
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


    $("#btnstart").click(function () {

        var ordervalid = ValidateOrder();

        if (ordervalid) {

            var d = new Date();
            starthour = d.getHours()
            var startmin = d.getMinutes();
            var startyear = d.getFullYear();
            var startmonth = d.getMonth();
            var rightmonth = parseInt(startmonth) + 1;
            var startdate = d.getDate();


            prodstarttime = rightmonth + "/" + startdate + "/" + startyear + " " + starthour + ":" + startmin;
            $("#prodstarttime").val(prodstarttime);

            prodstartdatetime = prodstartdatetime != "" ? prodstartdatetime : new Date(startyear, startmonth, startdate, starthour, startmin);
            console.log("prodstartdatetime")
            console.log(prodstartdatetime);

            var curtime = starthour + ":" + startmin;
            //var durationinhours = parseInt(curhour) * 60 + parseInt(curmin);



            $("#starttime").text(curtime);
            $("#endtime").text(curtime);
            $("#duration").text("00:00");
            $("#durationmin").text("(0 mins)")

            setInterval(checktime, 3000);
            
            $(this).addClass("btn-disabled");

            $("#btnend").removeClass("btn-disabled");        

            
            
            $(this).attr("disabled", true);
            $("#product").attr("disabled", true);
            $("#sapnumber").attr("disabled", true);
            $("#btnend").attr("disabled", false);

            ShowVolumes();
            CreateOrder();
        }
    })


    
})