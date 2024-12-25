Project #3. Stock Analysis project. Part 3. Project #3 is a continuation of Project #2

Goals: As in project #2, there is no datagridview and we will display multiple stock charts. We will also, as in project 2, identity some candlestick patterns. The difference, however, is that unlike in project #2 where the patterns were 1-candlestick patterns, project #3 introduces the recognition of multi-candlestick patterns (as well as single-candlestick patterns from project #2).

Now would be a good time to read about Polymorphism. Please refer to the w3schools.com chapter on polymorphism. It also has an example. If that doesn’t clarify things for you, it will provide you with a reason to ask for clarifications in class or during office hours.

Because of this change, you will have to create a new type of class called axxxRecognizer, whose role is to identify the location of its target pattern xxx where examples of xxx are: Doji, Hammer, Marubozu (the single-candlestick patterns you identified in project #2) or engulfing Pattern, Bullish engulfing Pattern, Bearish engulfing Pattern (see The Engulfing Candlestick Patterns - Bullish Engulfing, Bearish Engulfing - Aim ArrowLinks to an external site.) engulfing as well as bearish and bullish Haramis What Is a Harami Candle? Example Charts Help You Interpret Trend Reversal - Commodity.comLinks to an external site.

Add the 3-candlestick patterns called Peak and Valley. a Peak is when the high of the middle candlestick is higher than the high of the 2 candlesticks on its left and its right, and a Valley is when the low of the middle candlestick is lower than the lows of the 2 candlesticks on its left and its right.

Load and display stock data in candlestick format and allow for multiple stocks to be displayed on individual forms and identify and display some basic single-candlestick patterns.

USE DATA BINDING. Do not load the data into the chart in code. Why write 10’s of lines of code to go through your list of candlesticks and Add each candlestick into the Chart (with all the complications and the lack of synchronization) when all you have to do is make a list of candlestick you wish to display and tell the chart: chart_display.DataSource = listOfCandlesticks then bind the chart to  the list with: chart_display.Bind() (That’s 2 lines of code!!!)

consider not changing the core of project 2. But because of the change in architecture due to the fact that we are now going to also recognize multi-candlestick patterns, we will discuss how to pick the appropriate recognizer when the user selects one particular one from the pattern selecting ComboBox.

Again, the user will pick a pattern from the pattern selecting ComboBox and your application will (as in project 2) identify the patterns amongst the candlesticks being displayed and then place an annotation on the chart around each candlesticks that form the desired pattern.

ChatGPT to show you how to display those annotations on a chart control (it is pretty simple).

DO NOT USE DataTables, LINQ, Databases or other complex data structures or classes that complicate your solution. Use what we COVER IN CLASS. Those other approaches will NOT BE ACCEPTED IN PROJECT3!

Abstract classes and concrete classes derived from those abstract classes to solve the problem, so PAY ATTENTION in class as EVERYTHING I will cover WILL BE USED in the project!

This project is to teach you what Polymorphism is and how powerful it is! I will not accept projects that do not use polymorphism or use material obviously obtained from other sources than the classroom!



