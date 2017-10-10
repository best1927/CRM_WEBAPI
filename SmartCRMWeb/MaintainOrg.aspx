<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.master" AutoEventWireup="true" CodeFile="MaintainOrg.aspx.cs" Inherits="MaintainOrg" %>

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
                        <asp:Label ID="lblPageHeader" runat="server" Text="การจัดการข้อมูล Org"></asp:Label>
                        <button id="btnAddNew" type="button" class="btn btn-info btn-xs" data-toggle="modal">
                            <i class="fa fa-plus"></i><span data-lang="lblAddData">Add Data</span>
                        </button>
                    </h3>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-md-12">
                            <table id="oTable" class="table table-bordered table-hover" style="width:100%;">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th></th>
                                        <th data-lang="thOrgCode">Org Code</th>
                                        <th data-lang="thOrgNameLoc">Org Name Loc</th>
                                        <th data-lang="thOrgNameEng">Org Name Eng</th>
                                        <th data-lang="thShortNameLoc">Short Name Loc</th>
                                        <th data-lang="thShortNameEng">Short Name Eng</th>
                                        <th data-lang="thSchemaName">Schema Name</th>
                                        <th class="w80" data-lang="thCenterFlag">Center?</th>
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

    <div id="organizationModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title"><span data-lang="lblAddNewOrg">AddNew/Copy Organization</span></h4>
                </div>
                <div class="modal-body">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtOrgCode" data-lang="lblOrgCode">Org Code:</label>
                            <div class="col-xs-3">
                                <input type="text" class="form-control" id="txtOrgCode" placeholder="Org Code" maxlength="10" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtOrgNameLoc" data-lang="lblNameLocal">Name Local:</label>
                            <div class="col-xs-9">
                                <input type="text" class="form-control" id="txtOrgNameLoc" placeholder="Name Local" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtOrgNameEng" data-lang="lblNameEng">Name Eng:</label>
                            <div class="col-xs-9">
                                <input type="text" class="form-control" id="txtOrgNameEng" placeholder="Name Eng" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtShortNameLoc" data-lang="lblShortNameLocal">ShortName Local:</label>
                            <div class="col-xs-9">
                                <input type="text" class="form-control" id="txtShortNameLoc" placeholder="ShortName Local" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtShortNameEng" data-lang="lblShortNameEng">ShortName Eng:</label>
                            <div class="col-xs-9">
                                <input type="text" class="form-control" id="txtShortNameEng" placeholder="ShortName Eng" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtSchema" data-lang="lblSchema">Schema</label>
                            <div class="col-xs-9">
                                <input type="text" class="form-control" id="txtSchema" placeholder="Schema" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-xs-3" data-lang="lblCenter">Center:</label>
                            <div class="col-xs-2">
                                <label class="radio-inline">
                                    <input id="chkCenter" type="radio" name="centerRadios" value="Y" />
                                    Yes
                                </label>
                            </div>
                            <div class="col-xs-2">
                                <label class="radio-inline">
                                    <input id="chkNotCenter" type="radio" name="centerRadios" value="N" checked="checked" />
                                    No
                                </label>
                            </div>
                        </div>


                        <%--<div class="form-group">
                            <label class="control-label col-xs-3" for="ddlSourceOrg" data-lang="lblOrgCode">Copy From:</label>
                            <div class="col-xs-9">
                                <select id="ddlSourceOrg" class="form-control">
                                    <option value="0">--Select Organization--</option>

                                </select>
                            </div>
                        </div>--%>

                        <div class="form-group">
                            <div class="col-xs-offset-3 col-xs-9">
                                <input id="btnSaveOrg" type="button" class="btn btn-primary" value="Save" />
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

    <script type="text/javascript">
        //Initial pushMenu for hide first.
        $("body").addClass('sidebar-collapse');
        //================================== Organization Tab
        var $btnAddNew = $("#btnAddNew");
        var $organizationModal = $('#organizationModal');
        var $txtOrgCode = $('#txtOrgCode');
        var $txtOrgNameEng = $('#txtOrgNameEng');
        var $txtOrgNameLoc = $('#txtOrgNameLoc');
        var $txtShortNameEng = $('#txtShortNameEng');
        var $txtShortNameLoc = $('#txtShortNameLoc');
        var $txtSchema = $('#txtSchema');
        var $chkCenter = $('#chkCenter');
        var $chkNotCenter = $('#chkNotCenter');
        var $ddlOrgGroup = $("#ddlOrgGroup");
        var $ddlSourceOrg = $("#ddlSourceOrg");

        var $btnSaveOrg = $("#btnSaveOrg");

        var oTable;
        $(function () {
            getScreenProfile();
            oTable = $("#oTable").DataTable({
                "scrollCollapse": true,
                "bServerSide": true,
                "sAjaxSource": 'AuthenService.svc/GetOrganization',
                "sAjaxDataProp": "aaData",
                "bProcessing": true,
                "iDisplayLength": 10,
                "bSort": false,
                "aoColumns": [
                    {
                        "mData": "OrgCode",
                        "bSearchable": false,
                        "bSortable": false,
                        "sClass": "c",
                        "mRender": function (data) {
                            return "<a href='#' data-id='" + data + "' class='btnOrgEdit'><i class=\"fa fa-edit\"></i></a>";
                        }
                    },
                    {
                        "mData": "OrgCode",
                        "bSearchable": false,
                        "bSortable": false,
                        "sClass": "c",
                        "bSearchable ": false,
                        "mRender": function (data) {
                            return "<a href='#' data-id='" + data + "' class='btnOrgDelete'><i class='fa fa-trash-o'></i></a>";
                        }
                    },
                    {
                        "mData": "OrgCode",
                        "bSearchable": false,
                        "bSortable": false,
                        "bSearchable ": false,
                        "mRender": function (data) {
                            return "<a href='MaintainGroup.aspx?id=" + data + "'>" + data + "</a>";
                        }
                    },
                    { "mData": "OrgNameLoc" },
                    { "mData": "OrgNameEng" },
                    { "mData": "ShortNameLoc" },
                    { "mData": "ShortNameEng" },
                    { "mData": "Schema" },
                    { "mData": "CenterOrg" }
                ],
                "fnServerData": function (sSource, aoData, fnCallback) {
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
                    $('.btnOrgEdit').bind("click", showOrgEditModal);
                    $('.btnOrgDelete').bind("click", showOrgDeleteModal);
                }
            });
            oTable.fnSetFilteringEnterPress();

            $btnAddNew.on("click", function (e) {
                e.preventDefault();
                $organizationModal.modal("show");
            })

            $btnSaveOrg.on('click', function (e) {
                var errMessage = "";

                if (_.isEmpty($txtOrgCode.val()) || _.isUndefined($txtOrgCode.val())) {
                    errMessage = errMessage.concat($("label[for='txtOrgCode']").text(), " is required!!!", "\n");
                }

                if (_.isEmpty($txtOrgNameLoc.val()) || _.isUndefined($txtOrgNameLoc.val())) {
                    errMessage = errMessage.concat($("label[for='txtOrgNameLoc']").text(), " is required!!!", "\n");
                }

                if (_.isEmpty($txtOrgNameEng.val()) || _.isUndefined($txtOrgNameEng.val())) {
                    errMessage = errMessage.concat($("label[for='txtOrgNameEng']").text(), " is required!!!", "\n");
                }

                if (_.isEmpty($txtShortNameLoc.val()) || _.isUndefined($txtShortNameLoc.val())) {
                    errMessage = errMessage.concat($("label[for='txtShortNameLoc']").text(), " is required!!!", "\n");
                }

                if (_.isEmpty($txtShortNameEng.val()) || _.isUndefined($txtShortNameEng.val())) {
                    errMessage = errMessage.concat($("label[for='txtShortNameEng']").text(), " is required!!!", "\n");
                }

                if (_.isEmpty($txtSchema.val()) || _.isUndefined($txtSchema.val())) {
                    errMessage = errMessage.concat($("label[for='txtSchema']").text(), " is required!!!", "\n");
                }
                if (!_.isEmpty(errMessage)) {
                    sweetAlert("Error...", errMessage, "error");
                    return false;
                }

                if ($txtOrgCode.prop("disabled") == true) {
                    //Update
                    setOrganization(false);
                } else {
                    //AddNew
                    var jData = {};
                    jData.ORG_CODE = $txtOrgCode.val();
                    callService("AuthenService.svc/CheckDupOrg", "POST", JSON.stringify(jData), function (results) {
                        var IsDup = $.parseJSON(results.d);
                        if (IsDup) {
                            sweetAlert("Error:", $("label[for='txtOrgCode']").text() + " is duplicate!!!", "error");
                        } else {
                            setOrganization(true);
                        }
                    });
                }
            });
        });

        function showOrgEditModal(e) {
            e.preventDefault();
            var orgCode = $(this).attr("data-id");
            var jData = {};
            jData.ORG_CODE = orgCode;
            callService("AuthenService.svc/GetOrgByPrimaryKey", "POST", JSON.stringify(jData), function (results) {
                var orgs = $.parseJSON(results.d);
                //console.log(results);
                txtOrgCode.value = orgs.OrgCode;
                txtOrgCode.disabled = true;
                txtOrgNameLoc.value = orgs.OrgNameLoc;
                txtOrgNameEng.value = orgs.OrgNameEng;
                txtShortNameLoc.value = orgs.ShortNameLoc;
                txtShortNameEng.value = orgs.ShortNameEng;
                txtSchema.value = orgs.Schema == undefined ? "" : orgs.Schema;
                if (orgs.CenterOrg == "Y")
                    chkCenter.checked = true;
                else
                    chkNotCenter.checked = true;
                $ddlSourceOrg.prop('disabled', 'disabled')
                $organizationModal.modal("show");
            });
        }

        function showOrgDeleteModal(e) {
            e.preventDefault();
            var id = $(this).attr("data-id");
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
                jData.ORG_CODE = id;
                callService("AuthenService.svc/DeleteOrg", "POST", JSON.stringify(jData), function (results) {
                    swal("Deleted!", "", "success");
                    oTable.fnDraw();
                });
            });
        }

        function setOrganization(isAddNew) {
            var jData = {};
            jData.ORG_CODE = $txtOrgCode.val();
            jData.ORG_NAME_LOC = $txtOrgNameLoc.val();
            jData.ORG_NAME_ENG = $txtOrgNameEng.val();
            jData.SHORT_NAME_LOC = $txtShortNameLoc.val();
            jData.SHORT_NAME_ENG = $txtShortNameEng.val();
            jData.SCHEMA = $txtSchema.val();
            if ($chkCenter.prop("checked"))
                jData.CENTER_ORG = "Y"
            else
                jData.CENTER_ORG = "N"


            var URL;
            if (isAddNew)
                URL = "AuthenService.svc/AddNewOrg";
            else
                URL = "AuthenService.svc/UpdateOrg";
            callService(URL, "POST", JSON.stringify({ values: jData }), function (results) {
                if (isAddNew)
                    swal("Add New Organization Success.", "", "success");
                else
                    swal("Update Organization Success.", "", "success")
                oTable.fnDraw();
                $organizationModal.modal('hide');;
            });
        }


        $organizationModal.on("show.bs.modal", function () {
            if (_.isEmpty($txtOrgCode.val()) || _.isUndefined($txtOrgCode.val()))
                $txtOrgCode.parent().parent().addClass("has-error");
            else
                $txtOrgCode.parent().parent().removeClass("has-error");

            if (_.isEmpty($txtOrgNameLoc.val()) || _.isUndefined($txtOrgNameLoc.val()))
                $txtOrgNameLoc.parent().parent().addClass("has-error");
            else
                $txtOrgNameLoc.parent().parent().removeClass("has-error");

            if (_.isEmpty($txtOrgNameEng.val()) || _.isUndefined($txtOrgNameEng.val()))
                $txtOrgNameEng.parent().parent().addClass("has-error");
            else
                $txtOrgNameEng.parent().parent().removeClass("has-error");

            if (_.isEmpty($txtShortNameLoc.val()) || _.isUndefined($txtShortNameLoc.val()))
                $txtShortNameLoc.parent().parent().addClass("has-error");
            else
                $txtShortNameLoc.parent().parent().removeClass("has-error");

            if (_.isEmpty($txtShortNameEng.val()) || _.isUndefined($txtShortNameEng.val()))
                $txtShortNameEng.parent().parent().addClass("has-error");
            else
                $txtShortNameEng.parent().parent().removeClass("has-error");

            if (_.isEmpty($txtSchema.val()) || _.isUndefined($txtSchema.val()))
                $txtSchema.parent().parent().addClass("has-error");
            else
                $txtSchema.parent().parent().removeClass("has-error");
        });

        $organizationModal.on("hidden.bs.modal", function () {
            $txtOrgCode.val(null);
            $txtOrgCode.prop("disabled", false);
            $txtOrgNameEng.val(null);
            $txtOrgNameLoc.val(null);
            $txtShortNameEng.val(null);
            $txtShortNameLoc.val(null);
            $txtSchema.val(null);
            $chkNotCenter.prop("checked", true);
            $ddlSourceOrg.prop("disabled", false);
            $ddlSourceOrg.val(0);
        });

        ////////////////////----------------Screen Profile-------------/////////////////////////
        function getScreenProfile() {
            //ajax
            callService("AuthenService.svc/GetScreenProfile", "POST", JSON.stringify({ programCode: "TRORG" }), function (results) {
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
    </script>
</asp:Content>

