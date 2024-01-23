import security
from gui import app
from globals import HandlingUnit, NumberRange
def nextpow10(n):
    number = int(n)
    rounded = round(number/10)*10
    if int(rounded - number) < 0:
        rounded = rounded + 10
    return rounded
def calculator():
    SSCC = str(NumberRange.Prefix + NumberRange.Bank + NumberRange.Root + NumberRange.NextNumber)
    SSCClist = list(map(int, str(SSCC)))
    f = 1
    p0 = 3 * SSCClist[2]
    p1 = 1 * SSCClist[3]
    p2 = 3 * SSCClist[4]
    p3 = 1 * SSCClist[5]
    p4 = 3 * SSCClist[6]
    p5 = 1 * SSCClist[7]
    p6 = 3 * SSCClist[8]
    p7 = 1 * SSCClist[9]
    p8 = 3 * SSCClist[10]
    p9 = 1 * SSCClist[11]
    p10 = 3 * SSCClist[12]
    p11 = 1 * SSCClist[13]
    p12 = 3 * SSCClist[14]
    p13 = 1 * SSCClist[15]
    p14 = 3 * SSCClist[16]
    p15 = 1 * SSCClist[17]
    p16 = 3 * SSCClist[18]
    pSum = int(p0+p1+p2+p3+p4+p5+p6+p7+p8+p9+p10+p11+p12+p13+p14+p15+p16)
    pRound = nextpow10(pSum)
    chkdig = pRound-pSum
    HandlingUnit.SSCC = NumberRange.SSCC = str(NumberRange.Prefix + NumberRange.Bank + NumberRange.Root + NumberRange.NextNumber + str(chkdig))




def close_App():
    app.destroy()
def reboot_App():
    print("rebooting system")
def login():
    security.wnd_login.show_login()





