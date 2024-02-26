from time import sleep
from guizero import Box, Text, TextBox, TitleBox
from gui import heading, content, main_gui
from globals import HandlingUnit, MachineConfiguration, Waypoint, gus_Save_HU
import urllib.request, urllib.error, os
from datetime import *
import json
global Horse, Trailer, Berth

Horse = ''
Trailer = ''
Berth = ''
Consignment = []

def Reload():
    gus()
def gus():
    global content
    content.destroy()
    content = Box(main_gui, height='fill', width='fill', align='top', border=True)
    heading.value = Waypoint.Type + ' | ' + Waypoint.Description
    class header():
        global content
        header_bar = Box(content, width='fill', align='top')
        header_bar.text_size = 12
        scannerBx = Box(content, width='fill', height='fill', align='left', border=True)        
    class scanner():
        global input_Scanner, action_Scanner_Result, input_Scanner_Result, content, Consignment
        def scan():
            global input_Scanner, Horse, Trailer, input_Scanner_Result, HandlingUnit, Consignment, Berth, action_Scanner_Result
            inputText = input_Scanner.value
            if len(input_Scanner.value) >= 7 and "TRN" in inputText:
                print("New Vehicle Started")
                #Creates New Array as Train
                Horse = input_Scanner.value + " " + str(datetime.now()).replace(":","").replace(".","")
                input_Scanner_Result.value = 'New Tractor Scanned'
                action_Scanner_Result.value = 'Scan Trailer or Scan Handling Unit To Continue'
                input_Scanner.value = ''
                input_Scanner.focus()
            elif len(input_Scanner.value) >= 7 and "FRK" in inputText:
                print("New Vehicle Started")
                #Creates New Array as Train
                Horse = input_Scanner.value + " " + str(datetime.now()).replace(":","").replace(".","")
                input_Scanner_Result.value = 'New Forklift Scanned'
                action_Scanner_Result.value = 'Scan Trailer or Scan Handling Unit To Continue'
                input_Scanner.value = ''
                input_Scanner.focus()
            elif len(input_Scanner.value) >= 7 and "TRR" in inputText:
                #Creates Trailer Record For Horse
                print("Trailer Linked to Vehicle")
                input_Scanner_Result.value = 'Trailer Scanned'
                action_Scanner_Result.value = 'Scan Handling Unit To Continue'
                Trailer = input_Scanner.value
                input_Scanner.value = ''
                input_Scanner.focus()
            elif  len(input_Scanner.value) >= 7 and "TRB" in inputText:
                #Creates Berth Record For Handling Unit
                print("Berth Linked to Trailer and HU")
                Berth = input_Scanner.value
                input_Scanner_Result.value = 'Berth Scanned'
                action_Scanner_Result.value = 'Scan HU To Continue'
                input_Scanner.value = ''
                input_Scanner.focus()
            elif len(input_Scanner.value) == 20 and str.isalnum(input_Scanner.value):
                f = open('storage/handlingUnits/gus/pending.json')
                hu = json.load(f)
                f.close()
                for i in hu:
                    if i['SSCC'] == inputText:
                        print(i['SSCC'])
                        HandlingUnit.SSCC = (i['SSCC'])
                        HandlingUnit.Id = (i['Id'])
                        HandlingUnit.Product = (i['Product'])
                        HandlingUnit.Created = (i['Created'])
                        HandlingUnit.CreatedBy = (i['CreatedBy'])
                        HandlingUnit.NumberBank = (i['NumberBank'])
                        HandlingUnit.Device = (i['Device'])
                        HandlingUnit.Batch = (i['Batch'])
                        HandlingUnit.Age = (i['Age'])
                        HandlingUnit.ScannedGTIN = (i['ScannedCode'])
                        HandlingUnit.ProductDescription = (i['ProductDescription'])
                        HandlingUnit.Horse = Horse
                        HandlingUnit.Trailer = Trailer
                        HandlingUnit.Berth = Berth
                        input_Scanner_Result.value = 'Scan Action or Next HU or Berth'
                        action_Scanner_Result.value = ''
                        input_Scanner.value = ''
                        input_Scanner.focus()
                        HandlingUnit.Status = 'ACCEPTED'
                        input_Scanner.focus()
                        action_Scanner_Result.value = 'Accepted'
                        gus_Save_HU()
                        sleep(1)
                        input_Scanner.value = ''
                        break
                    else:
                        input_Scanner_Result.value = 'Invalid Scan'
                        sleep(1)
                        input_Scanner_Result.value = 'Scan Action or Next HU or Berth'
                        action_Scanner_Result.value = ''
                        input_Scanner.value = ''
                        input_Scanner.focus()
            elif inputText == "ACCEPT":
                HandlingUnit.Status = 'ACCEPTED'
                input_Scanner.focus()
                action_Scanner_Result.value = 'Accepted'
                gus_Save_HU()
                sleep(1)
                input_Scanner.value = ''
            elif inputText == "REJECT":
                HandlingUnit.Status = 'REJECT'
                input_Scanner.focus()
                action_Scanner_Result.value = 'Rejected'
                gus_Save_HU()
                sleep(1)
                input_Scanner.value = ''
            elif inputText == "RELEASEALL":
                RejectedStock = 0
                f = open('storage/handlingUnits/gus/manifests/' + HandlingUnit.Horse + '.json')
                hu = json.load(f)
                f.close()
                for i in hu:
                    if i['Status'] != 'ACCEPTED' and i['Status'] != 'REJECT':
                        RejectedStock = RejectedStock + 1
                if RejectedStock == 0:
                    HandlingUnit.Status = 'RELEASEALL'
                    gus_Save_HU()
                    action_Scanner_Result.value = 'Released'
                    #GREEN LIGHT ON
                    sleep(1)
                    Reload()
                else:
                    action_Scanner_Result.value = "HU's Pending Removal"
            elif inputText == "RESET":
                HandlingUnit.Status = 'GUS_CANCEL_TRAIN'
                gus_Save_HU()
                action_Scanner_Result.value = 'Train Cancelled Start Again'
                sleep(1)
                Reload()
        scanner = Box(content, width='fill', align='left', border=True, height='fill')
        scanner.bg = '#ffffff'
        scanner.text_size = 28
        scanner_group = Box(scanner, align='top', width='fill', height='fill', border=True)
        input_Scanner = TextBox(scanner_group, width='fill', align='top')
        input_Scanner.bg = '#0068b3'
        input_Scanner.text_color = '#ffffff'
        input_Scanner.value = ''
        input_Scanner.focus()
        input_Scanner_Result = TextBox(scanner_group, width='fill', align='top')
        input_Scanner_Result.value = 'Scan Train or Forklift To Start'
        input_Scanner_Result.text_size = 28
        input_Scanner_Result.disable()
        input_Scanner.when_key_pressed = scan
        action_Scanner_Result = TextBox(scanner_group, width='fill', align='top')
        action_Scanner_Result.value = ''
        action_Scanner_Result.text_size = 28
        action_Scanner_Result.disable()
        #box_label = Box(content, width='fill', height='fill', align='right', border=True)
        #img_Label = Picture(box_label, image=Operational_Variables.OMD_Logo)
        #product_box = Box(scannerBx, width='fill', align='bottom', layout='grid')
        hu_list_box = TitleBox(scanner_group, 'Pending From CPC',align='bottom', width='fill', height='fill')
        path = 'storage/handlingUnits/gus/pending.json'
        if os.path.exists(path):        
            p = open(path)
            schu = json.load(p)
            p.close()
            for j in schu:
                row = Box(hu_list_box, align='top', width='fill', border=True)
                row.text_size = 8
                Text(row, j['ScannedCode'], align='left')
                Text(row, j['ProductDescription'], align='left')
                if j['ScannedCode'] == '':
                    row.bg = 'Red'
                elif j['ScannedCode'] != '':
                    row.bg = '#00ff00'
                else:
                    row.bg = 'Orange'
    class ResultsGroup:
        global bx_receive
        def clear():
            global bx_receive
            bx_receive.destroy()
        bx_receive = TitleBox(content, 'GUS Ready',align='right', width='fill', height='fill')    
        header = Box(bx_receive,align='top', width='fill', border=True)
        header.bg = 'Lime'        
        header.text_size = 9
        bx_receive_SSCC = Text(header, 'SSCC                | ', align='left')
        bx_receive_prod = Text(header, 'Product', align='left')
        bx_receive_age = Text(header, 'Waiting Time', align='right')
        url = urllib.request.urlopen(MachineConfiguration.BASE_URL + "/Handling_Units/Get_GUS_List/?DeviceId=" + str(MachineConfiguration.DEVICE_ID) + "&Status=From%20CPC")
        response = json.loads(url.read().decode())
        pending_HUs = json.dumps(response, indent = 4)
        print(str(datetime.now()) + ' Contacting Server | Downloading Pending Units | Started')
        f = open("storage/handlingUnits/gus/pending.json", "w")
        f.write(pending_HUs)
        f.close()
        print(pending_HUs)
        url = urllib.request.urlopen(MachineConfiguration.BASE_URL + "/Handling_Units/Get_GUS_List/?DeviceId=" + str(MachineConfiguration.DEVICE_ID) + "&Status=From%20GUS")
        response = json.loads(url.read().decode())
        completed_HUs = json.dumps(response, indent = 4)
        print(str(datetime.now()) + ' Contacting Server | Downloading Completed Units | Started')
        f = open("storage/handlingUnits/gus/completed.json", "w")
        f.write(completed_HUs)
        f.close()
        f = open("storage/handlingUnits/gus/completed.json")
        from_cpc = json.load(f)
        f.close()
        for i in from_cpc:
            row = Box(bx_receive,align='top', width='fill', border=True)
            row.text_size = 8
            cpc_gus_SSCC = Text(row, i['SSCC'], align='left')
            cpc_gus_product = Text(row, i['ProductDescription'], align='left')
            cpc_gus_age = Text(row,  i['Age'], align='right')
        print(str(datetime.now()) + ' Contacting Server | Going Online') 
print('Starting GUS')

def Sync():
    from globals import Waypoint_Configurations, server_Check, Device
    from gui import status_Bar
    from time import sleep
    c = 1
    while True:
        if c == 1:
            c = c - 1
            sleep(int(1))
        else:
            sleep(int(60))
            if input_Scanner_Result.value == 'Scan Train or Forklift To Start':
                status_Bar.txt_LastSynced.value = "Checking In ...."
                server_Check()
                status_Bar.txt_LastSynced.value = str(Device.LastCheckin)
                Reload()
                if Device.LockedOut == True:
                    content.destroy()
                    security.wnd_login.show_login()

class Sync_Service:
    import threading
    x = threading.Thread(target=Sync)
    x.setDaemon(True)
    x.start()