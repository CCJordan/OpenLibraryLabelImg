# This is a piece of software I scavanged together as I took my first steps training yolo networks
# I use it to get a sense of what my networks are currently capable of and to quickly add more trainig data
# Feel free to customize it to your needs

import argparse
import os
import queue
import shutil
import threading
import time

import cv2
import numpy as np
import pandas as pd


def convert(size, box):
    dw = 1.0 / size[0]
    dh = 1.0 / size[1]
    x = (box[0] + box[1]) / 2.0
    y = (box[2] + box[3]) / 2.0
    w = box[1] - box[0]
    h = box[3] - box[2]
    x = x * dw
    w = w * dw
    y = y * dh
    h = h * dh
    return (x, y, w, h)

#
# Thread to analyze images from the mainthreads queue
# Takes images from the queue and analyzes them with the given net and parameters
# It terminates, when the queue is empty
#
class AnalyzerThread(threading.Thread):
    def __init__(self, group=None, target=None, name=None,
                 args=(), kwargs=None, *, daemon=None):
        super().__init__(group=group, target=target, name=name,
                         daemon=daemon)
        self.args = args
        self.kwargs = kwargs
        self.annotated = 0
        self.processed = 0

    def getAnnotated(self):
        return self.annotated

    def getProcessed(self):
        return self.processed

    def run(self):
        weightsPath = self.kwargs['weightsPath']
        imagesPath = self.kwargs['imagesPath']
        configPath = self.kwargs['configPath']
        targetConfidence = self.kwargs['targetConfidence']
        moveImages = self.kwargs['moveImages']
        outputFolder = self.kwargs['output']

        # Load net
        net = cv2.dnn.readNetFromDarknet(configPath, weightsPath)
        path_df = []
        class_total_df = []
        class_df = []
        xmin_df = []
        xmax_df = []
        ymin_df = []
        ymax_df = []
        confidence_df = []
        x_df = []
        y_df = []
        w_df = []
        h_df = []
        H_df = []
        W_df = []

        while not imageQueue.empty():
            path = imageQueue.get()
            imageQueue.task_done()
            self.processed = self.processed + 1

            image = []
            try:
                image = cv2.imread(path)
                image.shape
            except AttributeError:
                print("could not load image:", path)
                continue

            (H, W) = image.shape[:2]

            ln = net.getLayerNames()
            ln = [ln[i[0] - 1] for i in net.getUnconnectedOutLayers()]

            blob = cv2.dnn.blobFromImage(
                image, 1 / 255.0, (416, 416), swapRB=True, crop=False
            )
            net.setInput(blob)
            layerOutputs = net.forward(ln)

            boxes = []
            confidences = []
            classIDs = []

            for output in layerOutputs:
                for detection in output:
                    scores = detection[5:]
                    classID = np.argmax(scores)
                    confidence = scores[classID]

                    if confidence > targetConfidence:
                        box = detection[0:4] * np.array([W, H, W, H])
                        (centerX, centerY, width, height) = box.astype("int")

                        x = int(centerX - (width / 2))
                        y = int(centerY - (height / 2))

                        boxes.append([x, y, int(width), int(height)])
                        confidences.append(float(confidence))
                        classIDs.append(classID)

            idxs = cv2.dnn.NMSBoxes(boxes, confidences, targetConfidence, targetConfidence)

            if len(idxs) == 0:
                if moveImages:
                    try:
                        shutil.move(path, imagesPath + 'untagged/')
                    except:
                        print("Error moving", path)
            else:
                self.annotated = self.annotated + 1
                img = str.split(path, "/")[-1]
                txtFilePath = outputFolder + os.path.splitext(img)[0] + ".txt"

                file = open(txtFilePath, "w")
                for i in idxs.flatten():
                    classID = classIDs[i]
                    (x, y) = (boxes[i][0], boxes[i][1])
                    (w, h) = (boxes[i][2], boxes[i][3])

                    xmin = x
                    xmax = x + w
                    ymin = y
                    ymax = y + h

                    b = (float(xmin), float(xmax), float(ymin), float(ymax))
                    x_yolo, y_yolo, w_yolo, h_yolo = convert((W, H), b)

                    path_df += [path]
                    class_total_df += [len(idxs)]
                    class_df += [classID]
                    xmin_df += [xmin]
                    xmax_df += [xmax]
                    ymin_df += [ymin]
                    ymax_df += [ymax]
                    x_df += [x_yolo]
                    y_df += [y_yolo]
                    w_df += [w_yolo]
                    h_df += [h_yolo]
                    W_df += [W]
                    H_df += [H]
                    confidence_df += [confidences[i]]
                    data_txt = []

                    data_txt.append(
                        str(classID)
                        + " "
                        + str(x_yolo)
                        + " "
                        + str(y_yolo)
                        + " "
                        + str(w_yolo)
                        + " "
                        + str(h_yolo)
                    )

                    data = pd.DataFrame(
                        {
                            "path": path_df,
                            "width": W_df,
                            "height": H_df,
                            "total_class": class_total_df,
                            "class_object": class_df,
                            "xmin": xmin_df,
                            "xmax": xmax_df,
                            "ymin": ymin_df,
                            "ymax": ymax_df,
                            "x": x_df,
                            "y": y_df,
                            "w": w_df,
                            "h": h_df,
                            "confidence": confidence_df,
                        }
                    )
                    listToStr = " ".join(map(str, data_txt))
                    file.write(listToStr + "\n")

                data.to_csv("data.csv", index=False)
                file.close()
                if moveImages:
                    try:
                        shutil.move(path, imagesPath + 'tagged/')
                    except:
                        print ("Error moving", path)
                
            print("Images left:", imageQueue.qsize(), "     ", end="\r")

