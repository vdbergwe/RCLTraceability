from driver_1602 import lcd_text, lcd_init
from statistics import median
from time import sleep
from globals import Device, MachineConfiguration, Product, Reading, Batch, QC_Station, QC_Scale
from services import server_Check, Save_Reading, post_Readings
import datetime
import os
import json
lcd_init()
LCD_LINE_1 = 0x80 # LCD memory location for 1st line
LCD_LINE_2 = 0xC0 # LCD memory location 2nd line
global samplesCollected
global scannedText
samplesCollected = 0
scannedText = ""
def systemReady():
    lcd_init()
    lcd_text("SCAN BARCODE",LCD_LINE_1)
    lcd_text("",LCD_LINE_2)
    scannedText = input('SCAN BARCODE :\n')
def animationWaiting():
    sleep(0.1)
    lcd_text(">-",LCD_LINE_2)
    sleep(0.1)
    lcd_text(">->-",LCD_LINE_2)
    sleep(0.1)
    lcd_text(">->->-",LCD_LINE_2)
    sleep(0.1)
    lcd_text(">->->->-",LCD_LINE_2)
    sleep(0.1)
    lcd_text(">->->->->-",LCD_LINE_2)
    sleep(0.1)
    lcd_text(">->->->->->-",LCD_LINE_2)
    sleep(0.1)
    lcd_text(">->->->->->->-",LCD_LINE_2)
    sleep(0.1)
    lcd_text(">->->->->->->->-",LCD_LINE_2)
    sleep(0.1)
    lcd_text(">->->->->->->->->-",LCD_LINE_2)
    sleep(0.1)
    lcd_text(">->->->->->->->->->",LCD_LINE_2)
    sleep(0.1)
    lcd_text("",LCD_LINE_2)
    sleep(0.1)
    return "Done"
def pingServer():
    print("Pinging Server")
    animate = animationWaiting()
    server_Check()
    return "Done"
lcd_init()
lcd_text("SCAN BARCODE",LCD_LINE_1)
lcd_text("",LCD_LINE_2)
scannedText = input('SCAN BARCODE :\n')
while True:
    if scannedText == "DISP_NET":
        sleep(0.1)
        lcd_text("Network Name",LCD_LINE_1)
        lcd_text(Device.Description,LCD_LINE_2)
        sleep(1)
        lcd_text("Network IP",LCD_LINE_1)
        lcd_text(Device.IP,LCD_LINE_2)
        sleep(1)
        systemReady()
    elif scannedText == "DISP_SERVER_STATUS":
        lcd_text("Ping Server",LCD_LINE_1)
        lcd_text(MachineConfiguration.BASE_URL,LCD_LINE_2)
        ping = pingServer()
        systemReady()
    elif scannedText == "DISP_SYNC_STATUS":
        lcd_text("Sync Status",LCD_LINE_1)
        lcd_text(MachineConfiguration.BASE_URL,LCD_LINE_2)
        ping = pingServer()
        animate = animationWaiting()
        systemReady()
    elif scannedText == "SHUTDOWN":
        lcd_init()
        lcd_text("SYSTEM SHUTDOWN",LCD_LINE_1)
        lcd_text("GOODBYE",LCD_LINE_2)
        sleep(2)
        os.system("shutdown -s -t 0")
    elif scannedText == "REBOOT":
        lcd_init()
        lcd_text("SYSTEM REBOOT",LCD_LINE_1)
        lcd_text("GOODBYE",LCD_LINE_2)
        sleep(2)
        os.system("shutdown -r -t 0")
    elif str.isalnum(scannedText) and len(scannedText) == 13:
        f = open('storage/configs/configuration_products.json')
        products = json.load(f)
        f.close()
        for i in products:
            if i['ConsumerBarcode'] == scannedText[0:13]:
                print(i['Description'])
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
                Product.QCSampleSize = (i['QCSampleSize'])
        lcd_text(Product.Description,LCD_LINE_1)
        print("Target: " + str(Product.TargetWeight) + Product.UOM)
        lcd_text("Target: " + str(Product.TargetWeight) + Product.UOM,LCD_LINE_2)
        sleep(1)
        print("S:" + str(Product.QCSampleSize) + "|C:" + str(samplesCollected)+ "|T:" + str(Product.TareWeight) + Product.UOM)
        lcd_text("S:" + str(Product.QCSampleSize) + "|C:" + str(samplesCollected)+ "|T:" + str(Product.TareWeight) + str(Product.UOM), LCD_LINE_2)
        if samplesCollected == Product.QCSampleSize:
            Reading.S4 = weight
            Reading.Batch = Batch.Id
            Reading.ReadingDate = datetime.datetime.now()
            Reading.Median = median([float(Reading.S1),float(Reading.S2),float(Reading.S3),float(Reading.S4)])
            Reading.Product = Product.Id
            Reading.Tare = Product.TareWeight
            Reading.UOM = Product.UOM
            Reading.Target = Product.TargetWeight
            Reading.QC_Scale = QC_Scale.Id
            Reading.QC_Station = QC_Station.Id
            Save_Reading()
            lcd_text("Sample Completed", LCD_LINE_1)
            lcd_text("Sending Data",LCD_LINE_2)
            sleep(1)
            samplesCollected = 0
            post_Readings()
            systemReady()
        lcd_init()
        lcd_text("Weigh Sample",LCD_LINE_1)
        lcd_text("",LCD_LINE_2)
        weight = input('Weight :\n')
        if weight != "":
            if samplesCollected == 1:
                Reading.S1 = weight
            elif samplesCollected == 2:
                Reading.S2 = weight
            elif samplesCollected == 3:
                Reading.S3 = weight
            samplesCollected = samplesCollected + 1
            lcd_text("Gross", LCD_LINE_1)
            lcd_text(str(weight) + Product.UOM,LCD_LINE_2)
            sleep(1.5)
            lcd_text("Nett", LCD_LINE_1)
            lcd_text(str(int(weight - Product.TareWeight)) + Product.UOM,LCD_LINE_2)
    else:
        print("Invalid Scan")
        lcd_text("Invlaid Scan", LCD_LINE_1)
        lcd_text("",LCD_LINE_2)
        sleep(1.5)
        systemReady()