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
          LabelLines.append('^FX Start of label number '+str(LabelNo)+' for SSCC '+str(SSCC)+'                      \n')
          LabelLines.append('^XA                                                                                    \n')
          LabelLines.append('^FX Block outlines^FS                                                                  \n')
          LabelLines.append('^FO25,540^GB752,2,2,B,0^FS                                                             \n')
          LabelLines.append('^FO25,540^GB2,210,2,B,0^FS                                                             \n')
          LabelLines.append('^FO417,540^GB2,210,2,B,0^FS                                                            \n')
          LabelLines.append('^FO775,540^GB2,210,2,B,0^FS                                                            \n')
          LabelLines.append('^FO25,750^GB752,2,2,B,0^FS                                                             \n')
          LabelLines.append('^FO10,1080^GB810,2,2,B,0^FS                                                            \n')
          LabelLines.append('^FX Bottom group indicators ^FS                                                        \n')
          LabelLines.append('^FO1,1168^GB810,3,3,B,0^FS                                                             \n')
          LabelLines.append('^FO1,1168^GB203,40,21,B,0^FS                                                           \n')
          LabelLines.append('^FO204,1168^GB203,40,3,B,0^FS                                                          \n')
          LabelLines.append('^FO407,1168^GB203,40,3,B,0^FS                                                          \n')
          LabelLines.append('^FO610,1168^GB203,40,3,B,0^FS                                                          \n')
          LabelLines.append('^FX End of block outlines ^FS                                                          \n')
          LabelLines.append('^CF0,45^FB635,2,0,L,0^FO30,30^FD' + BUnit + '^FS                                       \n')
          LabelLines.append('^CF0,32^FB643,2,0,L,0^FO30,145^FD'+MachineConfiguration.COUNTRY+'^FS                   \n')
          LabelLines.append('^FX GS1 Data Matrix and Linear encoding for SSCC^FS                                    \n')
          LabelLines.append('^FO600,25^BXN,10,200,,,,,1^FD'+str(SSCC)+'^FS                                          \n')
          LabelLines.append('^FO30,220^BY3^BCN,280,Y,N,N^FD'+str(SSCC)+'^FS                                         \n')
          LabelLines.append('^FX GS1 Data Matrix and Linear encoding for Pallet GTIN^FS                             \n')
          LabelLines.append('^FO620,780^BXN,10,200,,,,,1^FD'+Product.SalesUnitBarcode+'^FS                          \n')
          LabelLines.append('^FO30,770^BY3^BCN,160,Y,N,N^FD'+Product.SalesUnitBarcode+'^FS                          \n')
          LabelLines.append('^CF0,40^FB635,2,0,L,0^FO30,980^FD'+Product.Description+'^FS                            \n')
          LabelLines.append('^CF0,35^FB403,1,0,J,0^FO40,560^FDPRODUCTION DATA:^FS                                   \n')
          LabelLines.append('^CF0,28^FB403,1,0,J,0^FO50,610^FDDate Code:^FS ^FO190,610^FD'+DateCode+'^FS            \n')
          LabelLines.append('^FO50,645^FDDate/Time:^FS^FO190,645^FD'+DateTime+'^FS                                  \n')
          LabelLines.append('^FO40,680^FDBatch Code:^FS^FO190,680^FD'+Batch.Description+'^FS                        \n')
          LabelLines.append('^FO40,715^FDBest Before:^FS ^FO190,715^FD'+BestBefore+'^FS                             \n')
          LabelLines.append('^CF0,35^FB403,1,0,L,0^FO445,560^FDPRODUCT DETAILS:^FS                                  \n')
          LabelLines.append('^CF0,28^FB403,1,0,J,0^FO475,610^FDProduct Code:^FS^FO650,610^FD'+str(Product.PLU)+'^FS \n')
          LabelLines.append('^FO498,645^FDOrder Units:^FS^FO650,645^FD'+str(Product.SalesUnits)+'^FS                \n')
          LabelLines.append('^FO445,680^FDConsumer Units:^FS ^FO650,680^FD'+str(Product.ConsumerUnits)+'^FS         \n')
          LabelLines.append('^FO493,715^FDNett Weight:^FS ^FO650,715^FD'+str(Product.HUTargetWeight)+'^FS           \n')
          LabelLines.append('^FO90,1115^FDSSCC Label ID: ^FS                                                        \n')
          LabelLines.append('^FO685,1088^BQN,2,3,H,7^FH_^FDQA,'+str(SSCC)+'-'+str(LabelNo)+'-'+str(LabelCount)+'^FS \n')
          LabelLines.append('^FO290,1115^FD'+str(SSCC)+' - '+str(LabelNo)+' - '+str(LabelCount)+'^FS                \n')
          LabelLines.append('^XZ                                                                                    \n')
          LabelLines.append('^FX End of label number '+str(LabelNo)+'                                               \n')
          LabelLines.append('                                                                                       \n')
      # End While
    f = open('storage/handlingUnits/labels/'+str(HandlingUnit.SSCC)+".zpl", "w")
    f.writelines(LabelLines)
    f.close()
    return "OK"
def printLabels():
    try:
        f = open('storage/handlingUnits/labels/'+str(HandlingUnit.SSCC)+".zpl", "r")
        z.output(f.read())
    except Exception as e:
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
