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

  
