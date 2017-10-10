<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.master" AutoEventWireup="true" CodeFile="MaintainUser.aspx.cs" Inherits="MaintainUser" %>

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
                        <asp:Label ID="lblPageHeader" runat="server" Text="การจัดการข้อมูล ผู้ใช้งาน"></asp:Label>
                        <button id="btnAddNew" type="button" class="btn btn-info btn-xs" data-toggle="modal">
                            <i class="fa fa-plus"></i><span data-lang="lblAddData">เพิ่มข้อมูลใหม่</span>
                        </button>

                    </h3>
                    <%--            <div class="pull-right">
                        <button type="button" class="btn btn-xs" onclick="window.history.back();">
                            <i class="fa fa-arrow-left"></i>กลับ
                        </button>
                    </div>--%>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <table id="oTable" class="table table-bordered table-hover">
                        <thead>
                            <tr>
                                <th class="w10"></th>
                                <th class="w10"></th>
                                <th class="w100" data-lang="thCode">รหัส</th>
                                <th data-lang="thDescLoc">ชื่อไทย</th>
                                <th data-lang="thDescEng">ชื่ออังกฤษ</th>
                                <th data-lang="thDepartment">หน่วยงาน</th>
                                <th class="w100" data-lang="thTel">เบอร์โทรศัพท์</th>
                                <th class="w100" data-lang="thEmail">Email</th>
                                <th class="w80" data-lang="thCCA">CCA</th>
                                <th class="w80" data-lang="thServiceKey">Service Key</th>
                                <th class="w80" data-lang="thSignature">ลายเซ็น</th>
                            </tr>
                        </thead>
                    </table>
                </div>
                <!-- /.box-body -->
            </div>
            <!-- /.box -->
        </div>
        <!-- /.col -->
    </div>

    <div id="userModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title"><span data-lang="lblHeaderAddEdit">Add/Edit User</span></h4>
                </div>
                <div class="modal-body">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtUserId" data-lang="lblUserId">User Id:</label>
                            <div class="col-xs-3">
                                <input type="text" class="form-control" id="txtUserId" placeholder="User Id" maxlength="15" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtPassword" data-lang="lblPassword">Password:</label>
                            <div class="col-xs-6">
                                <input type="password" class="form-control" id="txtPassword" placeholder="Password" maxlength="50" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtUserNameLoc" data-lang="lblNameLocal">Name Local:</label>
                            <div class="col-xs-9">
                                <input type="text" class="form-control" id="txtUserNameLoc" placeholder="Name Local" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtUserNameEng" data-lang="lblNameEng">Name Eng:</label>
                            <div class="col-xs-9">
                                <input type="text" class="form-control" id="txtUserNameEng" placeholder="Name Eng" />
                            </div>
                        </div>
                           <div class="form-group">
                            <label class="control-label col-xs-3" for="txtDepartmentName" data-lang="lblDepartmentName">Department Name:</label>
                            <div class="col-xs-9">
                                <input type="text" class="form-control" id="txtDepartmentName" placeholder="Department Name" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtPhoneNo" data-lang="lblPhone">Phone No:</label>
                            <div class="col-xs-6">
                                <input type="text" class="form-control" id="txtPhoneNo" placeholder="Phone No" value="N/A" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtEmail" data-lang="lblEmail">Email:</label>
                            <div class="col-xs-6">
                                <input type="text" class="form-control" id="txtEmail" placeholder="Email" value="N/A" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtCCA" data-lang="lblCCA">CCA:</label>
                            <div class="col-xs-6">
                                <input type="text" class="form-control" id="txtCCA" placeholder="CCA" value="N/A" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtServiceKey" data-lang="lblServiceKey">Service Key:</label>
                            <div class="col-xs-6">
                                <input type="text" class="form-control" id="txtServiceKey" placeholder="Service Key" value="N/A" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtServiceKey" data-lang="lblSignature">Signature:</label>
                            <div class="col-xs-6">
                                <input id="fileUpload" type="file" class="form-control" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="ddlCancelFlag" data-lang="lblCancelFlag">Cancel Flag:</label>
                            <div class="col-xs-6">
                                <select id="ddlCancelFlag" class="form-control">
                                    <option value="N">N</option>
                                    <option value="Y">Y</option>
                                </select>
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

    <div id="imageModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title"><span data-lang="lblHeaderSignature">Signature</span></h4>
                </div>
                <div class="modal-body">
                    <img id="imgSignature" alt="" />
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

        var $txtUserId = $("#txtUserId");
        var $txtPassword = $("#txtPassword");
        var $txtUserNameLoc = $("#txtUserNameLoc");
        var $txtUserNameEng = $("#txtUserNameEng");
        var $txtPhoneNo = $("#txtPhoneNo");
        var $txtEmail = $("#txtEmail");
        var $txtCCA = $("#txtCCA");
        var $txtServiceKey = $("#txtServiceKey");
        var $ddlCancelFlag = $("#ddlCancelFlag");

        var $btnAddNew = $("#btnAddNew");
        var $btnSave = $("#btnSave");
        var $fileUpload = $("#fileUpload"), file = "";
        var $btnUploadFile = $("#btnUploadFile");
        var $userModal = $('#userModal');

        var $imageModal = $("#imageModal");
        var $imgSignature = $("#imgSignature");

        var $txtDepartmentName = $("#txtDepartmentName");

        var oTable;
        $(function () {
            getScreenProfile();
            oTable = $("#oTable").DataTable({
                "scrollCollapse": true,
                "bServerSide": true,
                "sAjaxSource": 'AuthenService.svc/GetUser',
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
                            return "<a href='#' data-id='" + data + "' class='btnEdit'><i class=\"fa fa-edit\"></i></a>";
                        }
                    },
                    {
                        "mData": "Code",
                        "bSearchable": false,
                        "bSortable": false,
                        "sClass": "c",
                        "bSearchable ": false,
                        "mRender": function (data, type, full) {
                            return "<a href='#' data-id='" + data + "' class='btnDelete'><i class='fa fa-trash-o'></i></a>";
                        }
                    },
                    {
                        "mData": "Code",
                        "bSearchable": false,
                        "bSortable": false,
                        "bSearchable ": false,
                        "mRender": function (data, type, full) {
                            return "<a href='#'>" + data + "</a>";
                        }
                    },
                    { "mData": "NameLoc" },
                    { "mData": "NameEng" },
                    { "mData": "DepartmentName" },
                    { "mData": "PhoneNo" },
                    { "mData": "Email" },
                    { "mData": "CCA" },
                    { "mData": "ServiceKey" },
                    {
                        "mData": "Signature",
                        "bSearchable": false,
                        "bSortable": false,
                        "sClass": "c",
                        "mRender": function (data, type, full) {
                            if (data.length > 0)
                                return "<a href='#' class='btnViewImage'  data-id='" + full.Code + "'>View Image</a>";
                            else
                                return "";
                        }
                    }
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
                    $('.btnEdit').bind("click", showEditModal);
                    $('.btnDelete').bind("click", showDeleteModal);
                    $('.btnViewImage').bind("click", showImage);
                }
            });
            oTable.fnSetFilteringEnterPress();

            $btnAddNew.on('click', function (e) {
                e.preventDefault();
                $txtUserId.val(null);
                $txtUserId.prop("disabled", false);
                $txtPassword.val(null);
                $txtPassword.prop("disabled", false);
                $txtUserNameLoc.val(null);
                $txtUserNameEng.val(null);
                $txtPhoneNo.val("N/A");
                $txtEmail.val("N/A");
                $txtCCA.val("N/A");
                $txtServiceKey.val("N/A");
                $ddlCancelFlag.val("N");
                $userModal.modal({
                    backdrop: 'static',
                    show: true
                });
            });

            $btnSave.on('click', function (e) {
                var errMessage = "";
                if (_.isEmpty($txtUserId.val()) || _.isUndefined($txtUserId.val())) {
                    errMessage = errMessage.concat($("label[for='txtUserId']").text(), " is required!!!", "\n");
                }

                if (_.isEmpty($txtPassword.val()) || _.isUndefined($txtPassword.val())) {
                    errMessage = errMessage.concat($("label[for='txtPassword']").text(), " is required!!!", "\n");
                }

                if (_.isEmpty($txtUserNameLoc.val()) || _.isUndefined($txtUserNameLoc.val())) {
                    errMessage = errMessage.concat($("label[for='txtUserNameLoc']").text(), " is required!!!", "\n");
                }

                if (_.isEmpty($txtUserNameEng.val()) || _.isUndefined($txtUserNameEng.val())) {
                    errMessage = errMessage.concat($("label[for='txtUserNameEng']").text(), " is required!!!", "\n");
                }

                if (_.isEmpty($txtDepartmentName.val()) || _.isUndefined($txtDepartmentName.val())) {
                    errMessage = errMessage.concat($("label[for='txtDepartmentName']").text(), " is required!!!", "\n");
                }

                if (_.isEmpty($txtPhoneNo.val()) || _.isUndefined($txtPhoneNo.val())) {
                    errMessage = errMessage.concat($("label[for='txtPhoneNo']").text(), " is required!!!", "\n");
                }

                if (_.isEmpty($txtEmail.val()) || _.isUndefined($txtEmail.val())) {
                    errMessage = errMessage.concat($("label[for='txtEmail']").text(), " is required!!!", "\n");
                }

                if (_.isEmpty($txtCCA.val()) || _.isUndefined($txtCCA.val())) {
                    errMessage = errMessage.concat($("label[for='txtCCA']").text(), " is required!!!", "\n");
                }

                if (_.isEmpty($txtServiceKey.val()) || _.isUndefined($txtServiceKey.val())) {
                    errMessage = errMessage.concat($("label[for='txtServiceKey']").text(), " is required!!!", "\n");
                }

                if (!_.isEmpty(errMessage)) {
                    sweetAlert("Error...", errMessage, "error");
                    return false;
                }

                if ($txtUserId.prop("disabled") == true) {
                    //Update
                    setUser(false);
                } else {
                    //AddNew
                    var jData = {};
                    jData.userId = $txtUserId.val();
                    callService("AuthenService.svc/CheckDup", "POST", JSON.stringify(jData), function (results) {
                        var IsDup = $.parseJSON(results.d);
                        if (IsDup) {
                            sweetAlert("Error...", $("label[for='txtGroupId']").text().concat(" is duplicate!!!"), "error");
                        } else {
                            setUser(true);
                        }
                    });
                }
            });

            $fileUpload.on('change', function (e) {
                var files = e.target.files;
                var f = files[0];
                if (f.type.match('image.*')) {
                    var reader = new FileReader();
                    // Closure to capture the file information.
                    reader.onload = (function (theFile) {
                        return function (e) {
                            file = e.target.result;
                        };
                    })(f);

                    // Read in the image file as a data URL.
                    reader.readAsDataURL(f);
                }
            });
        });

        function showImage(e) {
            e.preventDefault();
            var id = $(this).attr("data-id");
            var file = _.findWhere(oTable.fnGetData(), { Code: id });
            $imgSignature.attr("src", file.Signature);
            $imageModal.modal({
                backdrop: 'static',
                show: true
            });
        }

        function showEditModal(e) {
            e.preventDefault();
            var userId = $(this).attr("data-id");
            var jData = {};
            jData.userId = userId;
            callService("AuthenService.svc/GetUserByPrimaryKey", "POST", JSON.stringify(jData), function (results) {
                var obj = $.parseJSON(results.d);

                $txtUserId.val(obj.Code);
                $txtUserId.prop("disabled", true);
                $txtPassword.val(obj.Pwd);
                $txtPassword.prop("disabled", true);
                $txtUserNameLoc.val(obj.NameLoc);
                $txtUserNameEng.val(obj.NameEng);
                $txtPhoneNo.val(obj.PhoneNo);
                $txtEmail.val(obj.Email);
                $txtCCA.val(obj.CCA);
                $txtServiceKey.val(obj.ServiceKey);
                $ddlCancelFlag.val(obj.CancelFlag);
                $txtDepartmentName.val(obj.DepartmentName);
                $userModal.modal({
                    backdrop: 'static',
                    show: true
                });
            });
        }

        function showDeleteModal(e) {
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
                jData.userId = id;
                callService("AuthenService.svc/DeleteUser", "POST", JSON.stringify(jData), function (results) {
                    swal("Deleted!", "", "success");
                    oTable.fnDraw();
                });
            });
        }

        function setUser(isAddNew) {
            var jData = {};
            jData.USER_ID = $txtUserId.val();
            jData.PASSWORD = $txtPassword.val();
            jData.USER_NAME_LOC = $txtUserNameLoc.val();
            jData.USER_NAME_ENG = $txtUserNameEng.val();
            jData.PHONE_NO = $txtPhoneNo.val();
            jData.EMAIL = $txtEmail.val();
            jData.CCA = $txtCCA.val();
            jData.CCA_SERVICEKEY = $txtServiceKey.val();
            jData.CANCEL_FLAG = $ddlCancelFlag.val();
            jData.DEPARTMENT_NAME = $txtDepartmentName.val();

            var URL;
            if (isAddNew) {
                jData.SIGNATURE = file;
                URL = "AuthenService.svc/AddNewUser";
            } else {
                if (file == "") {
                    var obj = _.findWhere(oTable.fnGetData(), { Code: jData.USER_ID });
                    jData.SIGNATURE = obj.Signature;
                }
                URL = "AuthenService.svc/UpdateUser";
            }
            callService(URL, "POST", JSON.stringify({ values: jData }), function (results) {
                if (isAddNew)
                    swal("Add New User Success.", "", "success");
                else
                    swal("Update User Success.", "", "success")
                oTable.fnDraw();
                $userModal.modal('hide');;
            });
        }

        $userModal.on("show.bs.modal", function () {
            if (_.isEmpty($txtUserId.val()) || _.isUndefined($txtUserId.val()))
                $txtUserId.parent().parent().addClass("has-error");
            else
                $txtUserId.parent().parent().removeClass("has-error");

            if (_.isEmpty($txtPassword.val()) || _.isUndefined($txtPassword.val()))
                $txtPassword.parent().parent().addClass("has-error");
            else
                $txtPassword.parent().parent().removeClass("has-error");

            if (_.isEmpty($txtUserNameLoc.val()) || _.isUndefined($txtUserNameLoc.val()))
                $txtUserNameLoc.parent().parent().addClass("has-error");
            else
                $txtUserNameLoc.parent().parent().removeClass("has-error");

            if (_.isEmpty($txtUserNameEng.val()) || _.isUndefined($txtUserNameEng.val()))
                $txtUserNameEng.parent().parent().addClass("has-error");
            else
                $txtUserNameEng.parent().parent().removeClass("has-error");

            if (_.isEmpty($txtDepartmentName.val()) || _.isUndefined($txtDepartmentName.val()))
                $txtDepartmentName.parent().parent().addClass("has-error");
            else
                $txtDepartmentName.parent().parent().removeClass("has-error");

            if (_.isEmpty($txtPhoneNo.val()) || _.isUndefined($txtPhoneNo.val()))
                $txtPhoneNo.parent().parent().addClass("has-error");
            else
                $txtPhoneNo.parent().parent().removeClass("has-error");

            if (_.isEmpty($txtEmail.val()) || _.isUndefined($txtEmail.val()))
                $txtEmail.parent().parent().addClass("has-error");
            else
                $txtEmail.parent().parent().removeClass("has-error");

            if (_.isEmpty($txtCCA.val()) || _.isUndefined($txtCCA.val()))
                $txtCCA.parent().parent().addClass("has-error");
            else
                $txtCCA.parent().parent().removeClass("has-error");

            if (_.isEmpty($txtServiceKey.val()) || _.isUndefined($txtServiceKey.val()))
                $txtServiceKey.parent().parent().addClass("has-error");
            else
                $txtServiceKey.parent().parent().removeClass("has-error");
        });

        $userModal.on("hidden.bs.modal", function () {
            $txtUserId.val(null);
            $txtUserId.prop("disabled", false);
            $txtPassword.val(null);
            $txtPassword.prop("disabled", false);
            $txtUserNameLoc.val(null);
            $txtUserNameEng.val(null);
            $txtDepartmentName.val(null);
            $txtPhoneNo.val("N/A");
            $txtEmail.val("N/A");
            $txtCCA.val("N/A");
            $txtServiceKey.val("N/A");
            $fileUpload.val('');
            file = "";
        });

        ////////////////////----------------Screen Profile-------------/////////////////////////
        function getScreenProfile() {
            //ajax
            callService("AuthenService.svc/GetScreenProfile", "POST", JSON.stringify({ programCode: "TRUSER" }), function (results) {
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

