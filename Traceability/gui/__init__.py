from datetime import datetime
from time import sleep
from globals import Device, Waypoint
from guizero import App, Box, Text
app = App("Omegadata Waypoint Solution")
app.set_full_screen('True')
heading = Text(app, Waypoint.Type, width="fill")
heading.text_size = 25
heading.bg = '#0068b3'
heading.text_color = '#FFFFFF'
layout = Box(app, height='fill', width='fill', align='top', border = True)
main_gui = Box(layout, height='fill', width='fill', align='right', border=True)
content = Box(main_gui, height='fill', width='fill', align='top', border=True)
bar = Box(app, width='fill', align='bottom')
class status_Bar():
    global bar
    bar.destroy()
    bar = Box(app, width='fill', align='bottom')
    bar.text_size = 10
    txt_Device = Text(bar, 'Device: ' + Device.Description, align='left')
    txt_Waypoint = Text(bar, ' | Waypoint: ' + Waypoint.Description, align='left')
    txt_IP = Text(bar, ' | IP: ' + Device.IP, align='left')
    txt_MAC = Text(bar, ' | MAC: ' + Device.MAC , align='left')
    txt_User = Text(bar, ' | Username: ' + Device.CurrentOperatorId, align='left')
    txt_LastSynced = Text(bar, ' | Last Synced: ' + str(Device.LastCheckin), align='right')
    txt_Status = Text(bar, ' | Status: ' + Device.Status, align='right')
    txt_SoftwareVersion = Text(bar, ' | Software: ' + Device.SoftwareVersion, align='right')
if Device.LockedOut == True or Device.RequiresUpdate == True or Device.RequiresSupport == True:
        print("Device Lock Out Or Updating")
        from security.wnd_login import show_login
        show_login()
def launchSubSystem():
    if Waypoint.Type == 'PAS':
        from gui.gui_pas import pas
        from gui.scrn_help import update_Menu
        update_Menu()
        pas()
    elif Waypoint.Type == 'CPC':
        from gui.gui_cpc import cpc
        from gui.scrn_help import update_Menu
        update_Menu()
        cpc()
    elif Waypoint.Type == 'GUS':
        from gui.gui_gus import gus
        from gui.scrn_help import update_Menu
        update_Menu()
        gus()
