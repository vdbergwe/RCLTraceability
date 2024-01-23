from gui import layout
from guizero import Box, PushButton
from globals import IsLoggedIn
from functions import close_App, reboot_App, login

main_menu = Box(layout, height='fill', align='left')

class menu():
    main_menu = Box(layout, height='fill', align='left')
    btn_Login = PushButton(main_menu, command=login, text="Login", width="fill", align='top')
    # Styling
    main_menu.bg = '#0068b3'
    main_menu.text_color = '#FFFFFF'
