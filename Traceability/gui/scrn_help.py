from gui import app, layout
from gui.menus import menu
from globals import Operational_Variables, Device, get_DeviceEndpoints , get_DeviceConfigurations, post_HandlingUnits, server_Check
from guizero import Box, Text, Picture, PushButton, Window
from labels import AutoSense, FactoryReset, LoadDefaults, Print_Config

def show_Help():
    def close_Help():
        help_scrn.destroy()
    # Help Screen
    help_scrn = Window(layout, 'Support', layout='grid', width=800, height=400)
    # Contents
    help_Title = Text(help_scrn, 'System Help', grid=[0,0,2,1])
    help_Title.text_size = 25
    contact_Procedure = Text(help_scrn, 'Please contact Pronto Support Desk to get assistance', grid=[0,1,2,1])
    software_Version = Text(help_scrn, 'Software Version: ' + str(Device.SoftwareVersion), grid=[0,2,2,1])

    img_help = Picture(help_scrn, image=Operational_Variables.OMD_Logo ,grid=[2,0,1,2])
    btn_Box_Bottom = Box(help_scrn, grid=[0,8,3,1], align='bottom')
    btn_Close_Help = PushButton(btn_Box_Bottom, command=close_Help, text="Close", align='left')
    btn_Close_SyncEndpoints = PushButton(btn_Box_Bottom, command=get_DeviceEndpoints, text="Get Endpoints", align='left')
    btn_Close_SyncProducts = PushButton(btn_Box_Bottom, command=get_DeviceConfigurations, text="Get Data", align='left')
    btn_Close_SyncHandlingUnits = PushButton(btn_Box_Bottom, command=post_HandlingUnits, text="Sync Handling Units", align='left')
    btn_Close_CheckServer = PushButton(btn_Box_Bottom, command=server_Check, text="Check Server", align='left')
    btn_Print_FactoryReset = PushButton(btn_Box_Bottom, command=FactoryReset, text="Reset Printer", align='left')
    btn_Print_AutoSense = PushButton(btn_Box_Bottom, command=AutoSense, text="Auto Sense", align='left')
    btn_Print_LoadDefaults = PushButton(btn_Box_Bottom, command=LoadDefaults, text="Load System Defaults", align='left')
    btn_Print_Print_Config = PushButton(btn_Box_Bottom, command=Print_Config, text="Print Config", align='left')
    help_scrn.show()

class update_Menu():
    btn_Support = PushButton(menu.main_menu, command=show_Help, text="Support", width="fill", align='top')