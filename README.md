# WpfApp1
A Desktop application for flight investigation in the Flightgear flight simulator.

### Description
This app is a flight investigation analysis tool in the popular FlightGear web flight simulator.
A user who is interested in researching his flight will be able to use the app and receive live data from the flight to the app.
The dashboard screen will show the user data about the aircraft, altitude clocks, speed and direction, as well as graphs and indices for statistical analysis. The application is convenient and clear to the user, allows a combination of learning and investigating anomalies during the flight.
This app written in the MVVM code architecture.

### Installation
In order to use the application, you will need to load it using framework suppurt C# code - our recommendation [Visual Studio 2019](https://visualstudio.microsoft.com/vs/).
In addition, in order to view the flight, the user must have the Flightgear flight simulator installed on the computer [Download](https://www.flightgear.org/download/) [Steup tutorial](https://wiki.flightgear.org/New_to_FlightGear) . As well, csv files that contain flight data, XML file which defines the functionality of the CSV file and translates and connect between the code to the flight simulator.

### Usage
![FlighGear Desktop App.](C:\Users\lared\Desktop\readme.jpg "FlighGear Desktop App")

To run the flight on the simulator, you must open the application and follow the steps below:
> 1. Click the 'Open CSV' button. A dialog will immediately open in which you select and upload the flight data file - must be a csv file.
> 2. Click the 'Open FlightGear' button. By providing the path to Flightgear execute file, the application will run it for you and connect to a dedicated communication server using the TCP internet protocol.
> 3. Click the 'Run FlightGear' button - the app will automatically connect you to the simulator.
> 4. Once the flight simulator is up, you can click the 'Play' button and start exploring the playback vedio of the your flight.

**Additional features**
> * On the bottom of the application there is a video player which help the user investigate the flight. You can control the data transfer rate from the app to the simulator by pressing the appropriate button: Pressing the Pause, Stop, previous, or next button will operate according to the accepted convention in video players. In addition, you have a slider that shows the progress of the flight and the time of it, you can choose a start point of displaying the playback vedio by moving the slider to the point of time and play the playback from there.
> * A dashboard which may be relevant to the flight analysis. A speedometer, height clock of the plane, a compass that indicates the direction and other indicators of the plan such as yaw, pich, roll that will help the user to investigate the flight in the best and most accurate way.
> * User can select a data from the XML data file which the app supports and analyze it specifically.
By clicking on a data from the list of data features, the app will display using dedicated graphs, statistics about the data, and the data feature that is most correlative to it. As well, its display a regression line between those two data features, and other statistics will be displayed live.
> * User can upload Dll files during the flight (On Run-Time) which include algorithms for detecting anomalies of the flight.
The first Algorithem which provide is linear regression-based. The algorithm returns the regression line between two correlative featueres, as well the samples during the flight that deviated from the norm, and displays them to the user on the graph.
The second algorithm is based on welzl's algorithm. The algorithem detect the time step deviated from a circle that defines the radius of the norm.

### Dictionary
/!\ HERE WE WILL EXPLAIN ON DICTIONARY USER CAN FIND IN THE PROJECY /!\

### Professional explanations
The app written in C# language, built using WPF tool. The project is written according to the MVVM code architecture which separates the functionality of the data presentation and the processing and calculation of the data. The ViewModel link between them to provide safety and separation of responsibilities.
The algorithms for detecting anomalies dynamically load are written in c++.
The advantage of dynamically loading the algorithms expressed that using them is an important tool for flight investigation on live, and on the other hand using them does not require restarting the flight or stopping the program. User can load them during the flight, choose which algorithm is more suitable for investigating the situation and even replace them. In addition, this method allows the use of additional algorithms that can be adapted to the investigator and simply added to the project.

### Credits

The project was written by Maoz Kosover, Ofir Stronberg and Itamar Lardo, as part of a project in Advanced programming 2 course, Bar-Ilan University.
