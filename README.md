# PairTradingView

![Screenshot](https://github.com/dv-lebedev/PairTradingView/blob/master/screenshots/main_page.png)


**Pair Trading View** - application for the visual analysis of synthetic financial instruments based on econometrics models. 


**HOW TO**

Application needs pre-installed database(sql server, mysql, postgres or whatever) and odbc driver.
Database should has created table with (code, lot, price, volume) columns with updating market data.


**Service => Settings** to set connection for market data, updating interval, data saving settings and delta params.

**Service => Csv To Storage** to load values from csv format files to application data storage.
To save stocks data into the local data storage stocks info should be available in db table with updating market data.

**Service => Quote Downloader** to download quotes history from Yahoo Finance.


