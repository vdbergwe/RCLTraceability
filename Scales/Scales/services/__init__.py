from driver_1602 import lcd_text, lcd_init
import os
import datetime
from time import sleep
from statistics import median
from telnetlib import theNULL
import uuid
from globals import system_Checks, Operational_Variables, MachineConfiguration, Device, Batch, QC_Scale, QC_Station, Reading
import urllib.request, urllib.error
import requests
import ssl
import json
ssl._create_default_https_context = ssl._create_unverified_context
m = open("storage/configs/machine_config.json")
data = json.load(m)
m.close()
MachineConfiguration.BASE_URL = str(data["BASE_URL"])
MachineConfiguration.DEVICE_ID = str(data["DEVICE_ID"])
MachineConfiguration.REGISTRATION_URL = str(data["REGISTRATION_URL"])
MachineConfiguration.CONFIGURATION_ENDPOINTS_URL = str(data["CONFIGURATION_ENDPOINTS_URL"])
MachineConfiguration.DEV_MODE = str(data["DEV_MODE"])
MachineConfiguration.COUNTRY = str(data["COUNTRY"])
lcd_init()
LCD_LINE_1 = 0x80 # LCD memory location for 1st line
LCD_LINE_2 = 0xC0 # LCD memory location 2nd line
#Server Check
def server_Check():
    try:
        urllib.request.urlopen(MachineConfiguration.BASE_URL)  
    except urllib.error.HTTPError as e:
        print(str(datetime.datetime.now()) + ' Contacting Server | Failed')
        log_Entry = (str(datetime.datetime.now()) + ' Contacting Server | Failed' +'HTTPError: {}'.format(e.code))
        f = open("network_log.txt", "a")
        f.write("\n"+log_Entry)
        f.close()
        system_Checks.Server_Online = False
    except urllib.error.URLError as e:
        print(str(datetime.datetime.now()) + ' Contacting Server | Failed')
        log_Entry =(str(datetime.datetime.now()) + ' Contacting Server | Failed'+'URLError: {}'.format(e.reason))
        f = open("network_log.txt", "a")
        f.write("\n"+log_Entry)
        f.close()
        system_Checks.Server_Online = False
    else:
        print(str(datetime.datetime.now()) + ' Contacting Server | Success')
        Operational_Variables.Status = 'Online'
        system_Checks.Server_Online = True
#Get Latest Configs
def get_Online_Config():
    if system_Checks.Server_Online == True:
        print(str(datetime.datetime.now()) + ' Contacting Server | Going Online')
        url = urllib.request.urlopen(MachineConfiguration.BASE_URL + MachineConfiguration.REGISTRATION_URL + str(MachineConfiguration.DEVICE_ID))
        response = json.loads(url.read().decode())
        json_object = json.dumps(response, indent = 4)
        print(str(datetime.datetime.now()) + ' Contacting Server | Downloading Configuration | Started')
        f = open("storage/configs/configuration.json", "w")
        f.write(json_object)
        f.close()           
        print(str(datetime.datetime.now()) + ' Contacting Server | Downloading Configuration | Completed')
#Get Latest Endpoints
def get_DeviceEndpoints():
    if system_Checks.Server_Online == True:
        print(str(datetime.datetime.now()) + ' Contacting Server | Going Online')
        url = urllib.request.urlopen(MachineConfiguration.BASE_URL + MachineConfiguration.CONFIGURATION_ENDPOINTS_URL + str(MachineConfiguration.DEVICE_ID))
        response = json.loads(url.read().decode())
        json_object = json.dumps(response, indent = 4)
        print(str(datetime.datetime.now()) + ' Contacting Server | Downloading Configuration | Endpoints | Started')
        f = open("storage/configs/configuration_endpoints.json", "w")
        f.write(json_object)
        f.close()           
        print(str(datetime.datetime.now()) + ' Contacting Server | Downloading Configuration | Endpoints | Completed')
#Get Latest Device Configs
def get_Data():
    if system_Checks.Server_Online == True:
        global endpointsList
        print(str(datetime.datetime.now()) + ' Contacting Server | Going Online')
        if os.path.isfile("storage/configs/configuration_endpoints.json"):
            ec = open('storage/configs/configuration_endpoints.json')
            endpointsList = json.load(ec)
            for i in endpointsList:
                url = urllib.request.urlopen(MachineConfiguration.BASE_URL + str(i["EndpointUrl"]) + str(MachineConfiguration.DEVICE_ID))
                response = json.loads(url.read().decode())
                json_object = json.dumps(response, indent = 4)
                print(str(datetime.datetime.now()) + ' Contacting Server | Downloading Configuration | Started')
                lcd_init()
                lcd_text("Downloading ",LCD_LINE_1)
                lcd_text(i["Description"],LCD_LINE_2)
                f = open('storage/configs/' + i["Description"]+".json", "w")
                f.write(str(json_object))
                f.close()           
                print(str(datetime.datetime.now()) + ' Contacting Server | Downloading Configuration '+i["Description"]+' | Completed')
                sleep(1)
