from driver_1602 import lcd_text, lcd_init
import time
from services import RunAll

#Run Checks
RunAll()
#Start LCD
lcd_init()
LCD_LINE_1 = 0x80 # LCD memory location for 1st line
LCD_LINE_2 = 0xC0 # LCD memory location 2nd line
lcd_init()
import globals
lcd_text("Omegadata",LCD_LINE_1)
lcd_text("Solution",LCD_LINE_2)
time.sleep(0.1)
#lcd_init()
import gui