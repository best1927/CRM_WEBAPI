<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.master" AutoEventWireup="true" CodeFile="MaintainGroupDetail.aspx.cs" Inherits="MaintainGroupDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        legend {
            font-size: larger;
        }

        .tree, .tree ul {
            margin: 0;
            padding: 0;
            list-style: none;
        }

            .tree ul {
                margin-left: 1em;
                position: relative;
            }

                .tree ul ul {
                    margin-left: .5em;
                }

                .tree ul:before {
                    content: "";
                    display: block;
                    width: 0;
                    position: absolute;
                    top: 0;
                    bottom: 0;
                    left: 0;
                    border-left: 1px solid;
                }

            .tree li {
                margin: 0;
                padding: 0 1em;
                line-height: 2em;
                color: #369;
                font-weight: 700;
                position: relative;
            }


            .tree ul li:before {
                content: "";
                display: block;
                width: 10px;
                height: 0;
                border-top: 1px solid;
                margin-top: -1px;
                position: absolute;
                top: 1em;
                left: 0;
            }

            .tree ul li:last-child:before {
                background: #fff;
                height: auto;
                top: 1em;
                bottom: 0;
            }

        .indicator {
            margin-right: 5px;
        }

        .tree li a {
            text-decoration: none;
            color: #369;
        }

        .tree li button, .tree li button:active, .tree li button:focus {
            text-decoration: none;
            color: #369;
            border: none;
            background: transparent;
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            outline: 0;
        }

        .badge {
            margin-left: 10px;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        <i class="ion ion-clipboard"></i>
                        <label id="lblPageHeader" data-lang="lblPageHeader">รายละเอียด กลุ่มผู้ใช้งาน</label>
                    </h3>
                    <div class="pull-right">
                        <button type="button" class="btn btn-xs" onclick="window.history.back();">
                            <i class="fa fa-arrow-left"></i><span data-lang="lblBack">กลับ</span>
                        </button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-md-6">
                            <fieldset>
                                <legend>
                                    <i class="ion ion-person"></i>
                                    <label id="lblUserPageHeader" data-lang="lblUserPageHeader">ผู้ใช้งาน</label>
                                </legend>
                                <dl class="dl-horizontal">
                                    <dt>
                                        <asp:Label ID="lblUser" runat="server" Text="เงื่อนไขการค้นหา"></asp:Label></dt>
                                    <dd>
                                        <select id="ddlUserFilter">
                                            <option value="1" data-lang="lblUserIn">ผู้ใช้ที่อยู่ในกลุ่ม</option>
                                            <option value="0" data-lang="lblUserOut">ผู้ใช้ที่ไม่อยู่ในกลุ่ม</option>
                                        </select>
                                    </dd>
                                </dl>
                                <table id="userTable" class="table table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th class="w10"></th>
                                            <th class="w100" data-lang="thCode">รหัส</th>
                                            <th data-lang="thName">ชื่อ</th>
                                        </tr>
                                    </thead>
                                </table>
                            </fieldset>
                        </div>
                        <div class="col-md-6">
                            <fieldset>
                                <legend>
                                    <i class="fa fa-shield"></i>
                                    <label id="lblPermissionPageHeader" data-lang="lblPermissionPageHeader">หน้าจอการทำงาน</label>
                                </legend>
                                <dl class="dl-horizontal">
                                    <dt>
                                        <label id="lblPermission" data-lang="lblPermission">เงื่อนไขการค้นหา</label>
                                    </dt>
                                    <dd>
                                        <select id="ddlPermissionFilter">
                                            <option value="1" data-lang="lblPermission">หน้าจอที่กำหนดสิทธิแล้ว</option>
                                            <option value="0" data-lang="lblNotPermission">หน้าจอที่ยังไม่ได้กำหนดสิทธิ</option>
                                        </select>
                                    </dd>
                                </dl>
                                <ul id="treeMenu">
                                </ul>
                            </fieldset>
                        </div>
                    </div>
                </div>
                <!-- /.box-body -->
            </div>
            <!-- /.box -->
        </div>
        <!-- /.col -->
    </div>
    <script src="plugins/datatables/jquery.dataTables.js"></script>
    <script src="plugins/datatables/dataTables.bootstrap.js"></script>
    <script src="plugins/datatables/dataTableExt.fnFilter.js"></script>

    <script type="text/javascript">
        $.fn.extend({
            treed: function (o) {

                var openedClass = 'glyphicon-minus-sign';
                var closedClass = 'glyphicon-plus-sign';

                if (typeof o != 'undefined') {
                    if (typeof o.openedClass != 'undefined') {
                        openedClass = o.openedClass;
                    }
                    if (typeof o.closedClass != 'undefined') {
                        closedClass = o.closedClass;
                    }
                };

                //initialize each of the top levels
                var tree = $(this);
                tree.addClass("tree");
                tree.find('li').has("ul").each(function () {
                    var branch = $(this); //li with children ul
                    branch.prepend("<i class='indicator glyphicon " + closedClass + "'></i>");
                    branch.addClass('branch');
                    branch.on('click', function (e) {
                        if (this == e.target) {
                            var icon = $(this).children('i:first');
                            icon.toggleClass(openedClass + " " + closedClass);
                            $(this).children().children().toggle();
                        }
                    })
                    branch.children().children().toggle();
                });
                //fire event from the dynamically added icon
                tree.find('.branch .indicator').each(function () {
                    $(this).on('click', function () {
                        $(this).closest('li').click();
                    });
                });
                //fire event to open branch if the li contains an anchor instead of text
                tree.find('.branch>a').each(function () {
                    $(this).on('click', function (e) {
                        $(this).closest('li').click();
                        e.preventDefault();
                    });
                });
                //fire event to open branch if the li contains a button instead of text
                tree.find('.branch>button').each(function () {
                    $(this).on('click', function (e) {
                        $(this).closest('li').click();
                        e.preventDefault();
                    });
                });
            }
        });

        var $ddlUserFilter = $("#ddlUserFilter");
        var $ddlPermissionFilter = $("#ddlPermissionFilter");
        var $lblPageHeader = $("#lblPageHeader");

        var permissionTable, userTable;
        $(function () {


            $ddlUserFilter.on("change", function () {
                userTable.fnDraw();
            });
            $ddlPermissionFilter.on("change", function () {
                //getPermission();
                var programCode = $(this).val();
                if (programCode == "0") {
                    getPermission();
                }
                else {
                    getPermissionByRoot(programCode);
                }
            });

            getScreenProfile();
            getPermission();
            bindRootMenu();
            setGroupDetailName();

            userTable = $("#userTable").DataTable({
                "scrollCollapse": true,
                "bServerSide": true,
                "sAjaxSource": 'AuthenService.svc/GetGroupUser',
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
                        "mRender": function (data) {
                            var html;
                            if ($ddlUserFilter.val() == "0") {
                                html = "<a href='#' data-id='" + data + "' class='btnAddToGroup'><i class=\"fa fa-plus\"></i></a>";

                            } else {
                                html = "<a href='#' data-id='" + data + "' class='btnRemoveFromGroup'><i class=\"fa fa-times\"></i></a>";

                            }
                            return html;
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
                    { "mData": "NameLoc" }
                ],
                "fnServerData": function (sSource, aoData, fnCallback) {
                    aoData.push({ "name": "OrgCode", "value": "<%:this.OrgCode%>" });
                    aoData.push({ "name": "GroupCode", "value": "<%:this.GroupCode%>" });
                    aoData.push({ "name": "iExisting", "value": $ddlUserFilter.val() });
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
                    $('.btnAddToGroup').bind("click", addToGroup);
                    $('.btnRemoveFromGroup').bind("click", removeFromGroup);
                }
            });
            userTable.fnSetFilteringEnterPress();
        })

        function bindRootMenu() {
            callService("AuthenService.svc/GetRootMenu", "POST", "", function (results) {
                var temp = JSON.parse(results.d);

                $ddlPermissionFilter.empty();
                $ddlPermissionFilter.append('<option value="0">--Select Root--</option>');
                $.each(temp, function (i, value) {
                    var text = value.PROGRAM_CODE + " : " + value.DESC_LOC
                    $ddlPermissionFilter.append('<option value=' + value.PROGRAM_CODE + '>' + text + '</option>');
                });
            });
        }

        function getPermissionByRoot(programCode) {
            var jData = {};
            jData.ORG_CODE = "<%:this.OrgCode%>";
            jData.GROUP_ID = "<%:this.GroupCode%>";
            jData.PROGRAM_CODE = programCode;
            callService("AuthenService.svc/GetUserPermissionByRoot", "POST", JSON.stringify(jData), function (results) {
                var arrUserPermissions = $.parseJSON(results.d);
                $treeMenu = $('#treeMenu');
                console.log(arrUserPermissions);
                var parentProgramCode;
                var html = "";

                $treeMenu.empty();
                $.each(arrUserPermissions, function (i, item) {
                    if (parentProgramCode == undefined) {
                        if (item.PARENT_PROGRAM_CODE == null || item.PARENT_PROGRAM_CODE == "") {
                            ////new root
                            //html += "<li data-id=" + item.PROGRAM_CODE + "><a href='#'>" + item.PROGRAM_CODE + " : " + item.DESC_LOC + "</a><span class='badge bg-green root-add'>Add all</span><span class='badge bg-red root-remove'>Remove all</span>";
                            //html += "<ul>";
                            //parentProgramCode = item.PROGRAM_CODE;
                            if (item.CHILD_COUNT != 0) {
                                var btnHtml = "";
                                if (!(item.PROGRAM_PER == null || item.PROGRAM_PER == "")) {
                                    btnHtml = "</a><span class='badge bg-red root-remove'>Remove all</span>";
                                } else {
                                    btnHtml = "</a><span class='badge bg-green root-add'>Add all</span>";
                                }
                                //new root

                                html += "<li data-id=" + item.PROGRAM_CODE + "><a href='#'>"
                                    + item.PROGRAM_CODE + " : "
                                    + item.DESC_LOC
                                    + btnHtml;
                                html += "<ul>";
                                parentProgramCode = item.PROGRAM_CODE;
                            }
                            else {
                                //new root not child

                                var btnHtml = "";
                                if (!(item.PROGRAM_PER == null || item.PROGRAM_PER == "")) {
                                    btnHtml = "</a><span class='badge bg-red child'>Remove</span>";
                                    html += "<li data-id=" + item.PROGRAM_CODE + " data-status='D'><a href='#'>"
                                   + item.PROGRAM_CODE + " : "
                                   + item.DESC_LOC
                                   + btnHtml;
                                } else {
                                    btnHtml = "</a><span class='badge bg-green child'>Add</span>";
                                    html += "<li data-id=" + item.PROGRAM_CODE + " data-status='A'><a href='#'>"
                                   + item.PROGRAM_CODE + " : "
                                   + item.DESC_LOC
                                   + btnHtml;
                                }

                            }
                        }
                    }
                    else {
                        if (parentProgramCode != item.PARENT_PROGRAM_CODE) {
                            html += "</li></ul>";
                            html += "<li data-id=" + item.PROGRAM_CODE + "><a href='#'>" + item.PROGRAM_CODE + " : " + item.DESC_LOC + "</a><span class='badge bg-green root-add'>Add all</span><span class='badge bg-red root-remove'>Remove all</span>";
                            html += "<ul>";
                            parentProgramCode = item.PROGRAM_CODE;
                        }
                        else {
                            if (!(item.PROGRAM_PER == null || item.PROGRAM_PER == "")) {
                                //Already set
                                html += "<li data-id=" + item.PROGRAM_CODE + " data-status='D'>" + item.PROGRAM_CODE + " : " + item.DESC_LOC + " <span class='badge bg-red child'>Remove</span></li>";
                            } else {
                                html += "<li data-id=" + item.PROGRAM_CODE + " data-status='A'>" + item.PROGRAM_CODE + " : " + item.DESC_LOC + " <span class='badge bg-green child'>Add</span></li>";
                            }

                        }
                    }
                });
                $treeMenu.append(html);
                $treeMenu.treed();

                $(".root-add").on("click", function (e) {
                    var $this = $(this);
                    var id = $this.parent().attr("data-id");
                    addGroupToPermission(id);
                })
                $(".root-remove").on("click", function (e) {
                    var $this = $(this);
                    var id = $this.parent().attr("data-id");
                    removeGroupFromPermission(id);
                })
                $(".child").on("click", function (e) {
                    var $this = $(this);
                    var id = $this.parent().attr("data-id");
                    var status = $this.parent().attr("data-status");
                    switch (status) {
                        case "A":
                            addGroupToPermission(id);
                            break;
                        case "D":
                            removeGroupFromPermission(id);
                            break;
                    }
                });
            });
        }

        function getPermission() {
            var jData = {};
            jData.ORG_CODE = "<%:this.OrgCode%>";
            jData.GROUP_ID = "<%:this.GroupCode%>";
            //jData.IS_EXISTING = $ddlPermissionFilter.val();
            callService("AuthenService.svc/GetUserPermissionByGroup", "POST", JSON.stringify(jData), function (results) {
                var arrUserPermissions = $.parseJSON(results.d);
                $treeMenu = $('#treeMenu');
                console.log(arrUserPermissions);
                var parentProgramCode;
                var html = "";

                $treeMenu.empty();
                $.each(arrUserPermissions, function (i, item) {
                    if (parentProgramCode == undefined) {
                        if (item.PARENT_PROGRAM_CODE == null || item.PARENT_PROGRAM_CODE == "") {
                            if (item.CHILD_COUNT != 0) {
                                var btnHtml = "";
                                if (!(item.PROGRAM_PER == null || item.PROGRAM_PER == "")) {
                                    btnHtml = "</a><span class='badge bg-red root-remove'>Remove all</span>";
                                } else {
                                    btnHtml = "</a><span class='badge bg-green root-add'>Add all</span>";
                                }
                                //new root

                                html += "<li data-id=" + item.PROGRAM_CODE + "><a href='#'>"
                                    + item.PROGRAM_CODE + " : "
                                    + item.DESC_LOC
                                    + btnHtml;
                                html += "<ul>";
                                parentProgramCode = item.PROGRAM_CODE;
                            }
                            else {
                                //new root not child
                                var btnHtml = "";
                                if (!(item.PROGRAM_PER == null || item.PROGRAM_PER == "")) {
                                    btnHtml = "</a><span class='badge bg-red child'>Remove</span>";
                                    html += "<li data-id=" + item.PROGRAM_CODE + " data-status='D'><a href='#'>"
                                   + item.PROGRAM_CODE + " : "
                                   + item.DESC_LOC
                                   + btnHtml;
                                } else {
                                    btnHtml = "</a><span class='badge bg-green child'>Add</span>";
                                    html += "<li data-id=" + item.PROGRAM_CODE + " data-status='A'><a href='#'>"
                                   + item.PROGRAM_CODE + " : "
                                   + item.DESC_LOC
                                   + btnHtml;
                                }
                            }



                        }
                    }
                    else {
                        if (parentProgramCode != item.PARENT_PROGRAM_CODE) {
                            html += "</li></ul>";
                            html += "<li data-id=" + item.PROGRAM_CODE + "><a href='#'>" + item.PROGRAM_CODE + " : " + item.DESC_LOC;
                            if (!(item.PROGRAM_PER == null || item.PROGRAM_PER == "")) {
                                html += "</a><span class='badge bg-red root-remove'>Remove all</span>"
                            } else {
                                html += "</a><span class='badge bg-green root-add'>Add all</span>";
                            }
                            //html += "<li data-id=" + item.PROGRAM_CODE + "><a href='#'>" + item.PROGRAM_CODE + " : " + item.DESC_LOC + "</a><span class='badge bg-green root-add'>Add all</span><span class='badge bg-red root-remove'>Remove all</span>";

                            html += "<ul>";
                            parentProgramCode = item.PROGRAM_CODE;
                        }
                        else {
                            if (!(item.PROGRAM_PER == null || item.PROGRAM_PER == "")) {
                                //Already set
                                html += "<li data-id=" + item.PROGRAM_CODE + " data-status='D'>" + item.PROGRAM_CODE + " : " + item.DESC_LOC + " <span class='badge bg-red child'>Remove</span></li>";
                            } else {
                                html += "<li data-id=" + item.PROGRAM_CODE + " data-status='A'>" + item.PROGRAM_CODE + " : " + item.DESC_LOC + " <span class='badge bg-green child'>Add</span></li>";
                            }

                        }
                    }
                });
                $treeMenu.append(html);
                $treeMenu.treed();

                $(".root-add").on("click", function (e) {
                    var $this = $(this);
                    var id = $this.parent().attr("data-id");
                    addGroupToPermission(id);
                })
                $(".root-remove").on("click", function (e) {
                    var $this = $(this);
                    var id = $this.parent().attr("data-id");
                    removeGroupFromPermission(id);
                })
                $(".child").on("click", function (e) {
                    var $this = $(this);
                    var id = $this.parent().attr("data-id");
                    var status = $this.parent().attr("data-status");
                    switch (status) {
                        case "A":
                            addGroupToPermission(id);
                            break;
                        case "D":
                            removeGroupFromPermission(id);
                            break;
                    }
                });
            });
        }

        function addToGroup() {
            var jData = {};
            jData.ORG_CODE = "<%:this.OrgCode%>";
            jData.GROUP_USER = "<%:this.GroupCode%>";
            jData.USER_ID = $(this).attr("data-id");
            callService("AuthenService.svc/AddUserToGroup", "POST", JSON.stringify(jData), function (results) {
                userTable.fnDraw();
            });
        }

        function removeFromGroup() {
            var jData = {};
            jData.ORG_CODE = "<%:this.OrgCode%>";
            jData.GROUP_USER = "<%:this.GroupCode%>";
            jData.USER_ID = $(this).attr("data-id");
            swal({
                title: "Are you sure?",
                text: "to remove " + jData.USER_ID + " from " + jData.GROUP_USER + " YES/NO?",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: true
            }, function () {
                callService("AuthenService.svc/RemoveUserFromGroup", "POST", JSON.stringify(jData), function (results) {
                    userTable.fnDraw();
                });
            });
        }

        function AddOrRemoveGroupWithPermission(bIsParent, sMode, sPROGRAM_CODE) {
            var jData = {};
            jData.ORG_CODE = "<%:this.OrgCode%>";
            jData.GROUP_USER = "<%:this.GroupCode%>";
            jData.PROGRAM_CODE = sPROGRAM_CODE;
            jData.IS_PARENT = bIsParent;
            //alert(bIsParent + "," + sMode + "," + jData.ORG_CODE + "," + jData.GROUP_USER + "," + sUSER_ID);
            var URL = "";
            switch (sMode) {
                case "A":  //Add
                    URL = "AuthenService.svc/AddGroupToPermission";
                    break;
                case "D": //Delete
                    URL = "AuthenService.svc/RemoveGroupFromPermission";
                    break;
            }
            callService(URL, "POST", JSON.stringify(jData), function (results) {
                //Refresh tree grid
                getPermission();
                //GetUserPermission(org_code, group_id);
            });
        }


        function addGroupToPermission(programCode) {
            var jData = {};
            jData.ORG_CODE = "<%:this.OrgCode%>";
            jData.GROUP_USER = "<%:this.GroupCode%>";
            jData.PROGRAM_CODE = programCode;
            callService("AuthenService.svc/AddGroupToPermission", "POST", JSON.stringify(jData), function (results) {
                //permissionTable.fnDraw();

                var rootProgramCode = $ddlPermissionFilter.val();
                if (rootProgramCode == "0") {
                    getPermission();
                }
                else {
                    getPermissionByRoot(programCode);
                }
            });
        }

        function removeGroupFromPermission(programCode) {
            var jData = {};
            jData.ORG_CODE = "<%:this.OrgCode%>";
             jData.GROUP_USER = "<%:this.GroupCode%>";
             jData.PROGRAM_CODE = programCode;
             swal({
                 title: "Are you sure?",
                 text: "to remove " + jData.PROGRAM_CODE + " from " + jData.GROUP_USER + " YES/NO?",
                 type: "warning",
                 showCancelButton: true,
                 confirmButtonColor: "#DD6B55",
                 confirmButtonText: "Yes, delete it!",
                 closeOnConfirm: true
             }, function () {
                 callService("AuthenService.svc/RemoveGroupFromPermission", "POST", JSON.stringify(jData), function (results) {
                     //permissionTable.fnDraw();
                     var rootProgramCode = $ddlPermissionFilter.val();
                     if (rootProgramCode == "0") {
                         getPermission();
                     }
                     else {
                         getPermissionByRoot(programCode);
                     }
                 });
             });
         }

         //Initial pushMenu for hide first.
         $("body").addClass('sidebar-collapse');

         function setGroupDetailName() {
             var jData = {};
             jData.ORG_CODE = "<%:this.OrgCode%>";
             jData.GROUP_USER = "<%:this.GroupCode%>";
             callService("AuthenService.svc/GetGroupDetailByPrimaryKey", "POST", JSON.stringify(jData), function (results) {
                 var orgs = $.parseJSON(results.d);
                 $lblPageHeader.text($lblPageHeader.text() + " " + orgs.GroupName + " : " + orgs.OrgName);
             });           
        }

        ////////////////////----------------Screen Profile-------------/////////////////////////
        function getScreenProfile() {
            //ajax
            callService("AuthenService.svc/GetScreenProfile", "POST", JSON.stringify({ programCode: "TRGROUPDETAIL" }), function (results) {
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

