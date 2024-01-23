@ModelType Intranet.Device
@Code
    ViewData("Title") = "Devices"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = Model.Description
    If ViewBag.IsPartial <> True Then
        Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
    End If
End Code
<h4>
    CPU @ViewBag.CPUTemp
</h4>
<dl class="dl-horizontal">
    <dt>
        @Html.DisplayNameFor(Function(model) model.CurrentOperatorId)
    </dt>

    <dd>
        @Html.DisplayFor(Function(model) model.CurrentOperatorId)
    </dd>
    <dt>
        @Html.DisplayNameFor(Function(model) model.LastCheckin)
    </dt>

    <dd>
        @Html.DisplayFor(Function(model) model.LastCheckin)
    </dd>
    <dt>
        @Html.DisplayNameFor(Function(model) model.Description)
    </dt>

    <dd>
        @Html.DisplayFor(Function(model) model.Description)
    </dd>

    <dt>
        @Html.DisplayNameFor(Function(model) model.IP)
    </dt>

    <dd>
        @Html.DisplayFor(Function(model) model.IP)
    </dd>

    <dt>
        @Html.DisplayNameFor(Function(model) model.Type)
    </dt>

    <dd>
        @Html.DisplayFor(Function(model) model.Type)
    </dd>

    <dt>
        @Html.DisplayNameFor(Function(model) model.Status)
    </dt>

    <dd>
        @Html.DisplayFor(Function(model) model.Status)
    </dd>

    <dt>
        @Html.DisplayNameFor(Function(model) model.MAC)
    </dt>

    <dd>
        @Html.DisplayFor(Function(model) model.MAC)
    </dd>

    <dt>
        @Html.DisplayNameFor(Function(model) model.SwitchPort)
    </dt>

    <dd>
        @Html.DisplayFor(Function(model) model.SwitchPort)
    </dd>

    <dt>
        @Html.DisplayNameFor(Function(model) model.Switch)
    </dt>

    <dd>
        @Html.DisplayFor(Function(model) model.Switch)
    </dd>

    <dt>
        @Html.DisplayNameFor(Function(model) model.SerialNumber)
    </dt>

    <dd>
        @Html.DisplayFor(Function(model) model.SerialNumber)
    </dd>
    <dt>
        @Html.DisplayNameFor(Function(model) model.NetworkInformation)
    </dt>
    <dd>
        @Html.DisplayFor(Function(model) model.NetworkInformation)
    </dd>
</dl>
<div>
    <h2>
        Device Control
    </h2>
    <div>
        @Html.Action("Device_Control", "Devices", New With {.Id = Model.Id, .IsPartial = True})
    </div>
</div>
