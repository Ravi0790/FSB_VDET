//daily production

function GetProductsByLine(objdropdown,lineid) {

    //var lineid = $("#line").val();

    ajaxrequest.URL = apiurl.productsbylineusertype + lineid + "/1";
    console.log("product request")
    console.log(ajaxrequest);

    SendAjaxRequest(ajaxrequest, "dropdownfill", hitapi.lines, objdropdown);

    //callback()


}




$("#line").change(function () {
    
    $("#linename").val($(this).find("option:selected").text())

    var dropdowninfo = new Object();
    var lineid = $("#line").val();
    dropdowninfo.controlobj = $("#product");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "ProductName"
    dropdowninfo.dropdownval = "ProductId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";
   // dropdowninfo.isconcatetext = 1;
   // dropdowninfo.concatetext = "ProductDesc";

    GetProductsByLine(dropdowninfo, lineid);

})


function SetProductValues(product) {
    //console.log("productid",product.ProductId)
    //$("#product").val(product.ProductId)
    $("#proddesc").text(product.ProductDesc);
    $("#prodcountry").text(product.ProductCountry);
    $("#hdproddesc").val(product.ProductDesc);
    $("#hdprodcountry").val(product.ProductCountry);
    
}

$("#product").change(function () {
    var gbakerydetail = JSON.parse(localStorage.getItem("bakeryinfo"));
    var productid = $(this).val();

    $("#productname").val($(this).find("option:selected").text())


    selectedproductinfo = gbakerydetail.ProductInfo.filter((product) => product.ProductId == productid);

    SetProductValues(selectedproductinfo[0])


})    

function fnSuccess(data) {
   // console.log(data);
    $(".form-control").val("");
    bootbox.alert("Record submitted successfully");
}

var arrDailyProd = [];

function fnSuccessEdit(data) {
     console.log(data);
   // $(".form-control").val("");
   // bootbox.alert("Record submitted successfully");


    arrDailyProd = null;
    arrDailyProd = data;
    ShowSearchData(arrDailyProd);
   
}

function ShowSearchData(data) {
    $("#tblDaily > tbody").empty();
    var str = "";

    for (var i = 0; i < data.length; i++) {

        var pdate = getdateformat(data[i].PDate);
        str += "<tr>";
        str += "<td>" + pdate + "</td>";
        str += "<td><a class='redLink font-weight-bold porder' style='cursor: pointer; text-decoration: underline' >" + data[i].Id + "</a></td>";
        str += "<td>" + data[i].ProductName + "</td>";
        str += "<td class='sm'>" + data[i].ProductDesc + "</td>";
        str += " <td class='sm'>" + data[i].ProductCountry + "</td>";
        str += " <td>" + data[i].Line + "</td>";
        str += "</tr>";
    }

    $("#tblDaily > tbody").append(str);
}
$(document).on('click','.porder', function () {
    var porderid = $(this).text();
    var objdailyprod = arrDailyProd.filter(x => x.Id == porderid);
    console.log("orderid", objdailyprod);
    var pdate = getdateformat(objdailyprod[0].PDate);
    var dropdowninfo = new Object();

    dropdowninfo.controlobj = $("#ddlProduct");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = objdailyprod[0].ProductName;// "ProductName"
    dropdowninfo.dropdownval = objdailyprod[0].ProductId;//"ProductId";
    //dropdowninfo.dropdownname = $("#ddlProduct");
    dropdowninfo.selectedval = objdailyprod[0].ProductId;

    console.log("dropdownname,dropdown value:", dropdowninfo.dropdownname + "," + dropdowninfo.selectedval);
   // GetProductsByLine(dropdowninfo, objdailyprod.LineId);
   
    $("#dvedit").show();
    $(".editform").show();
    FillUpdateForm(objdailyprod);

})

  
function FillUpdateForm(objdailyprod) {

   
    var pdate = getdateformat(objdailyprod[0].PDate);
    $("#txtDate").val(pdate);
    $("#txtId").val(objdailyprod[0].Id);
    $("#txtStarttime").val(objdailyprod[0].StartTime);
    $("#txtEndtime").val(objdailyprod[0].EndTime);
    $("#txtUmrusten").val(objdailyprod[0].Umrusten);
    $("#txtReinigung").val(objdailyprod[0].Reinigung);
    $("#txtTechnische").val(objdailyprod[0].Technische);
    $("#txtProduktion").val(objdailyprod[0].Produktion);
    $("#txtMenge").val(objdailyprod[0].Menge);
    $("#txtAuschuss").val(objdailyprod[0].Auschuss);
    $("#txtBrotchen").val(objdailyprod[0].Brötchen);
    $("#ddlLine").val(objdailyprod[0].LineId);
    //$("#ddlProduct").val(objdailyprod[0].ProductId);
    // $("#txtProddesc").find("option:selected").val = objdailyprod[0].ProductName;

    $('<option/>').val(objdailyprod[0].ProductId).html(objdailyprod[0].ProductName).appendTo('#ddlProduct');
    $("#txtProddesc").text(objdailyprod[0].ProductDesc);
    $("#txtProdcount").text(objdailyprod[0].ProductCountry);
    //Assigning Value to Hidden Field
    $("#hdproddescedit").val(objdailyprod[0].ProductDesc);
    $("#hdprodcountryedit").val(objdailyprod[0].ProductCountry);
    $("#linename1").val(objdailyprod[0].Line);
    $("#productname1").val(objdailyprod[0].ProductName);

    // console.log("textbox value", dob);
    //Fill TextBox


    //$.ajax(
    //    {
    //        type: "POST", //HTTP POST Method
    //        url: "DailyProduction/EditEmp", // Controller/View 
    //        data: { //Passing data
    //            Id: porderid //Reading text box values using Jquery 

    //        }

    //    });

    console.log("this is object", objdailyprod);
}


