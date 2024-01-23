@ModelType Intranet.Device
@Code
    ViewData("Title") = "Devices"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "Edit Device | " & Model.Description
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")

End Code
@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(model) model.Id)
    @Html.HiddenFor(Function(model) model.Status)
    @Html.HiddenFor(Function(model) model.HardwareVersion)
    @Html.HiddenFor(Function(model) model.SoftwareVersion)
    @Html.HiddenFor(Function(model) model.StorageInformation)
    @Html.HiddenFor(Function(model) model.NetworkInformation)
    @Html.HiddenFor(Function(model) model.LocalWebServerUrlPORT)
    @Html.HiddenFor(Function(model) model.RequiresUpdate)
    @Html.HiddenFor(Function(model) model.LastReportedStatus)
    @Html.HiddenFor(Function(model) model.SerialNumber)
    @Html.HiddenFor(Function(model) model.SecurityKey)
    @Html.HiddenFor(Function(model) model.CurrentOperatorId)
    @Html.HiddenFor(Function(model) model.RequiresSupport)

    @<div class="form-horizontal">
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Description, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Description, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Description, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.IP, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.IP, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.IP, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Type, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.DropDownList("Type", Nothing, htmlAttributes:=New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.Type, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.MAC, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.MAC, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.MAC, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.SwitchPort, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.SwitchPort, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.SwitchPort, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.NetworkConfigIP, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.NetworkConfigIP, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.NetworkConfigIP, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.NetworkConfigSubnet, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.NetworkConfigSubnet, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.NetworkConfigSubnet, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.NetworkConfigGateway, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.NetworkConfigGateway, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.NetworkConfigGateway, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.NetworkConfigDNS, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.NetworkConfigDNS, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.NetworkConfigDNS, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.LockedOut, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.LockedOut, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.LockedOut, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Waypoint, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.DropDownList("Waypoint", Nothing, htmlAttributes:=New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.Waypoint, "", New With {.class = "text-danger"})
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
