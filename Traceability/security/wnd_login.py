# Imports
import json
from globals import Device, server_Check
from guizero import Box, Text, PushButton, Window, TextBox, Combo
from gui import status_Bar, app, launchSubSystem

KeyBoardEntry = ''

def show_login():
    global KeyBoardEntry
    KeyBoardEntry = ''
    scrn = Window(app, title='Login')
    scrn.bg = '#0068b3'
    scrn.text_color = '#ffffff'
    scrn.text_size = 25
    scrn.set_full_screen('True')
    status_Bar
    comboValues = []
    f = open('storage/configs/configuration_operators.json')
    operators = json.load(f)
    f.close()
    for i in operators:
        comboValues.append(i['FirstName'])
    txt_User = Text(scrn, "Please Select Username")
    input_Username = Combo(scrn, options=comboValues)
    txt_PIN = Text(scrn, "Please Enter Pin Code")
    input_PIN = TextBox(scrn)

    def login():
        Device.CurrentOperatorId = input_Username.value
        def LoggedIn():
            f = open("storage/configs/configuration.json")
            data = json.load(f)
            f.close()
            data['CurrentOperatorId'] = str(input_Username.value)
            jsonobject = json.dumps(data, indent = 4)
            f = open("storage/configs/configuration.json", "w")
            f.write(jsonobject)
            f.close()
            Device.CurrentOperatorId = data['CurrentOperatorId']
            KeyBoardEntry = KeyBoardEntry = ""
            input_PIN.value = KeyBoardEntry
            scrn.destroy()
            launchSubSystem()
            status_Bar()
        for i in operators:
            if i['FirstName'] == input_Username.value and i['Code'] == str(input_PIN.value):
                LoggedIn()
    
    class keyboard:
        def btn1():
            global KeyBoardEntry
            KeyBoardEntry = KeyBoardEntry + "1"
            input_PIN.value = KeyBoardEntry
        def btn2():
            global KeyBoardEntry
            KeyBoardEntry = KeyBoardEntry + "2"
            input_PIN.value = KeyBoardEntry
        def btn3():
            global KeyBoardEntry
            KeyBoardEntry = KeyBoardEntry + "3"
            input_PIN.value = KeyBoardEntry
        def btn4():
            global KeyBoardEntry
            KeyBoardEntry = KeyBoardEntry + "4"
            input_PIN.value = KeyBoardEntry
        def btn5():
            global KeyBoardEntry
            KeyBoardEntry = KeyBoardEntry + "5"
            input_PIN.value = KeyBoardEntry
        def btn6():
            global KeyBoardEntry
            KeyBoardEntry = KeyBoardEntry + "6"
            input_PIN.value = KeyBoardEntry
        def btn7():
            global KeyBoardEntry
            KeyBoardEntry = KeyBoardEntry + "7"
            input_PIN.value = KeyBoardEntry
        def btn8():
            global KeyBoardEntry
            KeyBoardEntry = KeyBoardEntry + "8"
            input_PIN.value = KeyBoardEntry
        def btn9():
            global KeyBoardEntry
            KeyBoardEntry = KeyBoardEntry + "9"
            input_PIN.value = KeyBoardEntry
        def btn0():
            global KeyBoardEntry
            KeyBoardEntry = KeyBoardEntry + "0"
            input_PIN.value = KeyBoardEntry
        def btnclear():
            global KeyBoardEntry
            KeyBoardEntry = KeyBoardEntry = ""
            input_PIN.value = KeyBoardEntry
        def btncomma():
            global KeyBoardEntry
            KeyBoardEntry = KeyBoardEntry + ","
            input_PIN.value = KeyBoardEntry 
        keyboard_numeric = Box(scrn)
        btn_Group = Box(keyboard_numeric, layout="grid")
        if Device.LockedOut != True:
            btn_1 = PushButton(btn_Group, text=" 1 ",command=btn1, grid=[0,0,1,1])
            btn_2 = PushButton(btn_Group, text=" 2 ",command=btn2, grid=[1,0,1,1])
            btn_3 = PushButton(btn_Group, text=" 3 ",command=btn3, grid=[2,0,1,1])
            btn_4 = PushButton(btn_Group, text=" 4 ",command=btn4, grid=[0,1,1,1])
            btn_5 = PushButton(btn_Group, text=" 5 ",command=btn5, grid=[1,1,1,1])
            btn_6 = PushButton(btn_Group, text=" 6 ",command=btn6, grid=[2,1,1,1])
            btn_7 = PushButton(btn_Group, text=" 7 ",command=btn7, grid=[0,2,1,1])
            btn_8 = PushButton(btn_Group, text=" 8 ",command=btn8, grid=[1,2,1,1])
            btn_9 = PushButton(btn_Group, text=" 9 ",command=btn9, grid=[2,2,1,1])
            btn_clear = PushButton(btn_Group, text=" C ",command=btnclear, grid=[0,3,1,1])
            btn_0 = PushButton(btn_Group, text=" 0 ",command=btn0, grid=[1,3,1,1])
            btn_comma = PushButton(btn_Group, text=" , ",command=btncomma, grid=[2,3,1,1])
            btn_SubmitLogin = PushButton(scrn, text="Login", command=login)
        else:
            txt_PIN.value = "Unit Locked Out"
            txt_PIN.text_color = '#ffffff'
            txt_PIN.text_size = 30
            txt_PIN.focus()