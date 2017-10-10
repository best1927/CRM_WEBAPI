<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.master" AutoEventWireup="true" CodeFile="MaintainMenu.aspx.cs" Inherits="MaintainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="plugins/jstree/themes/default/style.min.css" rel="stylesheet" />
    <link href="plugins/bootstrap-iconpicker/css/bootstrap-iconpicker.min.css" rel="stylesheet" />
    <style>
        .btn-default {
            background-color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">
    <div class="col-md-12">
        <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">
                    <i class="ion ion-clipboard"></i>
                    <label id="lblPageHeader" data-lang="lblPageHeader">Maintain Menu</label>
                </h3>
            </div>
            <div class="box-body">
                <div class="row">
                    <div class="col-md-4 col-sm-8 col-xs-8">
                        <button type="button" class="btn btn-success btn-sm" onclick="createParent();"><i class="glyphicon glyphicon-asterisk"></i><span data-lang="lblCreateParent">Create Parent</span></button>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div id="tree" style="margin-top: 1em;">
                        </div>
                    </div>
                </div>
            </div>
            <%--  <div class="box-footer" style="text-align: right">
                <button id="btnSaveNode" type="button" class="btn btn-info">Save</button>
            </div>--%>
        </div>
    </div>

    <div id="programModal" class="modal fade" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" data-lang="lblHeaderAddEdit">Add/Edit Program</h4>
                </div>
                <div class="modal-body">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtProgramCode" data-lang="lblProgramCode">Program Code:</label>
                            <div class="col-xs-3">
                                <input type="text" class="form-control" id="txtProgramCode" placeholder="Program Code" maxlength="20" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtDescLoc" data-lang="lblDescLoc">Desc Loc:</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" id="txtDescLoc" placeholder="Desc Loc" maxlength="300" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtDescEng" data-lang="lblDescEng">Desc Eng:</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" id="txtDescEng" placeholder="Desc Eng" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="cboProgramType" data-lang="lblProgramType">Program Type:</label>
                            <div class="col-xs-3">
                                <select class="form-control" id="cboProgramType">
                                    <option value="" data-lang="lblSelect">-select-</option>
                                    <option value="R" data-lang="lblRoot">Root</option>
                                    <option value="M" data-lang="lblMaintain">Maintain</option>
                                    <option value="T" data-lang="lblTransaction">Transaction</option>
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtProgramPath" data-lang="lblProgramPath">Program Path:</label>
                            <div class="col-xs-6">
                                <input type="text" class="form-control" id="txtProgramPath" placeholder="Program Path" maxlength="150" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtProgramExtension" data-lang="lblProgramExtension">Program Extension:</label>
                            <div class="col-xs-6">
                                <input type="text" class="form-control" id="txtProgramExtension" placeholder="Program Extension" maxlength="15" />
                            </div>
                        </div>
                       <%--  <div class="form-group">
                            <label class="control-label col-xs-3" for="txtUserAccess" data-lang="lblUserAccess">User Access</label>
                            <div class="col-xs-6">
                             <input type="text" class="form-control" id="txtUserAccess" placeholder="User Access" maxlength="50" />
                            </div>
                        </div>--%>
                        <div class="form-group">
                            <label class="control-label col-xs-3" for="txtProgramIcon" data-lang="lblProgramIcon">Program Icon:</label>
                            <div class="col-xs-6">
                                <button id="btnIcon" type="button" class="btn btn-default" data-placement="right" role="iconpicker" data-rows="5" data-cols="12" data-iconset="fontawesome"></button>
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

    <script src="plugins/jstree/jstree.min.js"></script>
    <script src="plugins/bootstrap-iconpicker/js/iconset/iconset-all.min.js"></script>
    <script src="plugins/bootstrap-iconpicker/js/bootstrap-iconpicker.min.js"></script>
    <script>

        var listData = [], listLevel = [], listChanged = [];
        var parentCode = "", isAddNew = false;

        $(function () {
            getScreenProfile();
            getMenu();
            $('#tree').on("move_node.jstree", function (e, data) {
                var tree = $("#tree").jstree().get_json();
                listChanged = [];
                $.each(tree, function (i, item) {
                    listChanged.push(item.id + ":" + (i + 1) + ":" + 0);
                    if (item["children"].length > 0) {
                        var children = item.children;
                        $.each(children, function (j, chi) {
                            listChanged.push(chi.id + ":" + (i + 1) + ":" + (j + 1));
                        });
                    }
                });
                var diff = _.difference(listChanged, listLevel);
                listLevel = listChanged;

                var listSend = [];
                $.each(diff, function (i, item) {
                    var obj = item.split(":");
                    var jData = {};
                    var programCode = obj[0];
                    var parent = $("#tree").jstree().get_parent(programCode);
                    jData.PROGRAM_CODE = programCode
                    jData.PARENT_PROGRAM_CODE = parent == "#" ? "" : parent;
                    jData.NODE_LEVEL = obj[1];
                    jData.SEQ_NO = obj[2];
                    listSend.push(jData);
                });
                if (listSend.length > 0) {
                    callService("AuthenService.svc/UpdateMenu", "POST", JSON.stringify({ values: listSend }), function (results) {
                    });
                }
            });

            $("#btnSaveNode").on("click", function (e) {
                e.preventDefault();
                var list = $('#tree').jstree().get_json();
                var obj = {}, listSend = [];
                //root
                $.each(list, function (i, root) {
                    obj = {};
                    obj.PROGRAM_CODE = root.id;
                    obj.PARENT_PROGRAM_CODE = null;
                    obj.NODE_LEVEL = i + 1;
                    obj.SEQ_NO = 0;
                    listSend.push(obj);
                    if (root["children"].length > 0) {
                        $.each(root["children"], function (j, chi) {
                            obj = {};
                            obj.PROGRAM_CODE = chi.id;
                            obj.PARENT_PROGRAM_CODE = root.id;
                            obj.NODE_LEVEL = i + 1;
                            obj.SEQ_NO = j + 1;
                            listSend.push(obj);
                        });
                    }
                });

            });

            $("#btnSave").on("click", function (e) {
                e.preventDefault();
                if (isAddNew)
                    setProgramAndMenu();
                else
                    updateProgram();
            });
        });

        function getMenu() {
            callService("AuthenService.svc/GetMenu", "POST", "", function (results) {
                var objs = JSON.parse(results.d);
                var group = _.groupBy(objs, "PARENT_PROGRAM_CODE");
                var root = _.sortBy(group[""], 'NODE_LEVEL');
                var obj = {}, objChi = {}, children = [];
                $.each(root, function (idx, item) {
                    obj = {};
                    obj.id = item.PROGRAM_CODE;
                    obj.text = item.DESC_NAME;
                    //obj.icon = "fa fa-map-marker";
                    listLevel.push(item.PROGRAM_CODE + ":" + item.NODE_LEVEL + ":" + item.SEQ_NO);
                    if (group[item.PROGRAM_CODE] != undefined) {
                        children = _.sortBy(group[item.PROGRAM_CODE], 'SEQ_NO');
                        obj.children = [];
                        $.each(children, function (j, chi) {
                            objChi = {};
                            objChi.id = chi.PROGRAM_CODE;
                            objChi.text = chi.DESC_NAME;
                            //objChi.icon = "fa fa-map-marker";
                            obj.children.push(objChi);
                            listLevel.push(chi.PROGRAM_CODE + ":" + chi.NODE_LEVEL + ":" + chi.SEQ_NO);
                        });
                    }
                    listData.push(obj);
                });

                setTree();
            });
        }

        function setTree() {
            $('#tree').jstree({
                "core": {
                    "check_callback": true,
                    "multiple": false,
                    "data": listData
                },
                "types": {
                    "default": {
                        "icon": "glyphicon glyphicon-flash"
                    }
                },
                "plugins": ["contextmenu", "dnd", "types", "unique", "changed"],
                "contextmenu": {
                    "items": function ($node) {
                        var id = $('#tree').jstree().get_parent($node);
                        parentCode = $node.id;
                        var ret = {};
                        //parent
                        if (id == "#") {
                            ret.Create = {
                                "label": "Create Children",
                                "action": function (obj) {
                                    clearModal();
                                    $("#cboProgramType option[value='R']").hide();
                                    isAddNew = true;
                                    $("#programModal").modal("show");
                                }
                            };
                        } 

                        ret.Edit = {
                            "label": "Edit",
                            "action": function (obj) {
                                isAddNew = false;
                                editProgram($node);
                            }
                        };
                        ret.Delete = {
                            "label": "Delete",
                            "action": function (obj) {
                                deleteProgram($node);                            
                            }
                        }
                        return ret;
                    }
                }
            });
        }

        function createParent() {
            parentCode = "#";
            clearModal();
            $("#cboProgramType").val("R");
            $("#cboProgramType option[value='R']").show();
            isAddNew = true;
            $("#programModal").modal("show");
        }

        function setProgramAndMenu() {
            var jData = {};
            jData.PROGRAM_CODE = $("#txtProgramCode").val();
            jData.DESC_ENG = $("#txtDescEng").val();
            jData.DESC_LOC = $("#txtDescLoc").val();
            jData.PROGRAM_TYPE = $("#cboProgramType").val();
            jData.PROGRAM_PATH = $("#txtProgramPath").val();
            jData.PROGRAM_EXTENSION = $("#txtProgramExtension").val();
            jData.PROGRAM_ICON = $("#btnIcon i").attr("class");
            jData.PARENT_PROGRAM_CODE = parentCode == "#" ? "" : parentCode;

            var inst = $('#tree').jstree(true);
            var parent = inst.get_node("#");
            var node = inst.get_node(parentCode);
            jData.NODE_LEVEL = parentCode == "#" ? parent.children.length + 1 : $.inArray(parentCode, parent.children) + 1;
            jData.SEQ_NO = parentCode == "#" ? 0 : node.children.length + 1;

            callService("AuthenService.svc/AddNewProgramAndMenu", "POST", JSON.stringify({ values: jData }), function (results) {
                $("#tree").jstree().create_node(parentCode, { id: jData.PROGRAM_CODE, text: results.d }, "last", false, false)
                swal("Add New Program Success.", "", "success");
                $("#programModal").modal("hide");
            });           
        }

        function clearModal() {
            $("input").val("");
            $("input").prop("disabled", false);
        }

        function editProgram(node) {
            clearModal();
            $("#txtProgramCode").prop("disabled", true);
            if (node.parent == "#") {
                $("#cboProgramType option[value='R']").show();
            } else {
                $("#cboProgramType option[value='R']").hide();
            }
            getProgramByPK(node.id);
        }

        function getProgramByPK(programCode) {
            var jData = {};
            jData.PROGRAM_CODE = programCode;
            callService("AuthenService.svc/GetProgramByPrimaryKey", "POST", JSON.stringify(jData), function (results) {
                var obj = JSON.parse(results.d);
                $("#txtProgramCode").val(obj.PROGRAM_CODE);
                $("#txtDescEng").val(obj.DESC_ENG);
                $("#txtDescLoc").val(obj.DESC_LOC);
                $("#cboProgramType").val(obj.PROGRAM_TYPE);
                $("#txtProgramPath").val(obj.PROGRAM_PATH);
                $("#txtProgramExtension").val(obj.PROGRAM_EXTENSION);
                $("#btnIcon i").attr("class", obj.PROGRAM_ICON);

                $("#programModal").modal("show");
            });
        }

        function updateProgram() {
            var jData = {};
            jData.PROGRAM_CODE = $("#txtProgramCode").val();
            jData.DESC_ENG = $("#txtDescEng").val();
            jData.DESC_LOC = $("#txtDescLoc").val();
            jData.PROGRAM_TYPE = $("#cboProgramType").val();
            jData.PROGRAM_PATH = $("#txtProgramPath").val();
            jData.PROGRAM_EXTENSION = $("#txtProgramExtension").val();
            jData.PROGRAM_ICON = $("#btnIcon i").attr("class");

            callService("AuthenService.svc/UpdateProgram", "POST", JSON.stringify({ values: jData }), function (results) {
                $("#tree").jstree().rename_node(jData.PROGRAM_CODE, results.d);
                swal("Update Program Success.", "", "success");
                $("#programModal").modal("hide");
            });
        }

        function deleteProgram(node) {
            var programCode = node.id;

            var list = [];
            list.push(programCode); //push parent;
            var chi = $("#tree").jstree().get_node(programCode).children;
            list = _.union(list, chi);

            callService("AuthenService.svc/DeleteProgram", "POST", JSON.stringify({ PROGRAM_CODE: list }), function (results) {
                swal("Delete Program Success.", "", "success");
                $("#tree").jstree().delete_node(node);
            });
        }

        ////////////////////----------------Screen Profile-------------/////////////////////////
        function getScreenProfile() {
            //ajax
            callService("AuthenService.svc/GetScreenProfile", "POST", JSON.stringify({ programCode: "TRMENU" }), function (results) {
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