# Set Device Information
def set_Device():
    if system_Checks.HasLocalConfig == True or os.path.isfile("storage/configs/configuration.json"):
        f = open("storage/configs/configuration.json")
        data = json.load(f)
        f.close()
        Device.Id = str(data["Id"])
        Device.Description = str(data["Description"])
        Device.IP = str(data["IP"])
        Device.Type = str(data["Type"])
        Device.Status = str(data["Status"])
        Device.MAC = str(data["MAC"])
        Device.SwitchPort = str(data["SwitchPort"])
        Device.Switch = str(data["Switch"])
        Device.Location = str(data["Location"])
        Device.LocationName = str(data["LocationName"])
        Device.Plant = str(data["Plant"])
        Device.PlantName = str(data["PlantName"])
        Device.SerialNumber = str(data["SerialNumber"])
        print(str(datetime.datetime.now()) + ' Setting Client | Device Information | Success')
# Set QC_Scale_Station Information
def set_QC_Station():
    if  os.path.isfile("storage/configs/configuration_qc_station.json"):
        f = open("storage/configs/configuration_qc_station.json")
        data = json.load(f)
        f.close()
        QC_Station.Id = str(data["Id"])
        QC_Station.Description = str(data["Description"])
        QC_Station.Location = str(data["Location"])
        QC_Station.Functions = str(data["Functions"])
        QC_Station.QC_Scale = str(data["QC_Scale"])
        print(str(datetime.datetime.now()) + ' Setting Client | QC Station | Success')
# Set QC_Scale Information
def set_QC_Scale():
    if  os.path.isfile("storage/configs/configuration_qc_scale.json"):
        f = open("storage/configs/configuration_qc_scale.json")
        data = json.load(f)
        f.close()
        QC_Scale.Id = str(data["Id"])
        QC_Scale.Description = str(data["Description"])
        QC_Scale.Make = str(data["Make"])
        QC_Scale.Model = str(data["Model"])
        QC_Scale.LoadCapacity = str(data["LoadCapacity"])
        QC_Scale.UOM = str(data["UOM"])
        QC_Scale.Device = str(data["Device"])
        print(str(datetime.datetime.now()) + ' Setting Client | QC Scale | Success')
# Set Batch Information
def set_Batch():
    if system_Checks.HasLocalBatch == True or os.path.isfile("storage/configs/configuration_batch.json"):
        f = open("storage/configs/configuration_batch.json")
        data = json.load(f)
        f.close()
        Batch.Id = str(data["Id"])
        Batch.Description = str(data["Description"])
        Batch.Type = str(data["Type"])
        Batch.Status = str(data["Status"])
        Batch.Shift = str(data["Shift"])
        Batch.BatchDate = str(data["BatchDate"])
        Batch.BatchCreated = str(data["BatchCreated"])
        Batch.BatchEnded = str(data["BatchEnded"])
        print(str(datetime.datetime.now()) + ' Setting Client | Batch | Success')
        lcd_init()
        lcd_text("Batch Set", LCD_LINE_1)
        lcd_text(Batch.Description, LCD_LINE_2)
        sleep(1)
# Save Reading Offline
def Save_Reading():   
    data = {'Id': str(0),
            'ReadingDate': str(Reading.ReadingDate),
            'Product': str(Reading.Product),
            'Operator': str(0), 
            'S1': str(Reading.S1),
            'S2': str(Reading.S2),
            'S3': str(Reading.S3),
            'S4': str(Reading.S4), 
            "Median" : str(Reading.Median),
            "Tare" : str(Reading.Tare),
            "Result" : str(Reading.Result),
            "Status" : str(Reading.Status),
            "Result_Action" : str(Reading.Result_Action),
            "Target" : str(Reading.Target),
            "Batch" : str(Reading.Batch),
            "QC_Station" : str(Reading.QC_Station),
            "UOM" : str(Reading.UOM),
            "QC_Scale" : str(Reading.QC_Scale),
            }
    qc_Reading = json.dumps(data, indent = 4)
    print(qc_Reading)
    f = open(str("storage/local/"+str(uuid.uuid4().hex))+".json", "w")
    f.write(str(qc_Reading))
    f.close()
    lcd_init()
    lcd_text("Reading Saved",LCD_LINE_1)
    lcd_text("",LCD_LINE_2)
    sleep(1)

# Post Offline Readings
def post_Readings():
    # Get the list of all files and directories
    path = 'storage/local/'
    print(str(datetime.datetime.now()) + ' Contacting Server | Syncing Readings')
    reading_list = os.listdir(path)
    for r in reading_list:
        f = open(path + r)
        reading_json = json.load(f)
        f.close()
        print(reading_json)
        reading_json['Status'] = 'Synced'
        res = requests.post(MachineConfiguration.BASE_URL + 'QC_Scales_Readings/Create', json=reading_json, verify=False)
        print(res.text)
        if res.status_code == 200:
            os.rename(path + r, 'storage/remote/' + r)
    print(str(datetime.datetime.now()) + ' Contacting Server | Syncing Readings Completed')
    lcd_init()
    lcd_text("Readings Synced",LCD_LINE_1)
    lcd_text("",LCD_LINE_2)
    sleep(1)
# RunAll
class RunAll():
    server_Check()
    get_Online_Config()
    get_DeviceEndpoints()
    get_Data()
    post_Readings()
    #Setup
    set_Device()
    set_QC_Station()
    set_QC_Scale()
    set_Batch()
