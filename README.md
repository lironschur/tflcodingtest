# Overview
RoadStatus.exe is a command-line tool for getting the status of roads in London. The tool uses the publicly available TfL Unified API.

# Instructions

## How to build the code
Download the entire folder from github, then open the RoadStatus solution in visual studio and build it.

## How to run the output

Note: you can query multiple roads by providing a comma-separated list (e.g. 'A2,A3').

### Via Visual Studio
You can run the command-line tool from Visual Studio:
* Make RoadStatus the startup project
* Open the RoadStatus project properties (right-click and select 'Properties'), click the 'Debug' tab on the left and add the road(s) you with to test in the 'Application Arguments' window. 
* In the menu, choose Debug --> Start without debugging.

### From a command-line
* After building the solution, locate the output bin folder (under bin\debug or bin\release)
* Open a command-line in that folder and run e.g. RoadStatus.exe A2

## How to run any tests that you have written
In Visual Studio, open Test Explorer and run all tests.

## Assumptions
* All roads are alpha-numeric, e.g. A2
* the Unified API supports an array of comma-separated values, e.g. 'A2,A3'.
* All status codes besides 200 and 404 are errors.

## Overriding settings

### Running the tool with different API key
You can configure the API key (Ocp-Apim-Subscription-Key) used for the Unified API.
Modify the Ocp-Apim-Subscription-Key in the App.config file (found in the same folder as the executable).
If the value is left empty, it will not be added to the request header.

## Pointing to another unified API environment
You can modify the base url ('https://api.tfl.gov.uk') used for the API call.
Modify the BaseUrl value in the App.config file.

