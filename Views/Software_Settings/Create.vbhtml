@ModelType Intranet.Software_Settings
@Code
    ViewData("Title") = "Software Settings"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "Software Settings"
End Code
@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">

    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})


    <div class="form-group">
        @Html.LabelFor(Function(model) model.SettingName, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.SettingName, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.SettingName, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.SettingValue, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.SettingValue, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.SettingValue, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.SettingGroup, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.SettingGroup, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.SettingGroup, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.SettingSubGroup, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.SettingSubGroup, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.SettingSubGroup, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        <div class="col-md-offset-2 col-md-10 btn-group">
            <input type="submit" value="Save" class="btn btn-default" />
            @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
        </div>
    </div>
</div>
End Using
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
