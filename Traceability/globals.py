import urllib.request, urllib.error, requests
import os
import datetime
import math
import socket
import time
import re, uuid
import sys
import json
#import julian
from datetime import datetime, timedelta

def is_server_visible():
    try:        
        socket.create_connection(('rclstrace01.tsb.co.za', 80), timeout=5)
        return True
    except (socket.timeout, socket.error):
        return False

def connect_to_server():
    while not is_server_visible():
        print("Server not visible. Retrying in 10 seconds...")
        time.sleep(10)

    print("Server is now visible. Connecting...")    

connect_to_server()

class MachineConfiguration:
    if os.path.isfile("storage/configs/machine_config.json"):
        f = open("storage/configs/machine_config.json")
        data = json.load(f)
        f.close()
    else:
        print("Configuration Error Occured Contact Support To Assist")
    # Model Data
    BASE_URL = str(data["BASE_URL"])
    REGISTRATION_URL = str(data["REGISTRATION_URL"])
    CONFIGURATION_ENDPOINTS_URL = str(data["CONFIGURATION_ENDPOINTS_URL"])
    DEVICE_ID = str(data["DEVICE_ID"])
    DEV_MODE = str(data["DEV_MODE"])
    COUNTRY = str(data["COUNTRY"])
    url = urllib.request.urlopen(BASE_URL + REGISTRATION_URL + DEVICE_ID)
    response = json.loads(url.read().decode())
    data = json.dumps(response, indent = 4)
    f = open("storage/configs/configuration.json", "w")
    f.write(data)
    f.close()
# Device
class Device():
    if os.path.isfile("storage/configs/configuration.json") == False:
        print("Configuration Error Occured Contact Support To Assist")
        os.kill()
    f = open("storage/configs/configuration.json")
    data = json.load(f)
    f.close()
    # Model Data
    Id = str(data["Id"])
    Description = str(data["Description"])
    IP = str(data["IP"])
    Type = str(data["Type"])
    Status = str(data["Status"])
    MAC = str(data["MAC"])
    SwitchPort = str(data["SwitchPort"])
    Switch = str(data["Switch"])
    SerialNumber = str(data["SerialNumber"])
    HardwareVersion= str(data["HardwareVersion"])
    SoftwareVersion = str(data["SoftwareVersion"])
    StorageInformation = str(data["StorageInformation"])
    NetworkInformation = str(data["NetworkInformation"])
    LocalWebServerUrlPORT = str(data["LocalWebServerUrlPORT"])
    RequiresUpdate = str(data["RequiresUpdate"])
    LastCheckin = str(data["LastCheckin"])
    LastReportedStatus = str(data["LastReportedStatus"])
    NetworkConfigIP = str(data["NetworkConfigIP"])
    NetworkConfigSubnet = str(data["NetworkConfigSubnet"])
    NetworkConfigGateway = str(data["NetworkConfigGateway"])
    NetworkConfigDNS = str(data["NetworkConfigDNS"])
    LockedOut = str(data["LockedOut"])
    LockedOutBy = str(data["LockedOutBy"])
    LockedOutOn = str(data["LockedOutOn"])
    SecurityKey = str(data["SecurityKey"])
    CurrentOperatorId = str(data["CurrentOperatorId"])
    RequiresSupport = str(data["RequiresSupport"])
# Waypoint
class Waypoint():
    f = open("storage/configs/configuration.json")
    data = json.load(f)
    f.close()
    Id = str(data['Waypoint1']['Id'])
    Description = str(data['Waypoint1']['Description'])
    Type = str(data['Waypoint1']['Type'])
    Status = str(data['Waypoint1']['Status'])
    UOM = str(data['Waypoint1']['UOM'])
    LoadCapcity = str(data['Waypoint1']['LoadCapcity'])
    HasPrinter = str(data['Waypoint1']['HasPrinter'])
    HasScanner = str(data['Waypoint1']['HasScanner'])
    Location = str(data['Waypoint1']['Location'])
