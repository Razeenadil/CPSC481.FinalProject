# CPSC 481 Final Project - Fitness Tracker

## Table of Contents
- [Description](#description)
- [Project Demo](#project-demo)
- [Requirements](#requirements)
- [Installation](#installation)
- [Functionality ](#functionality)
- [Walkthrough](#walkthrough)
- [Authors](#authors)
- [License](#license)


## Description
This project was made by Computer Science Undergraduate students from the University of Calgary for the CPSC 481 Winter 2023 - Human Computer Interactions course.

## Project Demo
Demo of the project can be found [here](https://youtu.be/xxxxxxx).

## Requirements:
The following technologies and tools were used to build our project:
- C# (C Sharp)
- WPF (Windows Presentation Foundation)

## Installation:

## Step 1: Clone the repository to your local device

* Easiest way is to clone the repository:
    + [Fitness Tracker GitHub](https://github.com/Razeenadil/CPSC481.FinalProject)

### **<span style="color:red;">!!! Note !!!</span>** 
- **This section is only necessary if you want to download the source code and run in it at localhost in your local device.**

## Step 2: Setup Visual Studio Community
In order to launch our project, you need to download [Visual Studio Community](https://visualstudio.microsoft.com/vs/community/) 


## Step 3: Check WPF and .NET Framework Extensions are installed
Launch `Visual Studio Community` and go to the `Extensions` tab. Once you are in the extensions tab, check if the latest version of WPF and .NET Framework extensions are installed.

If the extensions are not installed, please refer to the `Visual Studio Community` documentation for further information. 

## Step 4: Starting the App

Go to the root directory of the project and then start the app file  `CPSC481.FinalProject.sln`. Once you start the app you will see be at the welcome page, through there you can navigate to the other pages.

## Functionality:
Here is the list of fully working features that our app presents to users:
- User can create an account and login to the app.
- Users can create new routines and add them to their routine list.
- User can check new exercises, watch their tutorials and add them to their routine.
- User can track their daily, weekly and monthly progress based on their workout and exercise history.

## Walkthrough 
((HAVE TO BE UPDATED))

Please follow the instructions below to navigate throughout the app:
- **Welcome Page** 
    + When the app is first launched the user will land on the welcome page. There are two options on this page: `Login` or `Continue As Guest`.
        +  If the user clicks `Continue As Guest` they will be taken to the main Landing page.
        + If the user clicks `Login` they will be taken to the Login page where they will enter their username and password to login to their account. Once they click `Submit` the user will be taken to the main Landing page. In order to access the app using the Login page you must use the following credentials:
            + Username: `admin`
            + Password: `admin`
- **Exercise Demonstration Page** 
    + Once user is logged in and on the main landing page, they can click on the `Navigation button` which is on the bottom right of the screen. 
        + Once the button is clicked, four other buttons will be displayed on the radial navigation button. In order to navigate to the `Exercise Demonstration Page` user must click on the play icon. 
        + Once the user clicks on the play icon, they will be taken to the `2D Body Part Selector Page`. On this page a human body will be shown for user to select a body part. 
            + The user can toggle between the front and back view of the human body by clicking on the `arrows` and also click and select a specific body part ( `Arms`,`Legs`,`Abs`,`Chest`, `Back`).
            + Once the user selects a body part, the body part will be automatically highlighted and will be displayed to the user in text. 
            + If user is not happy with their selections, they can click on `Reset Filters` to unselect all the options and start over.
        + Once the user is happy with their selections, they can click on `Apply Filters` to be taken to the Exercise Demonstration page.
        + On the Exercise Demonstration page, the user will be able to see all of their selected filters from the previous page. List of exercises will be grouped per body part and demonstrated in a list format. 
            + The user can click on the `Exercise Name` to be taken to the Exercise Tutorial page. 
                + On the Exercise Tutorial page, the user will be able to see the exercise name, equipment needed, a video tutorial of the exercise and a description of the exercise.     
                + The user can click on the `back` button to be taken to previous page where the selected exercises will be remembered based on the selected filters from the `Body Part Selector Page`. 
- **Progress Page** 

- **Routine Page** 

## AUTHORS:
* Anthony Dam
* Emir Avci
* Ali Sanchez Samuel
* Razeen Adil
* Abraham Abalos

## LICENSE
[MIT](https://github.com/Razeenadil/CPSC481.FinalProject/blob/master/LICENSE)
