@ModelType Intranet.Device
<div class="btn-toolbar">
    @Html.ActionLink("Reboot", "Device_Control", "Devices", New With {.Id = Model.Id, .SSHFunction = "Reboot"}, New With {.class = "btn btn-default"})
    @Html.ActionLink("Update\Install Repos", "Device_Control", "Devices", New With {.Id = Model.Id, .SSHFunction = "Repos"}, New With {.class = "btn btn-default"})
    @Html.ActionLink("Update\Install Python", "Device_Control", "Devices", New With {.Id = Model.Id, .SSHFunction = "Python"}, New With {.class = "btn btn-default"})
    @Html.ActionLink("Update\Install Pip", "Device_Control", "Devices", New With {.Id = Model.Id, .SSHFunction = "pip"}, New With {.class = "btn btn-default"})
    @Html.ActionLink("Update\Install GuiZero", "Device_Control", "Devices", New With {.Id = Model.Id, .SSHFunction = "GuiZero"}, New With {.class = "btn btn-default"})
    @Html.ActionLink("Update\Install Pillow", "Device_Control", "Devices", New With {.Id = Model.Id, .SSHFunction = "Pillow"}, New With {.class = "btn btn-default"})
    @Html.ActionLink("Update\Install 7z", "Device_Control", "Devices", New With {.Id = Model.Id, .SSHFunction = "7z"}, New With {.class = "btn btn-default"})
    @Html.ActionLink("Update\Install Julian", "Device_Control", "Devices", New With {.Id = Model.Id, .SSHFunction = "Julian"}, New With {.class = "btn btn-default"})
    @Html.ActionLink("Update\Install Labelary", "Device_Control", "Devices", New With {.Id = Model.Id, .SSHFunction = "Labelary"}, New With {.class = "btn btn-default"})
    @Html.ActionLink("Update\Install Zebra", "Device_Control", "Devices", New With {.Id = Model.Id, .SSHFunction = "Zebra"}, New With {.class = "btn btn-default"})
    @Html.ActionLink("Lock", "Device_Control", "Devices", New With {.Id = Model.Id, .SSHFunction = "Lock"}, New With {.class = "btn btn-default"})
    @Html.ActionLink("Backup", "Device_Control", "Devices", New With {.Id = Model.Id, .SSHFunction = "Backup"}, New With {.class = "btn btn-default"})
    @Html.ActionLink("Set Host Name", "Device_Control", "Devices", New With {.Id = Model.Id, .SSHFunction = "Set_Host"}, New With {.class = "btn btn-default"})
    @Html.ActionLink("Directories", "Device_Control", "Devices", New With {.Id = Model.Id, .SSHFunction = "Directories"}, New With {.class = "btn btn-default"})
    @Html.ActionLink("Decompress", "Device_Control", "Devices", New With {.Id = Model.Id, .SSHFunction = "Decompress"}, New With {.class = "btn btn-default"})
</div>