# Number Range
class NumberRange():
    if os.path.isfile("storage/configs/configuration.json"):
        f = open("storage/configs/configuration.json")
        data = json.load(f)
        f.close()
    Id = str(data['Waypoint1']['Waypoints_NumberBanks']['Id'])
    Prefix = str(data['Waypoint1']['Waypoints_NumberBanks']['Prefix'])
    Bank = str(data['Waypoint1']['Waypoints_NumberBanks']['Bank'])
    Root = str(data['Waypoint1']['Waypoints_NumberBanks']['Root'])
    FirstNumber = str(data['Waypoint1']['Waypoints_NumberBanks']['FirstNumber'])
    LastNumber = str(data['Waypoint1']['Waypoints_NumberBanks']['LastNumber'])
    LastIssued = str(data['Waypoint1']['Waypoints_NumberBanks']['LastIssued'])
    Created = str(data['Waypoint1']['Waypoints_NumberBanks']['Created'])
    Reserved = str(data['Waypoint1']['Waypoints_NumberBanks']['Reserved'])
    Released = str(data['Waypoint1']['Waypoints_NumberBanks']['Released'])
    Depleted = str(data['Waypoint1']['Waypoints_NumberBanks']['Depleted'])
    Waypoint = str(data['Waypoint1']['Waypoints_NumberBanks']['Waypoint'])
    Device = Device.Id
    Status = str(data['Waypoint1']['Waypoints_NumberBanks']['Status'])
    NextNumber = str(int(data['Waypoint1']['Waypoints_NumberBanks']['LastIssued']) + 1).zfill(5)
# Batch
class Batch():
    if os.path.isfile("storage/configs/configuration.json"):
        f = open("storage/configs/configuration.json")
        data = json.load(f)
        f.close()
    Id = str(data['Waypoint1']['Waypoints_Batches']['Id'])
    Description = str(data['Waypoint1']['Waypoints_Batches']['Description'])
    Type = str(data['Waypoint1']['Waypoints_Batches']['Type'])
    Status = str(data['Waypoint1']['Waypoints_Batches']['Status'])
    Shift = str(data['Waypoint1']['Waypoints_Batches']['Shift'])
    BatchDate = str(data['Waypoint1']['Waypoints_Batches']['BatchDate'])
    BatchCreated = str(data['Waypoint1']['Waypoints_Batches']['BatchCreated'])
    BatchEnded = str(data['Waypoint1']['Waypoints_Batches']['BatchEnded'])
    Plant = str(data['Waypoint1']['Waypoints_Batches']['Plant'])
# Check Waypoint Settings
class Waypoint_Configurations:
    f = open("storage/configs/configuration.json")
    data = json.load(f)
    f.close()
    CHECK_IN_INTERVAL = ''
    PRINT_DEFAULT_PRINTER = 'Zebra_Technologies_ZTC_ZT230-200dpi_ZPL'
    PRINT_LABELS = ''
    LABEL_QTY = ''
    for p in data['Waypoint1']["Waypoints_Configurations"]:
        if p['Id'] == 'CHECK_IN_INTERVAL':
            CHECK_IN_INTERVAL = p["SettingValue"]
        if p['Id'] == 'PRINT_DEFAULT_PRINTER':
            PRINT_DEFAULT_PRINTER = p["SettingValue"]
        if p['Id'] == 'PRINT_LABELS':
            PRINT_LABELS = p["SettingValue"]
        if p['Id'] == 'LABEL_QTY':
            LABEL_QTY = p["SettingValue"]
# All Data has been Recevied
# Operational Variable
class Operational_Variables():
    OMD_Logo = 'storage/images/logo.png'
    Customer_Logo = 'storage/images/logo_rcl.png'
    LabelImg = ''
    IsLoggedIn = False
    def calculate_julian_date(date_time):
        julian_datetime = 367 * date_time.year - int((7 * (date_time.year + int((date_time.month + 9) / 12.0))) / 4.0) + int(
                        (275 * date_time.month) / 9.0) + date_time.day + 1721013.5 + (date_time.hour + date_time.minute / 60.0 + date_time.second / math.pow(
                            60,2)) / 24.0 - 0.5 * math.copysign(1, 100 * date_time.year + date_time.month - 190002.5) + 0.5

        return julian_datetime

    # Get current date and time
    current_datetime = datetime.now() + timedelta(hours=12)

    # Convert to Julian Date manually
    DateCode = calculate_julian_date(current_datetime)
    #DateCode = julian.to_jd(datetime.datetime.now() + timedelta(hours=12), fmt='jd')

    print(DateCode)

    

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
    print("Checking Hardware        | OS:           " + Device.OS)
    print("Checking Hardware        | Serial:       " + Device.SerialNumber)
    print("Checking Network         | Hostname:     " + Device.Description)
    print("Checking Network         | IP:           " + Device.IP)
    print("Checking Network         | SubNet:       " + Device.NetworkConfigSubnet)
    print("Checking Network         | Gateway:      " + Device.NetworkConfigGateway)
    print("Checking Network         | MAC:          " + Device.MAC)
    print("Checking Software        | Version:      " + Device.SoftwareVersion)
    print("Checking Hardware        | Hardware      " + Device.HardwareVersion)
    print("Checking Security        | IsLocked:     " + Device.LockedOut)
    print("Checking Updates         | Update:       " + Device.RequiresUpdate)
    print("")
