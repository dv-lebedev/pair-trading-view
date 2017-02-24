# Pair Trading View


**Pair Trading View** - application for visual analysis of synthetic financial instruments based on statistical models. 

![License](https://img.shields.io/badge/license-Apache 2.0-brightgreen.svg)
![.Net version](https://img.shields.io/badge/framework-.Net Framework 4.5.2-red.svg)


**[ PairTradingView.WinFormsApp ]**

<p align="left">
  <img width="700" alt="pic" src="https://github.com/dv-lebedev/PairTradingView/blob/master/screenshots/mainwindow.png">
</p>


**[ PairTradingView.WpfApp ]**

<p align="left">
  <img width="700" alt="pic" src="https://github.com/dv-lebedev/PairTradingView/blob/master/screenshots/ptv-wpf.png">
</p>


##How To

Execute PairTradingView.exe in 'pair-trading-view\PairTradingView.WinFormsApp\bin\Debug\'.

<p align="left">
  <img width="270" alt="pic" src="https://github.com/dv-lebedev/PairTradingView/blob/master/screenshots/appstart.png">
</p>

Set 'Price' column. Put csv files with a historical data into
'pair-trading-view\PairTradingView.WinFormsApp\bin\Debug\csv-files' folder. Download csv files if you need by QuoteDownloader.
Press start.


##Model
- SI -> synthetic index
- s -> share
- fp -> financial pair
- fp_tv -> financial pair's trade volume
- fp_w -> weight of financial pair

SI_t = ( s1_t + s2_t + s3_t + ... + sn_t ) / n

SI = α + β * fp + err

Financial pair's weight has reverse dependency of β.

fp_w = (1 / (1 + abs(β))) / Σ(fp_w)

fp_tv = balance * fp_w


Calculate trade volume for each share:

fp_tv = x_tv + y_tv

y = α + β * x + err

w = 1.0 / (1.0 + abs(β)

x_tv = fp_tv * w * abs(β)

y_tv = fp_tv * w


##Dependencies
- Statistics https://github.com/dv-lebedev/statistics
- YahooFinanceQuoteDownloader https://github.com/ovnisoftware/YahooFinanceQuoteDownloader
- ZedGraph


## License
[Apache 2.0](LICENSE)
