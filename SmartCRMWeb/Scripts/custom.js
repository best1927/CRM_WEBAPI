
//var mySession = new function () { getMySession() };
//mySession.Guid;
//mySession.LoginId;
//mySession.LoginName;
//mySession.ModuleCode;
//mySession.MyCultureInfo;
//mySession.MyDateFormat;
//mySession.MyLanuage;
//mySession.MyLanuageName;
//mySession.OrgCode;
//mySession.OrgName;
//mySession.Schema;
//mySession.Abandon;


function getSwMsgType(val) {
    var answer = "";
    switch (val) {
        case 0:
            answer = "error";
            break;
        case 1:
            answer = "success";
            break;
        case 2: 
            answer = "warning";
            break;
        case 3:
            answer = "question";
            break;
        default:
            answer = "";
    }
    return answer;
}


function getMySession() {
    
    var mySession = $.parseJSON(sessionStorage.getItem('mySession'));
    if (typeof (mySession) === 'undefined' || mySession === null) {
        var NewSession = $.ajax({
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'GenericService.svc/GetMySession',
            data: {},
            error: function (error) {
                if (error.responseJSON == undefined) {
                    console.log(error.statusText);
                }
                else {
                    sweetAlert("Error...", error.responseJSON.Message, "error");
                }
            }, async: false
        });
        mySession = $.parseJSON(NewSession.responseJSON.d);
        sessionStorage.setItem('mySession', JSON.stringify(mySession));
   
  
  
    }
    return mySession;
    
}


function numberWithCommas(t) { var e = t.toString().split("."); return e[0] = e[0].replace(/\B(?=(\d{3})+(?!\d))/g, ","), e.join(".") } function confirmDelete() { return confirm('คุณต้องการลบข้อมูลจริงหรือไม่?\nเลือก "ตกลง" หากต้องการลบข้อมูล') }
$(document).ready(function () {
    $(".money").autoNumeric("init"),
    $(".search-btn").click(function () {
        $(".filter").fadeToggle("fast", "linear"),
            $(".filter input:first").focus()
    }), $(".btn-file input[type=file]").change(function () {
        if (null != $(this)) { var t = $(this).get(0).id, e = t + "_filename"; $("#" + e).length > 0 ? $("#" + e).html($(this).val()) : $(this).parent().after('<div id="' + e + '" class="btn-file-name">' + $(this).val() + "</div>") }
    })

   
    initDatePicker();
 
});
var DefaultRow;
var Msglist = [];

function initDatePicker() {

    $('.TimeOnly').datetimepicker({
        format: 'LT',
        defaultDate: new Date()
    });

    $.ajax({
        type: "POST",
        url: "HelperService.svc/GetDateTimeFormat",
        contentType: "application/json; charset=utr-8",
        dataType: "json",
        success: function (result) {
            $serverDateTimeFormat = result.d;
            //calendar thai datetimepickerlanguage

            $('.datetimepicker').datetimepicker({
                format: $serverDateTimeFormat,
                defaultDate: new Date()
            });

        }
    });


    var dRow = $.ajax({
        type: "POST",
        url: "HelperService.svc/GetDefautRowDataGrid",
        contentType: "application/json; charset=utr-8",
        dataType: "json",
        error: function (error) {
            if (error.responseJSON == undefined) {
                console.log(error.statusText);
            }
            else {
                sweetAlert("Error...", error.responseJSON.Message, "error");
            }
        },
        async: false
    });

    DefaultRow = dRow.responseJSON.d;

    var MsgObj = $.ajax({
        type: "POST",
        url: "CRMMasService.svc/GetMessageList",
        contentType: "application/json; charset=utr-8",
        dataType: "json",
        error: function (error) {
            if (error.responseJSON == undefined) {
                console.log(error.statusText);
            }
            else {
                sweetAlert("Error...", error.responseJSON.Message, "error");
            }
        },
        async: false
    });

    Msglist = jQuery.parseJSON(MsgObj.responseJSON.d);


    // กรณี default date หน้าเดียว 
    var ret = $.ajax({
        type: "POST",
        url: "HelperService.svc/GetDateFormat",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (error) {
            if (error.responseJSON == undefined) {
                console.log(error.statusText);
            }
            else {
                sweetAlert("Error...", error.responseJSON.Message, "error");
            }
        },
        async: false
    });

    $serverDateTimeFormat = ret.responseJSON.d;

    var mysess = getMySession();
    if (mysess.MyLanuageName == 'THA') {
        $('.datepicker').datetimepicker({
            format: $serverDateTimeFormat,
            defaultDate: new Date(),
            locale: 'th',
            // timeZone:'Asia/Bangkok' // moment().tz('Asia/Bangkok')
            //กรณี default หน้าเดียว
            //defaultDate: new Date()
        });
    }
    else {
        $('.datepicker').datetimepicker({
            format: $serverDateTimeFormat,
            defaultDate: new Date()
            // timeZone:'Asia/Bangkok' // moment().tz('Asia/Bangkok')
            //กรณี default หน้าเดียว
            //defaultDate: new Date()
        });
    }
    //$('.datepicker').datepicker({ language: 'th-th', format: 'dd/mm/yyyy' })


}