# System Checks
class system_Checks():
    Server_Online = False
    system_Status = ''
# System Printer
class system_Printer():
    HasPrinter = Waypoint.HasPrinter
    Printer = Waypoint_Configurations.PRINT_DEFAULT_PRINTER
    Type = False
    DeviceId = Device.Id
    Status = ''
# Product
class Product():
    Id = 0
    Description = 'Ready to Scan'
    PLU = ''
    Type = ''
    Packaging = ''
    ConsumerUnits = 0
    SalesUnits = 0
    TargetWeight = 0
    UOM = ''
    TareWeight = 0
    Labels = 0
    Expiry = 0
    ConsumerBarcode = ''
    SalesUnitBarcode = ''
    Commodity = ''
    ProducedBy = ''
    Status = ''
    HUTargetWeight = 0
    WERKS = ''
    GTIN_HU = ''
    def clear():
        Product.Id = 0
        Product.Description = 'Ready to Scan'
        Product.PLU = ''
        Product.Type = ''
        Product.Packaging = ''
        Product.ConsumerUnits = 0
        Product.SalesUnits = 0
        Product.TargetWeight = 0
        Product.UOM = ''
        Product.TareWeight = 0
        Product.Labels = 0
        Product.Expiry = 0
        Product.ConsumerBarcode = ''
        Product.SalesUnitBarcode = ''
        Product.Commodity = ''
        Product.ProducedBy = ''
        Product.Status = ''
        Product.HUTargetWeight = 0
        Product.WERKS = ''
        Product.GTIN_HU = ''
# Handling Units
class HandlingUnit():
    Id = ''
    LabelsPrinted = ''
    SSCC = NumberRange.SSCC = str(NumberRange.Prefix + NumberRange.Root + NumberRange.Bank + NumberRange.NextNumber)
    CheckDigit = ''
    Product = ''
    ProductBarcode = ''
    NumberBank = ''
    Batch = ''
    Device = ''
    Status = ''
    LabelImage = ''
    ExpiryDate = ''
    PrintedLabels = ''
    ScannedGTIN = ''
    Horse = ''
    Trailer = ''
    Berth = ''
    def clear():
        HandlingUnit.Id = ''
        HandlingUnit.LabelsPrinted = ''
        HandlingUnit.SSCC = NumberRange.SSCC = str(NumberRange.Prefix + NumberRange.Root + NumberRange.Bank + NumberRange.NextNumber)
        HandlingUnit.CheckDigit = ''
        HandlingUnit.Product = ''
        HandlingUnit.ProductBarcode = ''
        HandlingUnit.NumberBank = ''
        HandlingUnit.Batch = ''
        HandlingUnit.Device = ''
        HandlingUnit.Status = ''
        HandlingUnit.LabelImage = ''
        HandlingUnit.ExpiryDate = ''
        HandlingUnit.PrintedLabels = ''
        HandlingUnit.ScannedGTIN = ''
        HandlingUnit.Horse = ''
        HandlingUnit.Trailer = ''
        HandlingUnit.Berth = ''

