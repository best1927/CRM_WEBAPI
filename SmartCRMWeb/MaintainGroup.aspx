<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.master" AutoEventWireup="true" CodeFile="MaintainGroup.aspx.cs" Inherits="MaintainGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        <i class="ion ion-home"></i>
                        <%--<asp:Label ID="lblPageHeader" runat="server" Text="การจัดการข้อมูล กลุ่มผู้ใช้งาน"></asp:Label>--%>
                        <span id="lblPageHeader" data-lang="lblPageHeader">การจัดการข้อมูล กลุ่มผู้ใช้งาน</span>
                        <button id="btnAddNew" type="button" class="btn btn-info btn-xs" data-toggle="modal">
                            <i class="fa fa-plus"></i><span data-lang="lblAddData">เพิ่มข้อมูลใหม่</span>
                        </button>
                        <button id="btnExport" type="button" class="btn btn-info btn-xs" onclick="exportExcel(event);">
                            <i class="fa fa-file-excel-o"></i><span data-lang="lblExportExcel">Export Data</span>
                        </button>
                    </h3>
                    <div class="pull-right">
                        <button type="button" class="btn btn-xs" onclick="window.history.back();">
                            <i class="fa fa-arrow-left"></i><span data-lang="lblBack">Back</span>
                        </button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">

                        <div class="col-md-12">
                            <dl class="dl-horizontal">
                                <dt>Org Code :</dt>
                                <dd>
                                    <label id="lblOrgCode"></label>
                                </dd>
                            </dl>
                            <table id="oTable" class="table table-bordered table-hover" style="width:100%">
                                <thead>
                                    <tr>
                                        <th class="w50"></th>
                                        <th class="w50"></th>
                                        <th data-lang="lblCode">รหัส</th>
                                        <th data-lang="lblDescLoc">ชื่อไทย</th>
                                        <th data-lang="lblDescEng">ชื่ออังกฤษ</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>

                    </div>
                </div>
                <!-- /.box-body -->
            </div>
            <!-- /.box -->
        </div>
        <!-- /.col -->
    </div>

    <div id="groupModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" data-lang="lblHeaderAddEdit">Add/Edit Group</h4>
                </div>
                <div class="modal-body">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtOrgGroup" data-lang="lblOrgCode">Org Code:</label>
                            <div class="col-xs-3">
                                <input type="text" class="form-control" id="txtOrgGroup" value="<%:this.OrgCode%>" disabled="disabled" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtGroupId" data-lang="lblGroupID">Group Id:</label>
                            <div class="col-xs-6">
                                <input type="text" class="form-control" id="txtGroupId" placeholder="Group Id" maxlength="15" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtGroupDescLoc" data-lang="lblDescLoc">Name Local:</label>
                            <div class="col-xs-9">
                                <input type="text" class="form-control" id="txtGroupDescLoc" placeholder="Name Local" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtGroupDescEng" data-lang="lblDescEng">Name Eng:</label>
                            <div class="col-xs-9">
                                <input type="text" class="form-control" id="txtGroupDescEng" placeholder="Name Eng" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-offset-3 col-xs-9">
                                <button id="btnSave" type="button" class="btn btn-primary"><span data-lang="lblSave">Save</span></button>
                                <button class="btn btn-default" data-dismiss="modal" aria-hidden="true">
                                    <span data-lang="lblClose">Close</span></button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="plugins/datatables/jquery.dataTables.js"></script>
    <script src="plugins/datatables/dataTables.bootstrap.js"></script>
    <script src="plugins/datatables/dataTableExt.fnFilter.js"></script>
    <script src="plugins/xlsx-xls-master/FileSaver.js"></script>
    <script src="plugins/xlsx-xls-master/jszip.min.js"></script>
    <script src="plugins/xlsx-xls-master/shim.js"></script>
    <script src="plugins/xlsx-xls-master/xlsx.js"></script>
    <script src="plugins/xlsx-xls-master/xls.js"></script>
    <script type="text/javascript">
        //Initial pushMenu for hide first.
        $("body").addClass('sidebar-collapse');

        var $groupModal = $('#groupModal');
        var $txtOrgGroup = $('#txtOrgGroup');
        var $txtGroupId = $('#txtGroupId');
        var $txtGroupDescLoc = $('#txtGroupDescLoc');
        var $txtGroupDescEng = $('#txtGroupDescEng');
        var $lblOrgCode = $('#lblOrgCode');

        var $btnAddNew = $("#btnAddNew");
        var $btnSave = $("#btnSave");

        var oTable;
        $(function () {
            setOrgName();
            getScreenProfile();
            oTable = $("#oTable").DataTable({
                "scrollCollapse": true,
                "bServerSide": true,
                "sAjaxSource": 'AuthenService.svc/GetGroup',
                "sAjaxDataProp": "aaData",
                "bProcessing": true,
                "iDisplayLength": 10,
                "bSort": false,
                "aoColumns": [
                    {
                        "mData": "Code",
                        "bSearchable": false,
                        "bSortable": false,
                        "sClass": "c",
                        "mRender": function (data, type, full) {
                            return "<a href='#' data-id='" + data + "' data-org='" + full.OrgCode + "' class='btnEdit'><i class=\"fa fa-edit\"></i></a>";
                        }
                    },
                    {
                        "mData": "Code",
                        "bSearchable": false,
                        "bSortable": false,
                        "sClass": "c",
                        "bSearchable ": false,
                        "mRender": function (data, type, full) {
                            return "<a href='#' data-id='" + data + "' data-org='" + full.OrgCode + "' class='btnDelete'><i class='fa fa-trash-o'></i></a>";
                        }
                    },
                    {
                        "mData": "Code",
                        "bSearchable": false,
                        "bSortable": false,
                        "bSearchable ": false,
                        "mRender": function (data, type, full) {
                            return "<a href='MaintainGroupDetail.aspx?id=" + data + "&org=" + full.OrgCode + "'>" + data + "</a>";
                        }
                    },
                    { "mData": "NameLoc" },
                    { "mData": "NameEng" }
                ],
                "fnServerData": function (sSource, aoData, fnCallback) {
                    aoData.push({ "name": "OrgCode", "value": "<%:this.OrgCode%>" });
                    $.ajax({
                        "dataType": 'json',
                        "contentType": "application/json; charset=utf-8",
                        "type": "GET",
                        "url": sSource,
                        "data": aoData,
                        "success": function (msg) {
                            var json = jQuery.parseJSON(msg.d);

                            fnCallback(json);
                        },
                        error: function (error) {
                            if (error.responseJSON == undefined) {
                                console.log(error.statusText);
                            }
                            else {
                                sweetAlert("Error...", error.responseJSON.Message, "error");
                            }
                        }
                    });
                },
                fnDrawCallback: function () {
                    $('.btnEdit').bind("click", showEditModal);
                    $('.btnDelete').bind("click", showDeleteModal);
                }
            });
            oTable.fnSetFilteringEnterPress();

            $btnAddNew.on('click', function (e) {
                e.preventDefault();
                $groupModal.modal("show");
            });

            $btnSave.on('click', function (e) {
                var errMessage = "";
                if (_.isEmpty($txtGroupId.val()) || _.isUndefined($txtGroupId.val())) {
                    errMessage = errMessage.concat($("label[for='txtGroupId']").text(), " is required!!!", "\n");
                }

                if (_.isEmpty($txtGroupDescEng.val()) || _.isUndefined($txtGroupDescEng.val())) {
                    errMessage = errMessage.concat($("label[for='txtGroupDescEng']").text(), " is required!!!", "\n");
                }

                if (_.isEmpty($txtGroupDescLoc.val()) || _.isUndefined($txtGroupDescLoc.val())) {
                    errMessage = errMessage.concat($("label[for='txtGroupDescLoc']").text(), " is required!!!", "\n");
                }

                if (!_.isEmpty(errMessage)) {
                    sweetAlert("Error...", errMessage, "error");
                    return false;
                }

                if ($txtGroupId.prop("disabled") == true) {
                    //Update
                    setGroup(false);
                } else {
                    //AddNew
                    var jData = {};
                    jData.GROUP_USER = $txtGroupId.val();
                    jData.ORG_CODE = "<%:this.OrgCode%>";
                    callService("AuthenService.svc/CheckDupGroup", "POST", JSON.stringify(jData), function (results) {
                        var IsDup = $.parseJSON(results.d);
                        if (IsDup) {
                            sweetAlert("Error...", $("label[for='txtGroupId']").text() + " is duplicate!!!", "error");
                        } else {
                            setGroup(true);
                        }
                    });
                }
            });
        })

            function showEditModal(e) {
                e.preventDefault();
                var groupUser = $(this).attr("data-id");
                var orgCode = $(this).attr("data-org");
                var jData = {};
                jData.ORG_CODE = orgCode;
                jData.GROUP_USER = groupUser;
                callService("AuthenService.svc/GetGroupByPrimaryKey", "POST", JSON.stringify(jData), function (results) {
                    var obj = $.parseJSON(results.d);
                    $txtOrgGroup.val(obj.OrgCode);
                    $txtOrgGroup.prop("disabled", true);
                    $txtGroupId.val(obj.Code);
                    $txtGroupId.prop("disabled", true);
                    $txtGroupDescLoc.val(obj.NameLoc);
                    $txtGroupDescEng.val(obj.NameEng);
                    $groupModal.modal("show");
                });
            }

            function showDeleteModal(e) {
                e.preventDefault();
                var orgCode = $(this).attr("data-org");
                var groupUser = $(this).attr("data-id");
                swal({
                    title: "Are you sure?",
                    text: "",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Yes, delete it!",
                    closeOnConfirm: false
                }, function () {
                    var jData = {};
                    jData.ORG_CODE = orgCode;
                    jData.GROUP_USER = groupUser;
                    callService("AuthenService.svc/DeleteGroup", "POST", JSON.stringify(jData), function (results) {
                        swal("Deleted!", "", "success");
                        oTable.fnDraw();
                    });
                });
            }

            function setGroup(isAddNew) {
                var jData = {};
                jData.ORG_CODE = $txtOrgGroup.val();
                jData.GROUP_USER = $txtGroupId.val();
                jData.DESC_ENG = $txtGroupDescEng.val();
                jData.DESC_LOC = $txtGroupDescLoc.val();
                var URL;
                if (isAddNew)
                    URL = "AuthenService.svc/AddNewGroup";
                else
                    URL = "AuthenService.svc/UpdateGroup";
                callService(URL, "POST", JSON.stringify({ values: jData }), function (results) {
                    if (isAddNew)
                        swal("Add New Group Success.", "", "success");
                    else
                        swal("Update Group Success.", "", "success");
                    oTable.fnDraw();
                    $groupModal.modal('hide');
                });
            }


            $groupModal.on("show.bs.modal", function () {
                if (_.isEmpty($txtGroupId.val()) || _.isUndefined($txtGroupId.val()))
                    $txtGroupId.parent().parent().addClass("has-error");
                else
                    $txtGroupId.parent().parent().removeClass("has-error");

                if (_.isEmpty($txtGroupDescLoc.val()) || _.isUndefined($txtGroupDescLoc.val()))
                    $txtGroupDescLoc.parent().parent().addClass("has-error");
                else
                    $txtGroupDescLoc.parent().parent().removeClass("has-error");

                if (_.isEmpty($txtGroupDescEng.val()) || _.isUndefined($txtGroupDescEng.val()))
                    $txtGroupDescEng.parent().parent().addClass("has-error");
                else
                    $txtGroupDescEng.parent().parent().removeClass("has-error");
            });

            $groupModal.on("hidden.bs.modal", function () {
                //$txtOrgGroup.val(null);
                $txtGroupId.val(null);
                $txtGroupId.prop("disabled", false);
                $txtGroupDescLoc.val(null);
                $txtGroupDescEng.val(null);
            });

            function setOrgName() {
                var jData = {};
                jData.ORG_CODE = "<%:this.OrgCode%>";
            callService("AuthenService.svc/GetOrgByOrgCode", "POST", JSON.stringify(jData), function (results) {
                var orgs = $.parseJSON(results.d);
                $lblOrgCode.text(orgs.OrgName);
            });
        }

        ////////////////////----------------Screen Profile-------------/////////////////////////
        function getScreenProfile() {
            //ajax
            callService("AuthenService.svc/GetScreenProfile", "POST", JSON.stringify({ programCode: "TRGROUP" }), function (results) {
                var list = $.parseJSON(results.d)
                var arrScreenObj = $('[data-lang]');
                var filter;
                $.each(arrScreenObj, function (idx, obj) {
                    filter = _.findWhere(list, { OBJECT_ID: $(obj).attr("data-lang") });
                    if (filter != undefined)
                        $(obj).text(filter.OBJECT_TEXT);
                });
            });
        }

        ///////////////////////////-------------Export Excel-------------///////////////////////////
        function exportExcel(e) {
            e.preventDefault();
            callService("AuthenService.svc/GetUserByOrg", "POST", JSON.stringify({ ORG_CODE: "<%:this.OrgCode%>" }), function (results) {
                var list = $.parseJSON(results.d);
                //var groupUser = _.groupBy(list, "GROUP_USER");
                //var listKey = _.keys(groupUser);
                var listExport = [], row = [];
                //$.each(listKey, function (i, item) {
                //    listExport.push(["Group ID : " + item, "Group Name Loc : " + groupUser[item][0].GROUP_DESC_LOC, "Group Name Eng : " + groupUser[item][0].GROUP_DESC_ENG]);
                //    listExport.push(["User ID", "User Name Local", "User Name Eng", "Department", "User Create", "Create Date", "Last User ID", "Last Update Date"]);
                //    $.each(groupUser[item], function (j, value) {
                //        row = [];
                //        row.push(value.USER_ID);
                //        row.push(value.USER_NAME_LOC);
                //        row.push(value.USER_NAME_ENG);
                //        row.push(value.DEPARTMENT_NAME);
                //        row.push(value.USER_CREATE);
                //        row.push(value.CREATE_DATE);
                //        row.push(value.LAST_USER_ID);
                //        row.push(value.LAST_UPDATE_DATE);
                //        listExport.push(row);
                //    });
                //});
                listExport.push(["User ID", "Geoup User", "Group User Name Local", "Group User Name Eng", "User Name Local", "User Name Eng", "Department", "User Create", "Create Date", "Last User ID", "Last Update Date", "Status"]);
                $.each(list, function (i, value) {
                    row = [];
                    row.push(value.USER_ID);
                    row.push(value.GROUP_USER);
                    row.push(value.GROUP_DESC_LOC);
                    row.push(value.GROUP_DESC_ENG);
                    row.push(value.USER_NAME_LOC);
                    row.push(value.USER_NAME_ENG);
                    row.push(value.DEPARTMENT_NAME);
                    row.push(value.USER_CREATE);
                    row.push(value.CREATE_DATE);
                    row.push(value.LAST_USER_ID);
                    row.push(value.LAST_UPDATE_DATE);
                    if (value.CANCEL_FLAG == "Y")
                        row.push("ยกเลิก");
                    else
                        row.push("ปกติ");
                    listExport.push(row);
                });

                var ws_name = "User";
                /* require XLSX */
                if (typeof XLSX === "undefined") { try { XLSX = require('./'); } catch (e) { XLSX = require('../'); } }


                var wb = new Workbook();

                var ws = sheet_from_array_of_arrays(listExport);

                /* TEST: add worksheet to workbook */
                wb.SheetNames.push(ws_name);
                wb.Sheets[ws_name] = ws;

                var wbout = XLSX.write(wb, { bookType: 'xlsx', bookSST: true, type: 'binary' });

                ///* the saveAs call downloads a file on the local machine */
                saveAs(new Blob([s2ab(wbout)], { type: "application/octet-stream" }), "User.xlsx");
            });

        }
        /* dummy workbook constructor */
        function Workbook() {
            if (!(this instanceof Workbook)) return new Workbook();
            this.SheetNames = [];
            this.Sheets = {};
        }

        /* TODO: date1904 logic */
        function datenum(v, date1904) {
            if (date1904) v += 1462;
            var epoch = Date.parse(v);
            return (epoch - new Date(Date.UTC(1899, 11, 30))) / (24 * 60 * 60 * 1000);
        }

        function s2ab(s) {
            var buf = new ArrayBuffer(s.length);
            var view = new Uint8Array(buf);
            for (var i = 0; i != s.length; ++i) view[i] = s.charCodeAt(i) & 0xFF;
            return buf;
        }

        /* convert an array of arrays in JS to a CSF spreadsheet */
        function sheet_from_array_of_arrays(data, opts) {
            var ws = {};
            var range = { s: { c: 10000000, r: 10000000 }, e: { c: 0, r: 0 } };
            var k = 0;
            for (var R = 0; R != data.length; ++R) {
                for (var C = 0; C != data[R].length; ++C) {
                    if (range.s.r > R) range.s.r = R;
                    if (range.s.c > C) range.s.c = C;
                    if (range.e.r < R) range.e.r = R;
                    if (range.e.c < C) range.e.c = C;
                    var cell = { v: data[R][C] };
                    if (cell.v == null) continue;
                    var cell_ref = XLSX.utils.encode_cell({ c: C, r: R });

                    /* TEST: proper cell types and value handling */
                    if (typeof cell.v === 'number') cell.t = 'n';
                    else if (typeof cell.v === 'boolean') cell.t = 'b';
                    else if (cell.v instanceof Date) {
                        cell.t = 'n';
                        cell.z = XLSX.SSF._table[22];
                        cell.v = datenum(cell.v);
                    }
                    else cell.t = 's';

                    var style = {};
                    style.font = { name: "Calibri", sz: 10 };

                    if (R == 0) {
                        style.font = { name: "Calibri", sz: 10, color: { rgb: "FFFFFF" }, bold: true };
                        style.fill = { fgColor: { rgb: "5D7B9D" } };
                        style.alignment = { horizontal: "center" };
                    } 

                    cell.s = style;
                    ws[cell_ref] = cell;
                }
            }
            var wscols = [{ wch: 12 }, { wch: 15 }, { wch: 20 }, { wch: 20 }, { wch: 20 }, { wch: 20 }, { wch: 20 }, { wch: 10 }, { wch: 10 }, { wch: 10 }, { wch: 10 }];


            /* TEST: proper range */
            if (range.s.c < 10000000) {
                ws['!ref'] = XLSX.utils.encode_range(range);
                ws['!cols'] = wscols;
            }
            return ws;
        }
    </script>
</asp:Content>

