import json
from datetime import *
import os
import threading
from pickle import TRUE
from guizero import Box, Text, Picture, TextBox, TitleBox
from gui import heading, content, main_gui, status_Bar
from globals import Waypoint, Batch, NumberRange, Operational_Variables, Product, HandlingUnit, pas_Save_HU, Batch, server_Check, post_HandlingUnits, Device, hu_Reject
from functions import calculator, security
from labels import GenerateLabels, printLabels
from time import sleep
p = open('storage/configs/configuration_products.json')
products = json.load(p)
p.close()
heading.value = Waypoint.Type + ' | ' + Waypoint.Description

global IsIdle, GoForIt
IsIdle = True

def pas():
    global content, img_Label, box_label, Product, hu_list_box, start_Sync
    content.destroy()
    Product.clear()
    HandlingUnit.clear()
    # Set Layout
    content = Box(main_gui, height='fill', width='fill', align='top', border=True)
    pas_header_bar = Box(content, width='fill', align='top')
    scannerBx = Box(content, width='fill', height='fill', align='left', border=True)
    box_label = Box(content, width='fill', height='fill', align='right', border=True)
    img_Label = Picture(box_label, image=Operational_Variables.OMD_Logo)
    product_box = Box(scannerBx, width='fill', align='bottom', layout='grid')
    hu_list_box = TitleBox(scannerBx, 'Scanned History',align='bottom', width='fill', height='fill')
    pas_header_bar.text_size = 10
    scannerBx.text_size = 28
    scannerBx.bg = '#ffffff'
    product_box.text_size = 15
    # Set Controls
    Text(pas_header_bar, "Batch: " + Batch.Description, align='left')
    Text(pas_header_bar, "GTIN: " + NumberRange.NextNumber, align='right')
    Text(pas_header_bar, "Root: " + NumberRange.Root, align='right')
    Text(pas_header_bar, "Bank: " + NumberRange.Bank, align='right')
    Text(pas_header_bar, "Prefix: " + NumberRange.Prefix, align='right')
    Text(product_box, 'Sales Units', align='left', width='fill', height='fill', grid=[0,0])
    Text(product_box, 'Consumer Units', align='left', width='fill', height='fill', grid=[0,1])
    Text(product_box, 'Nett Weight', align='left', width='fill', height='fill', grid=[0,2])
    Text(product_box, 'Calc Weight', align='left', width='fill', height='fill', grid=[0,3])
    Text(product_box, 'UOM', align='left', width='fill', height='fill', grid=[0,4])
    Text(product_box, 'Commodity', align='left', width='fill', height='fill', grid=[0,5])
    Text(product_box, 'Type', align='left', width='fill', height='fill', grid=[0,6])
    val_Sales_Units = Text(product_box, Product.SalesUnits, align='right', width='fill', height='fill', grid=[1,0])
    val_Consumer_Units = Text(product_box, Product.ConsumerUnits, align='right', width='fill', height='fill', grid=[1,1])
    val_NettWeight = Text(product_box, str(int(Product.HUTargetWeight) * int(Product.ConsumerUnits)) + ' ' + Waypoint.UOM, align='right', width='fill', height='fill', grid=[1,2])
    val_CalculatedWeight = Text(product_box,  str(int(Product.HUTargetWeight) * int(Product.ConsumerUnits)) + ' ' + Waypoint.UOM, align='right', width='fill', height='fill', grid=[1,3])
    val_UOM = Text(product_box, Waypoint.UOM, align='right', width='fill', height='fill', grid=[1,4])
    val_Commodity = Text(product_box, Product.Commodity, align='right', width='fill', height='fill', grid=[1,5])
    val_Type = Text(product_box, Product.Type, align='right', width='fill', height='fill', grid=[1,6])
    input_Scanner = TextBox(scannerBx, width='fill')
    input_Scanner_Result = TextBox(scannerBx, width='fill')
    input_Scanner_Result.text_size = 28
    input_Scanner.bg = 'Green'    
    input_Scanner.text_color = '#ffffff'
    input_Scanner.value = ''
    input_Scanner_Result.value = Product.Description
    path = 'storage/handlingUnits/local/'
    hu_list = os.listdir(path)
    for i in hu_list:
        p = open(path + i)
        schu = json.load(p)
        p.close()
        row = Box(hu_list_box, align='top', width='fill', border=True)
        row.text_size = 8
        Text(row, schu['ScannedCode'], align='left')
        Text(row, schu['Description'], align='left')
        if schu['ScannedCode'] == '':
            row.bg = 'Red'
        elif schu['ScannedCode'] != '':
            row.bg = '#00ff00'
        else:
            row.bg = 'Orange'
    if Product.Description == 'Ready to Scan':
        input_Scanner_Result.bg = '#00ff00'
    elif Product.Description == 'FAILED':
        input_Scanner_Result.bg = 'Red'
    else:
        input_Scanner_Result.bg = 'White'    
    # Functions
    def scan(event):
        global products, img_Label, box_label, Product, IsIdle, hu_Reject
        if event.key == "\r":
            IsIdle = False
            def product_Lookup():
                searchString = input_Scanner.value[0:14]
                global products, img_Label, box_label
                for i in products:
                    if i['SalesUnitBarcode'] == searchString:
                        HandlingUnit.ScannedGTIN = input_Scanner.value
                        # Set Product Information
                        Product.Description = (i['Description'])
                        Product.Expiry = (i['Expiry'])
                        Product.Labels = (i['Labels'])
                        Product.SalesUnits = (i['SalesUnits'])
                        Product.ConsumerUnits = (i['ConsumerUnits'])
                        Product.TargetWeight = (i['TargetWeight'])
                        Product.HUTargetWeight = (i['HUTargetWeight'])
                        Product.TareWeight = (i['TareWeight'])
                        Product.SalesUnitBarcode = (i['SalesUnitBarcode'])
                        Product.PLU = (i['PLU'])
                        Product.UOM = (i['UOM'])
                        Product.Id = (i['Id'])
                        Product.Commodity = (i['Commodity'])
                        # Set Handling Units
                        HandlingUnit.Status = 'Pending'
                        # Set GUI
                        input_Scanner_Result.value = Product.Description
                        val_Sales_Units.value = Product.SalesUnits
                        val_Consumer_Units.value = Product.ConsumerUnits
                        val_NettWeight.value = ((Product.TargetWeight))
                        val_CalculatedWeight.value = ((Product.TargetWeight))
                        val_Commodity.value = Product.Commodity
                        val_UOM.value = Product.UOM
                        # Set Check Digit
                        calculator()
                        # Get Labels
                        l = GenerateLabels()                        
                        if l == "OK":
                            Operational_Variables.LabelImg = 'storage/handlingUnits/labels/' + str(HandlingUnit.SSCC) + '.png'
                            img_Label.destroy()
                            img_Label = Picture(box_label, image=Operational_Variables.LabelImg, width=425, height=550)
                            input_Scanner.value = ''
                            input_Scanner.focus()
                            break
                        else:
                            Product.Description = "FAILED"
            if 'CLEAR' in input_Scanner.value:
                pas()
                IsIdle = True
                print('Cleared')
            if 'RELEASEALL' in input_Scanner.value:
                post_HandlingUnits()
                pas()
                IsIdle = True
                print('RELEASED')
            if 'PRINT' in input_Scanner.value:
                pas_Save_HU()
                printLabels()
                pas()
            if 'FLAG_REJECT' in input_Scanner.value:
                hu_Reject()
                pas()
            if len(input_Scanner.value) == 32 and str.isalnum(input_Scanner.value) or len(input_Scanner.value) == 14 and str.isalnum(input_Scanner.value):
                product_Lookup()
    # Actions
    input_Scanner.focus()
    input_Scanner.when_key_pressed = scan

def Sync():
    from globals import Waypoint_Configurations, server_Check, Device
    from gui import status_Bar
    from time import sleep
    c = 1
    while True:
        if c == 1:
            c = c - 1
            sleep(0.1)
        else:
            if IsIdle == True:
                status_Bar.txt_LastSynced.value = "Checking In ...."
                post_HandlingUnits()
                server_Check()
                status_Bar.txt_LastSynced.value = str(Device.LastCheckin)
                sleep(int(Waypoint_Configurations.CHECK_IN_INTERVAL))
                if Device.LockedOut == True:
                    content.destroy()
                    security.wnd_login.show_login()
            else:
                c = 1

class Sync_Service:
    import threading
    x = threading.Thread(target=Sync)
    x.setDaemon(True)
    x.start()