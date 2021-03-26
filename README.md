OpenLibraryLabelImg
===================

Inspired by OpenLabelImg I designed a tool, which helps to organize models and data. 
This is a work in progress. 

## Use

You add you classes in the first step, give them a name, a description if you like, and choose a color for the class, which shows up in the annotation interface and the charts.

Then you can add collections, which consist of a unique name and a path. You have to select the classes you wish to use for annotations in the collection.  
When selecting the path, you can use a folder, which already contains images, they will be imported, when the annotation window opens.
A double-click on the collection tile opens the annotation window. 

You navigate your images with "A" and "D", your classes with "W" and "S". The Image number is displayed in the bottom left corner as well as the selected class.  
By clicking and dragging you can mark an area.  
Currently the first click marks the top left corner of the selection, so you have to drag to the bottom right.

After your data is annotated you can export it from the Yolo-Nets tab, after adding a net.  
Currently you only need to fill in the nets-data directory and the desired resolution, in order to export images. The rest of its fields are currently not functional.

When annotated images are imported, they will have the status "autoannotated", which is indicated by the boxes filled with a pattern of lines. You can change the state by pressing space or making any modifications to the annotations. The new state will be "annotated". Only annotated images will be exported.

# Installation

Setup a mysql server 5.6 or newer. It has to be mysql, not mariadb, as the MySQL Package I use checks the provider string.

Create the Database using the sql file and change the connection string accordingly in the .config file.

Now you're good to go. 

# Autoannotation

If you have an existing model you can use it to annotate your new training data with the python script.

I recommend setting the constant `darknetfolder` to your darknet installation path and adjusting the defaults in the argument parser to your needs.  
You can set every parameter via commandline arguments.
- `--network-path` is the path to your models weigth file
- `--config-path` is the .cfg file for the model
- `--target-confidence` is a float between 0 and 1 to set a threshould for an annotations confidence to be output
- `--output-path` is the path to a folder to store the resulting txt files in YOLO format.
- `--move-images` is a flag, when set the input folder will be rearranged, all processed images are stored in either the "tagged" or the "untagged" folder
- `IMAGEPATH` the folder you want to annotate

Example:  
`python3 autoanotation.py --network-path ~/darknet/test.weigths --config-path ~/darknet/cgf/test.cfg --target-confidence 0.7 --output-path autoannotations/ testimages/`

The resulting annotation files can either be imported directly, if the images are already in the collection, or they can be imported with the images.
# Future plans

- The net integration will be enhanced, so you can autoannotate data from within the application.  
- Image-list on the annotation windows side, to provide quick navigation in image sets. 

# Known Issues

The annotation boxes should have z-indizes corresponding to thier size. So when boxes are on top of one another the smaller one will be the upper one. Currently this is not always the case, so you have to move boxes around, in order to reach boxes, which are under them. 