#
#   Hello World server in Python
#   Binds REP socket to tcp://*:5555
#   Expects b"Hello" from client, replies with b"World"
#

import numpy as np
import pandas as pd
import pickle
from tqdm import tqdm
import random
import openpyxl
from sklearn.preprocessing import MinMaxScaler,LabelEncoder
from sklearn.preprocessing import StandardScaler
import heapq

# import warnings
import time
import zmq

context = zmq.Context()
socket = context.socket(zmq.REP)
socket.bind("tcp://*:5555")

with open("/Users/sci/Desktop/공예py코드/w_list.pkl","rb") as fr:
    data = pickle.load(fr)

df = pd.read_csv('/Users/sci/Desktop/공예py코드/concat.csv', encoding='euc-kr')
df = df.iloc[:,1:-1]
df.drop(['사진'],axis=1,inplace=True)

# len(df['업체명'].unique())

length_uni = len(df['업체명'].unique())

while True:
    #  Wait for next request from client
    message = socket.recv()
    print("Received request: %s" % message)

    #  Do some 'work'.
    #  Try reducing sleep time to 0.01 to see how blazingly fast it communicates
    #  In the real world usage, you just need to replace time.sleep() with
    #  whatever work you want python to do, maybe a machine learning task?
    time.sleep(1)

    #  Send reply back to client
    #  In the real world usage, after you finish your work, send your output here
    #  socket.send(b"Heechan's test done")
    socket.send(b'%d' % length_uni)