# Run Startup Functions
#__________________________End Current_______________________
OMD_Logo = 'storage/images/logo_omd.png'
Customer_Logo = 'storage/images/logo.png'
IsLoggedIn = False
Status = ''
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
        system_Checks.Server_Online = True
        f = open('storage/configs/configuration.json')
        mc_json = json.load(f)
        f.close()
        url = requests.post(MachineConfiguration.BASE_URL + '/Devices/Device_Checkin', json=mc_json, verify=True)
        response = json.loads(url._content.decode())
        data = json.dumps(response, indent = 4)
        f = open("storage/configs/configuration.json", "w")
        f.write(data)
        f.close()
        if os.path.isfile("storage/configs/configuration.json") == False:
            print("Configuration Error Occured Contact Support To Assist")
            os.kill()
        f = open("storage/configs/configuration.json")
        data = json.load(f)
        f.close()
        # Model Data
        Device.Id = str(data["Id"])
        Device.Description = str(data["Description"])
        Device.Type = str(data["Type"])
        Device.Status = str(data["Status"])
        Device.LocalWebServerUrlPORT = str(data["LocalWebServerUrlPORT"])
        Device.RequiresUpdate = str(data["RequiresUpdate"])
        Device.LastCheckin = str(data["LastCheckin"])
        Device.LockedOut = str(data["LockedOut"])
        Device.SecurityKey = str(data["SecurityKey"])
        Device.CurrentOperatorId = str(data["CurrentOperatorId"])
        Device.RequiresSupport = str(data["RequiresSupport"])
        NumberRange.LastIssued = str(data['Waypoint1']['Waypoints_NumberBanks']['LastIssued'])
        NumberRange.NextNumber = str(int(data['Waypoint1']['Waypoints_NumberBanks']['LastIssued']) + 1).zfill(5)
        Batch.BatchId = str(data['Waypoint1']['Waypoints_Batches']['Id'])
        Batch.Description = str(data['Waypoint1']['Waypoints_Batches']['Description'])
        Batch.Type = str(data['Waypoint1']['Waypoints_Batches']['Type'])
        Batch.Status = str(data['Waypoint1']['Waypoints_Batches']['Status'])
        Batch.Shift = str(data['Waypoint1']['Waypoints_Batches']['Shift'])
        Batch.BatchDate = str(data['Waypoint1']['Waypoints_Batches']['BatchDate'])
        Batch.BatchCreated = str(data['Waypoint1']['Waypoints_Batches']['BatchCreated'])
        Batch.BatchEnded = str(data['Waypoint1']['Waypoints_Batches']['BatchEnded'])
        Batch.Plant = str(data['Waypoint1']['Waypoints_Batches']['Plant'])


def get_DeviceEndpoints():
    url = urllib.request.urlopen(MachineConfiguration.BASE_URL + MachineConfiguration.CONFIGURATION_ENDPOINTS_URL + str(MachineConfiguration.DEVICE_ID))
    endpoints = json.loads(url.read().decode())
    endpoints_object = json.dumps(endpoints, indent = 4)
    f = open("storage/configs/configuration_endpoints.json", "w")
    f.write(endpoints_object)
    f.close()           
def get_DeviceConfigurations():
    global endpointsList
    if os.path.isfile("storage/configs/configuration_endpoints.json"):
        ec = open('storage/configs/configuration_endpoints.json')
        endpointsList = json.load(ec)
        for i in endpointsList:
            url = urllib.request.urlopen(MachineConfiguration.BASE_URL + str(i["EndpointUrl"]) + str(MachineConfiguration.DEVICE_ID))
            response = json.loads(url.read().decode())
            json_object = json.dumps(response, indent = 4)
            f = open('storage/configs/' + i["Description"]+".json", "w")
            f.write(str(json_object))
            f.close()           

def post_HandlingUnits():
    def post_HandlingUnit():
        path = 'storage/handlingUnits/local/'
        hu_list = os.listdir(path)
        for hu in hu_list:
            f = open(path + hu)
            hu_json = json.load(f)
            f.close()
            print(hu_json)
            if hu_json['ScannedCode'] != '':
                hu_json['Status'] = 'From CPC'
                res = requests.post(MachineConfiguration.BASE_URL + '/Handling_Units/PAS', json=hu_json, verify=True)
                try:
                    res = requests.post(MachineConfiguration.BASE_URL + '/Handling_Units/PAS', json=hu_json, verify=True)
                    print('Handling Unit Sync Completed')
                except:
                    print('Handling Unit Sync Failed')
                else:
                    os.remove(path + hu)
                print(res.text)
            else:
                os.remove(path + hu)
    post_HandlingUnit()
