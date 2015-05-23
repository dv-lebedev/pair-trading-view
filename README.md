# PairTradingView

![Screenshot](https://github.com/dv-lebedev/PairTradingView/blob/master/screenshot.png)


**Pair Trading View** - application for the visual analysis of synthetic financial instruments based on econometrics models. App uses market data in csv file format.


![Screenshot](https://github.com/dv-lebedev/PairTradingView/blob/master/app_start.png)

![Screenshot](https://github.com/dv-lebedev/PairTradingView/blob/master/quote_downloader.png)


**How To Use:**

*>CSV format files*

- Download market data in csv format using Quote Downloader
or just put downloaded files to the /MarketData directory.

- Set the price and volume columns and press start.

*>SQL Server connection*

- After first run app create 'PairTradingViewDb' with 2 tables: Stocks and StockValues.

- App read new market data from 'Stocks' table, update pairs data, save new values to 'StockValues' table.



**Third-party:**

- ZedGraph
- EntityFramework 6.1.3
