# Fake News Detection

Authors: Barat Narcis, Chira Mihaela, Martonca Daniel, Cana Ana, Gradinariu Florin

## Motivation and Statement

Nowadays, distinguishing between real and fake news has become a challenging task. But it can be achieved using machine
learning concepts and algorithms. Fake news detection is one of the most interesting and easy machine learning project
ideas well suited for beginners.

Within this project, you need to develop a model that can differentiate between real and fake news. You can
use [this](https://www.kaggle.com/c/fake-news/data?select=train.csv) dataset to train the Machine Learning
model.

Having previous knowledge of Natural Language Processing (NLP) concepts and classification algorithms in machine
learning is beneficial for this project. If so, this project will only take a few hours.

This project will also improve your machine learning algorithm and NLP knowledge.

https://docs.google.com/document/d/1ikEEuIc7ujCE5O0gw0tXBAokGvAdjXZr0gT3Bg_zXrQ/edit

## Functional requirements

1. The client enters the app via browser and fill the inputs:
    * Title of the news(an input)
    * The news content(a textarea)
    * The news type(a dropdown button)
    * The date
    * The user presses the classify button
2. The web app uses an ML algorithm to check if the news is fake or not
3. A response will pop out to let the user know weather the news is fake or is legit

## Nonfunctional requirements

1. The app should return a response in a reasonable time
2. The WEB app will also have a mobile version
3. The final test accuracy should be at least 80%
4. Make sure data to train algorithm is consistent
5. Constraint for inputs:
    * The title should not be longer thar 255 characters
    * The content of the article should be reasonable (max 1000 characters)

## Project Stack

.NET 5 and React

## ADH/ADR

0. Server - Client architecture
1. a REST API that will be called with HTTP Requests from the web application Onion architecture for the REST API
2. HTML CSS and Javascript on the Frontend part of the web application using React.js library/framework
3. We decided to use Fetch API to send the requests
4. The API will be created in .NET6 and will have multiple endpoints that receive a JSON body object containing all the
   required informations about the fake news inputted by the user of the application
5. For the database we will opt for Oracle Database Service
6. For the algorithm itself that decides whether the news is fake or not we will use Microsoft ML.NET which is a machine
   learning algorithm.
7. During development we might encounter certain problems that require extra architectural decisions to be taken so this
   section might change during development.

## C4 Diagram

### Level 1

![Solution/Images/C4Lvl1.png](E:\Info\FACULTATE\ANUL_3\dotNET\PROIECT\Fake News Detector\Fake News Detector\images\C4Lvl1.png)

### Level 2

![Solution/Images/C4Lvl2.png](E:\Info\FACULTATE\ANUL_3\dotNET\PROIECT\Fake News Detector\Fake News Detector\images\C4lvl2.png)

## Presentation layer approach:

For the FE as we said earlier, we’ll use React.js library and we decided to group files and tests based on react
component structure. Each component will have its own folder grouped inside a components folder. <br>
For the BE, the REST API will have multiple endpoints that will handle the view and the controllers section.

## Unit tests approach plan:

- A folder created for tests <br>
- XUnit test projects for infrastructure, data, service,API <br>
- GIVEN WHEN THEN type of tests

Infrastructure:

- Data
    - Tests for repositories
- Service
    - Tests for handlers
- API
    - Tests for controllers

## Maintainability index:

### Meaning

Measures how maintainable (easy to support and change) the source code is

### Formula

MAX(0, (171 - 5.2 * ln(Halstead Volume) - 0,23 * (Cyclomatic Complexity) - 16.2 * ln(Lines of Code)) * 100 / 171)

### Thresholds:

0-9 = Red <br>
10-19 = Yellow<br>
20-100 = Green<br>

### Our index

TBD

## Class coupling:

### Meaning

Measures how many classes a single class uses

### Formula

?

### Goal

maximum 9

### Our coupling situation

TBD

## Cyclomatic Complexity:

### Meaning

Determine the stability and level of confidence in a program, It measures the number of linearly-independent paths
through a program module and measures of how difficult the code will be to test

### Formula

M = E - N + 2*P where,<br>
E = the number of edges in the control flow graph<br>
N = the number of nodes in the control flow graph<br>
P = the number of connected components<br>

### Goal

as low as possible

### Our index

Control Flow Graph => TBD

### Cognitive Complexity

### Meaning

Measures of how difficult(easy to read and understand) a unit of code is

### Formula

?

### Our index

TBD
