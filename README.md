# Azure-Stream-Analysis-AML-WS-Call
This to provide a simple example on how to use ASA function to call an AML WS.

Since 2017, Azure Stream Analysis provides a way to call Azure Machine Learning Studio Web Service.

In this ASA query

WITH Allrecords AS (SELECT * FROM iot)
SELECT * INTO blob FROM Allrecords
SELECT *, Fuelcomsuption/Poweroutput AS FuelPerKWH, 'Warn' AS Alert into pbi FROM Allrecords 
WHERE alert(Poweroutput,Fuelcomsuption) LIKE '%WARN%'

The input is from IoT hub. In the input JSON message there are two columns, Fuelcomsuption and Poweroutput (both are float). 
In ASA we define a function ‘alert’ which points to an AML WS. This WS also takes these two parameters and in the same data type. 
Screenshots of tis model and it Predictive Experience (new web service) are in anohter file.

ASA calls this WS for prediction and if the WS returns '%WARN%', then ASA push this message plus a new column Alert with 
value of "Warn" to Power BI for visualization.

