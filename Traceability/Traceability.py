from time import sleep
from globals import Device, server_Check
from security.wnd_login import show_login
show_login()
from gui import app
server_Check()
if Device.RequiresUpdate == True:
    print("Preparing to Auto Update Unit ..........")
    app.destroy()
app.display()