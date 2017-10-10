<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.master" AutoEventWireup="true" CodeFile="MaintainScreenProfile.aspx.cs" Inherits="MaintainScreenProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">
    <div class="box box-primary">
        <div class="box-header with-border">
            <h3 class="box-title" data-lang="lblPageHeader">Add/Update Screen Profile</h3>
        </div>
        <div class="box-body">
            <div class="form-horizontal" role="form">
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="cboProgram" class="col-sm-4 control-label" data-lang="lblProgram">Program</label>
                            <div class="col-sm-8" style="padding-left: 15px; padding-right: 15px;">
                                <select id="cboProgram" class="form-control"></select>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="cboLanguage" class="col-sm-4 control-label" data-lang="lblLanguage">Language</label>
                            <div class="col-sm-8" style="padding-left: 15px; padding-right: 15px;">
                                <select id="cboLanguage" class="form-control"></select>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-1">
                        <button id="btnOK" type="button" class="btn btn-info pull-right"><span data-lang="lblOK">OK</span></button>
                    </div>
                </div>
            </div>
            <hr />

            <div class="table-responsive" style="overflow: auto; height: 350px">
                <table class="table no-margin table-striped">
                    <thead>
                        <tr>
                            <th class="w250" data-lang="thObjectID">Object ID</th>
                            <th data-lang="thText">Text</th>
                        </tr>
                    </thead>
                    <tbody id="rowControl">
                    </tbody>
                </table>
            </div>
        </div>
        <div class="box-footer" style="text-align: right">
            <button id="btnSave" type="button" class="btn btn-success" disabled="disabled">
                <i class="fa fa-save"></i>
                <span data-lang="lblSave">Save</span>
            </button>
        </div>
    </div>

    <script>
        var listProgram = [], programCode = "", lang = "";
        //Initial pushMenu for hide first.
        $("body").addClass('sidebar-collapse');
        $(function () {
            setScreenProfile();
            getProgramList();
            getLanguageList();

            $("#btnOK").on("click", function () {
                if (!(validate($("#cboProgram").add("#cboLanguage")))) {
                    sweetAlert("Oops...", "Save Fail, Please check your data.", "error");
                    return;
                }
                programCode = $("#cboProgram").val();
                lang = $("#cboLanguage").val();
                var obj = _.findWhere(listProgram, { PROGRAM_CODE: programCode });
                getControl(obj.PROGRAM_PATH);
                $("#btnSave").prop("disabled", false);
            });

            $("#btnSave").on("click", function () {
                var coll = [], obj = {};
                $.each($("#rowControl tr"), function (i, item) {
                    obj = {};
                    obj.PROGRAM_CODE = programCode;
                    obj.LANGUAGE_CODE = lang;
                    obj.OBJECT_ID = $(item).find(".objId").text();
                    obj.OBJECT_TEXT = $(item).find("input").val();
                    coll.push(obj);
                });

                callService("AuthenService.svc/SetScreenProfile", "POST", JSON.stringify({ values: coll }), function (results) {
                    swal("Save successful!", "", "success");
                    clearTable();
                    $("#btnSave").prop("disabled", true);
                });
            });

            $("#cboProgram").on("change", function () {
                clearTable();
            });

            $("#cboLanguage").on("change", function () {
                clearTable();
            });
        });

        function getControl(URL) {
            $.ajax({
                url: URL + "?org=0&id=0",
                type: 'GET',
                success: function (data) {
                    var listControl = $(data).find('[data-lang]');

                    listControl = _.uniq(listControl, function (item) {
                        return $(item).attr("data-lang");
                    });

                    getScreenProfile(listControl);
                }
            });
        }

        function getProgramList() {
            callService("AuthenService.svc/GetProgramList", "POST", "", function (results) {
                results = $.parseJSON(results.d);
                listProgram = _.uniq(results, function (item) {
                    return item.PROGRAM_CODE
                });
                var listDiff = _.difference(results, listProgram);
                var s = "";
                $.each(listProgram, function (i, item) {
                    if (item.PROGRAM_PATH == "TraceProcess.aspx") {
                        s = s.concat("<option value='", item.PROGRAM_CODE, "'>Trace Process : ", item.PROGRAM_NAME);
                        if (listDiff.length > 0)
                            s = s.concat(",", _.pluck(listDiff, "PROGRAM_NAME").join());
                        s = s.concat("</option>");
                    } else
                        s = s.concat("<option value='", item.PROGRAM_CODE, "'>", item.PROGRAM_NAME, "</option>");
                });
                $("#cboProgram").append(s);
            });          
            
            var s = "";
            $.each(listProgram, function (i, item) {
                s = s.concat("<option value='", item.PROGRAM_CODE, "'>", item.PROGRAM_NAME, "</option>");
            });
            $("#cboProgram").append(s);

        }

        function getLanguageList() {
            callService("AuthenService.svc/GetLanguageList", "POST", "", function (results) {
                var list = $.parseJSON(results.d);
                var s = "";
                $.each(list, function (i, item) {
                    s = s.concat("<option value='", item.LANGUAGE_CODE, "'>", item.LANGUAGE_NAME, "</option>")
                });
                $("#cboLanguage").append(s);
            });
        }

        function getScreenProfile(listControl) {
            callService("AuthenService.svc/GetScreenProfileByLang", "POST", JSON.stringify({ programCode: programCode, langCode: lang }), function (results) {
                var list = $.parseJSON(results.d);
                var s = "", obj = {};
                if (list.length > 0) {
                    $.each(listControl, function (i, item) {
                        obj = _.findWhere(list, { OBJECT_ID: $(item).attr("data-lang") });
                        s = s.concat("<tr>");
                        s = s.concat("<td class='objId' style='vertical-align:middle;'>", $(item).attr("data-lang"), "</td>");
                        if (obj != undefined)
                            s = s.concat("<td><input type='text' class='form-control input-sm' value='", obj.OBJECT_TEXT, "' /></td>");
                        else
                            s = s.concat("<td><input type='text' class='form-control input-sm' value='", $(item).text(), "' /></td>");
                        s = s.concat("</tr>");
                    });

                } else {
                    $.each(listControl, function (i, item) {
                        s = s.concat("<tr>");
                        s = s.concat("<td class='objId' style='vertical-align:middle;'>", $(item).attr("data-lang"), "</td>");
                        s = s.concat("<td><input type='text' class='form-control input-sm' value='", $(item).text(), "' /></td>");
                        s = s.concat("</tr>");
                    });
                }
                $("#rowControl").empty();
                $("#rowControl").append(s);
            });
        }

        function clearTable() {
            $("#rowControl").empty();
            programCode = "";
            lang = "";
        }

        ////////////////////----------------Screen Profile-------------/////////////////////////
        function setScreenProfile() {
            //ajax
            callService("AuthenService.svc/GetScreenProfile", "POST", JSON.stringify({ programCode: "TRSCREEN" }), function (results) {
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

