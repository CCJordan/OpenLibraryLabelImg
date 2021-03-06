# OpenLibraryLabelImg

Data Annotation Tool to organize libraries of images, tag them by hand or aided by the net you are already training.

## Library Fenster

- Enthält die Übersicht über alle annotierten Bilder
- Liste aller Bildergruppen
	- Pfad
	- Diagramme
		- Balken: Klassen Häufigkeit
		- Torte: Autoannotiert, händisch annotiert, ungesehen
	- Zahlenwerte
		- Anzahl der Bilder
		- Trainingsgruppengröße vs. Validationgruppengröße
	- Beschreibung
	- Checkbox: Bei Export einschließen
	- Button "autoannotate"

- Netzeinstellungen
	- obj-CFG File
	- yolo-CFG File
		- Max Iterations
		- Lerneinstellungen
	- weight Folder
	- data Folder
	- Target Imagesize

- Autoannotation fügt die Annotationen in die Datenbank ein, Bilder müssen reviewed werden, bevor sie beim Export eingeschlossen werden

## Explorer Fenster

Übersicht über alle Bilder im Ordner mit eingeblendeten annotationen, schraffiert, wenn noch im Review

## Annotation Fenster
Wie OpenLabelImg
Tools für Cropping und Bilddrehung