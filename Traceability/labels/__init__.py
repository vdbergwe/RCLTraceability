from globals import HandlingUnit, Product, Operational_Variables, Batch, MachineConfiguration, Waypoint_Configurations
import labelary
from datetime import *
from zebra import Zebra


z = Zebra()
z.setqueue(Waypoint_Configurations.PRINT_DEFAULT_PRINTER)

def GenerateLabels():
    global data
    Set1 = '21'
    Set2 = '3'
    Set3 = '3'
    Set4 = '3'
    BUnit = 'RCL Foods Sugar and Milling (PTY) LTD'
    Country = MachineConfiguration.COUNTRY
    SSCC = HandlingUnit.SSCC
    DateCode = str(int(Operational_Variables.DateCode))
    # using now() to get current time
    current_time = datetime.now()
    DateTime = current_time.strftime("%d/%m/%Y %H:%M")
    ExpiryDate = date.today() + timedelta(days=Product.Expiry)
    BestBefore = ExpiryDate.strftime("%d/%m/%Y")
  #   Use Python List to create the label file entries, for the number of labels required for this set
    LabelCount = Product.Labels
    LabelNo = 0
    LabelLines = ["^XA\n"]
    LabelLines.clear()
    while LabelNo < LabelCount:
          LabelNo += 1
          LabelLines.append('^FX Start of label number '+str(LabelNo)+' for SSCC '+str(SSCC)+'                               \n')
          LabelLines.append('^XA                                                                                             \n')
          LabelLines.append('^CF0,47^FB790,2,0,C,0^FO10,40^FD'+BUnit+'^FS                                                    \n')
          LabelLines.append('^CF0,40^FB790,2,0,C,0^FO10,105^FD'+MachineConfiguration.COUNTRY+'^FS                            \n')
          LabelLines.append('^FX Company and country underline                                                               \n')
          LabelLines.append('^FO10,165^GB810,2,2,B,0^FS                                                                      \n')
          LabelLines.append('^FX GS1 Data Matrix encoding for SSCC and production data^FS                                    \n')
          LabelLines.append('^FO40,205^BXN,18,200,,,,,1^FD'+str(SSCC)+'^FS                                                   \n')
          LabelLines.append('^CF0,35^FB403,1,0,C,0^FO340,210^FDPRODUCTION DATA:\&^FS                                         \n')
          LabelLines.append('^CF0,28                                                                                         \n')
          LabelLines.append('^FB240,1,0,R,0^FO250,260^FDDate Code:\&^FS ^FO500,260^FD'+DateCode+'^FS                         \n')
          LabelLines.append('^FB240,1,0,R,0^FO250,295^FDDate/Time:\&^FS^FO500,295 ^FD'+DateTime+'^FS                         \n')
          LabelLines.append('^FB240,1,0,R,0^FO250,330^FDPlant:\&^FS^FO500,330 ^FD'+Product.WERKS+'^FS                        \n')
          LabelLines.append('^FB240,1,0,R,0^FO250,365^FDBatch Code:\&^FS^FO500,365  ^FD'+Batch.Description+'^FS              \n')
          LabelLines.append('^FB240,1,0,R,0^FO250,400^FDBest Before:\&^FS ^FO500,400 ^FD'+BestBefore+'^FS                    \n')
          LabelLines.append('^FB240,1,0,R,0^FO250,435^FDSSCC:\&^FS ^FO500,435 ^FD'+SSCC+'^FS                                 \n')
          LabelLines.append('^FX SSCC and production data underline                                                          \n')
          LabelLines.append('^FO10,520^GB810,2,2,B,0^FS                                                                      \n')
          LabelLines.append('^FX Material code and Description in plain text                                                 \n')
          LabelLines.append('^CF0,105^FB785,1,0,C,0^FO30,560^FD'+str(Product.PLU)+'\&^FS                                     \n')
          LabelLines.append('^CF0,85^FB785,2,0,C,0^FO30,680^FD'+Product.Description+'\&^FS                                   \n')
          LabelLines.append('^FX Description underline                                                                       \n')
          LabelLines.append('^FO10,880^GB810,2,2,B,0^FS                                                                      \n')
          LabelLines.append('^FX GS1 Data Matrix encoding for Pallet GTIN^FS                                                 \n')
          LabelLines.append('^FO60,955^BXN,8,200,,,,,1^FD'+Product.GTIN_HU+'^FS                                              \n')
          LabelLines.append('^CF0,35^FB403,1,0,C,0^FO295,930^FDPRODUCT DETAILS:\&^FS                                         \n')
          LabelLines.append('^CF0,28                                                                                         \n')
          LabelLines.append('^FB240,1,0,R,0^FO250,975^FDProduct HU GTIN:^FS^FO500,975^FD'+Product.GTIN_HU+'^FS               \n')
          LabelLines.append('^FB240,1,0,R,0^FO250,1010^FDOrder Units:^FS^FO500,1010  ^FD'+str(Product.SalesUnits)+'^FS       \n')
          LabelLines.append('^FB240,1,0,R,0^FO250,1045^FDConsumer Units:^FS ^FO500,1045^FD'+str(Product.ConsumerUnits)+'^FS  \n')
          LabelLines.append('^FB240,1,0,R,0^FO250,1080^FDNet Weight:^FS^FO500,1080FD'+str(Product.HUTargetWeight)+'^FS      \n')
          LabelLines.append('^FX Unique label ID                                                                             \n')
          LabelLines.append('^FO10,1130^GB810,2,2,B,0^FS                                                                     \n')
          LabelLines.append('^FO90,1140^FDSSCC Label ID: ^FS                                                                 \n')
          LabelLines.append('^FO290,1140^FD'+str(SSCC)+'-'+str(LabelNo)+'-'+str(LabelCount)+'^FS                             \n')
          LabelLines.append('^FX Bottom label group indicators ^FS                                                           \n')
          LabelLines.append('^FO1,1168^GB810,3,3,B,0^FS                                                                      \n')
          LabelLines.append('^FO1,1168^GB203,40,21,B,0^FS                                                                    \n')
          LabelLines.append('^FO204,1168^GB203,40,3,B,0^FS                                                                   \n')
          LabelLines.append('^FO407,1168^GB203,40,3,B,0^FS                                                                   \n')
          LabelLines.append('^FO610,1168^GB203,40,3,B,0^FS                                                                   \n')
          LabelLines.append('^FX End of bottom label group indicators^FS                                                     \n')
          LabelLines.append('^XZ                                                                                             \n')
          LabelLines.append('^FX End of label number '+str(LabelNo)+'                                                        \n')
          LabelLines.append('                                                                                                \n')     
      # End While
    f = open('storage/handlingUnits/labels/'+str(HandlingUnit.SSCC)+".zpl", "w")
    f.writelines(LabelLines)
    f.close()
    return "OK"
def printLabels():
    try:
        print('Trying to open file: ' + 'storage/handlingUnits/labels/'+str(HandlingUnit.SSCC) + '.zpl')
        f = open('storage/handlingUnits/labels/'+str(HandlingUnit.SSCC)+'.zpl', 'r')
        print(f)
        z.output(f.read())        
    except Exception as e:
        print('Error calling printer : ' + str(e))
        return "Error calling printer :" +  str(e)        
    return "Print Succesfull"



def AutoSense():
    z.autosense()
def FactoryReset():
    z.reset_default()
def LoadDefaults():
    z.setup(direct_thermal=None, label_height=None, label_width=None)
def Print_Config():
    z.print_config_label()
def Get_Current_Config():
    z.output()