def pas_Save_HU():
    HandlingUnit.Status = 'Created Locally'
    data = {'Id': str(0),
            'SSCC': str(HandlingUnit.SSCC),
            'Product': str(Product.Id), 
            'Created': str(datetime.now()), 
            'CreatedBy': str(Device.CurrentOperatorId),
            'Status': str(HandlingUnit.Status),
            'NumberBank': str(NumberRange.Id),
            'Device': str(Device.Id), 
            'Batch': str(Batch.Id),
            'ScannedCode': str(HandlingUnit.ScannedGTIN),
            'Description': str(Product.Description)
            }
    hu_json = json.dumps(data, indent = 4)
    print(hu_json)
    f = open(str("storage/handlingUnits/local/"+str(HandlingUnit.SSCC))+".json", "w")
    f.write(str(hu_json))
    f.close() 
    f = open("storage/configs/configuration.json", "r")
    data = json.load(f)
    data['Waypoint1']['Waypoints_NumberBanks']['LastIssued'] = str(int(NumberRange.LastIssued) + 1).zfill(5)
    data["LastCheckin"] = str(datetime.now())
    json_object = json.dumps(data, indent = 4)
    f.close()
    f = open("storage/configs/configuration.json", "w")
    f.write(json_object)  
    f.close()   
    NumberRange.LastIssued = data['Waypoint1']['Waypoints_NumberBanks']['LastIssued']
    NumberRange.NextNumber = str(int(data['Waypoint1']['Waypoints_NumberBanks']['LastIssued']) + 1).zfill(5)

def hu_Reject():
    print('Rejecting HU')
    print('Going Online')
    SSCC = ''
    res = requests.get(MachineConfiguration.BASE_URL + '/Handling_Units/HU_Reject/?SSCC='+ SSCC + '&', verify=True)


def cpc_Save_HU():
    Operational_Variables.Status = 'Online Syncing Handling Units'
    data = {'Id': str(HandlingUnit.Id),
            'SSCC': str(HandlingUnit.SSCC),
            'Product': str(HandlingUnit.Product), 
            'Created': str(datetime.datetime.now()), 
            'CreatedBy': str(Device.CurrentOperatorId),
            'Status': str(HandlingUnit.Status),
            'NumberBank': str(HandlingUnit.NumberBank),
            'Device': str(Device.Id), 
            'Batch': str(HandlingUnit.Batch),
            'Horse' : str(HandlingUnit.Horse),
            'Trailer' : str(HandlingUnit.Trailer),
            'Berth' : str(HandlingUnit.Berth)
            }
    hu_json = json.dumps(data, indent = 4)
    print(hu_json)
    print('Syncing Handling Units')
    url = requests.post(MachineConfiguration.BASE_URL + '/Handling_Units/CPC', json=data, verify=True)
    response = json.loads(url._content.decode())
    print(response)
    hu_json = json.dumps(response, indent = 4)
    print(hu_json)
    f = open(str("storage/handlingUnits/cpc/manifests/"+str(HandlingUnit.Horse))+".json", "w")
    f.write(str(hu_json))
    f.close()
    print('Handling Unit Sync Completed')
    Operational_Variables.LastSynced = str(datetime.now())
def gus_Save_HU():
    Operational_Variables.Status = 'Online Syncing Handling Units'
    data = {'Id': str(HandlingUnit.Id),
            'SSCC': str(HandlingUnit.SSCC),
            'Product': str(HandlingUnit.Product), 
            'Created': str(datetime.now()), 
            'CreatedBy': str(Device.CurrentOperatorId),
            'Status': str(HandlingUnit.Status),
            'NumberBank': str(HandlingUnit.NumberBank),
            'Device': str(Device.Id), 
            'Batch': str(HandlingUnit.Batch),
            'Horse' : str(HandlingUnit.Horse),
            'Trailer' : str(HandlingUnit.Trailer),
            'Berth' : str(HandlingUnit.Berth)
            }
    hu_json = json.dumps(data, indent = 4)
    print(hu_json)
    print('Syncing Handling Units')
    url = requests.post(MachineConfiguration.BASE_URL + '/Handling_Units/GUS', json=data, verify=True)
    response = json.loads(url._content.decode())
    print(response)
    hu_json = json.dumps(response, indent = 4)
    print(hu_json)
    f = open(str("storage/handlingUnits/gus/manifests/"+str(HandlingUnit.Horse))+".json", "w")
    f.write(str(hu_json))
    f.close()
    print('Handling Unit Sync Completed')
    Operational_Variables.LastSynced = str(datetime.now())
get_DeviceEndpoints()
get_DeviceConfigurations()
