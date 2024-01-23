import os as OS
import datetime as DT
import socket
import re, uuid
from statistics import median
import sys
import json
from time import sleep
# Load LCD Drivers
#from driver_1602 import lcd_text, lcd_init
import time
#Start LCD
#lcd_init()
#LCD_LINE_1 = 0x80 # LCD memory location for 1st line
#LCD_LINE_2 = 0xC0 # LCD memory location 2nd line
#lcd_text("System Checks",LCD_LINE_1)
#sleep(0.5)
#lcd_text("Loading Globals",LCD_LINE_2)
# Classes
# Machine Config
class MachineConfiguration():
    BASE_URL = ""
    DEVICE_ID = 0
    REGISTRATION_URL = ""
    CONFIGURATION_ENDPOINTS_URL = ""
    DEV_MODE = True
    COUNTRY = ""
# Device
class Device():
    print(str(DT.datetime.now()) + ' | System | Sub System | Globals Loaded | Device')
    Id = str(MachineConfiguration.DEVICE_ID)
    Description = ''
    IP = ''
    Type = ''
    Status = ''
    MAC = ''
    SwitchPort = ''
    Switch = ''
    Location = ''
    LocationName = ''
    Plant = ''
    PlantName = ''
    SerialNumber = ''
    OS = ''
# Batch
class Batch():
        Id = ''
        Description = ''
        Type = ''
        Status = ''
        Shift = ''
        BatchDate = ''
        BatchCreated = ''
        BatchEnded = ''
# Operational Variables
class Operational_Variables():
    IsLoggedIn = False
    UserName = ''
    Status = ''
    LastSynced = ''
# Product
class Product():
    Id = 0
    Description = ''
    PLU = ''
    Type = ''
    Packaging = ''
    ConsumerUnits = 0
    SalesUnits = 0
    TargetWeight = 0.00
    UOM = ''
    TareWeight = 0.00
    Labels = 0
    Expiry = 0
    ConsumerBarcode = ''
    SalesUnitBarcode = ''
    Commodity = ''
    ProducedBy = ''
    Status = ''
    QCSampleSize = 0
# QC Scale Model
class QC_Scale():
    Id =0
    Description = ""
    Make = ""
    Model = ""
    LoadCapacity = 0
    UOM = ""
    Device = 0
    SoftwareVersion= ""
    BoardVersion= ""
    SerialNumber= ""
# QC Station Model
class QC_Station():
    Id =0
    Description =''
    Location = 0
    Functions =''
    QC_Scale = 0
# Reading Model
class Reading():
    Id = 0
    ReadingDate = DT.datetime.now()
    Product = 0
    Operator = 0
    S1 = 0.00
    S2 = 0.00
    S3 = 0.00
    S4 = 0.00
    Median = 0.00
    Tare = 0.00
    Result = ""
    Status = "Weighed"
    Result_Action = ""
    Target = 0.00
    Batch = 0
    QC_Station = 0
    UOM = 0.00
    QC_Scale = 0

# Startup Checks
class startup_Checks():
    global Device
    os_type = sys.platform.lower()
    if "darwin" in os_type:
        Device.SerialNumber =  "0000000000000000"
        Device.OS =  "Darwin"
    elif "win32" in os_type:
        Device.SerialNumber =  "0000000000000000"
        Device.OS =  "Windows"
    elif "linux" in os_type:
        Device.OS =  "linux"
        Device.SerialNumber = "0000000000000000"
        try:
            f = open('/proc/cpuinfo','r')
            for line in f:
                if line[0:6]=='Serial':
                    Device.SerialNumber = line[10:26]
            f.close()
        except:
            Device.OS =  "Raspbian"
            Device.SerialNumber = "ERROR000000000"
    # Get Device Information
    Device.Description = socket.gethostname()
    Device.IP = socket.gethostbyname(Device.Description)
    Device.MAC = str(':'.join(re.findall('..', '%012x' %uuid.getnode())))
    print("Checking Hardware        | OS:      " + Device.OS)
    print("Checking Hardware        | Serial:  " + Device.SerialNumber)
    print("Checking Hardware        | Network")
    print("Checking Network         | Hostname:     " + Device.Description)
    print("Checking Network         | IP:           " + Device.IP)
    print("Checking Network         | MAC:          " + Device.MAC)
    print("")
    #lcd_text("OS",LCD_LINE_1)
    #lcd_text(Device.OS,LCD_LINE_2)
    sleep(1)
    #lcd_text("Serial #",LCD_LINE_1)
    #lcd_text(Device.SerialNumber,LCD_LINE_2)
    #sleep(1)
    #lcd_text("Network Name",LCD_LINE_1)
    #lcd_text(Device.Description,LCD_LINE_2)
    #sleep(1)
    #lcd_text("Network IP",LCD_LINE_1)
    #lcd_text(Device.IP,LCD_LINE_2)
    #sleep(1)
    #lcd_text("Network MAC",LCD_LINE_1)
    #lcd_text(Device.MAC.replace(':',""),LCD_LINE_2)
    #sleep(2)
# System Checks
class system_Checks():
    HasLocalConfig = False
    HasLocalEndPoints = False
    HasLocalNumberBank = False
    HasLocalProducts = False
    HasLocalBatch = False
    HasWaypointConfig = False
    Server_Online = False
    system_Status = ''
# Run Startup Functions
#lcd_text("System Checks",LCD_LINE_1)
#lcd_text("Completed",LCD_LINE_2)
sleep(0.5)