#Libraries
import RPi.GPIO as GPIO
import time
import socket
import math

#GPIO Config
GPIO.setmode(GPIO.BCM)
GPIO_TRIGGER = 18
GPIO_LIGHT = 23
GPIO_ECHO = 24
GPIO.setup(GPIO_TRIGGER, GPIO.OUT)
GPIO.setup(GPIO_ECHO, GPIO.IN)
GPIO.setup(GPIO_LIGHT, GPIO.OUT)

def lightInd(on):
    GPIO.output(GPIO_LIGHT, on)
lightInd(False)

def distance():
    GPIO.output(GPIO_TRIGGER, True)
    time.sleep(0.00001)
    GPIO.output(GPIO_TRIGGER, False)

    StartTime = time.time()
    StopTime = time.time()

    while GPIO.input(GPIO_ECHO) == 0:
        StartTime = time.time()

    while GPIO.input(GPIO_ECHO) == 1:
        StopTime = time.time()

    # time difference between start and arrival
    TimeElapsed = StopTime - StartTime

    distance = (TimeElapsed * 34300) / 2

    return distance

if __name__ == '__main__':
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as srv:
        srv.bind(("0.0.0.0", 2048))
        try:
            srv.listen()
            print("Server Started...")
            while True:
                conn, addr = srv.accept()
                with conn:
                    lightInd(True)
                    print("Client Connected...")
                    try:
                        while True:
                            dist = math.ceil(distance())
                            time.sleep(0.08)
                            # Unify the communication length to avoid guess work and cause race-condition
                            paddStr = ""
                            if(dist < 10):
                                paddStr += "000"
                            elif(dist < 100):
                                paddStr += "00"
                            elif(dist < 1000):
                                paddStr += "0"
                            conn.sendall((paddStr+str(dist)).encode("utf-8"))
                    except socket.error:
                        print("Client Disconnected...")
                    except KeyboardInterrupt:
                        print("Manual Exit detected, press again to exit code...")
                    except Exception as ex:
                        print("Error: "+ex)
                    finally:
                        lightInd(False)
        except KeyboardInterrupt:
            print("Measurement stopped by User")
        except socket.error as ex:
            print("Server Error: "+ex)
        except Exception as ex:
            print("Unknown Error: "+ex)
        finally:
            srv.shutdown(socket.SHUT_RDWR)
            srv.close()
            GPIO.cleanup()
