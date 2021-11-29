import random
import time


print("\nBeginning data generation\n\n")

index = 1

data = [0, 0]

while(1):
    print("index is: " + str(index - 1))
    
    i = 0
    data[i] = index - 1
    with open("Y.txt",'w') as dataHandle:
        while i < index:
            dataHandle.write(str(data[i]) + '\n')
            i += 1
    
    print("new data point added\n")
    data.append(random.randint(0,500))
    time.sleep(1.5)
    index += 1
    
    if index == 20:
        index = 1
        data = [0,0]