function fnFailure(data) {
    alert("Failure")
}
function fnFailureEdit(data) {
    console.log(data);
}

$(".tab").click(function () {

    var id = $(this).attr("aval");

    $(".tab").removeClass("active");
    $(this).addClass("active");
    $(".editform").hide();
    $(".dailyform").hide();
    $(".dailyform").eq(id).show();
})
$("#editsearch").click(function () {

    $(".gridlist").show();
    
})

//For Edit Page
$("#ddlLine").change(function () {


    
    $("#linename1").val($(this).find("option:selected").text())

    var dropdowninfo = new Object();
    var lineid = $("#ddlLine").val();
    dropdowninfo.controlobj = $("#ddlProduct");
    dropdowninfo.objdata = "";
    dropdowninfo.dropdowntext = "ProductName"
    dropdowninfo.dropdownval = "ProductId";
    dropdowninfo.dropdownname = "";
    dropdowninfo.selectedval = "";
    // dropdowninfo.isconcatetext = 1;
    // dropdowninfo.concatetext = "ProductDesc";

    GetProductsByLine(dropdowninfo, lineid);

})
function SetProductValuesEdit(product) {
    //console.log("productid",product.ProductId)
    //$("#product").val(product.ProductId)
    $("#txtProddesc").text(product.ProductDesc);
    $("#txtProdcount").text(product.ProductCountry);
    $("#hdproddescedit").val(product.ProductDesc);
    $("#hdprodcountryedit").val(product.ProductCountry);

}
$("#ddlProduct").change(function () {
    var gbakerydetail = JSON.parse(localStorage.getItem("bakeryinfo"));
    var productid = $(this).val();
    $("#productname1").val($(this).find("option:selected").text())

    selectedproductinfo = gbakerydetail.ProductInfo.filter((product) => product.ProductId == productid);

    SetProductValuesEdit(selectedproductinfo[0])


}) 
function fnSuccessEditEmp(data) {
   
    //$(".form-control").val("");
    
    bootbox.alert("Record submitted successfully");
    var objdaily = new Object();
    objdaily.CDate = $("#CDate").val();
    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "DailyProduction/Edit", // Controller/View 
            data: objdaily,
            success: function (data, status, xhr) {// success callback function
                console.log("Data");
                console.log(data);
                arrDailyProd = null;
                arrDailyProd = data;
                ShowSearchData(arrDailyProd);            }

        });

}
function fnFailureEditEmp(data) {
    alert("Failure")
}
//Edit Page Method end here
function getdateformat(datepara) {
    var rdate = new Date(parseInt(datepara.substr(6)));
    
    var rmonth = rdate.getMonth() + 1;
    var ryear = rdate.getFullYear();
    var rday = rdate.getDate();
    var finaldate = rmonth + "/" + rday + "/" + ryear;
    return finaldate;
}