# Put your darknet directory here, to simpify your defaults
darknetfolder = '/home/ccj/Programming/darknet/'

parser = argparse.ArgumentParser(description='Configuration for Autoannotation.')
parser.add_argument('imagespath', type=str, metavar='IMAGESPATH', help='Folder you want to annotate')
parser.add_argument('--network-path', '-n', type=str, metavar='PATH', dest='path', default=darknetfolder+'backup/yolov4_last.weights', help='Specify path to weigth file')
parser.add_argument('--output-path', '-o', type=str, metavar='OUT', dest='output', default="output_txt", help='Folder to write annotation files to')
parser.add_argument('--target-confidence', '-tc', type=float, dest='targetconfidence', metavar='TC', default=0.5, help='Specify target confidence to annotate')
parser.add_argument('--config-path', '-c', type=str, metavar='CONFIG', dest='configPath', default=darknetfolder+'cfg/yolov4.cfg', help='Specify path to your networks config file')
parser.add_argument('--move-images', '-m', action='store_const', dest='move', const=True, default=False, help='Specify to move images into folders "tagged" and "untagged"')

args = parser.parse_args()

weightsPath = args.path
configPath = args.configPath

imagesProcesses = 0
imagesAnnotated = 0
imageQueue = queue.Queue()

moveImages = args.move
output = args.output
if not str.endswith(output, '/'):
    output += '/'

assert args.targetconfidence < 1 and args.targetconfidence > 0

targetConfidence = args.targetconfidence

print('Target confidence:', targetConfidence)
print('Output Path for annotations:', output)

imagesFolder = args.imagespath
if not str.endswith(imagesFolder, '/'):
    imagesFolder = imagesFolder + '/'

try:
    if not os.path.exists(output):
        os.makedirs(output)
    if moveImages:
        if not os.path.exists(imagesFolder + '/tagged'):
            os.makedirs(imagesFolder + '/tagged')
        if not os.path.exists(imagesFolder + '/untagged'):
            os.makedirs(imagesFolder + '/untagged')
            
except OSError:
    print('Error: Could not create directory.')

for entry in os.listdir(imagesFolder):
    # add all images to the queue
    path = os.path.join(imagesFolder, entry)
    if os.path.isfile(path):
        imagesProcesses = imagesProcesses + 1
        imageQueue.put_nowait(path)

print("Annotating", imageQueue.qsize(), "images.")

analyzers = []
for i in range(0, 7):
    t = AnalyzerThread(kwargs={'configPath': configPath, 'weightsPath': weightsPath, 'targetConfidence': targetConfidence, 'moveImages': moveImages, 'output': output, 'imagesPath': imagesFolder})
    t.start()
    analyzers.append(t)

for analizer in analyzers:
    analizer.join()
    imagesAnnotated += analizer.getAnnotated()

print(str(imagesAnnotated) + " annotations out of " + str(imagesProcesses) + " images")
