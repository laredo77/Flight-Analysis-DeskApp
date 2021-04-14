# WpfApp1
Desktop application for flight investigation using the Flightgear web flight simulator.
 
### Description
This app is an analysis tool to investigate flight on the popular FlightGear web flight simulator.
The user who is interested in conducting an investigation on his flight will be able to receive live data on the flight to the app.
The dashboard screen will show the user the data on the plane, altitude clocks, speed, direction and graphs are indicating the statistical analysis. The application is convenient and easy to the use. It provides users with the combination of learning and investigating anomalies during the flight.
This app was written with the MVVM code architecture.

### Installation
In order to use the application, you will need to load it using framework support C# code - our recommendation [Visual Studio 2019](https://visualstudio.microsoft.com/vs/).
In addition, to display the flight, the user must have the Flightgear program installed on their computer ([Download](https://www.flightgear.org/download/),  [Steup tutorial](https://wiki.flightgear.org/New_to_FlightGear)) and csv files that contain the flight data. Also, the user should have the XML file which defines the functionality of the CSV file, translates and connects between the code and the flight simulator.

### Usage
![Application](https://user-images.githubusercontent.com/60240620/114538320-ed2c6a00-9c5b-11eb-8d2d-6a48ddb99fd0.jpeg)

To run the flight on the simulator, please open the application and follow the steps below:
> 1. Click on the 'Open CSV' button. A dialog will immediately pop up in which you can select and upload the file of the flight data - it has to be a csv file.
> 2. Click on the 'Open FlightGear' button. By providing the path to Flightgear execute file, the application will collect the data; necessary for the upcoming process.
> 3. Click on the 'Run FlightGear' button - the app will automatically connect you to the simulator server using TCP internet protocol.
> 4. Once the flight simulator is set, you can click on the 'Play' button and start your investigation of your flight.

**Additional features**
> * At the bottom of the application there is a video player which is another useful tool to investigate the flight. You can control the data transfer rate from the app to the simulator by pressing any of the following buttons. Pressing the Pause, Stop, previous, or next buttons will operate according to the accepted convention of common video players. In addition, there is a slider that shows the progress and duration of the flight. The start point of the video can be chosen on the slider.
> * A dashboard which may be relevant to the flight analysis. A speedometer, height clock of the plane, a compass that indicates the direction and other indicators of the plane such as yaw, pich, roll that will help user investigating the flight the efficient and accurate way.
> * Users can select data from the XML file which is supported by the app and can be analyzed specifically.
By clicking on the data from the list of data features, the app will display using dedicated graphs, statistics and the data feature which correlates the most. Also, it will display a regression line between those two data features, and other statistics will be displayed live.
> * Users can load Dynamic Linking Files (Dll files) during the flight (On Run-Time) which include algorithms that detect anomalies of the flight.
The first Algorithm provided, is linear regression-based. The regression line between two correlative features and the anomalies detected out of the norm are returned and displayed on the graph by the first algorithm.
The second algorithm is based on Welzl's algorithm. This algorithm determines the radius of a cirlce as the norm and detects anomalies out of range.

### Dictionary
/!\ HERE WE WILL EXPLAIN THE DICTIONARY USER CAN FIND IN THE PROJECY /!\

### Technical explanation
The app was written in C# language and was built using WPF tool. The project was written according to the MVVM code architecture, which separates the functionality of the data presentation from the processing and calculation of the data. The ViewModel link between them is to provide safety and separation of responsibilities.
The algorithms for detecting anomalies which are loading dynamically on run time were written in c++.
The advantage of loading the algorithms dynamically is that using them is important for flight investigation on run time. On the other hand using them does not require restarting the flight or the program. Users can load it during the flight, choose which algorithm is more suitable for investigating the situation and even replace them. In addition, this method allows the use of additional algorithms that can be adapted by the investigator and simply added to the project.

### Credits

The project was written by Maoz Kosover, Ofir Shtrosberg and Itamar Laredo, as part of a project in Advanced programming 2 course, Bar-Ilan University.
