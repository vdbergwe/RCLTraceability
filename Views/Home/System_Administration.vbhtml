@Code
    ViewData("Title") = "System Administration"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "System Administration"
End Code
<style>
    .menu_Grid {
        background-color: whitesmoke;
        display: flex;
        flex-wrap: wrap;
        width: 100%;
    }

        .menu_Grid > .menu_Card {
            flex: 25%;
        }

    .menu_Card {
        background-color: white;
        border: 1px solid dodgerblue;
        padding: 0px;
        min-height: 100px;
        align-content: center;
        vertical-align: middle;
    }

        .menu_Card > h4 {
            text-align: center;
            padding: 0px;
            margin: 0px;
            background-color: dodgerblue;
            color: white;
            height: 30px;
        }

        .menu_Card > .menu_Card_Container {
            display: flex;
            flex-wrap: wrap;
        }

    .menu_Card_Container > i {
        padding: 10px;
        width: 30%;
        font-size: 50px;
        color: Highlight;
    }

    .menu_Card_Container > .card_Details {
        padding: 10px;
        height: 120px;
        width: 60%;
        word-wrap: anywhere;
        flex: 70%
    }
    @@media (max-width: 800px) {
        .menu_Grid > .menu_Card {
            flex: 100%;
        }
}

</style>
<div class="menu_Grid">
    <div class="menu_Card grow_row" onclick="location.href = '@Url.Action("Index", "Business_Units")'">
        <h4>
            Business Units
        </h4>
        <div class="menu_Card_Container">
            <i class="fa fa-building" aria-hidden="true"></i>
            <div class="card_Details">
                <h3>
                    @ViewBag.BU.Count()
                </h3>
            </div>
        </div>
    </div>
    <div class="menu_Card grow_row" onclick="location.href = '@Url.Action("Index", "Business_Units_Plants")'">
        <h4>
            Plants
        </h4>
        <div class="menu_Card_Container">
            <i class="fa fa-industry"></i>
            <div class="card_Details">
                <h3>
                    @ViewBag.Plants
                </h3>
            </div>
        </div>
    </div>
    <div class="menu_Card grow_row" onclick="location.href = '@Url.Action("Index", "Plants_Shifts")'">
        <h4>
            Shifts
        </h4>
        <div class="menu_Card_Container">
            <i class="fa fa-clock-o" aria-hidden="true"></i>
            <div class="card_Details">
                <h3>@ViewBag.CurrentShift</h3>
            </div>
        </div>
    </div>
    <div class="menu_Card grow_row" onclick="location.href = '@Url.Action("Index", "Production_Batches")'">
        <h4>
            Batches
        </h4>
        <div class="menu_Card_Container">
            <i class="fa fa-object-group" aria-hidden="true"></i>
            <div class="card_Details">
                <h3>Current Batch:<br />     @ViewBag.CurrentBatch</h3>
            </div>
        </div>
    </div>

    <div class="menu_Card grow_row" onclick="location.href = '@Url.Action("Index", "Devices")'">
        <h4>
            Devices
        </h4>
        <div class="menu_Card_Container">
            <i class="fa fa-tablet" aria-hidden="true"></i>
            <div class="card_Details">
                <h4>
                    Total:     @ViewBag.Devices.Count()<br />
                    Online:     @ViewBag.DevicesOnline<br />
                    Offline:    @ViewBag.DevicesOffline
                </h4>
            </div>
        </div>
    </div>

    <div class="menu_Card grow_row" onclick="location.href = '@Url.Action("Index", "QC_Scales")'">
        <h4>
            QC Scales
        </h4>
        <div class="menu_Card_Container">
            <i class="fa fa-balance-scale" aria-hidden="true"></i>
            <div class="card_Details">
                View Connected QC Scales<br />
                Total:     @ViewBag.QC_Scales.Count()<br />
                Online:   @ViewBag.QC_Scales_Online.Count()<br />
                Offline:   @ViewBag.QC_Scales_Offline.Count()
            </div>
        </div>
    </div>
    <div class="menu_Card grow_row" onclick="location.href = '@Url.Action("Index", "Waypoints_Devices")'">
        <h4>
            Waypoints
        </h4>
        <div class="menu_Card_Container">
            <i class="fa fa-tablet" aria-hidden="true"></i>
            <div class="card_Details">
                <h4>
                    PAS:   @ViewBag.PAS.Count()<br />
                    CPC:   @ViewBag.CPC.Count()<br />
                    GUS:   @ViewBag.GUS.Count()<br />
                    Mobile:   @ViewBag.Mobile.Count()
                </h4>
            </div>
        </div>
    </div>
    <div class="menu_Card grow_row" onclick="location.href = '@Url.Action("Index", "Devices_Information_Displays")'">
        <h4>
            Information Displays
        </h4>
        <div class="menu_Card_Container">
            <i class="fa fa-balance-scale" aria-hidden="true"></i>
            <div class="card_Details">
                <h3>
                    Online:   @ViewBag.IDS_Online.Count()<br />
                    Offline:   @ViewBag.IDS_Offline.Count()
                </h3>
            </div>
        </div>
    </div>
    <div class="menu_Card grow_row" onclick="location.href = '@Url.Action("Index", "Products")'">
        <h4>
            Products
        </h4>
        <div class="menu_Card_Container">
            <i class="fa fa-gift" aria-hidden="true"></i>
            <div class="card_Details">
                <h3>
                    @ViewBag.Products()
                </h3>
            </div>
        </div>
    </div>
    <div class="menu_Card grow_row" onclick="location.href = '@Url.Action("Index", "Waypoints_NumberBanks")'">
        <h4>
            Number Ranges
        </h4>
        <div class="menu_Card_Container">
            <i class="fa fa-desktop" aria-hidden="true"></i>
            <div class="card_Details">
                <h3>
                    @Viewbag.NumberRanges.Count()
                </h3>
            </div>
        </div>
    </div>
    <div class="menu_Card grow_row" onclick="location.href = '@Url.Action("Index", "Handling_Units")'">
        <h4>
            Handling Units
        </h4>
        <div class="menu_Card_Container">
            <i class="fa fa-desktop" aria-hidden="true"></i>
            <div class="card_Details">
                <h3>
                    @ViewBag.HU.Count()
                </h3>
            </div>
        </div>
    </div>
    <div class="menu_Card grow_row" onclick="location.href = '@Url.Action("Index", "Services")'">
        <h4>
            Services
        </h4>
        <div class="menu_Card_Container">
            <i class="fa fa-server" aria-hidden="true"></i>
            <div class="card_Details">
                <h4>
                    Total:     @ViewBag.Services.Count()<br />
                    Online:   @ViewBag.ServicesOnline<br />
                    Offline:   @ViewBag.ServicesOffline
                </h4>
            </div>
        </div>
    </div>
    <div class="menu_Card grow_row" onclick="location.href = '@Url.Action("Index", "Software_Dropdowns")'">
        <h4>
            System Types
        </h4>
        <div class="menu_Card_Container">
            <i class="fa fa-gear" aria-hidden="true"></i>
            <div class="card_Details">
                <h3>@ViewBag.Services.Count()</h3>
            </div>
        </div>
    </div>
    <div class="menu_Card grow_row" onclick="location.href = '@Url.Action("Treatment_Detail", "Treatments")'">
        <h4>
            Services
        </h4>
        <div class="menu_Card_Container">
            <i class="fa fa-tablet" aria-hidden="true"></i>
            <div class="card_Details">
                View Connected GUS<br />
                Total:     @ViewBag.Services.Count()<br />
                Online:   @ViewBag.Services.Count()<br />
                Offline:   @ViewBag.Services.Count()
            </div>
        </div>
    </div>
    <div class="menu_Card grow_row" onclick="location.href = '@Url.Action("Index", "Software_Packages")'">
        <h4>
            Configuration
        </h4>
        <div class="menu_Card_Container">
            <i class="fa fa-tablet" aria-hidden="true"></i>
            <div class="card_Details">
                Software Packages<br />
                Total:     @ViewBag.Services.Count()<br />
                Online:   @ViewBag.Services.Count()<br />
                Offline:   @ViewBag.Services.Count()
            </div>
        </div>
    </div>
    <div class="menu_Card grow_row" onclick="location.href = '@Url.Action("Index", "Software_Settings")'">
        <h4>
            Software Settings
        </h4>
        <div class="menu_Card_Container">
            <i class="fa fa-tablet" aria-hidden="true"></i>
            <div class="card_Details">
                View Settings<br />
            </div>
        </div>
    </div>
    <div class="menu_Card grow_row" onclick="location.href = '@Url.Action("Index", "Software_Packages")'">
        <h4>
            Software Packages
        </h4>
        <div class="menu_Card_Container">
            <i class="fa fa-tablet" aria-hidden="true"></i>
            <div class="card_Details">
                View Settings<br />
            </div>
        </div>
    </div>
    <div class="menu_Card grow_row" onclick="location.href = '@Url.Action("Menu_Main", "CCNCR")'">
        <h4>
            CC and NCR Configuration
        </h4>
        <div class="menu_Card_Container">
            <i class="fa fa-tablet" aria-hidden="true"></i>
            <div class="card_Details">
                View Settings<br />
            </div>
        </div>
    </div>
</div>