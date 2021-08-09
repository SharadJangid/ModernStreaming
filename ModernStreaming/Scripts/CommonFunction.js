
var getMonths = {};
getMonths["01"] = "Jan";
getMonths["02"] = "Feb";
getMonths["03"] = "Mar";
getMonths["04"] = "Apr";
getMonths["05"] = "May";
getMonths["06"] = "Jun";
getMonths["07"] = "Jul";
getMonths["08"] = "Aug";
getMonths["09"] = "Sep";
getMonths["10"] = "Oct";
getMonths["11"] = "Nov";
getMonths["12"] = "Dec";

// status change event
$(document).ready(function () {

    $(document).on('keypress', function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            if ($("#txtSearch").is(":focus")) {
                $('#btnSearch').click();
            }
        }
    });

    $('.status').change(function () {
        ajaxCallFilterAndStatus();

    });

    //when search button clicked
    $("#btnSearch").on("click", function (e) {
        $('.loading').show();
        ajaxCallFilterAndStatus();
    });

    //when refresh button clicked
    $('#btnRefresh').on('click', function () {
        $('.loading').show();
        window.location.reload();
    })

    // if dropdown is present 
    $('.dropdown').on("change", function () {
        $('.loading').show();
        ajaxCallFilterAndStatus();

    });

    function ajaxCallFilterAndStatus() {

        var status = "";
        var search = "";
        var dropdownid = "";

        // If Status Filter is present on the page
        if ($(".status").length) {
            if (($("#customCheck1").is(":checked")) == true && ($("#customCheck2").is(":checked")) == false) {
                status = "1";
            }
            else if (($("#customCheck1").is(":checked")) == false && ($("#customCheck2").is(":checked")) == true) {
                status = "2";
            }
            else {
                status = "0";
            }

        }

        // If Search Fitler is present
        if ($('#txtSearch').length) {
            if ($('#txtSearch').val() != "") {
                search = $('#txtSearch').val();
            }
        }

        // If DropDown filter is present
        if ($('.dropdown').length) {

            dropdownid = "";

            $(".dropdown").each(function (index) {

                if (
                    $(this).attr("id") != undefined
                    &&
                    $(this).attr("id") != "undefined"
                    &&
                    $(this).attr("id") != ""
                    &&
                    $(this).attr("id") != "null"
                    &&
                    $(this).attr("id") != null
                ) {

                    dropdownid = dropdownid + "&" + $(this).attr("id") + "=" + $(this).val();
                }

            })
        }
        



        var Param = "status=" + status + "&" +
            "searchstr=" + search + "&" + dropdownid + "";

          

        $.ajax({
            url: location.href,
            type: 'GET',
            dataType: 'html',
            data: Param,
            async: false,
            success: function (data) {
                $('.loading').hide();

                $("#divgrid").empty();
                $("#divgrid").html(data);

                // Update Counts in Check Boxs (Active/Inactive)
                if ($('#hdn_status_0').length > 0) {
                    $('#lblCustomeCheck_1').html($("#divgrid").find("#hdn_status_0").val());
                    $('#liStatus_0').show();
                } else {
                    $('#liStatus_0').hide();
                }

                if ($('#hdn_status_1').length > 0) {
                    $('#lblCustomeCheck_2').html($("#divgrid").find("#hdn_status_1").val());
                    $('#liStatus_1').show();
                } else {
                    $('#lblCustomeCheck_2').html('Inactive (0)');
                    $('#liStatus_1').hide();
                }

                PopUpReload();

             
            },
            error: function (xhr, textStatus, errorThrown) {
                // alert(errorThrown);
              
            }
        });
    }


});

//to display the confirm box, after add/edit
function confirmbox(msg, actionname, controllername, refresh, paramname, paramvalue) {

    $.confirm({
        title: '',
        content: msg,
        opacity: 0.5,
        animation: 'top',
        closeAnimation: 'bottom',
        confirmButtonClass: 'btn-primary',
        cancelButtonClass: '',
        cancelButton: false,
        theme: 'material',
        buttons: {
            OK: function () {
                if (refresh == 1) {
                    if (paramname != "") {
                        location.href = url_generator('/' + controllername + '/' + actionname + '?' + paramname + '=' + paramvalue);
                    }
                    else {
                        location.href = url_generator('/' + controllername + '/' + actionname);
                    }
                }
                else if (refresh == 2) {
                    parent.location.reload();
                }
                else if (refresh == 3) {
                    // Click Button Search, will not reload page 
                    $('#btnSearch').click();
                }
                else {

                }
            }
        }
    });
}

function GetCurrentDateForDatePickerDisplay() {

    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();
    var m = getMonths[mm];
    var strCurrentDate = dd + "-" + m + "-" + yyyy;

    return strCurrentDate;
} 
function PopUpReload() {

    $(".fancybox").fancybox({
        openEffect: "none",
        closeEffect: "none",
        helpers: {
            overlay: {
                locked: false
            }
        }
    });

    $(".popup-xs").fancybox({
        hideOnContentClick: true,
        maxWidth: 400,
        fitToView: true,
        width: '90%',
        height: 'auto',
        autoSize: false,
        closeClick: false,
        openMethod: 'dropIn',
        closeMethod: 'dropOut',
        openSpeed: '100',
        closeSpeed: '800',
        padding: 0,
        'onComplete': function () {
            $('#fancybox-frame').load(function () { // wait for frame to load and then gets it's height
                $('#fancybox-content').height($(this).contents().find('body').height() + 30);
            });
        }
    });

    $(".popup-sm").fancybox({
        hideOnContentClick: true,
        fitToView: false,
        width: 650,
        height: 'auto',
        padding: 0,
        openMethod: 'dropIn',
        closeMethod: 'dropOut',
        openSpeed: '100',
        closeSpeed: '800',
        'onComplete': function () {
            $('#fancybox-frame').load(function () { // wait for frame to load and then gets it's height
                $('#fancybox-content').height($(this).contents().find('body').height() + 30);
            });
        }
    });

    $(".popup-md").fancybox({
        hideOnContentClick: true,
        fitToView: true,
        width: 680,
        height: 'auto',
        padding: 0,
        autoSize: true,
        openMethod: 'dropIn',
        closeMethod: 'dropOut',
        openSpeed: '100',
        closeSpeed: '800',
        'onComplete': function () {
            $('#fancybox-frame').load(function () { // wait for frame to load and then gets it's height
                $('#fancybox-content').height($(this).contents().find('body').height() + 30);
            });
        }
    });

    $(".popup-lg").fancybox({
        hideOnContentClick: true,
        width: 900,
        padding: 0,
        openMethod: 'dropIn',
        closeMethod: 'dropOut',
        openSpeed: '100',
        closeSpeed: '800',
        'onComplete': function () {
            $('#fancybox-frame').load(function () { // wait for frame to load and then gets it's height
                $('#fancybox-content').height($(this).contents().find('body').height() + 30);
            });
        }
    });
}




