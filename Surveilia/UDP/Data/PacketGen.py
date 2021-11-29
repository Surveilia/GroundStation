import time
import random

print("\nGenerating test packets\n")

while(1):
    
    print("\nPacket updated\n")
    with open("TestPacket.txt", "w") as packHandle:
        packHandle.write(str(random.randint(0,50)) + "\n")
        packHandle.write(str(random.randint(0,1)) + "\n")
        packHandle.write(str(random.randint(0,3)) + "\n")
        packHandle.write(str(random.randint(0,100)) + "\n")
        packHandle.write(str(random.randint(0,40)) + "\n")
        packHandle.write(str(random.randint(0,360)) + "\n")
        packHandle.write(str(random.randint(0,360)) + "\n")
    time.sleep(4)